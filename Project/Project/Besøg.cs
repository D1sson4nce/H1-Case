using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    class Besøg
    {

        public void BilBesøg(string id)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select * from Værkstedsophold where Bil = '" + id + "'", Use.Con);
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("\nBesøgs ID | Besøgsdag\n");

                foreach (DataRow bil in Use.Dt.Rows)
                {
                    if (id == bil["Bil"].ToString())
                    {
                        Console.Write(bil["ID"] + " | ");
                        Console.Write(bil["Besøgsdato"]);
                        Console.WriteLine();
                    }
                }
            }
        }

        public void OpretBesøg(string id, string dato)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "insert into Værkstedsophold values('" + id + "', '" + dato + "')";

                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        public void RetBesøg(string id, string dato)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "update Værkstedsophold set Besøgsdato = '" + dato + "'  where Bil = '" + id + "'";
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        public string VælgBesøg(string valgID)
        {
            Console.Clear();
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select * from Værkstedsophold", Use.Con);
                Use.Ada.Fill(Use.Dt);

                foreach (DataRow besøg in Use.Dt.Rows)
                {
                    if (valgID == besøg["ID"].ToString())
                    {
                        Console.Write(besøg["ID"] + " | ");
                        Console.Write(besøg["Bil"] + " ");
                        Console.Write(besøg["Besøgsdato"]);
                        Console.WriteLine();
                        return valgID;
                    }
                }
            }
            return "Findes Ikke";
        }

        public void SletBesøg (string id)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "delete from Værkstedsophold where ID = " + id;
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
