using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpiroGraph
{
    public partial class ScriptForm : Form
    {

        private DrawingSpec drawingSpec;

        public DrawingSpec script
        {
            get { return drawingSpec; }
        }

        public ScriptForm(DrawingSpec drawingSpec, object[] colorNames)
        {
            InitializeComponent();
            // Catch and report data errors from color mismatches
            dgvScript.DataError += (s, e) =>
            {
                e.ThrowException = false;

                if (e.Context.HasFlag(DataGridViewDataErrorContexts.Commit) ||
                    e.Context.HasFlag(DataGridViewDataErrorContexts.Formatting) ||
                    e.Context.HasFlag(DataGridViewDataErrorContexts.Parsing))
                {
                    var cell = dgvScript[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                    var value = cell?.Value;

                    if (value != null)
                    {
                       // Console.WriteLine($"Missing color in ComboBox list: {value}");
                        MessageBox.Show($"Missing color: {value}");

                    }
                }
            };

            cboBGColor.Items.AddRange(colorNames);
            color.Items.AddRange(colorNames);
         //   drawingSpec = drawingSpec;
            txtName.Text = drawingSpec.DrawingName;
            centerX.Text = drawingSpec.Center.X.ToString();
            centerY.Text = drawingSpec.Center.Y.ToString();
            cboBGColor.Text = drawingSpec.BackgroundColor;
            foreach (object o in drawingSpec.Curves)
            {
                DrawingInputType di = (DrawingInputType)o;
                string[] row = { di.aRadius.ToString(), di.bRadius.ToString(), di.distance.ToString(),
                    di.startAngle.ToString(), "inside", di.color, di.pointsPerCurve.ToString(), 
                    di.offset.Width.ToString(), di.offset.Height.ToString(), di.penWidth.ToString(),
                    di.penStyle.ToString()};
                if (di.roll == RollSide.outside)
                    row[4] = "outside";
                dgvScript.Rows.Add(row);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool allRowsComplete = true;
            drawingSpec = new DrawingSpec();
            drawingSpec.DrawingName = txtName.Text;
            drawingSpec.Center = new Point(
                int.Parse(centerX.Text), int.Parse(centerY.Text));
            drawingSpec.BackgroundColor = cboBGColor.Text;
            foreach (DataGridViewRow row in dgvScript.Rows)
            {
                bool rowComplete = true;
                bool rowEmpty = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        rowComplete = false;
                    }
                    else
                    {
                        rowEmpty = false;
                    }
                }
                if (!rowComplete && !rowEmpty)
                {
                    MessageBox.Show("Missing data on row " + (row.Index + 1).ToString() +
                        ". Please finish the row or delete it.",
                        "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allRowsComplete = false;
                    break;
                }
                else if (rowComplete)
                {
                    DrawingInputType di = new DrawingInputType();
                    di.aRadius = int.Parse(row.Cells[0].Value.ToString());
                    di.bRadius = int.Parse(row.Cells[1].Value.ToString());
                    di.distance = int.Parse(row.Cells[2].Value.ToString());
                    di.startAngle = int.Parse(row.Cells[3].Value.ToString());
                    if (row.Cells[4].Value.ToString() == "outside")
                        di.roll = RollSide.outside;
                    else
                        di.roll = RollSide.inside;
                    di.color = row.Cells[5].Value.ToString();
                    di.pointsPerCurve = int.Parse(row.Cells[6].Value.ToString());
                    di.offset = new Size(
                        int.Parse(row.Cells[7].Value.ToString()),
                        int.Parse(row.Cells[8].Value.ToString()));
                    di.penWidth = float.Parse(row.Cells[9].Value.ToString());
                    di.penStyle = (System.Drawing.Drawing2D.DashStyle)
                        Enum.Parse(typeof(System.Drawing.Drawing2D.DashStyle), row.Cells[10].Value.ToString());
                    drawingSpec.Curves.Add(di);
                }
            }
            if (allRowsComplete)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dgvScript_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                case 1:
                    {
                        int i;
                        string s = e.FormattedValue.ToString();
                        if (!String.IsNullOrEmpty(s) && (!int.TryParse(s, out i) || (i < 1)))
                        {
                            MessageBox.Show("Must be an integer value greater than 0");
                            e.Cancel = true;
                        }
                        break;
                    }
                case 2:
                case 3:
                case 6:
                case 7:
                case 8:
                    {
                        int i;
                        string s = e.FormattedValue.ToString();
                        if (!String.IsNullOrEmpty(s) && !int.TryParse(s, out i))
                        {
                            MessageBox.Show("Must be an integer value");
                            e.Cancel = true;
                        }
                        break;
                    }
                case 9:
                    {
                        float f;
                        string s = e.FormattedValue.ToString();
                        if (!String.IsNullOrEmpty(s) && !float.TryParse(s, out f))
                        {
                            MessageBox.Show("Pen Width must be a number");
                            e.Cancel = true;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void centerX_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(centerX.Text, out i))
            {
                MessageBox.Show("Center X value must be integer");
                centerX.Focus();
            }
        }

        private void centerY_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(centerY.Text, out i))
            {
                MessageBox.Show("Center Y value must be integer");
                centerY.Focus();
            }
        }
    }
}