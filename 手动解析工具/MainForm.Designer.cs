namespace 手动解析工具
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.txtInput = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAnaly = new System.Windows.Forms.Button();
			this.lblTip = new System.Windows.Forms.Label();
			this.lblTimePrev = new System.Windows.Forms.Label();
			this.lblTimeThis = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInput.Location = new System.Drawing.Point(6, 20);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(638, 233);
			this.txtInput.TabIndex = 0;
			this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtInput);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(650, 259);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "输入";
			// 
			// btnAnaly
			// 
			this.btnAnaly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnaly.Enabled = false;
			this.btnAnaly.Font = new System.Drawing.Font("微软雅黑", 20F);
			this.btnAnaly.Location = new System.Drawing.Point(270, 277);
			this.btnAnaly.Name = "btnAnaly";
			this.btnAnaly.Size = new System.Drawing.Size(126, 57);
			this.btnAnaly.TabIndex = 2;
			this.btnAnaly.Text = "解析";
			this.btnAnaly.UseVisualStyleBackColor = true;
			this.btnAnaly.Click += new System.EventHandler(this.btnAnaly_Click);
			// 
			// lblTip
			// 
			this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTip.Font = new System.Drawing.Font("微软雅黑", 20F);
			this.lblTip.Location = new System.Drawing.Point(12, 360);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(650, 35);
			this.lblTip.TabIndex = 3;
			this.lblTip.Text = "请复制数据进输入框";
			this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTimePrev
			// 
			this.lblTimePrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTimePrev.Font = new System.Drawing.Font("微软雅黑", 20F);
			this.lblTimePrev.Location = new System.Drawing.Point(6, 288);
			this.lblTimePrev.Name = "lblTimePrev";
			this.lblTimePrev.Size = new System.Drawing.Size(252, 35);
			this.lblTimePrev.TabIndex = 4;
			this.lblTimePrev.Text = "上次:##:##:##";
			this.lblTimePrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTimeThis
			// 
			this.lblTimeThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTimeThis.Font = new System.Drawing.Font("微软雅黑", 20F);
			this.lblTimeThis.Location = new System.Drawing.Point(410, 288);
			this.lblTimeThis.Name = "lblTimeThis";
			this.lblTimeThis.Size = new System.Drawing.Size(252, 35);
			this.lblTimeThis.TabIndex = 5;
			this.lblTimeThis.Text = "此次:##:##:##";
			this.lblTimeThis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 420);
			this.Controls.Add(this.lblTimeThis);
			this.Controls.Add(this.lblTimePrev);
			this.Controls.Add(this.lblTip);
			this.Controls.Add(this.btnAnaly);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(690, 459);
			this.Name = "MainForm";
			this.Text = "手动解析工具";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAnaly;
		private System.Windows.Forms.Label lblTip;
		private System.Windows.Forms.Label lblTimePrev;
		private System.Windows.Forms.Label lblTimeThis;

	}
}

