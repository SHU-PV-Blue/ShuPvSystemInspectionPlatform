using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Components
{
    class Relay32 : Component
    {
        private string[] obliquityDec = { "010F0000002004040400008479",           //组件6倾角减少
                                         "010F000000200408080000472A" };
        private string[] obliquityInc = { "010F00000020040101000094B4",           //组件6倾角增加
                                          "010F00000020040202000064F0" };

        private string[] azimuthInc = { "010F0000002004000002024429",             //组件6方位角增加
                                          "010F00000020040000010104D8" };
        private string[] azimuthDec = { "010F000000200400000404C78B",             //组件6方位角减少
                                          "010F000000200400000808C28E"};

        private string disCon = "010F000000200400000000C488";                     //32路继电器全断指令

        private const string Relay32ReturnStr = "010F000000205413";               //32路继电器返回指令
        
        Random random = new Random();
        public override bool Analyze(Status status)
        {
            byte[] bytes = status.MessageQueue.Select(b => b.Key).ToArray();
            String message = Transfer.BaToS(bytes);
            int index = -1;
            while ((index = message.IndexOf(Relay32ReturnStr, index + 1, StringComparison.Ordinal)) != -1)
            {
                for (int i = index / 2; i < (index + Relay32ReturnStr.Length) / 2; i++)
                    status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
            }
            return true;
        }

        public override byte[] GetCommand(string commandName)
        {
            String str = "";
            switch (commandName)
            {
                case "断开":
                    str = disCon;
                    break;
                case "方位角增加":
                    str = azimuthInc[random.Next(2)];
                    break;
                case "方位角减少":
                    str = azimuthDec[random.Next(2)];
                    break;
                case "倾角增加":
                    str = obliquityInc[random.Next(2)];
                    break;
                case "倾角减少":
                    str = obliquityDec[random.Next(2)];
                    break;
                default:
                    break;
            }
            return Transfer.SToBa(str);
        }
    }
}
