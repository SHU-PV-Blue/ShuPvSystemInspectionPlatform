using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Components
{
    public class Status
    {

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 消息队列
        /// </summary>
        public List<KeyValuePair<byte, bool>> MessageQueue { get; set; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        public OleDbConnection OleDbCon { get;set; }

        /// <summary>
        /// 组件号
        /// </summary>
        public int ComponentId { get; set; }

        /// <summary>
        /// 方位角
        /// </summary>
        public double Azimuth
		{
			get
			{
			if(ComponentId == 6)
				return Component6Azimuth;
			else
				return 180;
			}
		}

        /// <summary>
        /// 倾角
        /// </summary>
        public double Obliquity
		{
			get
			{
				switch (ComponentId)
				{
					case 1:
						return 3;
					case 2:
						return 22;
					case 3:
						return 27;
					case 4:
						return 32;
					case 5:
						return 37;
				}
				return Component6Obliquity;
			}
		}

		/// <summary>
		/// 组件6的方位角
		/// </summary>
		public double Component6Azimuth { get; set; }

		/// <summary>
		/// 组件6的倾角
		/// </summary>
		public double Component6Obliquity { get; set; }

		/// <summary>
		/// 异常
		/// </summary>
		public Exception exception { get; set; }
    }
}
