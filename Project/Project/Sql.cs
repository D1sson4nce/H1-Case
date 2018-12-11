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
        private string strCon1 = $"data source={Environment.MachineName}; database=ProjektDB; integrated security=SSPI";
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
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in dt.Rows)
                {
                    Console.Write(kunde["ID"].ToString() + " | ");
                    Console.Write(kunde["Fornavn"].ToString());
                    Console.Write(kunde["Efternavn"].ToString() + " | ");
                    Console.Write(kunde["Adresse"].ToString() + " | ");
                    Console.Write(kunde["Alder"].ToString() + " | ");
                    Console.Write(kunde["Opretdato"].ToString());
                    Console.WriteLine();
                }
            }
        }

        public void KundeSøgning(string søgning)
        {
            dt = new DataTable();
            using (con = new SqlConnection(strCon1))
            {
                con.Open();
                ada = new SqlDataAdapter("select * from test where ID like '" + søgning + "%' " +
                "or Fornavn like '" + søgning + "%' " +
                "or Efternavn like '" + søgning + "%' " +
                "or Adresse like '" + søgning + "%' " +
                "or Alder like '" + søgning + "%' " + 
                "or Opretdato like '" + søgning + "%'", con);
                ada.Fill(dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in dt.Rows)
                {
                    Console.Write(kunde["ID"].ToString() + " | ");
                    Console.Write(kunde["Fornavn"].ToString());
                    Console.Write(kunde["Efternavn"].ToString() + " | ");
                    Console.Write(kunde["Adresse"].ToString() + " | ");
                    Console.Write(kunde["Alder"].ToString() + " | ");
                    Console.Write(kunde["Opretdato"].ToString());
                    Console.WriteLine();
                }
            }

        }
    }
}
