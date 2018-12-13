using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    class Use
    {
        private string strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI";

        public string StrCon1
        {
            get { return strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI"; }
        }

        public SqlConnection Con { get; set; }
        public SqlDataAdapter Ada { get; set; }
        public DataTable Dt { get; set; }
        

    }
}
