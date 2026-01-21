using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpiroGraph
{
    public partial class CustomNamedColorDialog : Form
    {
        public Color SelectedColor { get; private set; }
        private readonly ToolTip colorToolTip = new ToolTip();
        private Panel previewPanel;
        private Button okButton;
        private Button cancelButton;

        public CustomNamedColorDialog()
        {
            Text = "Select Color";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(600, 360);

            CreatePreviewPanel();
            CreateButtons();
            CreateColorGrid();
        }

        private void CreatePreviewPanel()
        {
            previewPanel = new Panel
            {
                Width = 80,
                Height = 80,
                Left = 430,
                Top = 6,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Controls.Add(previewPanel);
        }

        private void CreateButtons()
        {
            okButton = new Button
            {
                Text = "OK",
                Width = 80,
                Left = 430,
                Top = 106,
                DialogResult = DialogResult.OK
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                Width = 80,
                Left = 430,
                Top = 146,
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(okButton);
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private void AutoSizeForm(int cols, int swatchSize, int margin)
        {
            int count = MainForm.colorNames.Length;
            int rows = (int)Math.Ceiling(count / (double)cols);

            int gridWidth = margin + cols * (swatchSize + margin);
            int gridHeight = margin + rows * (swatchSize + margin);

            int previewWidth = previewPanel.Width + 40; // includes spacing
            int buttonArea = 200; // enough vertical space for OK/Cancel

            this.ClientSize = new Size(
                gridWidth + previewWidth,
                Math.Max(gridHeight, buttonArea)
            );
        }
        private void CreateColorGrid()
        {
            int swatchSize = 28;
            int margin = 6;
            int cols = 12;

            for (int i = 0; i < MainForm.colorNames.Length; i++)
            {
                Color col = Color.FromName(MainForm.colorNames[i]);

                var panel = new Panel
                {
                    BackColor = col,
                    Width = swatchSize,
                    Height = swatchSize,
                    Left = margin + (i % cols) * (swatchSize + margin),
                    Top = margin + (i / cols) * (swatchSize + margin),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = col
                };
                string colorName = MainForm.colorNames[i];

                panel.MouseMove += (s, e) =>
                {
                    var p = panel.PointToScreen(new Point(e.X, e.Y));

                    // Offset upward so it appears above the cursor
                    p.Y -= 20;

                    colorToolTip.Show(colorName, this, this.PointToClient(p), 2000);
                };
                panel.MouseLeave += (s, e) =>
                {
                    colorToolTip.Hide(this);
                };

                panel.Click += (s, e) =>
                {
                    SelectedColor = (Color)((Panel)s).Tag;
                    previewPanel.BackColor = SelectedColor;
                };

                Controls.Add(panel);
            }
            AutoSizeForm(cols, swatchSize, margin);
        }
    }
}