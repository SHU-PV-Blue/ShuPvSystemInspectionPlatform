using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 容错匹配办法
{
	class Program
	{
		static String rightString = "AA000105CC33C33CAA00002102CC33C33CAA00142402CC33C33C";

		static void Main(string[] args)
		{
			/*
			while (true)
			{
				string 源;
				string 目;
				int 容错;
				Console.Write("源:");
				源 = Console.ReadLine();
				Console.Write("目:");
				目 = Console.ReadLine();
				Console.Write("容错:");
				容错 = Int32.Parse(Console.ReadLine());
				Console.WriteLine("结果:" + FaultTolerantMatch.Match(源,目,容错));
			}
			*/
			int 应该匹配到实则匹配到 = 0;
			int 应该匹配到实则未匹配到 = 0;
			int 应该未匹配到实则未匹配到 = 0;
			int 应该未匹配到实则匹配对 = 0;
			int 应该未匹配到实则匹配错 = 0;
			Random random = new Random();
			for (int i = 1; i < 1000000; ++i)
			{
				int faultCount = random.Next(15);
				int randomIndex = random.Next(10000);
				int rightIndex;
				if (faultCount > 10)
					rightIndex = -1;
				else
					rightIndex = randomIndex;
				int mathcIndex = FaultTolerantMatch.Match(
					(RandomString(randomIndex, random).Append(RandomFaultString(faultCount, random)).Append(RandomString(random.Next(10000), random))).ToString()
					,rightString
					,10);
				if(rightIndex != -1)
				{
					if (mathcIndex == rightIndex)
						++应该匹配到实则匹配到;
					else
						++应该匹配到实则未匹配到;
				}
				else
				{
					if (mathcIndex == rightIndex)
						++应该未匹配到实则未匹配到;
					else
						if(mathcIndex == randomIndex)
							++应该未匹配到实则匹配对;
						else
							++应该未匹配到实则匹配错;
				}

				if (i % 10000 == 0)
				{
					Console.WriteLine("----------------------------------------");
					Console.WriteLine("应该匹配到实则匹配到" + 应该匹配到实则匹配到);
					Console.WriteLine("应该匹配到实则未匹配到" + 应该匹配到实则未匹配到);
					Console.WriteLine("应该未匹配到实则未匹配到" + 应该未匹配到实则未匹配到);
					Console.WriteLine("应该未匹配到实则匹配对" + 应该未匹配到实则匹配对);
					Console.WriteLine("应该未匹配到实则匹配错" + 应该未匹配到实则匹配错);
				}
			}
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("应该匹配到实则匹配到" + 应该匹配到实则匹配到);
			Console.WriteLine("应该匹配到实则未匹配到" + 应该匹配到实则未匹配到);
			Console.WriteLine("应该未匹配到实则未匹配到" + 应该未匹配到实则未匹配到);
			Console.WriteLine("应该未匹配到实则匹配对" + 应该未匹配到实则匹配对);
			Console.WriteLine("应该未匹配到实则匹配错" + 应该未匹配到实则匹配错);
			
		}

		static StringBuilder RandomString(int length, Random random)
		{
			String chose = "123456789ABCDEF";
			StringBuilder result = new StringBuilder(length);
			for(int i = 0; i < length; ++i)
				result.Append(chose[random.Next(14)]);
			return result;
		}

		static StringBuilder RandomFaultString(int faultCount, Random random)
		{
			StringBuilder result = new StringBuilder(rightString);
			for (int i = 0; i < faultCount; ++i)
				result[random.Next(result.Length - 1)] = RandomString(1,random)[0];
			return result;
		}
	}
}
