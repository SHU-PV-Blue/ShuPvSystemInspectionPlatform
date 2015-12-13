using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 光伏发电系统实验监测平台.Components;

namespace 光伏发电系统实验监测平台.Analyzer
{
	class ComponentAnalyzer : Component
	{

        public override bool Analyze(Status status)
        {

            return true;
        }

        public override byte[] GetCommand(String commandName)
        {
            return new byte[4];
        }
    }
}
