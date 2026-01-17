using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpiroGraph
{

    public partial class MainForm : Form
    {
        DrawingInputType di; // set of drawing inputs
        DrawingSpec drawingSpec = new DrawingSpec();
        Bitmap drawing;
        object[] colorNames = new object[] {
            "Aqua",
            "Beige",
            "Bisque",
            "Black",
            "Blue",
            "BlueViolet",
            "Brown",
            "Chocolate",
            "Coral",
            "Crimson",
            "DarkBlue",
            "DarkCyan",
            "DarkGoldenrod",
            "DarkGray",
            "DarkGreen",
            "DarkMagenta",
            "DarkOrange",
            "DarkOrchid",
            "DarkRed",
            "DarkSalmon",
            "DeepPink",
            "ForestGreen",
            "Fuchsia",
            "Gray",
            "Green",
            "GreenYellow",
            "HotPink",
            "LightBlue",
            "LightCoral",
            "LightCyan",
            "LightGoldenrodYellow",
            "LightGray",
            "LightGreen",
            "LightPink",
            "LightSalmon",
            "LightSeaGreen",
            "LightSkyBlue",
            "LightSlateGray",
            "LightSteelBlue",
            "LightYellow",
            "Lime",
            "Magenta",
            "Maroon",
            "MediumBlue",
            "MistyRose",
            "Navy",
            "Orange",
            "OrangeRed",
            "Pink",
            "PowderBlue",
            "Purple",
            "Red",
            "Silver",
            "Tomato",
            "Turquoise",
            "Violet",
            "White",
            "Yellow",
            "YellowGreen"};

        public MainForm()
        {
            InitializeComponent();
            this.cboColor.Items.AddRange(colorNames);
            this.cboBackgroundColor.Items.AddRange(colorNames);
            drawingSpec.DrawingName = "drawing1";
            drawingSpec.BackgroundColor = Color.White.Name;
            this.setCenter();

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
            this.initFormParams(di);
            this.cboBackgroundColor.Text = drawingSpec.BackgroundColor;
            this.cboColor.SelectedIndexChanged += new System.EventHandler(this.cboColor_SelectedIndexChanged);
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
            g.Clear(Color.FromName(drawingSpec.BackgroundColor));
            pictureBox1.Image = drawing;
            g.Dispose();
        }

        private void initFormParams(DrawingInputType di)
        {
            this.txtOffsetX.Text = di.offset.Width.ToString();
            this.txtOffsetY.Text = di.offset.Height.ToString();
            txtRadiusA.Text = di.aRadius.ToString();
            txtRadiusADelta.Text = (di.aRadiusDelta == 0) ? "" : di.aRadiusDelta.ToString();
            txtRadiusB.Text = di.bRadius.ToString();
            txtRadiusBDelta.Text = (di.bRadiusDelta == 0) ? "" : di.bRadiusDelta.ToString();
            this.txtPenDistance.Text = di.distance.ToString();
            this.txtPenDistanceDelta.Text = (di.distanceDelta == 0) ? "" : di.distanceDelta.ToString();
            this.txtPointsPerCurve.Text = di.pointsPerCurve.ToString();
            txtStartAngle.Text = di.startAngle.ToString();
            txtStartAngleDelta.Text = (di.startAngleDelta == 0) ? "" : di.startAngleDelta.ToString();
            cboColor.Text = di.color;
            lblColor.ForeColor = Color.FromName(di.color);
            txtPenWidth.Text = di.penWidth.ToString();
            cboPenStyle.Text = di.penStyle.ToString();
            if (di.roll == RollSide.inside)
                this.rbInside.Checked = true;
            else
                this.rbOutside.Checked = true;
        }

        private void btnGo_Click(object sender, System.EventArgs e)
        {
            this.drawingSpec.Curves.Add(di);
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
                this.drawSpiro(); // shows wheels and data with updated values (not yet drawn)
            }
            pictureBox1.Refresh();
        }

        private void cbShowWheels_CheckedChanged(object sender, EventArgs e)
        {
            this.drawSpiro();
        }

        private void txtRadiusA_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (int.TryParse(txtRadiusA.Text, out i) && (i > 0))
            {
                di.aRadius = i;
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
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
                    this.drawSpiro();
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
                di.distance = int.Parse(this.txtPenDistance.Text);
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show
                    ("distance from center must be integer");
                this.txtPenDistance.Focus();
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
                        this.drawSpiro();
                    }
                }
            else
            {
                MessageBox.Show
                    ("Points per curve must be greater than 0");
                this.txtPointsPerCurve.Focus();
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
                this.drawSpiro();
            }
        }

        private void txtStartAngle_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.startAngle = int.Parse(this.txtStartAngle.Text);
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
                }
            }
            catch
            {
                DialogResult r = MessageBox.Show
                    ("Start angle must be integer");
                this.txtStartAngle.Focus();
            }
        }

        private void cboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblColor.ForeColor = Color.FromName(cboColor.Text);
            di.color = this.lblColor.ForeColor.Name;
            this.drawSpiro();
        }

        private void drawSpiro()
        {
            Graphics g = Graphics.FromImage(drawing);
            g.Clear(Color.FromName(drawingSpec.BackgroundColor));
            foreach (DrawingInputType d in drawingSpec.Curves)
            {
                Spiro.DrawCurve(g, d, PointF.Add(drawingSpec.Center, d.offset));
            }
            if (cbShowWheels.Checked)
            {
                Spiro.ShowCircles(g, PointF.Add(drawingSpec.Center, di.offset), di.aRadius, di.bRadius,
                    di.distance, di.startAngle, di.pointsPerCurve, di.roll, this.lblColor.ForeColor,
                    di.penWidth);
            }
            g.Dispose();
            pictureBox1.Refresh();

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.setCenter();
            this.drawSpiro();
        }

        private void txtX_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.offset.Width = int.Parse(this.txtOffsetX.Text);
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Offsets from center must be integer");
                this.txtOffsetX.Focus();
            }
        }

        private void txtY_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.offset.Height = int.Parse(this.txtOffsetY.Text);
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Offsets from center must be integer");
                this.txtOffsetY.Focus();
            }
        }

        private void txtPenWidth_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                di.penWidth = float.Parse(txtPenWidth.Text);
                if (cbShowWheels.Checked)
                {
                    this.drawSpiro();
                }
            }
            catch
            {
                MessageBox.Show("Pen width must be a number (e.g. 1.0 to 3.5");
                this.txtPenWidth.Focus();
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
                this.drawingSpec = DrawingSpec.retrieveDrawing(fName);
                this.cboBackgroundColor.Text = drawingSpec.BackgroundColor;
                // populate form with last curve
                if (drawingSpec.Curves.Count > 0)
                {
                    di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                    this.initFormParams(di);
                }
                this.drawSpiro();
            }
            //this.drawSpiro();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = GetDrawingsDirectory();
            saveFileDialog1.Filter = "drawing scripts (*.xml)|*.xml|drawings (*.bmp)|*.bmp";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                if (fName.ToLower().EndsWith("bmp"))
                {
                    this.pictureBox1.Image.Save(fName);
                    fName = fName.Substring(0, fName.Length - 3) + "xml";
                }
                this.drawingSpec.saveDrawing(fName);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.drawingSpec.Curves.Clear();
            this.drawSpiro();
        }

        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptForm frmScript = new ScriptForm(drawingSpec, colorNames);
            frmScript.ShowDialog();
            if (frmScript.DialogResult == DialogResult.OK)
            {
                drawingSpec = frmScript.script;
                di = (DrawingInputType)drawingSpec.Curves[drawingSpec.Curves.Count - 1];
                this.initFormParams(di);
                this.drawSpiro();
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

        private void cboBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingSpec.BackgroundColor = cboBackgroundColor.Text;
            Graphics g = Graphics.FromImage(drawing);
            g.Clear(Color.FromName(drawingSpec.BackgroundColor));
            g.Dispose();
            this.drawSpiro();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRadiusADelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtRadiusADelta.Text))
              di.aRadiusDelta = 0;
            else
              try
                {
                    di.aRadiusDelta = int.Parse(this.txtRadiusADelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    this.txtRadiusADelta.Focus();
                }
        }

        private void txtRadiusBDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtRadiusBDelta.Text))
                di.bRadiusDelta = 0;
            else
                try
                {
                    di.bRadiusDelta = int.Parse(this.txtRadiusBDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    this.txtRadiusBDelta.Focus();
                }
        }

        private void txtPenDistanceDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtPenDistanceDelta.Text))
                di.distanceDelta = 0;
            else
                try
                {
                    di.distanceDelta = int.Parse(this.txtPenDistanceDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    this.txtPenDistanceDelta.Focus();
                }
        }

        private void txtStartAngleDelta_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtStartAngleDelta.Text))
                di.startAngleDelta = 0;
            else
                try
                {
                    di.startAngleDelta = int.Parse(this.txtStartAngleDelta.Text);
                }
                catch
                {
                    DialogResult r = MessageBox.Show("delta must be integer");
                    this.txtStartAngleDelta.Focus();
                }
        }
    }

}