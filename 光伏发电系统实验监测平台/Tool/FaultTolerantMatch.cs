using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Tool
{
	class FaultTolerantMatch
	{
		/// <summary>
		/// 容错匹配
		/// </summary>
		/// <param name="sourceString">源字符串</param>
		/// <param name="targetString">目标字符串</param>
		/// <param name="faultTolerance">容错度</param>
		/// <returns></returns>
		static public int Match(string sourceString, string targetString, int faultTolerance)
		{
			if (sourceString.Length < targetString.Length || faultTolerance < 0)
				return -1;
			if (targetString.Length <= faultTolerance || targetString.Length == 0)
				return 0;
			int index = 0;
			while (sourceString.Length - index >= targetString.Length)
			{
				int faultCount = 0;
				bool marched = true;
				for (int i = 0; i < targetString.Length; ++i)
				{
					if (sourceString[index + i] != targetString[i])
					{
						++faultCount;
						if (faultCount > faultTolerance)
						{
							marched = false;
							break;
						}
					}
				}
				if (marched)
					return index;
				++index;
			}
			return -1;
		}
	}
}
