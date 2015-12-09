using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Tool
{
	static class Transfer
	{
		public static string  DeleteSpacce(string s)
		{
			s = s.Replace(" ", "");
			return s;
		}
		public static byte[] SToBa(string s)
		{
			s = s.Replace(" ", "");
			byte[] Sendbyte = new byte[s.Length / 2];
			for (int i = 0, j = 0; i < s.Length; i = i + 2, j++)
			{
				string mysubsing = s.Substring(i, 2);
				Sendbyte[j] = Convert.ToByte(mysubsing, 16);
			}
			
			return Sendbyte;
		}
		public static string BaToS(byte[] buffer)
		{
			int n = buffer.Length;
			StringBuilder builder = new StringBuilder();
			string s="";
			foreach (byte b in buffer)
			{
				builder.Append(b.ToString("X2") + " ");
			}
			s = builder.ToString();
			s = DeleteSpacce(s);
			return s;
		}
	}
}