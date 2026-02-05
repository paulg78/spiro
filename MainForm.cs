using SpiroGraph.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SpiroGraph
{

    public partial class MainForm : Form
    {
        public struct DeltaType
        {
            public int aRadius;
            public int bRadius;
            public int penDistance;
            public int startAngle;
            public int offsetX;
            public int offsetY;
        }
        DrawingInputType di; // set of drawing inputs
        DeltaType delta; // delta values (not used as drawing inputs)

        DrawingSpec drawingSpec = new DrawingSpec();
        Bitmap drawing;
        public static readonly string[] colorNames = {
            "Black",
            "DarkGreen",
            "Green",
            "ForestGreen",
            "Lime",
            "MediumSpringGreen",
            "LightGreen",
            "YellowGreen",
            "GreenYellow",
            "Beige",
            "LightGoldenrodYellow",
            "LightYellow",
            "Yellow",
            "DarkGoldenrod",
            "Orange",
            "DarkOrange",
            "OrangeRed",
            "Tomato",
            "Coral",
            "LightCoral",
            "DarkSalmon",
            "LightSalmon",
            "Red",
            "Crimson",
            "DarkRed",
            "Maroon",
            "Pink",
            "LightPink",
            "HotPink",
            "DeepPink",
            "Fuchsia",
            "Magenta",
            "Purple",
            "DarkMagenta",
            "DarkOrchid",
            "Violet",
            "BlueViolet",
            "MediumBlue",
            "DarkBlue",
            "Navy",
            "Blue",
            "LightBlue",
            "PowderBlue",
            "LightSkyBlue",
            "LightSteelBlue",
            "LightSlateGray",
            "LightSeaGreen",
            "DarkCyan",
            "Aqua",
            "LightCyan",
            "Turquoise",
            "Chocolate",
            "Brown",
            "Gray",
            "DarkGray",
            "LightGray",
            "Silver",
            "Bisque",
            "MistyRose",
            "White"
            };

        public MainForm()
        {
            InitializeComponent();
            txtRadiusADelta.Tag = new Action<int>(v => delta.aRadius = v);
            this.txtRadiusADelta.Validating += NumericTextBox_Validating;
            txtStartAngleDelta.Tag = new Action<int>(v => delta.startAngle = v);
            this.txtStartAngleDelta.Validating += NumericTextBox_Validating;
            txtRadiusBDelta.Tag = new Action<int>(v => delta.bRadius = v);
            this.txtRadiusBDelta.Validating += NumericTextBox_Validating;
            txtPenDistanceDelta.Tag = new Action<int>(v => delta.penDistance = v);
            this.txtPenDistanceDelta.Validating += NumericTextBox_Validating;
            txtOffsetXdelta.Tag = new Action<int>(v => delta.offsetX = v);
            this.txtOffsetXdelta.Validating += NumericTextBox_Validating;
            txtOffsetYdelta.Tag = new Action<int>(v => delta.offsetY = v);
            this.txtOffsetYdelta.Validating += NumericTextBox_Validating;

            // initialize drawing inputs/deltas
            setDefaults();

            // populate form
            initFormParams(di, delta);
        }

        /// <summary>
        /// Returns the fixed "drawings" directory located alongside the application executable.
        /// Ensures the directory exists; if creation fails, falls back to the user's Documents folder.
        /// </summary>
        private string GetDrawingsDirectory()
        {
            string dir = Path.Combine(Application.StartupPath, "drawings");
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            catch
            {
                // If creation fails (e.g. running from a protected Program Files without admin),
                // fall back to user's Documents folder so Open/Save still works.
                dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            return dir;
        }

        private void setCenter()
        {
            int width = pictureBox1.ClientRectangle.Width;
            int height = pictureBox1.ClientRectangle.Height;
            drawingSpec.Center = new Point(
                (int)Math.Round((double)(width / 2)),
                (int)Math.Round((double)(height / 2)));
            if (drawing != null)
                drawing.Dispose();
            drawing = new Bitmap(Math.Max(1, width), Math.Max(1, height));
            Graphics g = Graphics.FromImage(drawing);
            g.Clear(ColorUtils.ActualColor(drawingSpec.BackgroundColor));
            pictureBox1.Image = drawing;
            g.Dispose();
        }

        private void setDefaults()
        {
            drawingSpec.DrawingName = "";
            drawingSpec.BackgroundColor = Color.White.Name;
            setCenter();
            di.aRadius = 210;
            di.bRadius = 90;
            di.distance = 110;
            di.startAngle = 0;
            di.pointsPerCurve = 100;
            di.roll = RollSide.inside;
            di.color = "Blue";
            di.penWidth = 1.0f;
            di.penStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            di.offset.Width = 0;
            di.offset.Height = 0;
            // initialize deltas
            delta.aRadius = 0;
            delta.bRadius = 0;
            delta.penDistance = 0;
            delta.startAngle = 0;
            delta.offsetX = 0;
            delta.offsetY = 0;
        }
        private void initFormParams(DrawingInputType di, DeltaType delta)
        {
            txtOffsetX.Text = di.offset.Width.ToString();
            txtOffsetXdelta.Text = (delta.offsetX == 0) ? "" : delta.offsetX.ToString();
            txtOffsetY.Text = di.offset.Height.ToString();
            txtOffsetYdelta.Text = (delta.offsetY == 0) ? "" : delta.offsetY.ToString();
            txtRadiusA.Text = di.aRadius.ToString();
            txtRadiusADelta.Text = (delta.aRadius == 0) ? "" : delta.aRadius.ToString();
            txtRadiusB.Text = di.bRadius.ToString();
            txtRadiusBDelta.Text = (delta.bRadius == 0) ? "" : delta.bRadius.ToString();
            txtPenDistance.Text = di.distance.ToString();
            txtPenDistanceDelta.Text = (delta.penDistance == 0) ? "" : delta.penDistance.ToString();
            txtPointsPerRev.Text = di.pointsPerCurve.ToString();
            txtStartAngle.Text = di.startAngle.ToString();
            txtStartAngleDelta.Text = (delta.startAngle == 0) ? "" : delta.startAngle.ToString();
            btnColor.ForeColor = ColorUtils.ActualColor(di.color);
            txtPenWidth.Text = di.penWidth.ToString();
            cboPenStyle.Text = di.penStyle.ToString();
            if (di.roll == RollSide.inside)
                rbInside.Checked = true;
            else
                rbOutside.Checked = true;
        }

        private void btnGo_Click(object sender, System.EventArgs e)
        {
            drawingSpec.Curves.Add(di);
            Graphics g = Graphics.FromImage(drawing);
            Spiro.DrawCurve(g, di, PointF.Add(drawingSpec.Center, di.offset));
            g.Dispose();
            di.aRadius += delta.aRadius;
            txtRadiusA.Text = di.aRadius.ToString();
            di.bRadius += delta.bRadius;
            txtRadiusB.Text = di.bRadius.ToString();
            di.distance += delta.penDistance;
            txtPenDistance.Text = di.distance.ToString();
            di.startAngle += delta.startAngle;
            txtStartAngle.Text = di.startAngle.ToString();
            di.offset.Width += delta.offsetX;
            txtOffsetX.Text = di.offset.Width.ToString();
            di.offset.Height += delta.offsetY;
            txtOffsetY.Text = di.offset.Height.ToString();
            if (cbShowWheels.Checked &&
                (delta.aRadius != 0 || delta.bRadius != 0 || delta.penDistance != 0 ||
                delta.startAngle != 0 || delta.offsetX != 0 || delta.offsetY != 0))
            {
                drawSpiro(); // shows wheels and data with updated values (not yet drawn)
            }
            pictureBox1.Refresh();
            btnUndo.Enabled = true;
        }

        private void cbShowWheels_CheckedChanged(object sender, EventArgs e)
        {
            drawSpiro();
        }

        private void txtRadiusA_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (int.TryParse(txtRadiusA.Text, out i) && (i > 0))
            {
                di.aRadius = i;
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            else
            {
                MessageBox.Show("Fixed circle radius must be an integer value greater than 0");
                txtRadiusA.Focus();
            }
        }

        private void txtRadiusB_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (int.TryParse(txtRadiusB.Text, out i) && (i > 0))
            {
                di.bRadius = i;
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            else
            {
                MessageBox.Show("Rolling circle radius must be an integer value greater than 0");
                txtRadiusB.Focus();
            }
        }

        private void txtPenDistance_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.distance = int.Parse(txtPenDistance.Text);
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show
                    ("distance from center must be integer");
                txtPenDistance.Focus();
            }
        }

        private void txtPointsPerCurve_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (int.TryParse(txtPointsPerRev.Text, out i) && (i > 0))
            {
                di.pointsPerCurve = i;
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            else
            {
                MessageBox.Show
                    ("Points per curve must be greater than 0");
                txtPointsPerRev.Focus();
            }
        }

        private void rbOutside_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOutside.Checked)
                di.roll = RollSide.outside;
            else
                di.roll = RollSide.inside;
            if (cbShowWheels.Checked)
            {
                drawSpiro();
            }
        }

        private void txtStartAngle_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.startAngle = int.Parse(txtStartAngle.Text);
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            catch
            {
                DialogResult r = MessageBox.Show
                    ("Start angle must be integer");
                txtStartAngle.Focus();
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (var dlg = new CustomNamedColorDialog())
            {
                dlg.StartPosition = FormStartPosition.Manual;
                dlg.Location = new Point(this.Left + 150, this.Top + 350);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    btnColor.ForeColor = dlg.SelectedColor;
                    di.color = btnColor.ForeColor.Name;
                    if (cbShowWheels.Checked)
                    {
                        drawSpiro();
                    }
                }
            }
        }

        private void drawSpiro()
        {
            Graphics g = Graphics.FromImage(drawing);
            g.Clear(ColorUtils.ActualColor(drawingSpec.BackgroundColor));
            foreach (DrawingInputType d in drawingSpec.Curves)
            {
                Spiro.DrawCurve(g, d, PointF.Add(drawingSpec.Center, d.offset));
            }
            if (cbShowWheels.Checked)
            {
                Spiro.ShowCircles(g, PointF.Add(drawingSpec.Center, di.offset), di.aRadius, di.bRadius,
                    di.distance, di.startAngle, di.pointsPerCurve, di.roll, btnColor.ForeColor,
                    di.penWidth);
            }
            g.Dispose();
            pictureBox1.Refresh();
            btnUndo.Enabled = drawingSpec.Curves.Count > 0;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            setCenter();
            drawSpiro();
        }

        private void txtX_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.offset.Width = int.Parse(txtOffsetX.Text);
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Offsets from center must be integer");
                txtOffsetX.Focus();
            }
        }

        private void txtY_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.offset.Height = int.Parse(txtOffsetY.Text);
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Offsets from center must be integer");
                txtOffsetY.Focus();
            }
        }

        private void txtPenWidth_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.penWidth = float.Parse(txtPenWidth.Text);
                if (cbShowWheels.Checked)
                {
                    drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Pen width must be a number (e.g. 1.0 to 3.5");
                txtPenWidth.Focus();
            }
        }

        private void loadScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = GetDrawingsDirectory();
            openFileDialog1.Filter = "drawing scripts (*.xml)|*.xml|drawings (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (fName.ToLower().EndsWith("bmp"))
                {
                    fName = fName.Substring(0, fName.Length - 3) + "xml";
                }
                drawingSpec = DrawingSpec.retrieveDrawing(fName);
                // populate form with last curve
                if (drawingSpec.Curves.Count > 0)
                {
                    di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                    initFormParams(di, delta);
                    btnUndo.Enabled = true;
                }
                txtFileName.Text = Path.GetFileNameWithoutExtension(fName);
                drawSpiro();
                btnRedo.Enabled = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = GetDrawingsDirectory();
            saveFileDialog1.Filter = "drawing scripts (*.xml)|*.xml|drawings (*.bmp)|*.bmp";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.FileName = drawingSpec.DrawingName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                if (fName.ToLower().EndsWith("bmp"))
                {
                    pictureBox1.Image.Save(fName);
                    fName = fName.Substring(0, fName.Length - 3) + "xml";
                }
                drawingSpec.saveDrawing(fName);
                txtFileName.Text = Path.GetFileNameWithoutExtension(fName);
            }
        }
        //clear drawing area
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingSpec.Curves.Clear();
            drawingSpec.ClearRedoStack();
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            txtFileName.Text = "";
            drawSpiro();
        }

        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptForm frmScript = new ScriptForm(drawingSpec, colorNames);
            frmScript.ShowDialog();
            if (frmScript.DialogResult == DialogResult.OK)
            {
                drawingSpec = frmScript.script;
                // load mainform with the last curve (pattern), if any, in the script
                if (drawingSpec.Curves.Count > 0)
                {
                    di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                    initFormParams(di, delta);
                }
                drawSpiro();
            }
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            Spiro.Animate(di, Point.Add(drawingSpec.Center, di.offset), pictureBox1);
        }

        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            Spiro.StopAnimation();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Spiro.ToggleAnimation();
        }

        private void btnFaster_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                if (Spiro.delayPerPoint > 20)
                    Spiro.delayPerPoint = Spiro.delayPerPoint - 10;
            }
        }

        private void btnSlower_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                Spiro.delayPerPoint = Spiro.delayPerPoint + 10;
            }
        }

        private void cboPenStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            di.penStyle = (System.Drawing.Drawing2D.DashStyle)
            Enum.Parse(typeof(System.Drawing.Drawing2D.DashStyle), cboPenStyle.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBox;
            var setter = tb.Tag as Action<int>;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                setter(0);
                return;
            }

            if (int.TryParse(tb.Text, out int value))
            {
                setter(value);
            }
            else
            {
                MessageBox.Show("Delta value must be an integer or empty");
                e.Cancel = true;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            drawingSpec.UndoLastPattern();
            // populate form with last curve
            if (drawingSpec.Curves.Count > 0)
            {
                di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                initFormParams(di, delta);
            }
            drawSpiro();
            btnRedo.Enabled = true;
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            btnRedo.Enabled = drawingSpec.RedoLastPattern() > 0;
            // populate form with last curve
            di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
            initFormParams(di, delta);
            drawSpiro();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new CustomNamedColorDialog())
            {
                dlg.StartPosition = FormStartPosition.Manual;
                dlg.Location = new Point(this.Left + 100, this.Top + 50);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Color chosen = dlg.SelectedColor;
                    drawingSpec.BackgroundColor = chosen.Name;
                    Graphics g = Graphics.FromImage(drawing);
                    g.Clear(chosen);
                    g.Dispose();
                    drawSpiro();
                }
            }
        }

        private void setDrawingDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDefaults();
            initFormParams(di, delta);
            cbShowWheels.Checked = false;
        }
        private HelpForm _helpWindow;
        private HelpForm _aboutWindow;

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_helpWindow == null || _helpWindow.IsDisposed)
            {
                _helpWindow = new HelpForm("Help", "SpiroGraph.Resources.HelpContent.rtf",600,540);
                _helpWindow.StartPosition = FormStartPosition.Manual;
                _helpWindow.Location = new Point(this.Left + 260, this.Top + 20);
                _helpWindow.Show(this); // modeless
            }
            else
            {
                _helpWindow.Focus(); // bring to front
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_aboutWindow == null || _aboutWindow.IsDisposed)
            {
                _aboutWindow = new HelpForm("About", "SpiroGraph.Resources.AboutContent.rtf",300, 50);
                _aboutWindow.StartPosition = FormStartPosition.Manual;
                _aboutWindow.Location = new Point(this.Left + 100, this.Top + 40);
                _aboutWindow.Show(this);
            }
            else
            {
                _aboutWindow.Focus();
            }
        }
    }
}