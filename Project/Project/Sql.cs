using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    class Sql
    {
        private string strCon1 = "data source=DESKTOP-RLV28AP; database=ProjektDB; integrated security=SSPI";
        SqlConnection con;
        SqlDataAdapter ada;
        SqlCommand cmd;
        DataTable dt;      

        public void KundeListe()
        {
            dt = new DataTable();
            using (con = new SqlConnection(strCon1))
            {
                con.Open();
                ada = new SqlDataAdapter("select * from Kunder", con);
                ada.Fill(dt);

                foreach (DataRow kunde in dt.Rows)
                {
                    Console.WriteLine(kunde["ID"].ToString());
                    Console.WriteLine(kunde["Fornavn"].ToString());
                    Console.WriteLine(kunde["Efternavn"].ToString());
                    Console.WriteLine(kunde["Adresse"].ToString());
                    Console.WriteLine(kunde["Alder"].ToString());
                    Console.WriteLine(kunde["Opretdato"].ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}
