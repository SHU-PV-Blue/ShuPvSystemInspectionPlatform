using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using 光伏发电系统实验监测平台.Tool;

namespace 手动解析工具
{
	class AnalyByHand
	{
		public static bool Check(string inputString, out StringBuilder reason)
		{
			String time;
			String data;
			try
			{
				time = inputString.Substring(0, inputString.IndexOf("###"));
				String[] timeSplit = time.Split(':');
				Int32.Parse(timeSplit[0]);
				Int32.Parse(timeSplit[1]);
				Int32.Parse(timeSplit[2]);
			}
			catch(Exception)
			{
				reason = new StringBuilder("没有时间戳");
				return false;
			}

			data = inputString.Substring(inputString.IndexOf("###") + "###".Length);

			foreach (char ch in data)
			{
				if(!(ch >= '0' && ch <= '9' || ch >= 'A' && ch <= 'Z'))
				{
					reason = new StringBuilder("含有非法字符:" + ch);
					return false;
				}
			}

			if (data.Length != 1808)
			{
				reason = new StringBuilder("数据长度不正确,现为" + data.Length + ",应为1808");
				return false;
			}

			reason = new StringBuilder();
			return true;
		}

		public static void Analy(string inputString, Workbook workBook, int raw)
		{
			string time = inputString.Substring(0, inputString.IndexOf("###"));
			string data = inputString.Substring(inputString.IndexOf("###") + "###".Length);
			string 特征数据 = data.Substring(52 + 12 + 800 + 20 + 800 + 20, 34);
			string 电流数据 = data.Substring(52 + 12, 800);
			string 电压数据 = data.Substring(52 + 12 + 800 + 20, 800);

			Worksheet sheet = workBook.Sheets[1];
			int col = 1;

			sheet.Cells[raw, col++] = time;

			int Tep = Convert.ToInt32(Inverse(特征数据.Substring(2, 4)), 16);
			double Vo = Convert.ToInt32(Inverse(特征数据.Substring(10, 4)), 16) / 10.0;
			double Is = Convert.ToInt32(Inverse(特征数据.Substring(14, 4)), 16) / 100.0;
			double Vm = Convert.ToInt32(Inverse(特征数据.Substring(18, 4)), 16) / 10.0;
			double Im = Convert.ToInt32(Inverse(特征数据.Substring(22, 4)), 16) / 100.0;
			double Pm = Convert.ToInt64(Inverse(特征数据.Substring(26, 8)), 16) / 10.0;

			sheet.Cells[raw, col++] = Vo;//开路电压
			sheet.Cells[raw, col++] = Is;//短路电流
			sheet.Cells[raw, col++] = Vm;//最大功率点电压
			sheet.Cells[raw, col++] = Im;//最大功率点电流
			sheet.Cells[raw, col++] = Pm;//最大功率
			sheet.Cells[raw, col++] = Tep;//组件1温度
		
			foreach (double currentSeq in IVTransfer.TransferCurrent(电流数据))
			{
				sheet.Cells[raw, col++] = currentSeq;
			}

			++raw;
			col = 8;

			foreach (double voltageSeq in IVTransfer.TransferVoltage(电压数据))
			{
				sheet.Cells[raw, col++] = voltageSeq;
			}

		}

		static string Inverse(string str)
		{
			int length = str.Length;
			string newStr = "";
			for (int i = 0; i < length; i += 2)
			{
				newStr = str.Substring(i, 2) + newStr;
			}
			return newStr;
		}
	}
}
