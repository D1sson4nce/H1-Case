using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    static class Use
    {
        static private string strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI";

        static public string StrCon1
        {
            get { return strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI"; }
        }

        static public SqlConnection Con { get; set; }
        static public SqlDataAdapter Ada { get; set; }
        static public DataTable Dt { get; set; }
        

    }
}
