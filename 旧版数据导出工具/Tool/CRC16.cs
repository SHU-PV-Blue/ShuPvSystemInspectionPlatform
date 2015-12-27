/*
 * 类名: CRC16
 * 说明: ModeBus串口协议下CRC校验码的计算
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace 光伏发电系统实验监测平台.Tool
{
	public class CRC16
	{
		/*需求: CRC算法
			2.1.置16位寄存器为全1，作为CRC寄存器。
			2.2.把一个8位数据与16位CRC寄存器的低字节相异或，把结果放于CRC寄存器中。
			2.3.把寄存器的内容右移一位（朝低位），用0填补最高位，检查最低位（移出位）。
			2.4.如果最低位为0，重复2.3（再移位）；如果最低位为1，CRC寄存器与多项式A001H（1010 0000 0000 0001）进行异或。
			2.5.重复2.3、2.4，直到右移8次，这样整个8位数据全部进行了处理。
			2.6.重复2.2－2.5，进行下一个8位数据的处理。
			2.7.将一帧的所有数据字节处理完后得到CRC-16寄存器。
			2.8.将CRC-16寄存器的低字节和高字节交换，得到的值即为CRC-16码。
		 */
		public static string GetCRC16(byte[] code)
		{
			string crcString = "";
			int crcRegister = 0xffff;
			for (int i = 0; i < code.Length; i++)
			{
				crcRegister = (crcRegister & 0xff00) | code[i] ^ (crcRegister & 0xff);
				int cf = 0;
				for (int j = 0; j < 8; j++)
				{
					cf = crcRegister & 1;
					crcRegister = crcRegister >> 1;
					if (cf == 1)
						crcRegister = crcRegister ^ 0xA001;
				}
			}
			int t = crcRegister & 0xff;
			crcRegister = crcRegister >> 8;
			crcRegister = crcRegister & 0xff;
			t = t << 8;
			t = t & 0xff00;
			crcRegister = t | crcRegister;
			crcString = Convert.ToString(crcRegister, 16).ToUpper();
			return crcString;
		}
	}
}