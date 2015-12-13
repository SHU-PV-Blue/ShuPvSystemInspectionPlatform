using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Tool
{
    class IVTransfer
    {
        public static double[] IVStransfer(string IVString)
        {
            double[] IVData = new double[200];
            for (int i = 0; i < 800; i += 4)
            {
                IVData[i / 4] = Convert.ToInt32(Inverse(IVString.Substring(i, 4)), 16) / 100.0;
            }
            return IVData;
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
