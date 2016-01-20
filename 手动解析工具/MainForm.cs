using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace 手动解析工具
{
	public partial class MainForm : Form
	{

		Workbook workBook;
		int raw;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
			workBook = excel.Workbooks.Add();
			excel.Visible = true;
			excel.DisplayAlerts = false;
			excel.AlertBeforeOverwriting = false;
			raw = 1;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			lblTip.Text = "正在关闭Excel...";
			string path = System.Environment.CurrentDirectory;
			workBook.SaveAs(path + "\\导出结果.xlsx");
			workBook.Close();
		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{
			btnAnaly.Enabled = false;
			if (txtInput.Text.Length == 0)
			{
				lblTip.Text = "请复制数据进输入框";
				lblTimeThis.Text = "此次:##:##:##";
				return;
			}

			StringBuilder reason;
			if (AnalyByHand.Check(txtInput.Text, out reason))
			{
				lblTip.Text = "数据格式正确";
				btnAnaly.Enabled = true;
				lblTimeThis.Text = "此次:" + txtInput.Text.Substring(0, txtInput.Text.IndexOf("###")); ;
				return;
			}
			else
			{
				lblTip.Text = reason.ToString();
				lblTimeThis.Text = "此次:##:##:##";
				return;
			}
			
		}

		private void btnAnaly_Click(object sender, EventArgs e)
		{
			AnalyByHand.Analy(txtInput.Text, workBook, raw);
			raw += 2;
			lblTimePrev.Text = "上次:" + txtInput.Text.Substring(0, txtInput.Text.IndexOf("###"));
			txtInput.Clear();
		}

	}
}
