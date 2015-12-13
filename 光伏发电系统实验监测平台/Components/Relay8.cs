using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Components
{
    class Relay8 : Component
    {
        private string[] componentSendStr = {    //测组件1-5的8路继电器指令
                    "020F0000000801017F40",
                    "020F0000000801023F41",
                    "020F000000080104BF43",
                    "020F000000080108BF46",
                    "020F000000080110BF4C"
                    };

        private string[] component6SendStr = { "020F000000080140BF70",   //测组件6的8路继电器指令
                                                "020F000000080120BF58" };

        private string disCon = "020F000000080100BE80";         //8路继电器全断指令

        private const string Relay8ReturnStr = "020F00000008543E";   //8路继电器返回指令

        public override bool Analyze(Status status)
        {
            byte[] bytes = status.MessageQueue.Select(b => b.Key).ToArray();

            String message = Transfer.BaToS(bytes);
            int index = -1;
            while ((index = message.IndexOf(Relay8ReturnStr, index + 1, StringComparison.Ordinal)) != -1)
            {
                for (int i = index / 2; i < (index + Relay8ReturnStr.Length) / 2; i++)
                    status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
            }

            return true;
        }

        public override byte[] GetCommand(string commandName)
        {
            string str = string.Empty;
            switch (commandName)
            {
                case "断开":
                    str = disCon;
                    break;
                case "组件1":
                    str = componentSendStr[0];
                    break;
                case "组件2":
                    str = componentSendStr[1];
                    break;
                case "组件3":
                    str = componentSendStr[2];
                    break;
                case "组件4":
                    str = componentSendStr[3];
                    break;
                case "组件5":
                    str = componentSendStr[4];
                    break;
                case "组件6":
                    str = component6SendStr[new Random().Next(2)];
                    break;
                default:
                    break;
            }
            return Transfer.SToBa(str);
        }
    }
}
