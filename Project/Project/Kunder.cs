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
    class Kunder
    {
        Use use = new Use();
        SqlConnection con;
        SqlDataAdapter ada;
        DataTable dt;      

        public void KundeListe()
        {
            dt = new DataTable();
            using (con = new SqlConnection(use.StrCon1))
            {
                con.Open();
                ada = new SqlDataAdapter("select * from Kunder", con);
                ada.Fill(dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in dt.Rows)
                {
                    Console.Write(kunde["ID"].ToString() + " | ");
                    Console.Write(kunde["Fornavn"].ToString() + " ");
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
            using (con = new SqlConnection(use.StrCon1))
            {
                con.Open();
                ada = new SqlDataAdapter("select * from Kunder where ID like '" + søgning + "%' " +
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
                    Console.Write(kunde["Fornavn"].ToString() + " ");
                    Console.Write(kunde["Efternavn"].ToString() + " | ");
                    Console.Write(kunde["Adresse"].ToString() + " | ");
                    Console.Write(kunde["Alder"].ToString() + " | ");
                    Console.Write(kunde["Opretdato"].ToString());
                    Console.WriteLine();
                }
            }
        }

        public void OpretBruger(string fornavn, string efternavn, string adresse, int alder)
        {
            using (con = new SqlConnection(use.StrCon1))
            {
                con.Open();
                string sql = "";
                ada = new SqlDataAdapter();

                sql = "insert into Kunder values('" + fornavn + "', '" + efternavn + "', '" + adresse + "', " + alder + ", '" + DateTime.Now.ToString("dd-MM-yyyy") + "')";

                ada.InsertCommand = new SqlCommand(sql, con);
                ada.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
