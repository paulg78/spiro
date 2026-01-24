namespace SpiroGraph
{
    partial class frmControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSlower = new System.Windows.Forms.Button();
            this.btnFaster = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStopAnimation = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSlower
            // 
            this.btnSlower.Location = new System.Drawing.Point(113, 53);
            this.btnSlower.Name = "btnSlower";
            this.btnSlower.Size = new System.Drawing.Size(58, 23);
            this.btnSlower.TabIndex = 47;
            this.btnSlower.Text = "slower";
            this.btnSlower.UseVisualStyleBackColor = true;
            this.btnSlower.Click += new System.EventHandler(this.btnSlower_Click);
            // 
            // btnFaster
            // 
            this.btnFaster.Location = new System.Drawing.Point(38, 53);
            this.btnFaster.Name = "btnFaster";
            this.btnFaster.Size = new System.Drawing.Size(58, 23);
            this.btnFaster.TabIndex = 46;
            this.btnFaster.Text = "faster";
            this.btnFaster.UseVisualStyleBackColor = true;
            this.btnFaster.Click += new System.EventHandler(this.btnFaster_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(38, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(58, 23);
            this.btnPause.TabIndex = 45;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStopAnimation
            // 
            this.btnStopAnimation.Location = new System.Drawing.Point(113, 12);
            this.btnStopAnimation.Name = "btnStopAnimation";
            this.btnStopAnimation.Size = new System.Drawing.Size(58, 23);
            this.btnStopAnimation.TabIndex = 44;
            this.btnStopAnimation.Text = "Stop";
            this.btnStopAnimation.UseVisualStyleBackColor = true;
            this.btnStopAnimation.Click += new System.EventHandler(this.btnStopAnimation_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(113, 96);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 23);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 131);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSlower);
            this.Controls.Add(this.btnFaster);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStopAnimation);
            this.Name = "frmControl";
            this.Text = "Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControl_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSlower;
        private System.Windows.Forms.Button btnFaster;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStopAnimation;
        private System.Windows.Forms.Button btnClose;
    }
}