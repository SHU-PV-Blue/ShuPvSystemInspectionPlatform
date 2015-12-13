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
        private const string Relay32ReturnStr = "010F000000205413";    //32路继电器返回指令
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
            throw new NotImplementedException();
        }
    }
}
