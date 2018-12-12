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
        Use use = new Use();

        public void BilBesøg(string id)
        {
            use.Dt = new DataTable();
            using (use.Con = new SqlConnection(use.StrCon1))
            {
                use.Con.Open();
                use.Ada = new SqlDataAdapter("select * from Værkstedsophold where Bil = '" + id + "'", use.Con);
                use.Ada.Fill(use.Dt);
                Console.WriteLine("\nBesøgs ID | Besøgsdag\n");

                foreach (DataRow bil in use.Dt.Rows)
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

        public void OpretBesøg(string id)
        {
            using (use.Con = new SqlConnection(use.StrCon1))
            {
                use.Con.Open();
                string sql = "";
                use.Ada = new SqlDataAdapter();

                sql = "insert into Værkstedsophold values('" + id + "', '" + DateTime.Now.ToString("dd-MM-yyyy") + "')";

                use.Ada.InsertCommand = new SqlCommand(sql, use.Con);
                use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
