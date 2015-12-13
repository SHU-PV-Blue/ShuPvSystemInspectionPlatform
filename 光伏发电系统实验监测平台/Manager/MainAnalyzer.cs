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
			bool isSCM = false;
			//TODO:调用各个组件的解析,优先检测角度仪
			//TODO:如果角度仪有返回， 置isSCM为true，跳过其他解析

			while (true)
			{
				
				//删掉队首已被取走的字节
				while (status.MessageQueue.Count != 0 && !status.MessageQueue[0].Value)
					status.MessageQueue.RemoveAt(0);

				//寻找第一个被取走的字节
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

				//TODO:写入出错记录
				//_errorLog.Add("Error#" + time + "#" + lineIndex + "#" + Transfer.BaToS(errorData.ToArray()));
			}

			return isSCM;
		}
	}
}
