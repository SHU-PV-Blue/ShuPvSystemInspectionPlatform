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

		private void button1_Click(object sender, EventArgs e)
		{
			Command[] cms = CommandReader.LoadCommands("code.txt");
			string str = "";
			foreach (var cm in cms)
				str += cm.Operate + " " + cm.Argument + Environment.NewLine;
			MessageBox.Show(str);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (SeriaOpen == false)
			{
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.on;
				SeriaOpen = true;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset_gray;
				btnReset.Enabled = false;
			}

			else
			{
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.off;
				SeriaOpen = false;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset;
				btnReset.Enabled = true;
			}
				
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

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

	}
}
