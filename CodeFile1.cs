using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

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

            center = _center;
            aRadius = di.aRadius;
            bRadius = di.bRadius;
            distance = di.distance;
            startAngle = di.startAngle;
            pointsPerCurve = di.pointsPerCurve;
            delayPerPoint = (int)Math.Round((double)(defaultDelayPerCurve / pointsPerCurve));
            pb = _pb;
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
            controlForm = null; // allow garbage collector to dispose form
            animationThread = null;  // might help garbage collector but probably not, 
            // since GC eliminates a thread only when complete (whether or not there is a reference to it)
        }

        // threadsafe method that allows animation thread to access form created by main thread
        private static void RefreshDrawing()
        {
            RefreshDrawingDelegate refreshDelegate = new RefreshDrawingDelegate(refDrawing);
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
            pb.BeginInvoke(closeDelegate);
        }

        private static void closeControlForm()
        {
            if (controlForm != null)
                controlForm.Close();
        }
        //private static void AnimateHypotrochoid(PointF ptOrigin, int aRadius, int bRadius,
        //    int distance, int startAngle, int PointsPerCurve, System.Windows.Forms.PictureBox pb)
        private static void AnimateHypotrochoid()
        {
            Bitmap imageForErase = (Bitmap)pb.Image.Clone();
            // create graphics object for the drawing so that the drawing can be changed and
            // new parts of the drawing won't be erased.
            Graphics gErase = Graphics.FromImage(imageForErase);
            Graphics g = Graphics.FromImage(pb.Image);
            Pen rollingCirclePen = new Pen(Color.Gray, 1);
            Pen penHolder = new Pen(pen.Color, 1.5F);  // pen for drawing pen holder line
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
            // x = (a-b)*cos(t) + h*cos(t*(a-b)/b)
            // y = (a-b)*cos(t) - h*sin(t*(a-b)/b)

            point1.X = (float)(center.X + aRadius - bRadius + distance);
            point1.Y = center.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, center, MatrixOrder.Append);
            // Apply the Matrix object to the Graphics object
            // (i.e., to all the Graphics items drawn on the Graphics object)
            g.Transform = transformMatrix;

            double angle = 0;
            double aMinusb = aRadius - bRadius;
            double aMinusbOverb = aMinusb / bRadius;
            int pt = 0;
            do
            {
                angle += angleStep;
                point2.X = (float)(center.X + aMinusb * Math.Cos(angle) + distance * Math.Cos(angle * aMinusbOverb));
                point2.Y = (float)(center.Y + aMinusb * Math.Sin(angle) - distance * Math.Sin(angle * aMinusbOverb));
                // draw next rolling circle
                PointF circlePt = new PointF(
                    (float)(center.X + aMinusb * Math.Cos(angle) - bRadius),
                    (float)(center.Y + aMinusb * Math.Sin(angle) - bRadius));
                g.DrawEllipse(rollingCirclePen, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                // draw pen holder
                penConnect.X = (float)(center.X + aMinusb * Math.Cos(angle) + bRadius * Math.Cos(angle * aMinusbOverb));
                penConnect.Y = (float)(center.Y + aMinusb * Math.Sin(angle) - bRadius * Math.Sin(angle * aMinusbOverb));
                g.DrawLine(penHolder, penConnect.X, penConnect.Y, point2.X, point2.Y);
                // draw pen (i.e. point)
                g.FillEllipse(penBrush, point2.X - 2, point2.Y - 2, 4, 4);

                // draw next line segment
                g.DrawLine(pen, point1, point2);
                //pb.Refresh();
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

                // create eraser from latest image
                gErase.DrawLine(pen, point1, point2);
                TextureBrush tb = new TextureBrush(imageForErase);
                Pen eraser = new Pen(tb, 1);

                // erase rolling circle
                g.DrawEllipse(eraser, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                // erase pen
                g.FillEllipse(tb, point2.X - 2, point2.Y - 2, 4, 4);
                // erase pen holder
                eraser.Width = 2.0F; // make eraser a little larger to see if that leaves less "dirt" behind
                g.DrawLine(eraser, penConnect.X, penConnect.Y, point2.X, point2.Y);
                point1 = point2;
                tb.Dispose();
                eraser.Dispose();
                pt++;
            }
            while (pt < NumPoints && !stopAnimation);
            if (pt == NumPoints)  // animation completed 
                Spiro.CloseControlForm();
            transformMatrix.Dispose();
            g.Dispose();
            gErase.Dispose();
        }

        private static void AnimateEpitrochoid()
        {
            Bitmap imageForErase = (Bitmap)pb.Image.Clone();
            // create graphics object for the drawing so that the drawing can be changed and
            // new parts of the drawing won't be erased.
            Graphics gErase = Graphics.FromImage(imageForErase);
            Graphics g = Graphics.FromImage(pb.Image);
            Pen rollingCirclePen = new Pen(Color.Gray, 1);
            Pen penHolder = new Pen(pen.Color, 1.5F);  // pen for drawing pen holder line
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
            // x = (a-b)*cos(t) + h*cos(t*(a-b)/b)
            // y = (a-b)*cos(t) - h*sin(t*(a-b)/b)

            point1.X = (float)(center.X + aRadius + bRadius - distance);
            point1.Y = center.Y;

            // create rotation transform around center
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(startAngle, center, MatrixOrder.Append);
            // Apply the Matrix object to the Graphics object
            // (i.e., to all the Graphics items drawn on the Graphics object)
            g.Transform = transformMatrix;

            double angle = 0;
            double aPlusb = aRadius + bRadius;
            double aPlusbOverb = aPlusb / bRadius;
            int pt = 0;
            do
            {
                angle += angleStep;
                point2.X = (float)(center.X + aPlusb * Math.Cos(angle) - distance * Math.Cos(angle * aPlusbOverb));
                point2.Y = (float)(center.Y + aPlusb * Math.Sin(angle) - distance * Math.Sin(angle * aPlusbOverb));
                // draw next rolling circle
                PointF circlePt = new PointF(
                    //(float)(center.X + aPlusb * Math.Cos(angle) + bRadius),
                    (float)(center.X + aPlusb * Math.Cos(angle) - bRadius),
                    (float)(center.Y + aPlusb * Math.Sin(angle) - bRadius));
                g.DrawEllipse(rollingCirclePen, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                // draw pen holder
                penConnect.X = (float)(center.X + aPlusb * Math.Cos(angle) - bRadius * Math.Cos(angle * aPlusbOverb));
                penConnect.Y = (float)(center.Y + aPlusb * Math.Sin(angle) - bRadius * Math.Sin(angle * aPlusbOverb));
                g.DrawLine(penHolder, penConnect.X, penConnect.Y, point2.X, point2.Y);
                // draw pen (i.e. point)
                g.FillEllipse(penBrush, point2.X - 2, point2.Y - 2, 4, 4);

                // draw next line segment
                g.DrawLine(pen, point1, point2);
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

                // create eraser from latest image
                gErase.DrawLine(pen, point1, point2);
                TextureBrush tb = new TextureBrush(imageForErase);
                Pen eraser = new Pen(tb, 1);

                // erase rolling circle
                g.DrawEllipse(eraser, circlePt.X, circlePt.Y, 2 * bRadius, 2 * bRadius);
                // erase pen
                g.FillEllipse(tb, point2.X - 2, point2.Y - 2, 4, 4);
                // erase pen holder
                eraser.Width = 2.0F; // make eraser a little larger to see if that leaves less "dirt" behind
                g.DrawLine(eraser, penConnect.X, penConnect.Y, point2.X, point2.Y);
                point1 = point2;
                tb.Dispose();
                eraser.Dispose();
                pt++;
            }
            while (pt < NumPoints && !stopAnimation);
            if (pt == NumPoints)  // animation completed 
                Spiro.CloseControlForm();
            transformMatrix.Dispose();
            g.Dispose();
            gErase.Dispose();
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
            // (i.e., to all the Graphics items drawn on the Graphics object)
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
            // (i.e., to all the Graphics items drawn on the Graphics object)
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
            // (i.e., to all the Graphics items drawn on the Graphics object)
            g.Transform = transformMatrix;

            Pen pen = new Pen(Color.Gray, 1.5F);  // pen for drawing wheels and boundary circles
            Pen penHolder = new Pen(penColor, 1.5F);  // pen for drawing pen holder line
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
                "points to be plotted: " + dr.nbrPoints.ToString(),
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
