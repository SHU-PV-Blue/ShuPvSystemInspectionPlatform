using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Tool
{
    class SumChecker
    {
        public static bool CheckSum(string a, string b)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i += 2 )
            {
                sum += Convert.ToInt32(a.Substring(i, 2), 16);
            }
            if (sum % 0x100 == Convert.ToInt32(b, 16))
                return true;
            return false;
        }
    }
}
