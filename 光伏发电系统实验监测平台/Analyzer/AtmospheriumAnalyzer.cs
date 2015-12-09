using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using 光伏发电系统实验监测平台.Tool;
using 光伏发电系统实验监测平台.Database;

namespace 光伏发电系统实验监测平台.Analyzer
{
	static class AtmospheriumAnalyzer
	{
		private static int byteLength = 38;							//如果匹配,则有效字段为28字节, 定长
		private static int stringLenth = 76;						//每个字节可以转化为两个字符
		public static bool Analy(DateTime time, List<KeyValuePair<byte, bool>> messgeQueue, OleDbConnection oleDbCon)
		{
			string messageString = TransferToString(messgeQueue);	//转化为字符串
			//Console.WriteLine(messageString);						//显示, 测试用
			int index = 0;											//从第几个字符开始匹配, 相应的, 第几个字节应为:index/2
			if (messgeQueue.Count < byteLength)
				return false;
			//如果检验到匹配, 将匹配的字节数组(Key)对应的Value置为false, 并返回true;
			if (CheckWeather(messageString, out index,time,oleDbCon))
			{
				index /= 2;
				for (int i = 0; i < byteLength; i++)
					messgeQueue[i + index] = new KeyValuePair<byte, bool>(messgeQueue[i + index].Key, false);
				return true;
			}
			//否则, 返回false;
			return false;
		}

		public static bool CheckWeather(string message, out int index, DateTime time, OleDbConnection oleDbCon)
		{
			index = 0;
			bool flag = false;
			if (message.Contains("03030020"))										//固定报头: 地址&长度
			{
				index = message.IndexOf("03030020");
				if (message.Length - index < stringLenth)
					return false;
				string dataString = message.Substring(index, (stringLenth - 4));			//数据字串
				byte[] DataByte = SToBa(dataString);									//数据字串对应的数组
				index += (stringLenth - 4);
				string checkSubString = message.Substring(index, 4);					//校验字串
				//byte[] CheckByte = SToBa(checkSubString);								//校验字串数组
				if (CRC16.GetCRC16(DataByte) == checkSubString)
				{
					message.Replace("03030020", "********");							//将地址码换成等长的*,防止干扰下一次验证
					GetDataString(dataString);
					WriteIntoDatabase(DataByte, time, oleDbCon);
					index -= (stringLenth - 4);
					flag = true;
				}
				else
					return false;
			}
			if (flag)
				return true;
			return false;
		}

		//保存有效数数据字符串
		private static string Datastring="";
		private static void GetDataString(string str)
		{
			Datastring += str;
		}

		/// <summary>
		/// 将数据写入数据库
		/// </summary>
		/// <param name="dataString"></param>
		private static void WriteIntoDatabase(byte[] dataByte, DateTime dateTime, OleDbConnection oleDbCon)
		{
			DatabaseCore dataCore = new DatabaseCore(oleDbCon);
			//数据库列名
			string[] colName = { "ID", "Year", "Month", "Day", "Hour", "Minute", "Second",
								   "WindSpeed(m/s)", "AirTemperayure", "Rasiation(W/m2)",
								   "WindDirection", "Humidity(%RH)",  
								   "Component2Temperature", "Component3Temperature",
								   "Component4Temperature", "Component5Temperature","Component6Temperature",
							   };
			//string colString = "Year, Month, Day, Hour, Minute, Second, WindSpeed(m/s), AirTemperayure, Rasiation(W/m2), WindDirection, Humidity(%RH), Component1Temperature, Component2Temperature, Component3Temperature,Component4Temperature, Component5Temperature, Component6Temperature";
			//string valueString = "";//要插入的语句
			Dictionary<string, string> QXdataDic = new Dictionary<string, string>();
			
			//添加日期数据
			int year = dateTime.Year;
			int month = dateTime.Month;
			int day = dateTime.Day;
			int hour = dateTime.Hour;
			int minute = dateTime.Minute;
			int second = dateTime.Second;
			int[] time = { year, month, day, hour, minute, second };
			for (int i = 0; i < time.Length; i++)
			{
				QXdataDic.Add(colName[i+1], time[i].ToString());						//第一列不添加
			}

			//添加气象仪数据
			int[] index = { 1, 3, 6, 7, 9, 11, 12, 13, 14, 15 };						//有效通道
			double[] precision = { 0.1, 0.1, 1.0, 1.0, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, };	//每个有效通道数值的精度
			for (int i = 0; i < index.Length; i++)
			{
				int k = (index[i] + 1) * 2;							//前面两个字内容无效, 所以+2 , 但由于dataByte的下标从零开始, 所以要-1 即: (index[i]-1+2),  每个数据占两个字节, 所以*2
				int value = (dataByte[k] << 8) + dataByte[k + 1];	//高位左移8位地位  =  实际值
				if (value >> 15 == 1)								//如果最高位为1, 则取补,  否则不改变
				{
					value = -(0x10000 - value);
				}
				double dvalue = value * precision[i];				//取精度
				QXdataDic.Add(colName[i + 7], dvalue.ToString());
				
			}
			try
			{
				dataCore.InsertData("MeteorologicalData", QXdataDic);	//插入数据
			}
			catch (Exception ex)
			{
				throw ex;
			}
			

		}

