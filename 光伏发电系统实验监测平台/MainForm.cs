using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 光伏发电系统实验监测平台.Commands;
using System.IO.Ports;
using Microsoft.Office;
using System.IO;

namespace 光伏发电系统实验监测平台
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		bool SeriaOpen = false;									//串口状态，默认为关

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (SeriaOpen == false)
			{
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.on;
				SeriaOpen = true;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset_gray;
				btnReset.Enabled = false;
				pctbxRunStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Sun2;
			}

			else
			{
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.off;
				SeriaOpen = false;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset;
				btnReset.Enabled = true;
				pctbxRunStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Sun2__2_;
			}
				
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			mkdir();
			string[] ports = SerialPort.GetPortNames();
			Array.Sort(ports);
			cmbPorts.Items.AddRange(ports);
			Initcmb();
		}

		/// <summary>
		/// 检查并创建路径
		/// </summary>
		private void mkdir()
		{
			DirectoryInfo dirInfo;
			dirInfo = new DirectoryInfo("ReceiveData");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("SendData");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("ErrorLog");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("Excel");
			if (!dirInfo.Exists)
				dirInfo.Create();
		}

		/// <summary>
		/// 配置各个列表
		/// </summary>
		private void Initcmb()
		{
			try
			{
				cmbPorts.SelectedIndex = 0;
				txtBaudRate.Text = "9600";
				cmbDataBit.SelectedIndex = 0;
				cmbParity.SelectedIndex = 0;
				cmbStopBit.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				return;
			}

		}

		private void pctbxSetOrder_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = true;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = false;
		}

		private void pctbxSetFunction_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = false;
			pnlFunction.Visible = true;
			pnlSearchData.Visible = false;
		}

		private void pctbxSearchData_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus;
			pnlOrder.Visible = false;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = true;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			
		}

		private void btnDataSearch_Click(object sender, EventArgs e)
		{
			string year = dtpDataSerach.Value.Year.ToString();
			string month = dtpDataSerach.Value.Month.ToString();
			string day = dtpDataSerach.Value.Day.ToString();
			string path = string.Format(@".\Excel\{0}-{1}-{2}.xlsx",year,month,day);
			FileInfo fi = new FileInfo(path);
			if (!fi.Exists)
			{
				MessageBox.Show("文件不存在, 请重新确认日期是否正确","文件不存在",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			System.Diagnostics.Process.Start(path);
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openSettingFile = new OpenFileDialog();
			openSettingFile.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
			if (openSettingFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				System.Diagnostics.Process.Start(openSettingFile.FileName);
			txtSettingFilePath.Text = openSettingFile.FileName;
		}

	}
}
