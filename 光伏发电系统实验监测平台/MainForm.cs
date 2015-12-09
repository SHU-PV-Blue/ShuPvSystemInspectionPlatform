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

namespace 光伏发电系统实验监测平台
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Command[] cms = CommandReader.LoadCommands("code.txt");
			string str = "";
			foreach (var cm in cms)
				str += cm.Operate + " " + cm.Argument + Environment.NewLine;
			MessageBox.Show(str);
		}
	}
}
