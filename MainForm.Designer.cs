using System;

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
            this.components = new System.ComponentModel.Container();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.groupBoxRolling = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStartAngle = new System.Windows.Forms.Label();
            this.lblPenDistance = new System.Windows.Forms.Label();
            this.lblRadiusB = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblDeltaHdg = new System.Windows.Forms.Label();
            this.cboPenStyle = new System.Windows.Forms.ComboBox();
            this.lblPenStyle = new System.Windows.Forms.Label();
            this.lblPenWidth = new System.Windows.Forms.Label();
            this.groupBoxInOut = new System.Windows.Forms.GroupBox();
            this.rbOutside = new System.Windows.Forms.RadioButton();
            this.rbInside = new System.Windows.Forms.RadioButton();
            this.groupBoxFixed = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblRadiusA = new System.Windows.Forms.Label();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.cbShowWheels = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblPointsPerRev = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDrawingDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtPenDistanceDelta = new SpiroGraph.customTextBox();
            this.txtPenDistance = new SpiroGraph.customTextBox();
            this.txtStartAngleDelta = new SpiroGraph.customTextBox();
            this.txtStartAngle = new SpiroGraph.customTextBox();
            this.txtRadiusBDelta = new SpiroGraph.customTextBox();
            this.txtRadiusB = new SpiroGraph.customTextBox();
            this.txtPenWidth = new SpiroGraph.customTextBox();
            this.txtOffsetX = new SpiroGraph.customTextBox();
            this.txtOffsetXdelta = new SpiroGraph.customTextBox();
            this.txtOffsetY = new SpiroGraph.customTextBox();
            this.txtOffsetYdelta = new SpiroGraph.customTextBox();
            this.txtRadiusA = new SpiroGraph.customTextBox();
            this.txtRadiusADelta = new SpiroGraph.customTextBox();
            this.txtPointsPerRev = new SpiroGraph.customTextBox();
            this.pnlControl.SuspendLayout();
            this.groupBoxRolling.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxInOut.SuspendLayout();
            this.groupBoxFixed.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.Transparent;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.groupBoxRolling);
            this.pnlControl.Controls.Add(this.btnColor);
            this.pnlControl.Controls.Add(this.btnRedo);
            this.pnlControl.Controls.Add(this.btnUndo);
            this.pnlControl.Controls.Add(this.lblDeltaHdg);
            this.pnlControl.Controls.Add(this.cboPenStyle);
            this.pnlControl.Controls.Add(this.lblPenStyle);
            this.pnlControl.Controls.Add(this.lblPenWidth);
            this.pnlControl.Controls.Add(this.txtPenWidth);
            this.pnlControl.Controls.Add(this.groupBoxInOut);
            this.pnlControl.Controls.Add(this.groupBoxFixed);
            this.pnlControl.Controls.Add(this.btnAnimate);
            this.pnlControl.Controls.Add(this.cbShowWheels);
            this.pnlControl.Controls.Add(this.btnGo);
            this.pnlControl.Controls.Add(this.lblPointsPerRev);
            this.pnlControl.Controls.Add(this.txtPointsPerRev);
            this.pnlControl.Controls.Add(this.menuStrip1);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(243, 650);
            this.pnlControl.TabIndex = 0;
            // 
            // groupBoxRolling
            // 
            this.groupBoxRolling.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxRolling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRolling.Location = new System.Drawing.Point(16, 150);
            this.groupBoxRolling.Name = "groupBoxRolling";
            this.groupBoxRolling.Size = new System.Drawing.Size(210, 103);
            this.groupBoxRolling.TabIndex = 1;
            this.groupBoxRolling.TabStop = false;
            this.groupBoxRolling.Text = "Rolling Circle";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtPenDistanceDelta, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblStartAngle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPenDistance, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPenDistance, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtStartAngleDelta, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtStartAngle, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRadiusBDelta, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRadiusB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtRadiusB, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(204, 84);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // lblStartAngle
            // 
            this.lblStartAngle.AutoSize = true;
            this.lblStartAngle.Location = new System.Drawing.Point(5, 33);
            this.lblStartAngle.Margin = new System.Windows.Forms.Padding(5);
            this.lblStartAngle.Name = "lblStartAngle";
            this.lblStartAngle.Size = new System.Drawing.Size(81, 13);
            this.lblStartAngle.TabIndex = 29;
            this.lblStartAngle.Text = "Pen Start Angle";
            this.lblStartAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPenDistance
            // 
            this.lblPenDistance.AutoSize = true;
            this.lblPenDistance.Location = new System.Drawing.Point(5, 56);
            this.lblPenDistance.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.lblPenDistance.Name = "lblPenDistance";
            this.lblPenDistance.Size = new System.Drawing.Size(92, 26);
            this.lblPenDistance.TabIndex = 5;
            this.lblPenDistance.Text = "Pen distance from center";
            this.lblPenDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRadiusB
            // 
            this.lblRadiusB.AutoSize = true;
            this.lblRadiusB.Location = new System.Drawing.Point(5, 5);
            this.lblRadiusB.Margin = new System.Windows.Forms.Padding(5);
            this.lblRadiusB.Name = "lblRadiusB";
            this.lblRadiusB.Size = new System.Drawing.Size(40, 13);
            this.lblRadiusB.TabIndex = 0;
            this.lblRadiusB.Text = "Radius";
            this.lblRadiusB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnColor
            // 
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColor.Location = new System.Drawing.Point(39, 425);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(92, 30);
            this.btnColor.TabIndex = 2;
            this.btnColor.Text = "Pen Color";
            this.toolTip1.SetToolTip(this.btnColor, "Pen Color");
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Location = new System.Drawing.Point(90, 568);
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
            this.btnUndo.Location = new System.Drawing.Point(35, 568);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(46, 23);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblDeltaHdg
            // 
            this.lblDeltaHdg.AutoSize = true;
            this.lblDeltaHdg.Location = new System.Drawing.Point(168, 31);
            this.lblDeltaHdg.Name = "lblDeltaHdg";
            this.lblDeltaHdg.Size = new System.Drawing.Size(70, 13);
            this.lblDeltaHdg.TabIndex = 17;
            this.lblDeltaHdg.Text = "Delta for next";
            this.lblDeltaHdg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblDeltaHdg, "+ or - amount to change property after next draw");
            // 
            // cboPenStyle
            // 
            this.cboPenStyle.FormattingEnabled = true;
            this.cboPenStyle.Items.AddRange(new object[] {
            "Dash",
            "Dot",
            "Solid"});
            this.cboPenStyle.Location = new System.Drawing.Point(102, 490);
            this.cboPenStyle.Name = "cboPenStyle";
            this.cboPenStyle.Size = new System.Drawing.Size(83, 21);
            this.cboPenStyle.TabIndex = 13;
            this.cboPenStyle.SelectedIndexChanged += new System.EventHandler(this.cboPenStyle_SelectedIndexChanged);
            // 
            // lblPenStyle
            // 
            this.lblPenStyle.AutoSize = true;
            this.lblPenStyle.Location = new System.Drawing.Point(41, 493);
            this.lblPenStyle.Name = "lblPenStyle";
            this.lblPenStyle.Size = new System.Drawing.Size(52, 13);
            this.lblPenStyle.TabIndex = 12;
            this.lblPenStyle.Text = "Pen Style";
            this.lblPenStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPenWidth
            // 
            this.lblPenWidth.AutoSize = true;
            this.lblPenWidth.Location = new System.Drawing.Point(41, 467);
            this.lblPenWidth.Name = "lblPenWidth";
            this.lblPenWidth.Size = new System.Drawing.Size(57, 13);
            this.lblPenWidth.TabIndex = 10;
            this.lblPenWidth.Text = "Pen Width";
            this.lblPenWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxInOut
            // 
            this.groupBoxInOut.Controls.Add(this.rbOutside);
            this.groupBoxInOut.Controls.Add(this.rbInside);
            this.groupBoxInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInOut.Location = new System.Drawing.Point(50, 268);
            this.groupBoxInOut.Name = "groupBoxInOut";
            this.groupBoxInOut.Size = new System.Drawing.Size(127, 57);
            this.groupBoxInOut.TabIndex = 0;
            this.groupBoxInOut.TabStop = false;
            this.groupBoxInOut.Text = "rolling circle location";
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
            // groupBoxFixed
            // 
            this.groupBoxFixed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFixed.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFixed.Location = new System.Drawing.Point(16, 41);
            this.groupBoxFixed.Name = "groupBoxFixed";
            this.groupBoxFixed.Size = new System.Drawing.Size(210, 103);
            this.groupBoxFixed.TabIndex = 0;
            this.groupBoxFixed.TabStop = false;
            this.groupBoxFixed.Text = "Fixed Circle";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblOffsetX, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOffsetX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOffsetXdelta, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOffsetY, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOffsetY, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOffsetYdelta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRadiusA, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRadiusA, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRadiusADelta, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 84);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.Location = new System.Drawing.Point(5, 5);
            this.lblOffsetX.Margin = new System.Windows.Forms.Padding(5);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(78, 13);
            this.lblOffsetX.TabIndex = 0;
            this.lblOffsetX.Text = "X offset (+right)";
            this.lblOffsetX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.Location = new System.Drawing.Point(5, 34);
            this.lblOffsetY.Margin = new System.Windows.Forms.Padding(5);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(84, 13);
            this.lblOffsetY.TabIndex = 1;
            this.lblOffsetY.Text = "Y offset (+down)";
            // 
            // lblRadiusA
            // 
            this.lblRadiusA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRadiusA.AutoSize = true;
            this.lblRadiusA.Location = new System.Drawing.Point(5, 63);
            this.lblRadiusA.Margin = new System.Windows.Forms.Padding(5);
            this.lblRadiusA.Name = "lblRadiusA";
            this.lblRadiusA.Size = new System.Drawing.Size(40, 13);
            this.lblRadiusA.TabIndex = 0;
            this.lblRadiusA.Text = "Radius";
            this.lblRadiusA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnimate
            // 
            this.btnAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimate.Location = new System.Drawing.Point(115, 334);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(92, 23);
            this.btnAnimate.TabIndex = 16;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // cbShowWheels
            // 
            this.cbShowWheels.AutoSize = true;
            this.cbShowWheels.Location = new System.Drawing.Point(25, 338);
            this.cbShowWheels.Name = "cbShowWheels";
            this.cbShowWheels.Size = new System.Drawing.Size(87, 17);
            this.cbShowWheels.TabIndex = 6;
            this.cbShowWheels.Text = "Show Circles";
            this.cbShowWheels.UseVisualStyleBackColor = true;
            this.cbShowWheels.CheckedChanged += new System.EventHandler(this.cbShowWheels_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(37, 363);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(126, 33);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Draw next pattern";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblPointsPerRev
            // 
            this.lblPointsPerRev.AutoSize = true;
            this.lblPointsPerRev.Location = new System.Drawing.Point(41, 532);
            this.lblPointsPerRev.Name = "lblPointsPerRev";
            this.lblPointsPerRev.Size = new System.Drawing.Size(103, 13);
            this.lblPointsPerRev.TabIndex = 14;
            this.lblPointsPerRev.Text = "Points per revolution";
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
            this.backgroundColorToolStripMenuItem,
            this.editScriptToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.setDrawingDefaultsToolStripMenuItem});
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.drawingToolStripMenuItem.Text = "Drawing";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // editScriptToolStripMenuItem
            // 
            this.editScriptToolStripMenuItem.Name = "editScriptToolStripMenuItem";
            this.editScriptToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.editScriptToolStripMenuItem.Text = "Edit Drawing Script";
            this.editScriptToolStripMenuItem.Click += new System.EventHandler(this.editScriptToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.clearToolStripMenuItem.Text = "Clear drawing";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // setDrawingDefaultsToolStripMenuItem
            // 
            this.setDrawingDefaultsToolStripMenuItem.Name = "setDrawingDefaultsToolStripMenuItem";
            this.setDrawingDefaultsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setDrawingDefaultsToolStripMenuItem.Text = "Set drawing defaults";
            this.setDrawingDefaultsToolStripMenuItem.Click += new System.EventHandler(this.setDrawingDefaultsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(244, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(759, 650);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.CausesValidation = false;
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(246, 628);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(331, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AllowFullOpen = false;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // txtPenDistanceDelta
            // 
            this.txtPenDistanceDelta.AcceptsReturn = true;
            this.txtPenDistanceDelta.AccessibleDescription = "";
            this.txtPenDistanceDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPenDistanceDelta.Location = new System.Drawing.Point(163, 59);
            this.txtPenDistanceDelta.MaxLength = 3;
            this.txtPenDistanceDelta.Name = "txtPenDistanceDelta";
            this.txtPenDistanceDelta.Size = new System.Drawing.Size(38, 20);
            this.txtPenDistanceDelta.TabIndex = 5;
            // 
            // txtPenDistance
            // 
            this.txtPenDistance.Location = new System.Drawing.Point(103, 59);
            this.txtPenDistance.MaxLength = 3;
            this.txtPenDistance.Name = "txtPenDistance";
            this.txtPenDistance.Size = new System.Drawing.Size(38, 20);
            this.txtPenDistance.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPenDistance, "how far pen point is from rolling circle center");
            this.txtPenDistance.Validating += new System.ComponentModel.CancelEventHandler(this.txtPenDistance_Validating);
            // 
            // txtStartAngleDelta
            // 
            this.txtStartAngleDelta.AcceptsReturn = true;
            this.txtStartAngleDelta.AccessibleDescription = "";
            this.txtStartAngleDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartAngleDelta.Location = new System.Drawing.Point(163, 31);
            this.txtStartAngleDelta.MaxLength = 3;
            this.txtStartAngleDelta.Name = "txtStartAngleDelta";
            this.txtStartAngleDelta.Size = new System.Drawing.Size(38, 20);
            this.txtStartAngleDelta.TabIndex = 4;
            // 
            // txtStartAngle
            // 
            this.txtStartAngle.Location = new System.Drawing.Point(103, 31);
            this.txtStartAngle.MaxLength = 3;
            this.txtStartAngle.Name = "txtStartAngle";
            this.txtStartAngle.Size = new System.Drawing.Size(38, 20);
            this.txtStartAngle.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtStartAngle, "degrees (0=east)");
            this.txtStartAngle.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartAngle_Validating);
            // 
            // txtRadiusBDelta
            // 
            this.txtRadiusBDelta.AcceptsReturn = true;
            this.txtRadiusBDelta.AccessibleDescription = "";
            this.txtRadiusBDelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRadiusBDelta.Location = new System.Drawing.Point(163, 3);
            this.txtRadiusBDelta.MaxLength = 3;
            this.txtRadiusBDelta.Name = "txtRadiusBDelta";
            this.txtRadiusBDelta.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusBDelta.TabIndex = 3;
            // 
            // txtRadiusB
            // 
            this.txtRadiusB.Location = new System.Drawing.Point(103, 3);
            this.txtRadiusB.MaxLength = 3;
            this.txtRadiusB.Name = "txtRadiusB";
            this.txtRadiusB.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusB.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtRadiusB, "rolling circle radius");
            this.txtRadiusB.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusB_Validating);
            // 
            // txtPenWidth
            // 
            this.txtPenWidth.Location = new System.Drawing.Point(103, 464);
            this.txtPenWidth.MaxLength = 3;
            this.txtPenWidth.Name = "txtPenWidth";
            this.txtPenWidth.Size = new System.Drawing.Size(38, 20);
            this.txtPenWidth.TabIndex = 11;
            this.txtPenWidth.Validating += new System.ComponentModel.CancelEventHandler(this.txtPenWidth_Validating);
            // 
            // txtOffsetX
            // 
            this.txtOffsetX.Location = new System.Drawing.Point(103, 3);
            this.txtOffsetX.MaxLength = 3;
            this.txtOffsetX.Name = "txtOffsetX";
            this.txtOffsetX.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtOffsetX, "shift circle center right or left");
            this.txtOffsetX.Validating += new System.ComponentModel.CancelEventHandler(this.txtX_Validating);
            // 
            // txtOffsetXdelta
            // 
            this.txtOffsetXdelta.AcceptsReturn = true;
            this.txtOffsetXdelta.AccessibleDescription = "";
            this.txtOffsetXdelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffsetXdelta.Location = new System.Drawing.Point(163, 3);
            this.txtOffsetXdelta.MaxLength = 3;
            this.txtOffsetXdelta.Name = "txtOffsetXdelta";
            this.txtOffsetXdelta.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetXdelta.TabIndex = 3;
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Location = new System.Drawing.Point(103, 30);
            this.txtOffsetY.MaxLength = 3;
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtOffsetY, "shift circle center up or down");
            this.txtOffsetY.Validating += new System.ComponentModel.CancelEventHandler(this.txtY_Validating);
            // 
            // txtOffsetYdelta
            // 
            this.txtOffsetYdelta.AcceptsReturn = true;
            this.txtOffsetYdelta.AccessibleDescription = "";
            this.txtOffsetYdelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffsetYdelta.Location = new System.Drawing.Point(163, 30);
            this.txtOffsetYdelta.MaxLength = 3;
            this.txtOffsetYdelta.Name = "txtOffsetYdelta";
            this.txtOffsetYdelta.Size = new System.Drawing.Size(38, 20);
            this.txtOffsetYdelta.TabIndex = 4;
            // 
            // txtRadiusA
            // 
            this.txtRadiusA.AcceptsReturn = true;
            this.txtRadiusA.AccessibleDescription = "";
            this.txtRadiusA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRadiusA.Location = new System.Drawing.Point(103, 59);
            this.txtRadiusA.MaxLength = 3;
            this.txtRadiusA.Name = "txtRadiusA";
            this.txtRadiusA.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusA.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtRadiusA, "fixed circle radius");
            this.txtRadiusA.Validating += new System.ComponentModel.CancelEventHandler(this.txtRadiusA_Validating);
            // 
            // txtRadiusADelta
            // 
            this.txtRadiusADelta.AcceptsReturn = true;
            this.txtRadiusADelta.AccessibleDescription = "";
            this.txtRadiusADelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRadiusADelta.Location = new System.Drawing.Point(163, 58);
            this.txtRadiusADelta.MaxLength = 3;
            this.txtRadiusADelta.Name = "txtRadiusADelta";
            this.txtRadiusADelta.Size = new System.Drawing.Size(38, 20);
            this.txtRadiusADelta.TabIndex = 5;
            // 
            // txtPointsPerRev
            // 
            this.txtPointsPerRev.Location = new System.Drawing.Point(147, 529);
            this.txtPointsPerRev.MaxLength = 3;
            this.txtPointsPerRev.Name = "txtPointsPerRev";
            this.txtPointsPerRev.Size = new System.Drawing.Size(38, 20);
            this.txtPointsPerRev.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtPointsPerRev, "Number of pen points painted each time rolling circle makes one revolution around" +
        " the fixed circle");
            this.txtPointsPerRev.Validating += new System.ComponentModel.CancelEventHandler(this.txtPointsPerCurve_Validating);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1002, 650);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(678, 526);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpiroGraph (version 2.0)";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.groupBoxRolling.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxInOut.ResumeLayout(false);
            this.groupBoxInOut.PerformLayout();
            this.groupBoxFixed.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private customTextBox txtRadiusA;
        private System.Windows.Forms.Label lblPointsPerRev;
        private customTextBox txtPointsPerRev;
        private System.Windows.Forms.Label lblPenDistance;
        private customTextBox txtPenDistance;
        private System.Windows.Forms.Label lblRadiusB;
        private customTextBox txtRadiusB;
        private System.Windows.Forms.Label lblRadiusA;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton rbInside;
        private System.Windows.Forms.RadioButton rbOutside;
        private System.Windows.Forms.CheckBox cbShowWheels;
        private customTextBox txtStartAngle;
        private System.Windows.Forms.Label lblStartAngle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private customTextBox txtOffsetY;
        private customTextBox txtOffsetX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editScriptToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxInOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboPenStyle;
        private System.Windows.Forms.Label lblPenStyle;
        private System.Windows.Forms.Label lblPenWidth;
        private customTextBox txtPenWidth;
        private customTextBox txtRadiusADelta;
        private System.Windows.Forms.Label lblDeltaHdg;
        private customTextBox txtRadiusBDelta;
        private customTextBox txtPenDistanceDelta;
        private customTextBox txtStartAngleDelta;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private customTextBox txtOffsetYdelta;
        private customTextBox txtOffsetXdelta;
        private System.Windows.Forms.ToolStripMenuItem setDrawingDefaultsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxFixed;
        private System.Windows.Forms.GroupBox groupBoxRolling;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

