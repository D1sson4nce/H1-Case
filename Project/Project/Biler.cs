using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    class Biler
    {
        Use use = new Use();

        public void BilListe()
        {
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Fornavn, Efternavn, Biler.Opretdato from Biler join Kunder on EjerID = ID", use.con);
                use.ada.Fill(use.dt);
                Console.WriteLine("Registreringsnummer | Mærke | Model | Årgang | KM | Brændstoftype | Ejer \n");

                foreach (DataRow bil in use.dt.Rows)
                {
                    Console.Write(bil["ID"].ToString() + " | ");
                    Console.Write(bil["Fornavn"].ToString() + " ");
                    Console.Write(bil["Efternavn"].ToString() + " | ");
                    Console.Write(bil["Adresse"].ToString() + " | ");
                    Console.Write(bil["Alder"].ToString() + " | ");
                    Console.Write(bil["Opretdato"].ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}
