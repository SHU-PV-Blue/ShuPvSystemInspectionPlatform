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
			}

			else
			{
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.off;
				SeriaOpen = false;
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
		}

	}
}
