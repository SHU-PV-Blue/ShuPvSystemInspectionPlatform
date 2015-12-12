using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace 光伏发电系统实验监测平台.Tool
{
	/// <summary>
	/// 
	/// </summary>
	class Recorder
	{
		static public bool SendLog(DateTime time, string data)
		{
			if (Write("SendData", time, data))
				return true;
			return false;
		}

		static public bool ReciveLog(DateTime time, string data)
		{
			if (Write("ReciveData", time, data))
				return true;
			return false;
		}

		static private bool Write(string type, DateTime time, string data)
		{
			try
			{
				FileStream fs = new FileStream(type + "\\" + 
					string.Format("{0}-{1}-{2}", time.Year, time.Month, time.Day) + type.Substring(0,4) + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
				fs.Position = fs.Length;                  //将待写入内容追加到文件末尾
				StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//(fs, System.Text.Encoding.GetEncoding("GB2312"));
				sw.Flush();
				sw.BaseStream.Seek(fs.Position, SeekOrigin.Begin);
				sw.WriteLine(time.ToString() + "###" + data);
				//sw.Flush();
				sw.Close();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception("写入文件失败: " + ex.Message, ex);
			}
		}
#warning 未完成
	}
}
