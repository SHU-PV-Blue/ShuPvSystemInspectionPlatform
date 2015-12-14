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

		private bool SeriaOpen = false;									//串口状态，默认为关
		private Timer nowTime;											//用于显示当前时间的计时器
	    private Timer SetLightTimer;
        private SerialPort _serialPort;									//串口对象
		private bool _ifSet = false;									//是否已经设置好了串口
        
		/// <summary>
		/// 收发器
		/// </summary>
		Transceiver _transceiver;
	
		private void pctbxStatu_Click(object sender, EventArgs e)
		{
			if (SeriaOpen == false)
			{
				SeriaOpen = true;
				pctbxStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.on;
				btnReset.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Reset_gray;
				btnReset.Enabled = false;
				pctbxRunStatu.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Sun2;
				btnSetting.Enabled = false;
#warning 这里参数要改
				_transceiver.Start(CommandReader.LoadCommands(txtSettingFilePath.Text),int.Parse(txtCycle.Text));
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
#warning 状态发生变化时候的工作，未测试
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
                pctbxStatu_Click(sender,e);
#warning 指令完了时候的工作， 未测试
            });
		}

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
			try
			{
				string[] ports = SerialPort.GetPortNames();
				Array.Sort(ports);
				cmbPorts.Items.AddRange(ports);
			}
			catch
			{
				return;
			}
		}

		/// <summary>
		/// 配置各个列表
		/// </summary>
		private void Initcmb()
		{
			try
			{
				cmbPorts.SelectedIndex = 0;
				txtBaudRate.Text = "9600";
				cmbDataBit.SelectedIndex = 0;
				cmbParity.SelectedIndex = 0;
				cmbStopBit.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				return;
			}

		}

		public void SetNowTimer()
		{
			nowTime = new Timer();
			nowTime.Interval = 1000;
			nowTime.Start();
			nowTime.Tick += nowTime_Tick;
		}

		void nowTime_Tick(object sender, EventArgs e)
		{
			lblTimeNow.Text = DateTime.Now.ToString();
			//throw new NotImplementedException();
		}

	    private void SetLight()
	    {
	        SetLightTimer = new Timer();
	        SetLightTimer.Interval = 500;
            SetLightTimer.Start();
            SetLightTimer.Tick += SetLightTimer_Tick;
	    }

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

		private void pctbxSetOrder_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = true;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = false;
		}

		private void pctbxSetFunction_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus__2_;
			pnlOrder.Visible = false;
			pnlFunction.Visible = true;
			pnlSearchData.Visible = false;
		}

		private void pctbxSearchData_Click(object sender, EventArgs e)
		{
			pctbxSetOrder.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Neptune__2_;
			pctbxSetFunction.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Earth__2_;
			pctbxSearchData.BackgroundImage = 光伏发电系统实验监测平台.Properties.Resources.Venus;
			pnlOrder.Visible = false;
			pnlFunction.Visible = false;
			pnlSearchData.Visible = true;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			_transceiver.Reset();
		}

		private void btnDataSearch_Click(object sender, EventArgs e)
		{
			string year = dtpDataSerach.Value.Year.ToString();
			string month = dtpDataSerach.Value.Month.ToString();
			string day = dtpDataSerach.Value.Day.ToString();
			string path = string.Format(@".\Excel\{0}-{1}-{2}.xlsx",year,month,day);
			FileInfo fi = new FileInfo(path);
			if (!fi.Exists)
			{
				MessageBox.Show("文件不存在, 请重新确认日期是否正确","文件不存在",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			System.Diagnostics.Process.Start(path);
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openSettingFile = new OpenFileDialog();
			openSettingFile.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
			if (openSettingFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				System.Diagnostics.Process.Start(openSettingFile.FileName);
			txtSettingFilePath.Text = openSettingFile.FileName;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			nowTime.Stop();
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			_ifSet = true;
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
			lblTip.Text = "每天六点整时，程序将自动按下启动按钮\n收发结束后，将自动解析";
			lblTip.ForeColor = Color.Green;
		}


	}
}