		/// <summary>
		/// 废弃代码, 我选择保留   ...  Orz
		/// </summary>
		private static void no()
		{
			//数据库列名
			//string[] colName = { "ID", "Year", "Month", "Day", "Hour", "Minute", "Second",
			//					   "WindSpeed(m/s)", "AirTemperayure", "Rasiation(W/m2)",
			//					   "WindDirection", "Humidity(%RH)", "Component1Temperature", 
			//					   "Component2Temperature", "Component3Temperature",
			//					   "Component4Temperature", "Component5Temperature", "Component6Temperature"
			//				   };
			//string colString = "Year, Month, Day, Hour, Minute, Second, WindSpeed(m/s), AirTemperayure, Rasiation(W/m2), WindDirection, Humidity(%RH), Component1Temperature, Component2Temperature, Component3Temperature,Component4Temperature, Component5Temperature, Component6Temperature";
			//string valueString = "";//要插入的语句

			//添加日期数据
			//int year = dateTime.Year;
			//int month = dateTime.Month;
			//int day = dateTime.Day;
			//int hour = dateTime.Hour;
			//int minute = dateTime.Minute;
			//int second = dateTime.Second;
			//int[] time = { year, month, day, hour, minute, second };
			//for (int i = 0; i < time.Length; i++)
			//{
			//	valueString += time[i].ToString() + ",";
			//}

			//Console.WriteLine(colString);
			//Console.WriteLine(valueString);

			//添加气象仪数据
			//1,3,6,7,9,12,13,14,15,16 通道的数据有效
			//int[] index = { 1, 3, 6, 7, 9, 11, 12, 13, 14, 15 };
			//double[] precision = { 0.1, 0.1, 1.0, 1.0, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, };
			//for (int i = 0; i < index.Length; i++)
			//{
			//	int k = (index[i] + 1) * 2;					//前面两个字内容无效, 所以+2 , 但由于dataByte的下标从零开始, 所以要-1 即: (index[i]-1+2),  每个数据占两个字节, 所以*2
			//	int value = (dataByte[k] << 8) + dataByte[k + 1];	//高位左移8位地位  =  实际值
			//	if (value >> 15 == 1)						//如果最高位为1, 则取补,  否则不改变
			//	{
			//		value = -(0x10000 - value);
			//	}
			//	double dvalue = value * precision[i];
			//	valueString += dvalue.ToString();
			//	if (i != index.Length - 1)
			//	{
			//		valueString += ",";
			//	}
			//}

			//Console.WriteLine(colString);
			//foreach (byte i in dataByte)
			//	Console.Write(i + " ");
			//Console.WriteLine();
			//Console.WriteLine(valueString);
			//string insertString = "insert into MeteorologicalData (" + colString + ") values (" + valueString + ")";
			//Console.WriteLine(insertString);
			//Console.ReadLine();
			//OleDbCommand cmd = new OleDbCommand(insertString, oleDbCon);
			//cmd.ExecuteNonQuery();
		}
		

		/// <summary>
		/// 将列表转为字符串用于分析
		/// </summary>
		/// <param name="messgeQueue"></param>
		/// <returns>返回的字符串, 对应十六进制</returns>
		public static string TransferToString(List<KeyValuePair<byte, bool>> messgeQueue)
		{
			string messageString = "";
			byte[] messageByte = new byte[2000];
			int j = 0;
			for (int i = 0; i < messgeQueue.Count; i++)
			{
				if (messgeQueue[i].Value == true)
					messageByte[j++] = messgeQueue[i].Key;
			}
			messageString = BaToS(messageByte, j);
			return messageString;
		}

		/// <summary>
		/// 将一个字节数组转为字符串
		/// </summary>
		/// <param name="buffer">需要转化的字节数组</param>
		/// <returns>相对应的字符串</returns>
		public static string BaToS(byte[] buffer, int n)
		{
			StringBuilder builder = new StringBuilder();
			string s = "";
			for (int i = 0; i < n; i++)
			{
				builder.Append(buffer[i].ToString("X2"));
			}
			s = builder.ToString();
			s.Trim();
			return s;
		}

		/// <summary>
		/// 将字符串转为字节数组
		/// </summary>
		/// <param name="s"></param>
		/// <returns>返回字节数组</returns>
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
	}
}