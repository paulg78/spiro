using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace SpiroGraph
{
    using ColorUtils = SpiroGraph.Utils.ColorUtils;

    public struct DrawingInputType
    {
        public RollSide roll;
        public Size offset; // center of curve relative to center of drawing
        public int aRadius;
        public int bRadius;
        public int distance;
        public int startAngle;
        public int pointsPerCurve;
        public string color;
        public float penWidth;
        public DashStyle penStyle;
    }

    public struct DrawingResultType
    {
        public Int64 nbrPoints;
        public int highestCommonFactor;
        public int nbrRevolutions;
        public int designPoints;
    }

    public enum RollSide
    {
        inside,
        outside
    }

    public class Spiro
    {
        private const Double radiansPerCircle = 2 * Math.PI;
        private const int defaultDelayPerCurve = 10000;
        private static readonly float circlePenSize = 2F;
        private static readonly float penHolderPenSize = 2F;
        private static Pen pen = new Pen(Color.Red);
        // member variables used for animation (used because ThreadStart delegate can't have parameters)
        private static Point center;
        private static int aRadius;
        private static int bRadius;
        private static int distance;
        private static int startAngle;
        private static int pointsPerCurve;
        private static System.Windows.Forms.PictureBox pb;
        public static int delayPerPoint;
        private static Bitmap overlay;               // transient animation layer
        private static object overlayLock = new object();
        private static object backgroundLock = new object();

        // helper paint handler - draws overlay on top of PictureBox image
        private static void OverlayPaint(object sender, PaintEventArgs e)
        {
            lock (overlayLock)
            {
                if (overlay != null)
                {
                    e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                    e.Graphics.DrawImageUnscaled(overlay, Point.Empty);
                }
            }
        }

        // Thread handling
        private static Thread animationThread;
        private static bool stopAnimation;	// indicates whether or not user has requested to stop animation
        private static bool pauseAnimation; // true=user has requested to pause animation; false=resume
        private delegate void RefreshDrawingDelegate();
        private delegate void CloseControlFormDelegate();

        private static frmControl controlForm;

        private Spiro() // private constructor prevents instantiation
        {
        }

        public static DrawingResultType PredictResults(int aRadius, int bRadius, int PointsPerCurve)
        {
            DrawingResultType dr;
            dr.highestCommonFactor = HighestCommonFactor(aRadius, bRadius);
            dr.nbrRevolutions = (int)(bRadius / dr.highestCommonFactor);
            dr.nbrPoints = PointsPerCurve * dr.nbrRevolutions;
            dr.designPoints = aRadius / dr.highestCommonFactor;
            return dr;
        }

        public static void StopAnimation()
        {
            stopAnimation = true;
        }

        public static void ToggleAnimation()
        {
            if (pauseAnimation)
            {
                pauseAnimation = false;
                animationThread.Interrupt();
            }
            else
            {
                pauseAnimation = true;
            }
        }

        public static void Animate(DrawingInputType di, Point _center, System.Windows.Forms.PictureBox _pb)
        {
            stopAnimation = false;
            pauseAnimation = false;
            pen.Color = ColorUtils.ActualColor(di.color);
            pen.Width = di.penWidth;

            center = _center;
            aRadius = di.aRadius;
            bRadius = di.bRadius;
            distance = di.distance;
            startAngle = di.startAngle;
            pointsPerCurve = di.pointsPerCurve;
            delayPerPoint = (int)Math.Round((double)(defaultDelayPerCurve / pointsPerCurve));
            pb = _pb;

            // create overlay bitmap (with alpha) sized to picturebox
            lock (overlayLock)
            {
                overlay?.Dispose();
                overlay = new Bitmap(Math.Max(1, pb.Width), Math.Max(1, pb.Height), PixelFormat.Format32bppArgb);
                using (var g = Graphics.FromImage(overlay))
                {
                    g.Clear(Color.Transparent);
                }
            }

            // attach paint handler so overlay is drawn over background
            pb.Paint -= OverlayPaint; // guard against double attach
            pb.Paint += OverlayPaint;
            try
            {
                if (di.roll == RollSide.outside)
                {
                    animationThread = new Thread(new ThreadStart(AnimateEpitrochoid));
                }
                else
                {
                    animationThread = new Thread(new ThreadStart(AnimateHypotrochoid));
                }
                animationThread.Priority = ThreadPriority.BelowNormal;
                animationThread.Start();
                controlForm = new frmControl();
                controlForm.ShowDialog();
            }
            finally
            {
                // cleanup overlay and handler (execute on UI thread)
                if (pb != null)
                {
                    try
                    {
                        pb.BeginInvoke(new Action(() =>
                        {
                            pb.Paint -= OverlayPaint;
                        }));
                    }
                    catch
                    {
                        // ignore exceptions during cleanup invocation
                    }
                }
                lock (overlayLock)
                {
                    overlay?.Dispose();
                    overlay = null;
                }
                controlForm = null;
                animationThread = null;
            }
        }

        // threadsafe method that allows animation thread to access form created by main thread
        private static void RefreshDrawing()
        {
            RefreshDrawingDelegate refreshDelegate = new RefreshDrawingDelegate(refDrawing);
            if (pb != null)
                pb.BeginInvoke(refreshDelegate);
        }

        private static void refDrawing()
        {
            pb.Refresh();
        }

        // threadsafe method that allows animation thread to access form created by main thread
        private static void CloseControlForm()
        {
            CloseControlFormDelegate closeDelegate = new CloseControlFormDelegate(closeControlForm);
            if (pb != null)
                pb.BeginInvoke(closeDelegate);
        }

        private static void closeControlForm()
        {
            if (controlForm != null)
                controlForm.Close();
        }

        private static void AnimateHypotrochoid()
        {
            // Pens/brushes for drawing
            Pen rollingCirclePen = new Pen(Color.Gray, circlePenSize);
            Pen penHolder = new Pen(pen.Color, penHolderPenSize);  // pen for drawing pen holder line
            SolidBrush penBrush = new SolidBrush(pen.Color);
            Double angleStep = radiansPerCircle / pointsPerCurve;
            PointF point1 = new PointF();
            PointF point2 = new PointF();
            PointF penConnect = new PointF();

            // Compute number of revolutions.
            int hcf = HighestCommonFactor(aRadius, bRadius);
            int NumRevolutions = bRadius / hcf;

            // Total number of points to generate
            int NumPoints = pointsPerCurve * NumRevolutions;

            point1.X = (float)(center.X + aRadius - bRadius + distance);
            point1.Y = center.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, center, MatrixOrder.Append);

            double angle = 0;
            double aMinusb = aRadius - bRadius;
            double aMinusbOverb = aMinusb / bRadius;
            int pt = 0;
            try
            {
                do
                {
                    angle += angleStep;
                    // x = (a-b)*cos(t) + h*cos(t*(a-b)/b)
                    // y = (a-b)*cos(t) - h*sin(t*(a-b)/b)
                    point2.X = (float)(center.X + aMinusb * Math.Cos(angle) + distance * Math.Cos(angle * aMinusbOverb));
                    point2.Y = (float)(center.Y + aMinusb * Math.Sin(angle) - distance * Math.Sin(angle * aMinusbOverb));

                    // rolling circle and pen holder positions (transformed coordinates)
                    PointF circlePt = new PointF(
                        (float)(center.X + aMinusb * Math.Cos(angle) - bRadius),
                        (float)(center.Y + aMinusb * Math.Sin(angle) - bRadius));
                    penConnect.X = (float)(center.X + aMinusb * Math.Cos(angle) + bRadius * Math.Cos(angle * aMinusbOverb));
                    penConnect.Y = (float)(center.Y + aMinusb * Math.Sin(angle) - bRadius * Math.Sin(angle * aMinusbOverb));

                    // draw overlay (transient)
                    lock (overlayLock)
                    {
                        using (Graphics gOverlay = Graphics.FromImage(overlay))
                        {
                            gOverlay.Clear(Color.Transparent);
                            gOverlay.SmoothingMode = SmoothingMode.AntiAlias;
                            gOverlay.Transform = transformMatrix;
                            // draw rolling circle (temporary)
                            gOverlay.DrawEllipse(rollingCirclePen, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                            // draw pen holder and pen (temporary)
                            gOverlay.DrawLine(rollingCirclePen, penConnect.X, penConnect.Y, point2.X, point2.Y);
                            gOverlay.FillEllipse(penBrush, point2.X - 2, point2.Y - 2, 4, 4);
                        }
                    }

                    // commit permanent line segment to background
                    // execute drawing on UI thread to avoid GDI+ cross-thread access
                    if (pb != null)
                    {
                        // capture values for UI thread
                        PointF _p1 = point1;
                        PointF _p2 = point2;
                        Matrix _m = transformMatrix.Clone() as Matrix;
                        Pen _pen = (Pen)pen.Clone();

                        try
                        {
                            pb.BeginInvoke(new Action(() =>
                            {
                                lock (backgroundLock)
                                {
                                    using (Graphics gBack = Graphics.FromImage(pb.Image))
                                    {
                                        gBack.SmoothingMode = SmoothingMode.AntiAlias;
                                        gBack.Transform = _m;
                                        gBack.DrawLine(_pen, _p1, _p2);
                                    }
                                }
                                _m.Dispose();
                                _pen.Dispose();
                            }));
                        }
                        catch
                        {
                            // ignore invocation exceptions during shutdown
                            _m.Dispose();
                            _pen.Dispose();
                        }
                    }

                    // request repaint (UI thread will paint background then overlay)
                    RefreshDrawing();

                    if (pauseAnimation)
                    {
                        try
                        {
                            Thread.Sleep(Timeout.Infinite);
                        }
                        catch (ThreadInterruptedException)
                        {
                        }
                    }
                    else
                        Thread.Sleep(delayPerPoint);

                    point1 = point2;
                    pt++;
                }
                while (pt < NumPoints && !stopAnimation);

                if (pt == NumPoints)  // animation completed 
                    Spiro.CloseControlForm();
            }
            finally
            {
                transformMatrix.Dispose();
                rollingCirclePen.Dispose();
                penHolder.Dispose();
                penBrush.Dispose();
            }
        }

        private static void AnimateEpitrochoid()
        {
            Pen rollingCirclePen = new Pen(Color.Gray,circlePenSize);
            Pen penHolder = new Pen(pen.Color, penHolderPenSize);  // pen for drawing pen holder line
            SolidBrush penBrush = new SolidBrush(pen.Color);
            Double angleStep = radiansPerCircle / pointsPerCurve;
            PointF point1 = new PointF();
            PointF point2 = new PointF();
            PointF penConnect = new PointF();

            // Compute number of revolutions.
            int hcf = HighestCommonFactor(aRadius, bRadius);
            int NumRevolutions = (int)(bRadius / hcf);

            // Total number of points to generate
            int NumPoints = pointsPerCurve * NumRevolutions;

            point1.X = (float)(center.X + aRadius + bRadius - distance);
            point1.Y = center.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, center, MatrixOrder.Append);

            double angle = 0;
            double aPlusb = aRadius + bRadius;
            double aPlusbOverb = aPlusb / bRadius;
            int pt = 0;
            try
            {
                do
                {
                    angle += angleStep;

                    // x = (a-b)*cos(t) + h*cos(t*(a-b)/b)
                    // y = (a-b)*cos(t) - h*sin(t*(a-b)/b)
                    point2.X = (float)(center.X + aPlusb * Math.Cos(angle) - distance * Math.Cos(angle * aPlusbOverb));
                    point2.Y = (float)(center.Y + aPlusb * Math.Sin(angle) - distance * Math.Sin(angle * aPlusbOverb));

                    PointF circlePt = new PointF(
                        (float)(center.X + aPlusb * Math.Cos(angle) - bRadius),
                        (float)(center.Y + aPlusb * Math.Sin(angle) - bRadius));
                    penConnect.X = (float)(center.X + aPlusb * Math.Cos(angle) - bRadius * Math.Cos(angle * aPlusbOverb));
                    penConnect.Y = (float)(center.Y + aPlusb * Math.Sin(angle) - bRadius * Math.Sin(angle * aPlusbOverb));

                    // draw overlay (transient)
                    lock (overlayLock)
                    {
                        using (Graphics gOverlay = Graphics.FromImage(overlay))
                        {
                            gOverlay.Clear(Color.Transparent);
                            gOverlay.SmoothingMode = SmoothingMode.AntiAlias;
                            gOverlay.Transform = transformMatrix;
                            gOverlay.DrawEllipse(rollingCirclePen, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                            gOverlay.DrawLine(rollingCirclePen, penConnect.X, penConnect.Y, point2.X, point2.Y);
                            gOverlay.FillEllipse(penBrush, point2.X - 2, point2.Y - 2, 4, 4);
                        }
                    }

                    // commit permanent line segment to background
                    // execute drawing on UI thread to avoid GDI+ cross-thread access
                    if (pb != null)
                    {
                        // capture values for UI thread
                        PointF _p1 = point1;
                        PointF _p2 = point2;
                        Matrix _m = transformMatrix.Clone() as Matrix;
                        Pen _pen = (Pen)pen.Clone();

                        try
                        {
                            pb.BeginInvoke(new Action(() =>
                            {
                                lock (backgroundLock)
                                {
                                    using (Graphics gBack = Graphics.FromImage(pb.Image))
                                    {
                                        gBack.SmoothingMode = SmoothingMode.AntiAlias;
                                        gBack.Transform = _m;
                                        gBack.DrawLine(_pen, _p1, _p2);
                                    }
                                }
                                _m.Dispose();
                                _pen.Dispose();
                            }));
                        }
                        catch
                        {
                            // ignore invocation exceptions during shutdown
                            _m.Dispose();
                            _pen.Dispose();
                        }
                    }

                    RefreshDrawing();

                    if (pauseAnimation)
                    {
                        try
                        {
                            Thread.Sleep(Timeout.Infinite);
                        }
                        catch (ThreadInterruptedException)
                        {
                        }
                    }
                    else
                        Thread.Sleep(delayPerPoint);

                    point1 = point2;
                    pt++;
                }
                while (pt < NumPoints && !stopAnimation);

                if (pt == NumPoints)  // animation completed 
                    Spiro.CloseControlForm();
            }
            finally
            {
                transformMatrix.Dispose();
                rollingCirclePen.Dispose();
                penHolder.Dispose();
                penBrush.Dispose();
            }
        }

        public static void DrawCurve(Graphics g, DrawingInputType di, PointF center)
        {
            pen.Color = ColorUtils.ActualColor(di.color);
            pen.Width = di.penWidth;
            pen.DashStyle = di.penStyle;
            if (di.roll == RollSide.outside)
                DrawEpitrochoid(g, center, di.aRadius, di.bRadius, di.distance, di.startAngle, di.pointsPerCurve);
            else
                DrawHypotrochoid(g, center, di.aRadius, di.bRadius, di.distance, di.startAngle, di.pointsPerCurve);
        }

        private static void DrawHypotrochoid(Graphics g, PointF ptOrigin, int aRadius, int bRadius, int distance,
            int startAngle, int PointsPerCurve)
        {
            Double angleStep = radiansPerCircle / PointsPerCurve;
            PointF point1 = new PointF();
            PointF point2 = new PointF();

            // Compute number of revolutions.
            int hcf = HighestCommonFactor(aRadius, bRadius);
            int NumRevolutions = (int)(bRadius / hcf);

            // Total number of points to generate
            int NumPoints = PointsPerCurve * NumRevolutions;
            // x = (a-b)*cos(t) + h*cos(t*(a-b)/b)
            // y = (a-b)*cos(t) - h*sin(t*(a-b)/b)

            point1.X = (float)(ptOrigin.X + aRadius - bRadius + distance);
            point1.Y = ptOrigin.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, ptOrigin, MatrixOrder.Append);
            // Apply the Matrix object to the Graphics object
            g.Transform = transformMatrix;

            double angle = 0;
            double aMinusb = aRadius - bRadius;
            double aMinusbOverb = aMinusb / bRadius;
            for (int pt = 0; pt < NumPoints; pt++)
            {
                angle += angleStep;
                point2.X = (float)(ptOrigin.X + aMinusb * Math.Cos(angle) + distance * Math.Cos(angle * aMinusbOverb));
                point2.Y = (float)(ptOrigin.Y + aMinusb * Math.Sin(angle) - distance * Math.Sin(angle * aMinusbOverb));
                g.DrawLine(pen, point1, point2);
                point1 = point2;
             }
            transformMatrix.Dispose();
            g.Transform = new Matrix();
        }

        private static void DrawEpitrochoid
            (Graphics g, PointF ptOrigin, int aRadius, int bRadius, int distance,
            int startAngle, int PointsPerCurve)
        {
            const Double radiansPerCircle = 2 * Math.PI;
            Double angleStep = radiansPerCircle / PointsPerCurve;
            PointF point1 = new PointF();
            PointF point2 = new PointF();

            // Compute number of revolutions.
            int hcf = HighestCommonFactor(aRadius, bRadius);
            int NumRevolutions = (int)(bRadius / hcf);

            // Total number of points to generate
            int NumPoints = PointsPerCurve * NumRevolutions;

            // x = (a+b)cos t - h cos (t*(a+b)/b)
            // y = (a+b)sin t - h sin (t*(a+b)/b)

            point1.X = (float)(ptOrigin.X + aRadius + bRadius - distance);
            point1.Y = ptOrigin.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, ptOrigin, MatrixOrder.Append);
            // Apply the Matrix object to the Graphics object
            g.Transform = transformMatrix;
            
            double angle = 0;
            double aPlusb = aRadius + bRadius;
            double aPlusbOverb = aPlusb / bRadius;

            for (int pt = 0; pt < NumPoints; pt++)
            {
                angle += angleStep;
                point2.X = (float)(ptOrigin.X + aPlusb * Math.Cos(angle) - distance * Math.Cos(angle * aPlusbOverb));
                point2.Y = (float)(ptOrigin.Y + aPlusb * Math.Sin(angle) - distance * Math.Sin(angle * aPlusbOverb));
                g.DrawLine(pen, point1, point2);
                point1 = point2;
            }
            transformMatrix.Dispose();
            g.Transform = new Matrix();
        }

        public static void ShowCircles(Graphics g, PointF ptOrigin, int aRadius, int bRadius, int distance,
            int startAngle, int pointsPerCurve, RollSide roll, Color penColor, float penWidth)
        {
            float pw = Math.Max(2, penWidth);
            float pw2 = 2 * pw;
            // set rotation transform, if applicable
            Matrix transformMatrix = new Matrix();
            // rotate around ptOrigin
            transformMatrix.RotateAt(startAngle,
                ptOrigin, MatrixOrder.Append);
            // Apply the Matrix object to the Graphics object
            g.Transform = transformMatrix;

            Pen pen = new Pen(Color.Gray, circlePenSize);  // pen for drawing wheels and boundary circles
            Pen penHolder = new Pen(penColor, penHolderPenSize);  // pen for drawing pen holder line
            // draw fixed circle
            g.DrawEllipse(pen, ptOrigin.X - aRadius, ptOrigin.Y - aRadius, 2 * aRadius, 2 * aRadius);
            // draw rolling circle and show pen, inside or outside of fixed circle
            if (roll == RollSide.inside)
            {
                // draw rolling circle
                g.DrawEllipse(pen, ptOrigin.X + aRadius - 2 * bRadius, ptOrigin.Y - bRadius, 2 * bRadius, 2 * bRadius);
                // draw pen holder
                g.DrawLine(penHolder, ptOrigin.X + aRadius - bRadius + distance, ptOrigin.Y, ptOrigin.X + aRadius, ptOrigin.Y);
                // draw "boundary circles"
                pen.DashStyle = DashStyle.Dot;
                g.DrawEllipse(pen, ptOrigin.X - aRadius + bRadius - distance,
                    ptOrigin.Y - aRadius + bRadius - distance, 2 * (aRadius - bRadius + distance),
                    2 * (aRadius - bRadius + distance));
                g.DrawEllipse(pen, ptOrigin.X - aRadius + bRadius + distance,
                    ptOrigin.Y - aRadius + bRadius + distance, 2 * (aRadius - bRadius - distance),
                    2 * (aRadius - bRadius - distance));
                // draw pen
                SolidBrush b = new SolidBrush(penColor);
                g.FillEllipse(b, ptOrigin.X + aRadius - bRadius + distance - pw, ptOrigin.Y - pw, pw2, pw2);
            }
            else
            {
                // draw rolling circle
                g.DrawEllipse(pen, ptOrigin.X + aRadius, ptOrigin.Y - bRadius, 2 * bRadius, 2 * bRadius);
                // draw pen holder
                g.DrawLine(penHolder, ptOrigin.X + aRadius, ptOrigin.Y, ptOrigin.X + aRadius + bRadius - distance, ptOrigin.Y);
                // draw "boundary circles"
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawEllipse(pen, ptOrigin.X - aRadius - bRadius - distance,
                    ptOrigin.Y - aRadius - bRadius - distance, 2 * (aRadius + bRadius + distance),
                    2 * (aRadius + bRadius + distance));
                g.DrawEllipse(pen, ptOrigin.X - aRadius - bRadius + distance,
                    ptOrigin.Y - aRadius - bRadius + distance, 2 * (aRadius + bRadius - distance),
                    2 * (aRadius + bRadius - distance));
                // draw pen
                SolidBrush b = new SolidBrush(penColor);
                g.FillEllipse(b, ptOrigin.X + aRadius + bRadius - distance - pw, ptOrigin.Y - pw, pw2, pw2);
            }
            pen.Dispose();
            transformMatrix.Dispose();
            g.Transform = new Matrix();

            // show drawing data
            DrawingResultType dr = Spiro.PredictResults(aRadius, bRadius, pointsPerCurve);
            double aCirc = 2 * Math.PI * aRadius;
            double bCirc = 2 * Math.PI * bRadius;
            g.DrawString(
                "Highest Common factor (HCF) of fixed and rolling radius: " + dr.highestCommonFactor.ToString() + "\n" +
                "# of 'lobes' (fixed radius/HCF): " + dr.designPoints.ToString() + "\n" +
                "# revolutions back to start (rolling radius/HCF): " + dr.nbrRevolutions.ToString() + "\n" +
                "Fixed circle circumference: " + (aCirc).ToString("F2") + "\n" +
                "Rolling circle circumference: " + (bCirc).ToString("F2") + "\n" +
                "Fixed Circ / Rolling Circ: " + (aCirc / bCirc).ToString("F2") + "\n" +
                "Points to be plotted: " + dr.nbrPoints.ToString(),
                new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Regular), Brushes.Black, 10, 10);
        }

        private static int HighestCommonFactor(int a, int b)
        {
            int i = 0;
            int j = 0;
            int hcf = 0;

            // Euclid's algorithm for finding the highest common factor
            // of two integers A and B.
            if (a < b)
            {
                hcf = a;
                i = b;
            }
            else
            {
                hcf = b;
                i = a;
            }
            do
            {
                j = i % hcf;
                if (j != 0)
                {
                    i = hcf;
                    hcf = j;
                }
            } while (j != 0);
            return hcf;
        }
    }
}
