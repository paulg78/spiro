namespace SpiroGraph
{
    partial class ScriptForm
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
            this.dgvScript = new System.Windows.Forms.DataGridView();
            this.aRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roll = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pointsPerCurve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsetX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsetY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBGColor = new System.Windows.Forms.ComboBox();
            this.centerY = new SpiroGraph.customTextBox();
            this.centerX = new SpiroGraph.customTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvScript
            // 
            this.dgvScript.AllowUserToOrderColumns = true;
            this.dgvScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvScript.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScript.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aRadius,
            this.bRadius,
            this.distance,
            this.startAngle,
            this.roll,
            this.color,
            this.pointsPerCurve,
            this.offsetX,
            this.offsetY,
            this.penWidth,
            this.penStyle});
            this.dgvScript.Location = new System.Drawing.Point(23, 30);
            this.dgvScript.Name = "dgvScript";
            this.dgvScript.Size = new System.Drawing.Size(943, 372);
            this.dgvScript.TabIndex = 0;
            this.dgvScript.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvScript_CellValidating);
            // 
            // aRadius
            // 
            this.aRadius.HeaderText = "fixed circle radius";
            this.aRadius.MaxInputLength = 3;
            this.aRadius.Name = "aRadius";
            this.aRadius.Width = 85;
            // 
            // bRadius
            // 
            this.bRadius.HeaderText = "rolling circle radius";
            this.bRadius.MaxInputLength = 3;
            this.bRadius.Name = "bRadius";
            this.bRadius.Width = 90;
            // 
            // distance
            // 
            this.distance.HeaderText = "pen distance from center";
            this.distance.MaxInputLength = 3;
            this.distance.Name = "distance";
            // 
            // startAngle
            // 
            this.startAngle.HeaderText = "start angle (deg.)";
            this.startAngle.MaxInputLength = 3;
            this.startAngle.Name = "startAngle";
            this.startAngle.Width = 85;
            // 
            // roll
            // 
            this.roll.HeaderText = "roll side";
            this.roll.Items.AddRange(new object[] {
            "inside",
            "outside"});
            this.roll.Name = "roll";
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.Name = "color";
            this.color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pointsPerCurve
            // 
            this.pointsPerCurve.HeaderText = "# points";
            this.pointsPerCurve.MaxInputLength = 3;
            this.pointsPerCurve.Name = "pointsPerCurve";
            this.pointsPerCurve.Width = 50;
            // 
            // offsetX
            // 
            this.offsetX.HeaderText = "X offset";
            this.offsetX.MaxInputLength = 3;
            this.offsetX.Name = "offsetX";
            this.offsetX.Width = 60;
            // 
            // offsetY
            // 
            this.offsetY.HeaderText = "Y offset";
            this.offsetY.MaxInputLength = 3;
            this.offsetY.Name = "offsetY";
            this.offsetY.Width = 60;
            // 
            // penWidth
            // 
            this.penWidth.HeaderText = "pen width";
            this.penWidth.Name = "penWidth";
            this.penWidth.Width = 60;
            // 
            // penStyle
            // 
            this.penStyle.HeaderText = "pen style";
            this.penStyle.Items.AddRange(new object[] {
            "Dash",
            "Dot",
            "Solid"});
            this.penStyle.Name = "penStyle";
            this.penStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.penStyle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(71, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 20);
            this.txtName.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(82, 416);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Save Edits";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(233, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel Edits";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X (drawing center)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y (drawing center)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "background color";
            // 
            // cboBGColor
            // 
            this.cboBGColor.FormattingEnabled = true;
            this.cboBGColor.Location = new System.Drawing.Point(682, 3);
            this.cboBGColor.Name = "cboBGColor";
            this.cboBGColor.Size = new System.Drawing.Size(107, 21);
            this.cboBGColor.TabIndex = 13;
            // 
            // centerY
            // 
            this.centerY.Location = new System.Drawing.Point(506, 3);
            this.centerY.MaxLength = 3;
            this.centerY.Name = "centerY";
            this.centerY.Size = new System.Drawing.Size(38, 20);
            this.centerY.TabIndex = 10;
            this.centerY.Validating += new System.ComponentModel.CancelEventHandler(this.centerY_Validating);
            // 
            // centerX
            // 
            this.centerX.Location = new System.Drawing.Point(347, 3);
            this.centerX.MaxLength = 3;
            this.centerX.Name = "centerX";
            this.centerX.Size = new System.Drawing.Size(38, 20);
            this.centerX.TabIndex = 9;
            this.centerX.Validating += new System.ComponentModel.CancelEventHandler(this.centerX_Validating);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 451);
            this.Controls.Add(this.cboBGColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.centerY);
            this.Controls.Add(this.centerX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgvScript);
            this.Name = "ScriptForm";
            this.Text = "Edit Drawing Script";
            ((System.ComponentModel.ISupportInitialize)(this.dgvScript)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScript;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private customTextBox centerX;
        private customTextBox centerY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBGColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn aRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn bRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAngle;
        private System.Windows.Forms.DataGridViewComboBoxColumn roll;
        private System.Windows.Forms.DataGridViewComboBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsPerCurve;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsetX;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsetY;
        private System.Windows.Forms.DataGridViewTextBoxColumn penWidth;
        private System.Windows.Forms.DataGridViewComboBoxColumn penStyle;
    }
}