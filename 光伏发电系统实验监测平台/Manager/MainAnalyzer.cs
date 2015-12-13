using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using 光伏发电系统实验监测平台.Tool;
using 光伏发电系统实验监测平台.Components;
using 光伏发电系统实验监测平台.Database;
using System.Data;
using System.Data.OleDb;


namespace 光伏发电系统实验监测平台.Manager
{
	static class MainAnalyzer
	{
		static public bool Analy(Status status)
		{
			try
			{

				OleDbConnection oleDbCon = DatabaseConnection.GetConnection();
				oleDbCon.Open();

				while (true)
				{
					//删掉队首已被取走的字节
					while (status.MessageQueue.Count != 0 && !status.MessageQueue[0].Value)
						status.MessageQueue.RemoveAt(0);
					int indexOfFirstNotUse = -1;
					for (int i = 0; i < status.MessageQueue.Count; ++i)
					{
						if (!status.MessageQueue[i].Value)
						{
							indexOfFirstNotUse = i;
							break;
						}
					}

					//如果队列中没有被取走的字节，说明没有出错
					if (indexOfFirstNotUse == -1)
						break;

					//取走队列中的出错的数据
					List<byte> errorData = new List<byte>();
					for (int i = 0; i < indexOfFirstNotUse; ++i)
					{
						errorData.Add(status.MessageQueue[i].Key);
						status.MessageQueue[i] = new KeyValuePair<byte, bool>(status.MessageQueue[i].Key, false);
					}
					//_errorLog.Add("Error#" + time + "#" + lineIndex + "#" + Transfer.BaToS(errorData.ToArray()));
				}
				oleDbCon.Close();
			}
			catch (Exception ex)
			{
				//throw new Exception(_receiveFilePath + "解析失败:" + ex.Message, ex);
			}
			return true;
		}
	}
}
