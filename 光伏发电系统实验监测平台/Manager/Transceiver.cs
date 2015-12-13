using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Threading;
using 光伏发电系统实验监测平台.Commands;
using 光伏发电系统实验监测平台.Tool;

namespace 光伏发电系统实验监测平台.Manager
{
	class Transceiver
	{
		SerialPort _serialPort;
		Thread _sendTread;
		Command[] _commands;
		int _cycle;

		public Transceiver(SerialPort serialPort)
		{
			_serialPort = serialPort;
		}

		public void Start(Command[] commands, int cycle)
		{
			_commands = commands;
			_cycle = cycle;
		}

		public void Stop(List<Command> listCommand)
		{

		}

		private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			byte[] readbyte = new byte[_serialPort.BytesToRead];

			_serialPort.Read(readbyte, 0, readbyte.Length);
			DateTime dt = DateTime.Now;
			//在这里写解析过程
		}

		private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			byte[] readbyte = new byte[_serialPort.BytesToRead];

			_serialPort.Read(readbyte, 0, readbyte.Length);
			DateTime dt = DateTime.Now;
			//在这里写解析过程
		}

		void Work()
		{
			while (_cycle > 0)
			{
				--_cycle;
				foreach (Command c in _commands)
				{

				}
			}
		}
	}
}
