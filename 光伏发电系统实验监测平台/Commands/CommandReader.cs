using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 光伏发电系统实验监测平台.Commands
{
	static class CommandReader
	{
		public static Command[] LoadCommands(string filePath)
		{
			List<Command> listCommand = new List<Command>();
			StreamReader reader = new StreamReader(filePath);
			string line;
			while (!reader.EndOfStream)
			{
				line = reader.ReadLine();
				if (string.IsNullOrEmpty(line))
					continue;
				try
				{
					string[] splitStrs = line.Split(" \t".ToArray(), StringSplitOptions.RemoveEmptyEntries);
					if (splitStrs.Length > 2)
						throw new Exception();
					Command.Operates op = Command.ToOperate(splitStrs[0]);
					int arg = 0;
					switch(op)
					{
						case Command.Operates.关闭:
						case Command.Operates.查询曲线仪:
						case Command.Operates.查询气象仪:
							if (splitStrs.Length == 2)
								throw new Exception();
							break;
						default:
							arg = Convert.ToInt32(splitStrs[1]);
							break;
					}
					listCommand.Add(new Command(op, arg));
				}
				catch (Exception ex)
				{
					reader.Close();
					throw new Exception("指令有误:" + line, ex);
				}
			}
			reader.Close();
			if(listCommand.Count == 0)
				throw new Exception("无任何指令:" + filePath);
			return listCommand.ToArray();
		}
	}
}
