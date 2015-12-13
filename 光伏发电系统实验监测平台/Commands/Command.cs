using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Commands
{
	class Command
	{
		/// <summary>
		/// 操作类型集合
		/// </summary>
		public enum Operates { 打开, 关闭, 等待, 旋转方位角, 旋转倾角, 查询气象仪, 查询曲线仪, 选择组件, 断开组件};

		/// <summary>
		/// 根据操作名返回操作
		/// </summary>
		/// <param name="operateName">操作名</param>
		/// <returns>操作</returns>
		public static Operates ToOperate(string operateName)
		{
			switch(operateName)
			{
				case "打开":
					return Operates.打开;
				case "关闭":
					return Operates.关闭;
				case "等待":
					return Operates.等待;
				case "旋转方位角":
					return Operates.旋转方位角;
				case "旋转倾角":
					return Operates.旋转倾角;
				case "查询气象仪":
					return Operates.查询气象仪;
				case "查询曲线仪":
					return Operates.查询曲线仪;
				case "选择组件":
					return Operates.选择组件;
				case "断开组件":
					return Operates.断开组件;
				default:
					throw new Exception("操作名有误:" + operateName);
			}
		}

		/// <summary>
		/// 伪指令构造
		/// </summary>
		/// <param name="operate">操作</param>
		/// <param name="argument">参数</param>
		public Command(Operates operate, int argument)
		{
			this.Operate = operate;
			this.Argument = argument;
		}

		/// <summary>
		/// 操作
		/// </summary>
		public Operates Operate { set; get; }
		
		/// <summary>
		/// 参数
		/// </summary>
		public int Argument { set; get; }
	}
}
