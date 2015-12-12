using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 光伏发电系统实验监测平台.Components
{
    abstract class Component
    {
        public abstract void Analyze(Status status);

        public abstract void GetCommand();
    }
}
