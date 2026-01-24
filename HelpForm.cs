using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace SpiroGraph
{
    public partial class HelpForm : Form
    {
        public HelpForm(string title, string resourceName, int width, int minHeight)
        {
            InitializeComponent();
            Text = title;
            richTextBox1.ReadOnly = true;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.DetectUrls = true;

            LoadRtf(resourceName);
            richTextBox1.SelectAll();
            richTextBox1.SelectionIndent = 20;   // pixels
            richTextBox1.DeselectAll();
            AutoSizeToContent(width, minHeight);
        }

        private void LoadRtf(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var stream = asm.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Resource not found: {resourceName}");

            using var reader = new StreamReader(stream);
            richTextBox1.Rtf = reader.ReadToEnd();
        }

        private void AutoSizeToContent(int width, int minHeight)
        {
            // Make sure the RichTextBox isn't docked/fill or over‑anchored
            richTextBox1.Dock = DockStyle.None;
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            richTextBox1.Width = width;
            var preferred = richTextBox1.GetPreferredSize(new Size(width, minHeight));

            richTextBox1.Height = Math.Max(preferred.Height + 20,minHeight);

            Width = richTextBox1.Right + 40;
            Height = richTextBox1.Bottom + 40;
        }
    }
}
