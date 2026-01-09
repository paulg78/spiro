using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpiroGraph
{
    public partial class frmControl : Form
    {
        private bool pauseAnimation = false;

        public frmControl()
        {
            InitializeComponent();
        }

        private void btnStopAnimation_Click(object sender, EventArgs e)
        {
            Spiro.StopAnimation();
            this.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pauseAnimation = !pauseAnimation;

            if (pauseAnimation)
            {
                btnPause.Text = "Resume";
            }
            else
            {
                btnPause.Text = "Pause";
            }
            Spiro.ToggleAnimation();
        }

        private void btnFaster_Click(object sender, EventArgs e)
        {
            lock(this)
            {
                if (Spiro.delayPerPoint > 19)
                    Spiro.delayPerPoint = Spiro.delayPerPoint - 10;
                else
                    btnFaster.Enabled = false;
                //Spiro.delay = (int)Math.Round((double)(Spiro.delay / 2));
            }
        }

        private void btnSlower_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                //Spiro.delay = 2 * Spiro.delay;
                Spiro.delayPerPoint = Spiro.delayPerPoint + 10;
                btnFaster.Enabled = true;
            }
        }

        private void frmControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Spiro.StopAnimation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
}
}