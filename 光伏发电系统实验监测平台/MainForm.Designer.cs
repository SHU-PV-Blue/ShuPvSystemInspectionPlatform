namespace 光伏发电系统实验监测平台
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.gpbSetting = new System.Windows.Forms.GroupBox();
			this.txtBaudRate = new System.Windows.Forms.TextBox();
			this.btnSetting = new System.Windows.Forms.Button();
			this.cmbParity = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbStopBit = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbDataBit = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbPorts = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtpSatrRun = new System.Windows.Forms.DateTimePicker();
			this.dtpEndRun = new System.Windows.Forms.DateTimePicker();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pctbxError = new System.Windows.Forms.PictureBox();
			this.pctbxAnalyze = new System.Windows.Forms.PictureBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lblComID = new System.Windows.Forms.Label();
			this.lblAzimuth = new System.Windows.Forms.Label();
			this.lblObliquity = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.pnlOrder = new System.Windows.Forms.Panel();
			this.label26 = new System.Windows.Forms.Label();
			this.txtSettingFilePath = new System.Windows.Forms.TextBox();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.pnlFunction = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.pctbxStatu = new System.Windows.Forms.PictureBox();
			this.pnlSearchData = new System.Windows.Forms.Panel();
			this.dtpDataSerach = new System.Windows.Forms.DateTimePicker();
			this.btnDataSearch = new System.Windows.Forms.Button();
			this.label30 = new System.Windows.Forms.Label();
			this.pctbxRunStatu = new System.Windows.Forms.PictureBox();
			this.pctbxSearchData = new System.Windows.Forms.PictureBox();
			this.pctbxSetFunction = new System.Windows.Forms.PictureBox();
			this.pctbxSetOrder = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblTimeNow = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblTip = new System.Windows.Forms.Label();
			this.gpbSetting.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxError)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxAnalyze)).BeginInit();
			this.pnlOrder.SuspendLayout();
			this.pnlFunction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxStatu)).BeginInit();
			this.pnlSearchData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxRunStatu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSearchData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSetFunction)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSetOrder)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbSetting
			// 
			this.gpbSetting.Controls.Add(this.txtBaudRate);
			this.gpbSetting.Controls.Add(this.btnSetting);
			this.gpbSetting.Controls.Add(this.cmbParity);
			this.gpbSetting.Controls.Add(this.label5);
			this.gpbSetting.Controls.Add(this.cmbStopBit);
			this.gpbSetting.Controls.Add(this.label4);
			this.gpbSetting.Controls.Add(this.cmbDataBit);
			this.gpbSetting.Controls.Add(this.label3);
			this.gpbSetting.Controls.Add(this.label2);
			this.gpbSetting.Controls.Add(this.cmbPorts);
			this.gpbSetting.Controls.Add(this.label1);
			this.gpbSetting.Location = new System.Drawing.Point(12, 12);
			this.gpbSetting.Name = "gpbSetting";
			this.gpbSetting.Size = new System.Drawing.Size(258, 213);
			this.gpbSetting.TabIndex = 0;
			this.gpbSetting.TabStop = false;
			this.gpbSetting.Text = "参数设置";
			// 
			// txtBaudRate
			// 
			this.txtBaudRate.Location = new System.Drawing.Point(127, 57);
			this.txtBaudRate.Name = "txtBaudRate";
			this.txtBaudRate.ReadOnly = true;
			this.txtBaudRate.Size = new System.Drawing.Size(82, 21);
			this.txtBaudRate.TabIndex = 13;
			// 
			// btnSetting
			// 
			this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnSetting.Location = new System.Drawing.Point(65, 165);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(119, 39);
			this.btnSetting.TabIndex = 12;
			this.btnSetting.Text = "设  置";
			this.btnSetting.UseVisualStyleBackColor = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// cmbParity
			// 
			this.cmbParity.FormattingEnabled = true;
			this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
			this.cmbParity.Location = new System.Drawing.Point(127, 136);
			this.cmbParity.Name = "cmbParity";
			this.cmbParity.Size = new System.Drawing.Size(82, 20);
			this.cmbParity.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F);
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(42, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 20);
			this.label5.TabIndex = 2;
			this.label5.Text = "校 验 位：";
			// 
			// cmbStopBit
			// 
			this.cmbStopBit.FormattingEnabled = true;
			this.cmbStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
			this.cmbStopBit.Location = new System.Drawing.Point(127, 110);
			this.cmbStopBit.Name = "cmbStopBit";
			this.cmbStopBit.Size = new System.Drawing.Size(82, 20);
			this.cmbStopBit.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F);
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(42, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "停 止 位 :  ";
			// 
			// cmbDataBit
			// 
			this.cmbDataBit.FormattingEnabled = true;
			this.cmbDataBit.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
			this.cmbDataBit.Location = new System.Drawing.Point(127, 85);
			this.cmbDataBit.Name = "cmbDataBit";
			this.cmbDataBit.Size = new System.Drawing.Size(82, 20);
			this.cmbDataBit.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F);
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(42, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "数 据 位 : ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(42, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "波 特 率 : ";
			// 
			// cmbPorts
			// 
			this.cmbPorts.FormattingEnabled = true;
			this.cmbPorts.Location = new System.Drawing.Point(127, 28);
			this.cmbPorts.Name = "cmbPorts";
			this.cmbPorts.Size = new System.Drawing.Size(82, 20);
			this.cmbPorts.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(42, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "串 口 号 : ";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(13, 303);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(257, 138);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "运行时间设置";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.dtpSatrRun);
			this.panel1.Controls.Add(this.dtpEndRun);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Location = new System.Drawing.Point(11, 18);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 112);
			this.panel1.TabIndex = 0;
			// 
			// dtpSatrRun
			// 
			this.dtpSatrRun.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtpSatrRun.Location = new System.Drawing.Point(48, 24);
			this.dtpSatrRun.Name = "dtpSatrRun";
			this.dtpSatrRun.Size = new System.Drawing.Size(167, 29);
			this.dtpSatrRun.TabIndex = 17;
			// 
			// dtpEndRun
			// 
			this.dtpEndRun.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtpEndRun.Location = new System.Drawing.Point(48, 71);
			this.dtpEndRun.Name = "dtpEndRun";
			this.dtpEndRun.Size = new System.Drawing.Size(167, 29);
			this.dtpEndRun.TabIndex = 16;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label13.ForeColor = System.Drawing.Color.White;
			this.label13.Location = new System.Drawing.Point(8, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(38, 28);
			this.label13.TabIndex = 14;
			this.label13.Text = "止:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(8, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(38, 28);
			this.label12.TabIndex = 14;
			this.label12.Text = "起:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new System.Drawing.Point(294, 303);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(414, 138);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "运行状态";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.实验平台图;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel2.Controls.Add(this.pctbxError);
			this.panel2.Controls.Add(this.pctbxAnalyze);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.label20);
			this.panel2.Controls.Add(this.label15);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.label16);
			this.panel2.Controls.Add(this.lblComID);
			this.panel2.Controls.Add(this.lblAzimuth);
			this.panel2.Controls.Add(this.lblObliquity);
			this.panel2.Location = new System.Drawing.Point(6, 18);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(402, 112);
			this.panel2.TabIndex = 3;
			// 
			// pctbxError
			// 
			this.pctbxError.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Balck;
			this.pctbxError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxError.Location = new System.Drawing.Point(352, 63);
			this.pctbxError.Name = "pctbxError";
			this.pctbxError.Size = new System.Drawing.Size(44, 33);
			this.pctbxError.TabIndex = 13;
			this.pctbxError.TabStop = false;
			// 
			// pctbxAnalyze
			// 
			this.pctbxAnalyze.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Green;
			this.pctbxAnalyze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxAnalyze.Location = new System.Drawing.Point(352, 9);
			this.pctbxAnalyze.Name = "pctbxAnalyze";
			this.pctbxAnalyze.Size = new System.Drawing.Size(44, 33);
			this.pctbxAnalyze.TabIndex = 12;
			this.pctbxAnalyze.TabStop = false;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label21.Location = new System.Drawing.Point(294, 13);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(55, 25);
			this.label21.TabIndex = 11;
			this.label21.Text = "解析:";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label20.Location = new System.Drawing.Point(294, 67);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(55, 25);
			this.label20.TabIndex = 10;
			this.label20.Text = "异常:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label15.Location = new System.Drawing.Point(7, 38);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 25);
			this.label15.TabIndex = 9;
			this.label15.Text = "方位角：";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label14.Location = new System.Drawing.Point(6, 6);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 25);
			this.label14.TabIndex = 8;
			this.label14.Text = "组件号：";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label16.Location = new System.Drawing.Point(6, 71);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(87, 25);
			this.label16.TabIndex = 7;
			this.label16.Text = "倾   角：";
			// 
			// lblComID
			// 
			this.lblComID.AutoSize = true;
			this.lblComID.BackColor = System.Drawing.Color.Transparent;
			this.lblComID.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblComID.Location = new System.Drawing.Point(95, 3);
			this.lblComID.Name = "lblComID";
			this.lblComID.Size = new System.Drawing.Size(23, 25);
			this.lblComID.TabIndex = 4;
			this.lblComID.Text = "0";
			// 
			// lblAzimuth
			// 
			this.lblAzimuth.AutoSize = true;
			this.lblAzimuth.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblAzimuth.Location = new System.Drawing.Point(95, 38);
			this.lblAzimuth.Name = "lblAzimuth";
			this.lblAzimuth.Size = new System.Drawing.Size(23, 25);
			this.lblAzimuth.TabIndex = 5;
			this.lblAzimuth.Text = "0";
			// 
			// lblObliquity
			// 
			this.lblObliquity.AutoSize = true;
			this.lblObliquity.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblObliquity.Location = new System.Drawing.Point(95, 71);
			this.lblObliquity.Name = "lblObliquity";
			this.lblObliquity.Size = new System.Drawing.Size(23, 25);
			this.lblObliquity.TabIndex = 6;
			this.lblObliquity.Text = "0";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label22.Location = new System.Drawing.Point(300, 107);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(88, 25);
			this.label22.TabIndex = 14;
			this.label22.Text = "运行状态";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.BackColor = System.Drawing.SystemColors.Highlight;
			this.label23.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label23.Location = new System.Drawing.Point(406, 109);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(88, 25);
			this.label23.TabIndex = 15;
			this.label23.Text = "指令设置";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label24.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label24.Location = new System.Drawing.Point(514, 110);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(88, 25);
			this.label24.TabIndex = 16;
			this.label24.Text = "功能设置";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label25.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label25.Location = new System.Drawing.Point(617, 109);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(88, 25);
			this.label25.TabIndex = 17;
			this.label25.Text = "数据查询";
			// 
			// pnlOrder
			// 
			this.pnlOrder.BackColor = System.Drawing.SystemColors.Highlight;
			this.pnlOrder.Controls.Add(this.label26);
			this.pnlOrder.Controls.Add(this.txtSettingFilePath);
			this.pnlOrder.Controls.Add(this.btnOpenFile);
			this.pnlOrder.Location = new System.Drawing.Point(300, 134);
			this.pnlOrder.Name = "pnlOrder";
			this.pnlOrder.Size = new System.Drawing.Size(408, 153);
			this.pnlOrder.TabIndex = 18;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label26.Location = new System.Drawing.Point(4, 113);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(48, 16);
			this.label26.TabIndex = 3;
			this.label26.Text = "路径:";
			this.label26.Visible = false;
			// 
			// txtSettingFilePath
			// 
			this.txtSettingFilePath.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.txtSettingFilePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtSettingFilePath.Location = new System.Drawing.Point(51, 108);
			this.txtSettingFilePath.Name = "txtSettingFilePath";
			this.txtSettingFilePath.Size = new System.Drawing.Size(331, 26);
			this.txtSettingFilePath.TabIndex = 2;
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOpenFile.Location = new System.Drawing.Point(137, 37);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(112, 45);
			this.btnOpenFile.TabIndex = 0;
			this.btnOpenFile.Text = "打开文件";
			this.btnOpenFile.UseVisualStyleBackColor = true;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// pnlFunction
			// 
			this.pnlFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.pnlFunction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pnlFunction.Controls.Add(this.label7);
			this.pnlFunction.Controls.Add(this.label6);
			this.pnlFunction.Controls.Add(this.btnReset);
			this.pnlFunction.Controls.Add(this.pctbxStatu);
			this.pnlFunction.Location = new System.Drawing.Point(300, 134);
			this.pnlFunction.Name = "pnlFunction";
			this.pnlFunction.Size = new System.Drawing.Size(408, 153);
			this.pnlFunction.TabIndex = 19;
			this.pnlFunction.Visible = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(291, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 25);
			this.label7.TabIndex = 22;
			this.label7.Text = "复位";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(103, 122);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 25);
			this.label6.TabIndex = 21;
			this.label6.Text = "开关";
			// 
			// btnReset
			// 
			this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
			this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnReset.FlatAppearance.BorderSize = 0;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Location = new System.Drawing.Point(266, 16);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(104, 103);
			this.btnReset.TabIndex = 2;
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// pctbxStatu
			// 
			this.pctbxStatu.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.off;
			this.pctbxStatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxStatu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pctbxStatu.Location = new System.Drawing.Point(31, 8);
			this.pctbxStatu.Name = "pctbxStatu";
			this.pctbxStatu.Size = new System.Drawing.Size(191, 113);
			this.pctbxStatu.TabIndex = 1;
			this.pctbxStatu.TabStop = false;
			this.pctbxStatu.Click += new System.EventHandler(this.pctbxStatu_Click);
			// 
			// pnlSearchData
			// 
			this.pnlSearchData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.pnlSearchData.Controls.Add(this.dtpDataSerach);
			this.pnlSearchData.Controls.Add(this.btnDataSearch);
			this.pnlSearchData.Controls.Add(this.label30);
			this.pnlSearchData.Location = new System.Drawing.Point(300, 134);
			this.pnlSearchData.Name = "pnlSearchData";
			this.pnlSearchData.Size = new System.Drawing.Size(408, 153);
			this.pnlSearchData.TabIndex = 20;
			this.pnlSearchData.Visible = false;
			// 
			// dtpDataSerach
			// 
			this.dtpDataSerach.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtpDataSerach.Location = new System.Drawing.Point(54, 58);
			this.dtpDataSerach.Name = "dtpDataSerach";
			this.dtpDataSerach.Size = new System.Drawing.Size(269, 33);
			this.dtpDataSerach.TabIndex = 18;
			// 
			// btnDataSearch
			// 
			this.btnDataSearch.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDataSearch.Location = new System.Drawing.Point(139, 102);
			this.btnDataSearch.Name = "btnDataSearch";
			this.btnDataSearch.Size = new System.Drawing.Size(116, 39);
			this.btnDataSearch.TabIndex = 22;
			this.btnDataSearch.Text = "查询";
			this.btnDataSearch.UseVisualStyleBackColor = true;
			this.btnDataSearch.Click += new System.EventHandler(this.btnDataSearch_Click);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label30.Location = new System.Drawing.Point(10, 20);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(150, 25);
			this.label30.TabIndex = 21;
			this.label30.Text = "请选择查询日期:";
			// 
			// pctbxRunStatu
			// 
			this.pctbxRunStatu.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Sun2__2_;
			this.pctbxRunStatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxRunStatu.Location = new System.Drawing.Point(294, 6);
			this.pctbxRunStatu.Name = "pctbxRunStatu";
			this.pctbxRunStatu.Size = new System.Drawing.Size(100, 98);
			this.pctbxRunStatu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pctbxRunStatu.TabIndex = 6;
			this.pctbxRunStatu.TabStop = false;
			// 
			// pctbxSearchData
			// 
			this.pctbxSearchData.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			this.pctbxSearchData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxSearchData.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pctbxSearchData.Location = new System.Drawing.Point(612, 6);
			this.pctbxSearchData.Name = "pctbxSearchData";
			this.pctbxSearchData.Size = new System.Drawing.Size(100, 98);
			this.pctbxSearchData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pctbxSearchData.TabIndex = 5;
			this.pctbxSearchData.TabStop = false;
			this.pctbxSearchData.Click += new System.EventHandler(this.pctbxSearchData_Click);
			// 
			// pctbxSetFunction
			// 
			this.pctbxSetFunction.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			this.pctbxSetFunction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxSetFunction.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pctbxSetFunction.Location = new System.Drawing.Point(506, 6);
			this.pctbxSetFunction.Name = "pctbxSetFunction";
			this.pctbxSetFunction.Size = new System.Drawing.Size(100, 98);
			this.pctbxSetFunction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pctbxSetFunction.TabIndex = 4;
			this.pctbxSetFunction.TabStop = false;
			this.pctbxSetFunction.Click += new System.EventHandler(this.pctbxSetFunction_Click);
			// 
			// pctbxSetOrder
			// 
			this.pctbxSetOrder.BackgroundImage = global::光伏发电系统实验监测平台.Properties.Resources.Neptune;
			this.pctbxSetOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pctbxSetOrder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pctbxSetOrder.Location = new System.Drawing.Point(400, 6);
			this.pctbxSetOrder.Name = "pctbxSetOrder";
			this.pctbxSetOrder.Size = new System.Drawing.Size(100, 98);
			this.pctbxSetOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pctbxSetOrder.TabIndex = 3;
			this.pctbxSetOrder.TabStop = false;
			this.pctbxSetOrder.Click += new System.EventHandler(this.pctbxSetOrder_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblTip);
			this.groupBox3.Controls.Add(this.lblTimeNow);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.ForeColor = System.Drawing.Color.Black;
			this.groupBox3.Location = new System.Drawing.Point(13, 231);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(257, 66);
			this.groupBox3.TabIndex = 21;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "信息";
			// 
			// lblTimeNow
			// 
			this.lblTimeNow.AutoSize = true;
			this.lblTimeNow.Location = new System.Drawing.Point(79, 21);
			this.lblTimeNow.Name = "lblTimeNow";
			this.lblTimeNow.Size = new System.Drawing.Size(0, 12);
			this.lblTimeNow.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 12);
			this.label8.TabIndex = 0;
			this.label8.Text = "当前时间:";
			// 
			// lblTip
			// 
			this.lblTip.AutoSize = true;
			this.lblTip.ForeColor = System.Drawing.Color.Red;
			this.lblTip.Location = new System.Drawing.Point(15, 35);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(221, 12);
			this.lblTip.TabIndex = 2;
			this.lblTip.Text = "串口未配置，程序不会自动按下自动按钮";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 454);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.pnlFunction);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.pnlOrder);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.pctbxRunStatu);
			this.Controls.Add(this.pctbxSearchData);
			this.Controls.Add(this.pctbxSetFunction);
			this.Controls.Add(this.pctbxSetOrder);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gpbSetting);
			this.Controls.Add(this.pnlSearchData);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "光伏发电系监测测平台";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.gpbSetting.ResumeLayout(false);
			this.gpbSetting.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxError)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxAnalyze)).EndInit();
			this.pnlOrder.ResumeLayout(false);
			this.pnlOrder.PerformLayout();
			this.pnlFunction.ResumeLayout(false);
			this.pnlFunction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxStatu)).EndInit();
			this.pnlSearchData.ResumeLayout(false);
			this.pnlSearchData.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctbxRunStatu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSearchData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSetFunction)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctbxSetOrder)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gpbSetting;
		private System.Windows.Forms.ComboBox cmbParity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbStopBit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbDataBit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbPorts;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pctbxSetOrder;
		private System.Windows.Forms.PictureBox pctbxSetFunction;
		private System.Windows.Forms.PictureBox pctbxSearchData;
		private System.Windows.Forms.PictureBox pctbxRunStatu;
		private System.Windows.Forms.TextBox txtBaudRate;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblComID;
		private System.Windows.Forms.Label lblAzimuth;
		private System.Windows.Forms.Label lblObliquity;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.PictureBox pctbxAnalyze;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.PictureBox pctbxError;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Panel pnlOrder;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox txtSettingFilePath;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Panel pnlFunction;
		private System.Windows.Forms.Panel pnlSearchData;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button btnDataSearch;
		private System.Windows.Forms.PictureBox pctbxStatu;
		private System.Windows.Forms.DateTimePicker dtpSatrRun;
		private System.Windows.Forms.DateTimePicker dtpEndRun;
		private System.Windows.Forms.DateTimePicker dtpDataSerach;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lblTimeNow;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblTip;

	}
}