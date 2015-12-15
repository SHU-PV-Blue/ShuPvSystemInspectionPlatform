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
        public double Azimuth { get; set; }

        /// <summary>
        /// 倾角
        /// </summary>
        public double Obliquity { get; set; }
    }
}
