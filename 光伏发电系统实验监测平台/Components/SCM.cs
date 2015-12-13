using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Components
{
    class SCM : Component
    {
        public override bool Analyze(Status status)
        {
            byte[] byteArray = status.MessageQueue.Select(b => b.Key).ToArray();
            string byteStr = Transfer.BaToS(byteArray);

            string ObRegex = @"680704811([A-Za-z0-9_]{5})([A-Za-z0-9_]{2})";
            Regex ObRe = new Regex(ObRegex);
            string AzRegex = @"680704830([A-Za-z0-9_]{5})([A-Za-z0-9_]{2})";
            Regex AzRe = new Regex(AzRegex);

            if (ObRe.IsMatch(byteStr))
            {
                Match match = ObRe.Match(byteStr);
                if (SumChecker.CheckSum(match.Value.Substring(2, 12), match.Groups[2].Value))
                {
                    status.Obliquity = Convert.ToInt32(match.Groups[1].Value) / 100.0;
                    int index = -1;
                    if ((index = byteStr.IndexOf(match.Value, index + 1)) != -1)
                    {
                        for (int i = index / 2; i < (index + match.Length) / 2; i++)
                            status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
                    }
                    return true;
                }
            }

            if (AzRe.IsMatch(byteStr))
            {
                Match match = AzRe.Match(byteStr);
                if (SumChecker.CheckSum(match.Value.Substring(2, 12), match.Groups[2].Value))
                {
                    status.Azimuth = Convert.ToInt32(match.Groups[1].Value) / 100.0;
                    int index = -1;
                    if ((index = byteStr.IndexOf(match.Value, index + 1)) != -1)
                    {
                        for (int i = index / 2; i < (index + match.Length) / 2; i++)
                            status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
                    }
                    return true;
                }
            }

            return false;
        }

        public override byte[] GetCommand(string commandName)
        {
            if(commandName=="查询方位角")
                return Transfer.SToBa("680404030B");
            if (commandName == "查询倾斜角")
                return Transfer.SToBa("6804040109");
            return Transfer.SToBa("");
        }
    }
}
