using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using 光伏发电系统实验监测平台.Database;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Analyzer
{
	static class VIAnalyzer
	{
		public static bool Analy(DateTime time, List<KeyValuePair<byte, bool>> messageQueue, OleDbConnection oleDbCon, int componentId, int azimuth, int obliquity)
		{
			DatabaseCore dataCore = new DatabaseCore(oleDbCon);
			Dictionary<string, string> IVdataDic = new Dictionary<string, string>();

			byte[] byteArray = messageQueue.Select(b => b.Key).ToArray();
			string byteStr = Transfer.BaToS(byteArray);

			string Regex = @"AA0012019001([A-Za-z0-9_]{800})CC33C33CAA0012029090([A-Za-z0-9_]{800})CC33C33CAA0012091100([A-Za-z0-9_]{34})CC33C33C";
			Regex Re = new Regex(Regex);


			if (Re.IsMatch(byteStr))
			{
				Match byteMatch = Re.Match(byteStr);
				string reasultStr = byteMatch.Groups[3].Value;
				int Tep = Convert.ToInt32(Inverse(reasultStr.Substring(2, 4)), 16);
				double Vo = Convert.ToInt32(Inverse(reasultStr.Substring(10, 4)), 16) / 10.0;
				double Is = Convert.ToInt32(Inverse(reasultStr.Substring(14, 4)), 16) / 100.0;
				double Vm = Convert.ToInt32(Inverse(reasultStr.Substring(18, 4)), 16) / 10.0;
				double Im = Convert.ToInt32(Inverse(reasultStr.Substring(22, 4)), 16) / 100.0;
				double Pm = Convert.ToInt64(Inverse(reasultStr.Substring(26, 8)), 16) / 10.0;

				int index = -1;
				//不用while，方朝增本来也这么做，也死循环；每次解析一条就好了
				if ((index = byteStr.IndexOf(byteMatch.Value, index + 1)) != -1)
				{
					for (int i = index / 2; i < (index + byteMatch.Length) / 2; i++)
						messageQueue[i] = new KeyValuePair<byte, bool>(messageQueue[i].Key, false);
					index = -1;
				}

				int year = time.Year;
				int month = time.Month;
				int day = time.Day;
				int hour = time.Hour;
				int minute = time.Minute;
				int second = time.Second;
				IVdataDic.Add("Year", year.ToString());
				IVdataDic.Add("Month", month.ToString());
				IVdataDic.Add("Day", day.ToString());
				IVdataDic.Add("Hour", hour.ToString());
				IVdataDic.Add("Minute", minute.ToString());
				IVdataDic.Add("Second", second.ToString());
				IVdataDic.Add("ComponentId", componentId.ToString());
				IVdataDic.Add("Component1Temperature", Tep.ToString());
				IVdataDic.Add("OpenCircuitVoltage", Vo.ToString());
				IVdataDic.Add("ShortCircuitCurrent", Is.ToString());
				IVdataDic.Add("MaxPowerVoltage", Vm.ToString());
				IVdataDic.Add("MaxPowerCurrent", Im.ToString());
				IVdataDic.Add("MaxPower", Pm.ToString());
				IVdataDic.Add("Azimuth", azimuth.ToString());
				IVdataDic.Add("Obliquity", obliquity.ToString());
				IVdataDic.Add("CurrentSeq", "'" + byteMatch.Groups[1].Value + "'");
				IVdataDic.Add("VoltageSeq", "'" + byteMatch.Groups[2].Value + "'");

				try
				{
					dataCore.InsertData("dbo_IVTable", IVdataDic);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}


			return true;

		}
		public static string Inverse(string str)
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
