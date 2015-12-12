using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Components
{
    class Status
    {
        public DateTime Time { get; set; }
        public List<KeyValuePair<byte, bool>> MessageQueue { get; set; }
        public OleDbConnection OleDbCon { get;set; }
        public int ComponentId { get; set; }
        public int Azimuth { get; set; }
        public int Obliquity { get; set; }
    }
}
