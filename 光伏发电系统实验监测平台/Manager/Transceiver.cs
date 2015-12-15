using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Threading;

using System.Data;
using System.Data.OleDb;
using 光伏发电系统实验监测平台.Commands;
using 光伏发电系统实验监测平台.Tool;
using 光伏发电系统实验监测平台.Components;
using 光伏发电系统实验监测平台.Database;

namespace 光伏发电系统实验监测平台.Manager
{
	/// <summary>
	/// 收发器事件
	/// </summary>
	public delegate void TransceiverEventHandler(Status status);


	class Transceiver
	{
		SerialPort _serialPort;
		Thread _sendTread;
		Command[] _commands;
		int _cycle;
		Status status;

		const int initComponentId = 6;
		const double initAzimuth = -10;
		const double initObliquity = 22;

		/// <summary>
		/// 命令执行完事件
		/// </summary>
		public event TransceiverEventHandler Ends;

		/// <summary>
		/// 状态改变事件
		/// </summary>
		public event TransceiverEventHandler Changed;

		/// <summary>
		/// 解析事件
		/// </summary>
		public event TransceiverEventHandler Analyzed;

		/// <summary>
		/// 异常事件
		/// </summary>
		public event TransceiverEventHandler Excepted;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="serialPort">串口</param>
		public Transceiver(SerialPort serialPort)
		{
			_serialPort = serialPort;
			_serialPort.DataReceived += DataReceivedHandler;
		}

		/// <summary>
		/// 开始执行指令
		/// </summary>
		/// <param name="commands">伪指令数组</param>
		/// <param name="cycle">执行周期</param>
		public void Start(Command[] commands, int cycle)
		{
			_commands = commands;
			_cycle = cycle;

			status = new Status();
			status.Time = DateTime.Now;
			status.MessageQueue = new List<KeyValuePair<byte, bool>>();
			status.ComponentId = initComponentId;
			status.Azimuth = initAzimuth;
			status.Obliquity = initObliquity;
			OleDbConnection oleDbCon;
			try
			{
				oleDbCon = DatabaseConnection.GetConnection();
				oleDbCon.Open();
			}
			catch (Exception ex)
			{
				throw new Exception("数据库连接失败:" + ex.Message, ex);
			}

			if (_sendTread != null && _sendTread.IsAlive)
				_sendTread.Abort();
			_sendTread = new Thread(new ThreadStart(Work));
			_sendTread.Start();
		}

		/// <summary>
		/// 强行停止
		/// </summary>
		public void Stop()
		{
			if (_sendTread != null && _sendTread.IsAlive)
				_sendTread.Abort();
			if (_serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();
			int sendCount = 3;
			while(sendCount-- > 0)
			{
				_serialPort.BaudRate = 9600;
				_serialPort.Open();
				byte[] bytes = (new Relay32()).GetCommand("停转");
				WritePort(bytes);
				_serialPort.Close();
			}

		}

		/// <summary>
		/// 复位
		/// </summary>
		public void Reset()
		{
			Command[] commands = new Command[4];
			commands[0] = new Command(Command.Operates.打开, 9600);
			commands[1] = new Command(Command.Operates.旋转方位角, (int)initAzimuth);
			commands[2] = new Command(Command.Operates.旋转倾角, (int)initObliquity);
			commands[3] = new Command(Command.Operates.关闭, 0);
			Start(commands, 1);
		}

		private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			byte[] readbyte = new byte[_serialPort.BytesToRead];

			_serialPort.Read(readbyte, 0, readbyte.Length);
			status.Time = DateTime.Now;
			foreach(var b in readbyte)
				status.MessageQueue.Add(new KeyValuePair<byte, bool>(b, true));
			Recorder.ReciveLog(status.Time, Transfer.BaToS(readbyte));
			if (MainAnalyzer.Analyze(status, Excepted))
				Changed(status);
			Analyzed(status);
		}

