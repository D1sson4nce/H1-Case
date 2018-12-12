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
                    Console.Write(bil["Regnr"] + " | ");
                    Console.Write(bil["Mærke"] + " ");
                    Console.Write(bil["Model"] + " | ");
                    Console.Write(bil["Årgang"] + " | ");
                    Console.Write(bil["Kilometer"] + " | ");
                    Console.Write(bil["Brændstoftype"] + " | ");
                    Console.Write(bil["Ejer"] + " | ");
                    Console.Write(bil["Opretdato"]);
                    Console.WriteLine();
                }
            }
        }

        public void OpretBil(string regnr, string mærke, string model, int årgang, double km, string brnstoftype, int ejer)
        {
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                string e = "wad";
                bool bilFindes = false;
                // Tjekker om en bil findes i databasen, før bilen kan blive oprettet
                foreach (DataRow bil in use.dt.Rows)
                {
                    if (e == bil["Regnr"].ToString())
                    {
                        bilFindes = true;
                    }
                    else
                    {
                        bilFindes = false;
                    }
                }

                // Hvis bilen ikke findes i databasen, skal den oprette bilen
                if (bilFindes == false)
                {
                    string sql = null;
                    use.ada = new SqlDataAdapter();

                    sql = $"insert into Biler values ('{regnr}', '{mærke}', '{model}', {årgang}, {km}, '{brnstoftype}', {ejer})";

                    use.ada.InsertCommand = new SqlCommand(sql, use.con);
                    use.ada.InsertCommand.ExecuteNonQuery();
                }
                // Hvis bilen findes i databasen, skal den oplyse det og afbryde aktionen
                else
                {
                    Console.WriteLine("Fejl. Bilen er allerede registreret i databasen.");
                }
            }
        }
    }
}
