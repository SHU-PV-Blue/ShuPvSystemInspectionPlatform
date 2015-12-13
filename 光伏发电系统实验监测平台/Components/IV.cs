using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using 光伏发电系统实验监测平台.Database;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Components
{
    class IV : Component
    {
        public override bool Analyze(Status status)
        {
            DatabaseCore dataCore = new DatabaseCore(status.OleDbCon);
            Dictionary<string, string> IVdataDic = new Dictionary<string, string>();

            byte[] byteArray = status.MessageQueue.Select(b => b.Key).ToArray();
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
                if ((index = byteStr.IndexOf(byteMatch.Value, index + 1)) != -1)
                {
                    for (int i = index / 2; i < (index + byteMatch.Length) / 2; i++)
                        status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
                }

                int year = status.Time.Year;
                int month = status.Time.Month;
                int day = status.Time.Day;
                int hour = status.Time.Hour;
                int minute = status.Time.Minute;
                int second = status.Time.Second;
                IVdataDic.Add("Year", year.ToString());
                IVdataDic.Add("Month", month.ToString());
                IVdataDic.Add("Day", day.ToString());
                IVdataDic.Add("Hour", hour.ToString());
                IVdataDic.Add("Minute", minute.ToString());
                IVdataDic.Add("Second", second.ToString());
                IVdataDic.Add("ComponentId", status.ComponentId.ToString());
                IVdataDic.Add("Component1Temperature", Tep.ToString());
                IVdataDic.Add("OpenCircuitVoltage", Vo.ToString());
                IVdataDic.Add("ShortCircuitCurrent", Is.ToString());
                IVdataDic.Add("MaxPowerVoltage", Vm.ToString());
                IVdataDic.Add("MaxPowerCurrent", Im.ToString());
                IVdataDic.Add("MaxPower", Pm.ToString());
                IVdataDic.Add("Azimuth", status.Azimuth.ToString());
                IVdataDic.Add("Obliquity", status.Obliquity.ToString());
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

        public override byte[] GetCommand(string commandName)
        {
            return Transfer.SToBa("AA000105CC33C33C");
        }
    }
}
