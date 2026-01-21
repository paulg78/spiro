using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SpiroGraph.Utils;

namespace SpiroGraph
{

    public partial class MainForm : Form
    {
        DrawingInputType di; // set of drawing inputs
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
            "DarkOliveGreen",
            "Olive",
            "DarkKhaki",
            "Khaki",
            "Beige",
            "LightGoldenrodYellow",
            "LightYellow",
            "Yellow",
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
            "MediumPurple",
            "BlueViolet",
            "DarkOrchid",
            "Orchid",
            "Violet",
            "DarkBlue",
            "MediumBlue",
            "Blue",
            "LightBlue",
            "PowderBlue",
            "LightSkyBlue",
            "SkyBlue",
            "DodgerBlue",
            "Turquoise",
            "LightSeaGreen",
            "DarkCyan",
            "Aqua",
            "LightCyan",
            "Silver",
            "Gray",
            "DarkGray",
            "LightGray",
            "White"
            };

        public MainForm()
        {
            InitializeComponent();
            cboColor.Items.AddRange(colorNames);
            //cboBackgroundColor.Items.AddRange(colorNames);
            drawingSpec.DrawingName = "";
            drawingSpec.BackgroundColor = Color.White.Name;
            setCenter();

            // initialize drawing inputs
            di.aRadius = 210;
            di.aRadiusDelta = 0;
            di.bRadius = 90;
            di.distance = 110;
            di.pointsPerCurve = 100;
            di.roll = RollSide.inside;
            di.color = "Blue";
            di.penWidth = 1.0f;
            di.penStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            di.offset.Width = 0;
            di.offset.Height = 0;
            // initialize form
            initFormParams(di);
            //cboBackgroundColor.Text = drawingSpec.BackgroundColor;
            cboColor.SelectedIndexChanged += new System.EventHandler(cboColor_SelectedIndexChanged);
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

        private void initFormParams(DrawingInputType di)
        {
            txtOffsetX.Text = di.offset.Width.ToString();
            txtOffsetY.Text = di.offset.Height.ToString();
            txtRadiusA.Text = di.aRadius.ToString();
            txtRadiusADelta.Text = (di.aRadiusDelta == 0) ? "" : di.aRadiusDelta.ToString();
            txtRadiusB.Text = di.bRadius.ToString();
            txtRadiusBDelta.Text = (di.bRadiusDelta == 0) ? "" : di.bRadiusDelta.ToString();
            txtPenDistance.Text = di.distance.ToString();
            txtPenDistanceDelta.Text = (di.distanceDelta == 0) ? "" : di.distanceDelta.ToString();
            txtPointsPerCurve.Text = di.pointsPerCurve.ToString();
            txtStartAngle.Text = di.startAngle.ToString();
            txtStartAngleDelta.Text = (di.startAngleDelta == 0) ? "" : di.startAngleDelta.ToString();
            cboColor.Text = di.color;
            lblColor.ForeColor = ColorUtils.ActualColor(di.color);
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
            di.aRadius += di.aRadiusDelta;
            txtRadiusA.Text = di.aRadius.ToString();
            di.bRadius += di.bRadiusDelta;
            txtRadiusB.Text = di.bRadius.ToString();
            di.distance += di.distanceDelta;
            txtPenDistance.Text = di.distance.ToString();
            di.startAngle += di.startAngleDelta;
            txtStartAngle.Text = di.startAngle.ToString();
            if (cbShowWheels.Checked && 
                (di.aRadiusDelta != 0 || di.bRadiusDelta != 0 || di.distanceDelta != 0 || di.startAngleDelta != 0))
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
                if (int.TryParse(txtPointsPerCurve.Text, out i) && (i > 0))
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
                txtPointsPerCurve.Focus();
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

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblColor.ForeColor = ColorUtils.ActualColor(cboColor.Text);
            di.color = lblColor.ForeColor.Name;
            if (cbShowWheels.Checked)
            {  
                drawSpiro();
            }    
        }
        //private void btnColor_Click(object sender, EventArgs e)
        //{
        //    if (colorDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        Color chosen = colorDialog1.Color;
        //        lblColor.ForeColor = chosen;
        //        di.color = lblColor.ForeColor.Name;
        //        if (cbShowWheels.Checked)
        //        {
        //            drawSpiro();
        //        }

        //    }

        //}
        private void btnColor_Click(object sender, EventArgs e)
        {
            using (var dlg = new CustomNamedColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Color chosen = dlg.SelectedColor;
                    lblColor.ForeColor = chosen;
                    di.color = lblColor.ForeColor.Name;
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
                    di.distance, di.startAngle, di.pointsPerCurve, di.roll, lblColor.ForeColor,
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
            //openFileDialog1.Filter = "drawing files (*.xml)|*.xml";
            openFileDialog1.Filter = "drawing scripts (*.xml)|*.xml|drawings (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (fName.ToLower().EndsWith("bmp"))
                {
                    fName = fName.Substring(0, fName.Length - 3) + "xml";
                }
                drawingSpec = DrawingSpec.retrieveDrawing(fName);
                //cboBackgroundColor.Text = drawingSpec.BackgroundColor;
                // populate form with last curve
                if (drawingSpec.Curves.Count > 0)
                {
                    di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                    initFormParams(di);
                    btnUndo.Enabled = true;
                }
                txtFileName.Text = fName;
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
                txtFileName.Text = fName;
            }
        }

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
                    initFormParams(di);
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
                //Spiro.delay = (int)Math.Round((double)(Spiro.delay / 2));
            }
        }

        private void btnSlower_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                //Spiro.delay = 2 * Spiro.delay;
                Spiro.delayPerPoint = Spiro.delayPerPoint + 10;
            }
        }

        private void cboPenStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            di.penStyle = (System.Drawing.Drawing2D.DashStyle)
            Enum.Parse(typeof(System.Drawing.Drawing2D.DashStyle), cboPenStyle.Text);
        }

        //private void cboBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        //{
        // //   drawingSpec.BackgroundColor = cboBackgroundColor.Text;
        //    Graphics g = Graphics.FromImage(drawing);
        //    g.Clear(ColorUtils.ActualColor(drawingSpec.BackgroundColor));
        //    g.Dispose();
        //    drawSpiro();
        //}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtRadiusADelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRadiusADelta.Text))
              di.aRadiusDelta = 0;
            else
              try
                {
                    di.aRadiusDelta = int.Parse(txtRadiusADelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    txtRadiusADelta.Focus();
                }
        }

        private void txtRadiusBDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRadiusBDelta.Text))
                di.bRadiusDelta = 0;
            else
                try
                {
                    di.bRadiusDelta = int.Parse(txtRadiusBDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    txtRadiusBDelta.Focus();
                }
        }

        private void txtPenDistanceDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPenDistanceDelta.Text))
                di.distanceDelta = 0;
            else
                try
                {
                    di.distanceDelta = int.Parse(txtPenDistanceDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    txtPenDistanceDelta.Focus();
                }
        }

        private void txtStartAngleDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtStartAngleDelta.Text))
                di.startAngleDelta = 0;
            else
                try
                {
                    di.startAngleDelta = int.Parse(txtStartAngleDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    txtStartAngleDelta.Focus();
                }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            drawingSpec.UndoLastPattern();
            // populate form with last curve
            if (drawingSpec.Curves.Count > 0)
            {
                di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                initFormParams(di);
            }
            drawSpiro();
            btnRedo.Enabled = true;
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            btnRedo.Enabled = drawingSpec.RedoLastPattern() > 0;
            // populate form with last curve
            di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
            initFormParams(di);
            drawSpiro();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new CustomNamedColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Color chosen = dlg.SelectedColor;
                    drawingSpec.BackgroundColor = chosen.Name;
                    Graphics g = Graphics.FromImage(drawing);
         //           g.Clear(ColorUtils.ActualColor(drawingSpec.BackgroundColor));
                    g.Clear(chosen);
                    g.Dispose();
                    drawSpiro();
                }
            }
        }
    }
}