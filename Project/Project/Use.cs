using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Use
    {
        private string strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI";

        public string StrCon1
        {
            get { return strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI"; }
            private set { strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI";; }
        }



    }
}