		void Work()
		{
			while (_cycle > 0)
			{
				foreach (Command command in _commands)
					switch(command.Operate)
					{
						case Command.Operates.关闭:
							{
								_serialPort.Close();
								break;
							}
						case Command.Operates.打开:
							{
								_serialPort.BaudRate = command.Argument;
								_serialPort.Open();
								break;
							}
						case Command.Operates.旋转倾角:
							{
								byte[] bytes = (new SCM()).GetCommand("查询倾斜角");
								WritePort(bytes);
								Thread.Sleep(100);


								if(status.Obliquity < command.Argument)
								{
									bytes = (new Relay32()).GetCommand("倾角增加");
									WritePort(bytes);
								}
								else
								{
									bytes = (new Relay32()).GetCommand("倾角减少");
									WritePort(bytes);
								}

								Stopwatch sw = new Stopwatch();
								sw.Start();
								while (true)
								{
									bytes = (new SCM()).GetCommand("查询倾斜角");
									WritePort(bytes);
									Thread.Sleep(100);
									if (Math.Abs(status.Obliquity - command.Argument) < 0.5)
										break;
									if(sw.ElapsedMilliseconds > 20 * 1000)
									{
										bytes = (new Relay32()).GetCommand("停转");
										WritePort(bytes);
										Thread.Sleep(100);
										throw new Exception("电机运作异常,调整倾斜角失败");
									}
								}
								bytes = (new SCM()).GetCommand("查询倾斜角");
								WritePort(bytes);
								Thread.Sleep(100);
								break;
							}
						case Command.Operates.旋转方位角:
							{
								byte[] bytes = (new SCM()).GetCommand("查询方位角");
								WritePort(bytes);
								Thread.Sleep(100);


								if (status.Azimuth < command.Argument)
								{
									bytes = (new Relay32()).GetCommand("方位角增加");
									WritePort(bytes);
								}
								else
								{
									bytes = (new Relay32()).GetCommand("方位角减少");
									WritePort(bytes);
								}

								Stopwatch sw = new Stopwatch();
								sw.Start();
								while (true)
								{
									bytes = (new SCM()).GetCommand("查询方位角");
									WritePort(bytes);
									Thread.Sleep(100);
									if (Math.Abs(status.Azimuth - command.Argument) < 0.5)
										break;
									if (sw.ElapsedMilliseconds > 20 * 1000)
									{
										bytes = (new Relay32()).GetCommand("停转");
										WritePort(bytes);
										Thread.Sleep(100);
										throw new Exception("电机运作异常,调整方位角失败");
									}
								}
								bytes = (new SCM()).GetCommand("查询方位角");
								WritePort(bytes);
								Thread.Sleep(100);
								break;
							}
						case Command.Operates.查询曲线仪:
							{
								byte[] bytes = (new IV()).GetCommand("查询");
								WritePort(bytes);
								break;
							}
						case Command.Operates.查询气象仪:
							{
								byte[] bytes = (new Atmospherium()).GetCommand("查询");
								WritePort(bytes);
								break;
							}
						case Command.Operates.等待:
							{
								Thread.Sleep(command.Argument);
								break;
							}
						case Command.Operates.选择组件:
							{
								byte[] bytes = (new Relay8()).GetCommand("组件" + command.Argument);
								WritePort(bytes);
								status.ComponentId = command.Argument;
								Changed(status);
								break;
							}
						case Command.Operates.断开组件:
							{
								byte[] bytes = (new Relay8()).GetCommand("断开");
								WritePort(bytes);
								break;
							}
						default:
							{
								throw new Exception("不支持的指令");
							}
					}
				--_cycle;
			}
			if (status.OleDbCon != null && status.OleDbCon.State == ConnectionState.Open)
				status.OleDbCon.Close();
			if (_serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();
			Ends(status);
		}

		void WritePort(byte [] bytes)
		{
			status.Time = DateTime.Now;
			_serialPort.Write(bytes, 0, bytes.Length);
			Recorder.SendLog(status.Time, Transfer.BaToS(bytes));
		}
	}
}
