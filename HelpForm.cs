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
        public HelpForm(string title, string resourceName, int maxwidth=600)
        {
            InitializeComponent();
            Text = title;
            richTextBox1.ReadOnly = true;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.DetectUrls = true;

            LoadRtf(resourceName);
            richTextBox1.SelectionIndent = 20;   // pixels
            AutoSizeToContent();
        }

        private void LoadRtf(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();
            using var stream = asm.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Resource not found: {resourceName}");

            using var reader = new StreamReader(stream);
            richTextBox1.Rtf = reader.ReadToEnd();
        }

        private void AutoSizeToContent()
        {
            const int maxWidth = 600;

            // First, constrain width
            richTextBox1.Width = maxWidth;

            // Now ask for preferred height with that width
            var preferred = richTextBox1.GetPreferredSize(new Size(maxWidth, int.MaxValue));

            richTextBox1.Height = preferred.Height + 20;

            Width = richTextBox1.Right + 40;
            Height = richTextBox1.Bottom + 40;
        }
    }
}
