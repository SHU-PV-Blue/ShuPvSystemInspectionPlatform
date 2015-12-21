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
using System.Windows.Forms;
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
		#region 字段
		SerialPort _serialPort;
		Thread _sendTread;
		Command[] _commands;
		int _cycle;
		Status _status;
		bool _needSendThread;
		bool _stopLock;

		const int initComponentId = 6;
		const double initAzimuth = 170;
		const double initObliquity = 22;
		#endregion

		#region 事件
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

		#endregion

		#region 公开方法
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

			_status = new Status();
			_status.Time = DateTime.Now;
			_status.MessageQueue = new List<KeyValuePair<byte, bool>>();
			_status.ComponentId = initComponentId;
			_status.Azimuth = initAzimuth;
			_status.Obliquity = initObliquity;
			try
			{
				_status.OleDbCon = DatabaseConnection.GetConnection();
				_status.OleDbCon.Open();
			}
			catch (Exception ex)
			{
				throw new Exception("数据库连接失败:" + ex.Message, ex);
			}

			if (_sendTread != null && _sendTread.IsAlive)
				_sendTread.Abort();
			_sendTread = new Thread(new ThreadStart(Work));
			_needSendThread = true;
			_stopLock = false;
			_sendTread.Start();
		}

		/// <summary>
		/// 停止
		/// </summary>
		public void Stop()
		{
			if (_stopLock)
				return;
			_stopLock = true;
			_needSendThread = false;
			ForceStop();
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

		#endregion

		#region 私有方法

		private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		{
			byte[] readbyte = new byte[_serialPort.BytesToRead];

			_serialPort.Read(readbyte, 0, readbyte.Length);
			_status.Time = DateTime.Now;
			foreach(var b in readbyte)
				_status.MessageQueue.Add(new KeyValuePair<byte, bool>(b, true));
			Recorder.ReciveLog(_status.Time, Transfer.BaToS(readbyte));
			try
			{
				if (MainAnalyzer.Analyze(_status, Excepted))
					Changed(_status);
				Analyzed(_status);
			}
			catch (Exception ex)
			{
				_status.exception = new Exception("解析异常:" + ex.Message, ex);
				Stop();
			}
		}

		void Work()
		{
			const int scmCycle = 500;//角度仪查询周期
			const int djDelay = 100;
			try
			{
				while (_cycle > 0)
				{
					foreach (Command command in _commands)
					{
						if (!_needSendThread)
							return;
						switch (command.Operate)
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
									Thread.Sleep(scmCycle);


									if (_status.Obliquity < command.Argument)
									{
										bytes = (new Relay32()).GetCommand("倾角增加");
									}
									else
									{
										bytes = (new Relay32()).GetCommand("倾角减少");
									}
									WritePort(bytes);
									Thread.Sleep(djDelay);

									Stopwatch sw = new Stopwatch();
									sw.Start();
									while (_needSendThread)
									{
										bytes = (new SCM()).GetCommand("查询倾斜角");
										WritePort(bytes);
										Thread.Sleep(scmCycle);
										if (Math.Abs(_status.Obliquity - command.Argument) < 0.5)
										{
											bytes = (new Relay32()).GetCommand("停转");
											WritePort(bytes);
											Thread.Sleep(djDelay);
											break;
										}
										if (sw.ElapsedMilliseconds > 20 * 1000)
										{
											throw new Exception("电机运作异常,调整倾斜角失败");
										}
									}
									bytes = (new SCM()).GetCommand("查询倾斜角");
									WritePort(bytes);
									Thread.Sleep(scmCycle);
									break;
								}
							case Command.Operates.旋转方位角:
								{
									byte[] bytes = (new SCM()).GetCommand("查询方位角");
									WritePort(bytes);
									Thread.Sleep(scmCycle);

									if (_status.Azimuth < command.Argument)
									{
										bytes = (new Relay32()).GetCommand("方位角增加");
									}
									else
									{
										bytes = (new Relay32()).GetCommand("方位角减少");
									}
									WritePort(bytes);
									Thread.Sleep(djDelay);

									Stopwatch sw = new Stopwatch();
									sw.Start();
									while (_needSendThread)
									{
										bytes = (new SCM()).GetCommand("查询方位角");
										WritePort(bytes);
										Thread.Sleep(scmCycle);
										if (Math.Abs(_status.Azimuth - command.Argument) < 0.5)
										{
											bytes = (new Relay32()).GetCommand("停转");
											WritePort(bytes);
											Thread.Sleep(djDelay);
											break;
										}
										if (sw.ElapsedMilliseconds > 20 * 1000)
										{
											throw new Exception("电机运作异常,调整方位角失败");
										}
									}
									bytes = (new SCM()).GetCommand("查询方位角");
									WritePort(bytes);
									Thread.Sleep(scmCycle);
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
									_status.ComponentId = command.Argument;
									Changed(_status);
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
					}
						
					--_cycle;
				}
			}
			catch(Exception ex)
			{
				_status.exception = new Exception("上位机平台运行异常:" + ex.Message, ex);
			}
			finally
			{
				ForceStop();
			}
		}

		void WritePort(byte [] bytes)
		{
			_status.Time = DateTime.Now;
			_serialPort.Write(bytes, 0, bytes.Length);
			Recorder.SendLog(_status.Time, Transfer.BaToS(bytes));
		}

		/// <summary>
		/// 强行停止
		/// </summary>
		void ForceStop()
		{
			_needSendThread = false;
			while (_sendTread != null && _sendTread.IsAlive)
				Thread.Sleep(100);//等待线程关闭
#error 如果执行这个函数的就是_sendTread，循环将不会退出，线程失控
			if (_serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();
			if (_status.OleDbCon != null && _status.OleDbCon.State == ConnectionState.Open)
				_status.OleDbCon.Close();
			Thread.Sleep(200);//等待串口关闭

			_serialPort.BaudRate = 9600;
			_serialPort.Open();
			Thread.Sleep(100);//等待串口打开，不确定是否必要
			byte[] bytes = (new Relay32()).GetCommand("停转");
			WritePort(bytes);
			Thread.Sleep(200);//等待指令送达
			_serialPort.Close();
			Ends(_status);
		}

		#endregion
	}
}
