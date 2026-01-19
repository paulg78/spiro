namespace SpiroGraph
{
    partial class MainForm
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.txtRadiusBDelta = new SpiroGraph.customTextBox();
            this.txtPenDistanceDelta = new SpiroGraph.customTextBox();
            this.txtStartAngleDelta = new SpiroGraph.customTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRadiusADelta = new SpiroGraph.customTextBox();
            this.cboPenStyle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.txtPenWidth = new SpiroGraph.customTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOutside = new System.Windows.Forms.RadioButton();
            this.rbInside = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOffsetY = new SpiroGraph.customTextBox();
            this.txtOffsetX = new SpiroGraph.customTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.txtStartAngle = new SpiroGraph.customTextBox();
            this.cbShowWheels = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPointsPerCurve = new SpiroGraph.customTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPenDistance = new SpiroGraph.customTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRadiusB = new SpiroGraph.customTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRadiusA = new SpiroGraph.customTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboBackgroundColor = new System.Windows.Forms.ToolStripComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnColor = new System.Windows.Forms.Button();
            this.pnlControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControl.BackColor = System.Drawing.Color.Transparent;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.btnColor);
            this.pnlControl.Controls.Add(this.btnRedo);
            this.pnlControl.Controls.Add(this.btnUndo);
            this.pnlControl.Controls.Add(this.txtRadiusBDelta);
            this.pnlControl.Controls.Add(this.txtPenDistanceDelta);
            this.pnlControl.Controls.Add(this.txtStartAngleDelta);
            this.pnlControl.Controls.Add(this.label9);
            this.pnlControl.Controls.Add(this.txtRadiusADelta);
            this.pnlControl.Controls.Add(this.cboPenStyle);
            this.pnlControl.Controls.Add(this.label6);
            this.pnlControl.Controls.Add(this.lblPenWidth);
            this.pnlControl.Controls.Add(this.txtPenWidth);
            this.pnlControl.Controls.Add(this.groupBox1);
            this.pnlControl.Controls.Add(this.groupBox2);
            this.pnlControl.Controls.Add(this.btnAnimate);
            this.pnlControl.Controls.Add(this.lblColor);
            this.pnlControl.Controls.Add(this.label5);
            this.pnlControl.Controls.Add(this.cboColor);
            this.pnlControl.Controls.Add(this.txtStartAngle);
            this.pnlControl.Controls.Add(this.cbShowWheels);
            this.pnlControl.Controls.Add(this.btnGo);
            this.pnlControl.Controls.Add(this.label3);
            this.pnlControl.Controls.Add(this.txtPointsPerCurve);
            this.pnlControl.Controls.Add(this.label4);
            this.pnlControl.Controls.Add(this.txtPenDistance);
            this.pnlControl.Controls.Add(this.label2);
            this.pnlControl.Controls.Add(this.txtRadiusB);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.txtRadiusA);
            this.pnlControl.Controls.Add(this.menuStrip1);
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(243, 649);
            this.pnlControl.TabIndex = 0;
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Location = new System.Drawing.Point(82, 511);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(46, 23);
            this.btnRedo.TabIndex = 37;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(12, 511);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(46, 23);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // txtRadiusBDelta
            // 
            this.txtRadiusBDelta.AcceptsReturn = true;
            this.txtRadiusBDelta.AccessibleDescription = "";
            this.txtRadiusBDelta.Location = new System.Drawing.Point(182, 73);
            this.txtRadiusBDelta.MaxLength = 3;
            this.txtRadiusBDelta.Name = "txtRadiusBDelta";
            this.txtRadiusBDelta.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusBDelta.TabIndex = 19;
            this.txtRadiusBDelta.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusBDelta_Validating);
            // 
            // txtPenDistanceDelta
            // 
            this.txtPenDistanceDelta.AcceptsReturn = true;
            this.txtPenDistanceDelta.AccessibleDescription = "";
            this.txtPenDistanceDelta.Location = new System.Drawing.Point(182, 95);
            this.txtPenDistanceDelta.MaxLength = 3;
            this.txtPenDistanceDelta.Name = "txtPenDistanceDelta";
            this.txtPenDistanceDelta.Size = new System.Drawing.Size(38, 20);
            this.txtPenDistanceDelta.TabIndex = 20;
            this.txtPenDistanceDelta.Validating += new System.ComponentModel.CancelEventHandler(this.txtPenDistanceDelta_Validating);
            // 
            // txtStartAngleDelta
            // 
            this.txtStartAngleDelta.AcceptsReturn = true;
            this.txtStartAngleDelta.AccessibleDescription = "";
            this.txtStartAngleDelta.Location = new System.Drawing.Point(182, 117);
            this.txtStartAngleDelta.MaxLength = 3;
            this.txtStartAngleDelta.Name = "txtStartAngleDelta";
            this.txtStartAngleDelta.Size = new System.Drawing.Size(38, 20);
            this.txtStartAngleDelta.TabIndex = 21;
            this.txtStartAngleDelta.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartAngleDelta_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(168, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "delta for next";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRadiusADelta
            // 
            this.txtRadiusADelta.AcceptsReturn = true;
            this.txtRadiusADelta.AccessibleDescription = "";
            this.txtRadiusADelta.Location = new System.Drawing.Point(182, 51);
            this.txtRadiusADelta.MaxLength = 3;
            this.txtRadiusADelta.Name = "txtRadiusADelta";
            this.txtRadiusADelta.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusADelta.TabIndex = 18;
            this.txtRadiusADelta.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusADelta_Validating);
            // 
            // cboPenStyle
            // 
            this.cboPenStyle.FormattingEnabled = true;
            this.cboPenStyle.Items.AddRange(new object[] {
            "Dash",
            "Dot",
            "Solid"});
            this.cboPenStyle.Location = new System.Drawing.Point(82, 392);
            this.cboPenStyle.Name = "cboPenStyle";
            this.cboPenStyle.Size = new System.Drawing.Size(83, 21);
            this.cboPenStyle.TabIndex = 13;
            this.cboPenStyle.SelectedIndexChanged += new System.EventHandler(this.cboPenStyle_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pen Style";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPenWidth
            // 
            this.lblPenWidth.AutoSize = true;
            this.lblPenWidth.Location = new System.Drawing.Point(25, 369);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(57, 13);
            this.lblPenWidth.TabIndex = 10;
            this.lblPenWidth.Text = "Pen Width";
            this.lblPenWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPenWidth
            // 
            this.txtPenWidth.Location = new System.Drawing.Point(87, 366);
            this.txtPenWidth.MaxLength = 3;
            this.txtPenWidth.Name = "txtPenWidth";
            this.txtPenWidth.Size = new System.Drawing.Size(38, 20);
            this.txtPenWidth.TabIndex = 11;
            this.txtPenWidth.Validating += new System.ComponentModel.CancelEventHandler(this.txtPenWidth_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOutside);
            this.groupBox1.Controls.Add(this.rbInside);
            this.groupBox1.Location = new System.Drawing.Point(23, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 57);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "rolling circle location";
            // 
            // rbOutside
            // 
            this.rbOutside.AutoSize = true;
            this.rbOutside.Location = new System.Drawing.Point(13, 36);
            this.rbOutside.Name = "rbOutside";
            this.rbOutside.Size = new System.Drawing.Size(114, 17);
            this.rbOutside.TabIndex = 1;
            this.rbOutside.TabStop = true;
            this.rbOutside.Text = "Outside fixed circle";
            this.rbOutside.UseVisualStyleBackColor = true;
            this.rbOutside.CheckedChanged += new System.EventHandler(this.rbOutside_CheckedChanged);
            // 
            // rbInside
            // 
            this.rbInside.AutoSize = true;
            this.rbInside.Location = new System.Drawing.Point(13, 21);
            this.rbInside.Name = "rbInside";
            this.rbInside.Size = new System.Drawing.Size(106, 17);
            this.rbInside.TabIndex = 0;
            this.rbInside.TabStop = true;
            this.rbInside.Text = "Inside fixed circle";
            this.rbInside.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOffsetY);
            this.groupBox2.Controls.Add(this.txtOffsetX);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(24, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 58);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "fixed circle offset";
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Location = new System.Drawing.Point(74, 32);
            this.txtOffsetY.MaxLength = 3;
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetY.TabIndex = 1;
            this.txtOffsetY.Validating += new System.ComponentModel.CancelEventHandler(this.txtY_Validating);
            // 
            // txtOffsetX
            // 
            this.txtOffsetX.Location = new System.Drawing.Point(13, 32);
            this.txtOffsetX.MaxLength = 3;
            this.txtOffsetX.Name = "txtOffsetX";
            this.txtOffsetX.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetX.TabIndex = 0;
            this.txtOffsetX.Validating += new System.ComponentModel.CancelEventHandler(this.txtX_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "X (+right)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Y (+down)";
            // 
            // btnAnimate
            // 
            this.btnAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimate.Location = new System.Drawing.Point(114, 274);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(92, 23);
            this.btnAnimate.TabIndex = 16;
            this.btnAnimate.Text = "animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(9, 310);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(62, 13);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "Pen Color";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Rolling circle start angle";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(27, 326);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(126, 21);
            this.cboColor.TabIndex = 8;
            // 
            // txtStartAngle
            // 
            this.txtStartAngle.Location = new System.Drawing.Point(131, 117);
            this.txtStartAngle.MaxLength = 3;
            this.txtStartAngle.Name = "txtStartAngle";
            this.txtStartAngle.Size = new System.Drawing.Size(38, 20);
            this.txtStartAngle.TabIndex = 3;
            this.txtStartAngle.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartAngle_Validating);
            // 
            // cbShowWheels
            // 
            this.cbShowWheels.AutoSize = true;
            this.cbShowWheels.Location = new System.Drawing.Point(24, 280);
            this.cbShowWheels.Name = "cbShowWheels";
            this.cbShowWheels.Size = new System.Drawing.Size(87, 17);
            this.cbShowWheels.TabIndex = 6;
            this.cbShowWheels.Text = "show wheels";
            this.cbShowWheels.UseVisualStyleBackColor = true;
            this.cbShowWheels.CheckedChanged += new System.EventHandler(this.cbShowWheels_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(12, 469);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(126, 33);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Draw next pattern";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Points per curve";
            // 
            // txtPointsPerCurve
            // 
            this.txtPointsPerCurve.Location = new System.Drawing.Point(114, 431);
            this.txtPointsPerCurve.MaxLength = 3;
            this.txtPointsPerCurve.Name = "txtPointsPerCurve";
            this.txtPointsPerCurve.Size = new System.Drawing.Size(40, 20);
            this.txtPointsPerCurve.TabIndex = 15;
            this.txtPointsPerCurve.Validating += new System.ComponentModel.CancelEventHandler(this.txtPointsPerCurve_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pen distance from center";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPenDistance
            // 
            this.txtPenDistance.Location = new System.Drawing.Point(131, 95);
            this.txtPenDistance.MaxLength = 3;
            this.txtPenDistance.Name = "txtPenDistance";
            this.txtPenDistance.Size = new System.Drawing.Size(38, 20);
            this.txtPenDistance.TabIndex = 2;
            this.txtPenDistance.Validating += new System.ComponentModel.CancelEventHandler(this.txtPenDistance_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rolling circle radius";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRadiusB
            // 
            this.txtRadiusB.Location = new System.Drawing.Point(131, 73);
            this.txtRadiusB.MaxLength = 3;
            this.txtRadiusB.Name = "txtRadiusB";
            this.txtRadiusB.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusB.TabIndex = 1;
            this.txtRadiusB.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusB_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fixed circle radius";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRadiusA
            // 
            this.txtRadiusA.AcceptsReturn = true;
            this.txtRadiusA.AccessibleDescription = "";
            this.txtRadiusA.Location = new System.Drawing.Point(131, 51);
            this.txtRadiusA.MaxLength = 3;
            this.txtRadiusA.Name = "txtRadiusA";
            this.txtRadiusA.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusA.TabIndex = 0;
            this.txtRadiusA.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusA_Validating);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.drawingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(241, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadScriptToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // loadScriptToolStripMenuItem
            // 
            this.loadScriptToolStripMenuItem.Name = "loadScriptToolStripMenuItem";
            this.loadScriptToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadScriptToolStripMenuItem.Text = "Load Drawing Script";
            this.loadScriptToolStripMenuItem.Click += new System.EventHandler(this.loadScriptToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.editScriptToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.drawingToolStripMenuItem.Text = "Drawing";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.clearToolStripMenuItem.Text = "Clear drawing";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // editScriptToolStripMenuItem
            // 
            this.editScriptToolStripMenuItem.Name = "editScriptToolStripMenuItem";
            this.editScriptToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.editScriptToolStripMenuItem.Text = "Edit Drawing Script";
            this.editScriptToolStripMenuItem.Click += new System.EventHandler(this.editScriptToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboBackgroundColor});
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background color";
            // 
            // cboBackgroundColor
            // 
            this.cboBackgroundColor.Name = "cboBackgroundColor";
            this.cboBackgroundColor.Size = new System.Drawing.Size(121, 23);
            this.cboBackgroundColor.SelectedIndexChanged += new System.EventHandler(this.cboBackgroundColor_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(243, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(759, 648);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.CausesValidation = false;
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(249, 629);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(331, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(159, 324);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Choose";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 650);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(678, 526);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpiroGraph (version 1.5)";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private customTextBox txtRadiusA;
        private System.Windows.Forms.Label label3;
        private customTextBox txtPointsPerCurve;
        private System.Windows.Forms.Label label4;
        private customTextBox txtPenDistance;
        private System.Windows.Forms.Label label2;
        private customTextBox txtRadiusB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton rbInside;
        private System.Windows.Forms.RadioButton rbOutside;
        private System.Windows.Forms.CheckBox cbShowWheels;
        private customTextBox txtStartAngle;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private customTextBox txtOffsetY;
        private customTextBox txtOffsetX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editScriptToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cboBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboPenStyle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPenWidth;
        private customTextBox txtPenWidth;
        private customTextBox txtRadiusADelta;
        private System.Windows.Forms.Label label9;
        private customTextBox txtRadiusBDelta;
        private customTextBox txtPenDistanceDelta;
        private customTextBox txtStartAngleDelta;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
    }
}

