using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Command
{
	class Command
	{
		/// <summary>
		/// 操作类型集合
		/// </summary>
		enum Operates { 打开, 关闭, 等待, 旋转方位角, 旋转倾角, 查询气象仪, 查询曲线仪, 选择组件};

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
		public Operates Operate { set; get; }
		public int Argument { set; get; }
	}
}
