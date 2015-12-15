using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 光伏发电系统实验监测平台.Commands;
using 光伏发电系统实验监测平台.Manager;
using System.IO.Ports;
using Microsoft.Office;
using System.IO;

namespace 光伏发电系统实验监测平台
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		#region 字段
		private bool SeriaOpen = false;									//串口状态，默认为关
		private Timer nowTime;											//用于显示当前时间的计时器
		private Timer SetLightTimer;
		private SerialPort _serialPort;									//串口对象
		private bool _ifSetPort = false;								//是否已经设置好了串口
		/// <summary>
		/// 收发器
		/// </summary>
		Transceiver _transceiver;
		#endregion

		#region 控件事件

		/// <summary>
		/// 窗口加载事件
		/// </summary>
		private void MainForm_Load(object sender, EventArgs e)
		{
			Mkdir();
			ScanPort();
			Initcmb();
			SetNowTimer();
			SetLight();
			_serialPort = new SerialPort();
			_transceiver = new Transceiver(_serialPort);
			_transceiver.Analyzed += new TransceiverEventHandler(delegate()
			{
				//解析时候的工作
				pctbxAnalyze.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Green;
#warning 解析时候的工作，未测试
			});
			_transceiver.Changed += new TransceiverEventHandler(delegate()
			{
				//状态发生变化时候的工作
				var x = _transceiver.status;
				lblAzimuth.Text = x.Azimuth.ToString();
				lblComID.Text = x.ComponentId.ToString();
				lblObliquity.Text = x.Obliquity.ToString();
			});
			_transceiver.Excepted += new TransceiverEventHandler(delegate()
			{
				pctbxError.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Red;
				//发生异常时候的工作
#warning 发生异常时候的工作，未测试
			});
			_transceiver.Ends += new TransceiverEventHandler(delegate()
			{
				//指令完了时候的工作
				pctbxStatu_Click(sender, e);
			});
		}

		/// <summary>
		/// 窗口关闭事件
		/// </summary>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			nowTime.Stop();
		}
		
		/// <summary>
		/// 开关按钮按下事件
		/// </summary>
		private void pctbxStatu_Click(object sender, EventArgs e)
		{
			if (SeriaOpen == false)
			{
				if (!_ifSetPort)
				{
					MessageBox.Show("请先配置串口!", "串口未配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (string.IsNullOrEmpty(txtSettingFilePath.Text))
				{
					MessageBox.Show("请先配置伪指令代码!", "伪指令代码未配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				SeriaOpen = true;
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.on;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset_gray;
				btnReset.Enabled = false;
				pctbxRunStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Sun2;
				btnSetting.Enabled = false;
				_transceiver.Start(CommandReader.LoadCommands(txtSettingFilePath.Text), int.Parse(txtCycle.Text));
			}
			else
			{
				SeriaOpen = false;
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.off;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset;
				btnReset.Enabled = true;
				pctbxRunStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Sun2__2_;
				btnSetting.Enabled = true;
				_transceiver.Stop();
			}
		}

		/// <summary>
		/// 时钟计时器触发事件
		/// </summary>
		void nowTime_Tick(object sender, EventArgs e)
		{
			lblTimeNow.Text = DateTime.Now.ToString();
		}

		/// <summary>
		/// 重置指示灯计时器触发事件
		/// </summary>
		void SetLightTimer_Tick(object sender, EventArgs e)
		{
			if (pctbxAnalyze.BackgroundImage != 光伏发电系统实验监测平台.Properties.Resources.Balck)
			{
				pctbxAnalyze.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Balck;
			}
			if (pctbxError.BackgroundImage != 光伏发电系统实验监测平台.Properties.Resources.Balck)
			{
				pctbxError.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Balck;
			}
		}

		/// <summary>
		/// ??按钮单击事件
		/// </summary>
		private void pctbxSetOrder_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = true;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = false;
		}

		/// <summary>
		/// ??按钮单击事件
		/// </summary>
		private void pctbxSetFunction_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = false;
			pnlFunction.Visible = true;
			pnlSearchData.Visible = false;
		}

		/// <summary>
		/// ??按钮单击事件
		/// </summary>
		private void pctbxSearchData_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus;
			pnlOrder.Visible = false;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = true;
		}

		/// <summary>
		/// 状态重置按钮单击事件
		/// </summary>
		private void btnReset_Click(object sender, EventArgs e)
		{
			_transceiver.Reset();
		}

		/// <summary>
		/// 查找Excel文件按钮单击事件
		/// </summary>
		private void btnDataSearch_Click(object sender, EventArgs e)
		{
			string year = dtpDataSerach.Value.Year.ToString();
			string month = dtpDataSerach.Value.Month.ToString();
			string day = dtpDataSerach.Value.Day.ToString();
			string path = string.Format(@".\Excel\{0}-{1}-{2}.xlsx", year, month, day);
			FileInfo fi = new FileInfo(path);
			if (!fi.Exists)
			{
				MessageBox.Show("文件不存在, 请重新确认日期是否正确", "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			System.Diagnostics.Process.Start(path);
		}

		/// <summary>
		/// 打开伪指令代码按钮单击事件
		/// </summary>
		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openSettingFile = new OpenFileDialog();
			openSettingFile.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
			if (openSettingFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				System.Diagnostics.Process.Start(openSettingFile.FileName);
			txtSettingFilePath.Text = openSettingFile.FileName;
			if (!string.IsNullOrEmpty(txtSettingFilePath.Text) && _ifSetPort)
			{
				lblTip.Text = "每天六点整时，程序将自动按下启动按钮";
				lblTip.ForeColor = Color.Green;
			}
		}

		/// <summary>
		/// 配置串口按钮单击事件
		/// </summary>
		private void btnSetting_Click(object sender, EventArgs e)
		{
			_ifSetPort = true;
			_serialPort.PortName = cmbPorts.Text;
			switch (cmbParity.Text)
			{
				case "None":
					_serialPort.Parity = Parity.None;
					break;
				case "Odd":
					_serialPort.Parity = Parity.Odd;
					break;
				case "Even":
					_serialPort.Parity = Parity.Even;
					break;
				case "Mark":
					_serialPort.Parity = Parity.Mark;
					break;
				case "Space":
					_serialPort.Parity = Parity.Space;
					break;
			}
			_serialPort.DataBits = Convert.ToInt32(cmbDataBit.Text);
			switch (cmbStopBit.Text)
			{

				case "0":
					_serialPort.StopBits = StopBits.None;
					break;
				case "1":
					_serialPort.StopBits = StopBits.One;
					break;
				case "2":
					_serialPort.StopBits = StopBits.Two;
					break;
				case "1.5":
					_serialPort.StopBits = StopBits.OnePointFive;
					break;
			}
			btnSetting.Enabled = false;
			if (!string.IsNullOrEmpty(txtSettingFilePath.Text))
			{
				lblTip.Text = "每天六点整时，程序将自动按下启动按钮";
				lblTip.ForeColor = Color.Green;
			}
		}

		#endregion

		#region 功能函数

		/// <summary>
		/// 检查并创建路径
		/// </summary>
		private void Mkdir()
		{
			DirectoryInfo dirInfo;
			dirInfo = new DirectoryInfo("ReceiveData");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("SendData");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("ErrorLog");
			if (!dirInfo.Exists)
				dirInfo.Create();
			dirInfo = new DirectoryInfo("Excel");
			if (!dirInfo.Exists)
				dirInfo.Create();
		}

		/// <summary>
		/// 扫描串口
		/// </summary>
		private void ScanPort()
		{
			cmbPorts.Items.Clear();
			string[] ports = SerialPort.GetPortNames();
			Array.Sort(ports);
			if(ports.Count() == 0)
				cmbPorts.Items.Add("无可用");
			else
				cmbPorts.Items.AddRange(ports);
		}

		/// <summary>
		/// 配置各个列表
		/// </summary>
		private void Initcmb()
		{
			cmbPorts.SelectedIndex = 0;
			txtBaudRate.Text = "不指定";
			cmbDataBit.SelectedIndex = 0;
			cmbParity.SelectedIndex = 0;
			cmbStopBit.SelectedIndex = 0;
		}

		/// <summary>
		/// 设置当前时间计时器
		/// </summary>
		public void SetNowTimer()
		{
			nowTime = new Timer();
			nowTime.Interval = 1000;
			nowTime.Start();
			nowTime.Tick += nowTime_Tick;
		}

		/// <summary>
		/// 设置重置指示灯计时器
		/// </summary>
	    private void SetLight()
	    {
	        SetLightTimer = new Timer();
	        SetLightTimer.Interval = 500;
            SetLightTimer.Start();
            SetLightTimer.Tick += SetLightTimer_Tick;
		}

		#endregion

	}
}
