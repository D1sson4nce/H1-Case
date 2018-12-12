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
            use.Dt = new DataTable();
            using (use.Con = new SqlConnection(use.StrCon1))
            {
                use.Con.Open();
                use.Ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Fornavn, Efternavn, Biler.Opretdato from Biler join Kunder on EjerID = ID order by EjerID", use.Con);
                use.Ada.Fill(use.Dt);
                Console.WriteLine("Registreringsnummer | Mærke | Model | Årgang | KM | Brændstoftype | Ejer \n");

                foreach (DataRow bil in use.Dt.Rows)
                {
                    Console.Write(bil["Regnr"] + " | ");
                    Console.Write(bil["Mærke"] + " ");
                    Console.Write(bil["Model"] + " | ");
                    Console.Write(bil["Årgang"] + " | ");
                    Console.Write(bil["Km"] + " | ");
                    Console.Write(bil["Brændstoftype"] + " | ");
                    Console.Write(bil["Fornavn"] + " ");
                    Console.Write(bil["Efternavn"] + " | ");
                    Console.Write(bil["Opretdato"]);
                    Console.WriteLine();
                }
            }
        }

        public void OpretBil(string regnr, string mærke, string model, int årgang, double km, string brnstoftype, int ejer)
        {
            use.Dt = new DataTable();
            using (use.Con = new SqlConnection(use.StrCon1))
            {
                use.Con.Open();
                string e = "wad";
                bool bilFindes = false;
                // Tjekker om en bil findes i databasen, før bilen kan blive oprettet
                foreach (DataRow bil in use.Dt.Rows)
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
                    use.Ada = new SqlDataAdapter();

                    sql = $"insert into Biler values ('{regnr}', '{mærke}', '{model}', {årgang}, {km}, '{brnstoftype}', {ejer}, '{DateTime.Now.ToString("dd-MM-yyyy")}')";

                    use.Ada.InsertCommand = new SqlCommand(sql, use.Con);
                    use.Ada.InsertCommand.ExecuteNonQuery();
                }
                // Hvis bilen findes i databasen, skal den oplyse det og afbryde aktionen
                else
                {
                    Console.WriteLine("Fejl. Bilen er allerede registreret i databasen.");
                }
            }

            Console.ReadKey();
        }

        public void BilSøgning(string bilSøg)
        {
            use.Dt = new DataTable();
            using (use.Con = new SqlConnection(use.StrCon1))
            {
                use.Con.Open();
                use.Ada = new SqlDataAdapter($"select * from Biler where Regnr like '{bilSøg}%'" +
                                             $"or Mærke like '{bilSøg}%'" +
                                             $"or Model like '{bilSøg}%'" +
                                             $"or Årgang like '{bilSøg}%'" +
                                             $"or Km like '{bilSøg}%'" +
                                             $"or Brændstoftype like '{bilSøg}%'" +
                                             $"or EjerID like '{bilSøg}%'" +
                                             $"or Opretdato like '{bilSøg}%'", use.Con);
                use.Ada.Fill(use.Dt);
                Console.WriteLine("Regnr | Mærke | Model | Årgang | Kilometer | Brændstoftype | Ejer ID | Oprettelses dato");

                foreach (DataRow bil in use.Dt.Rows)
                {
                    Console.Write(bil["Regnr"] + " | ");
                    Console.Write(bil["Mærke"] + " | ");
                    Console.Write(bil["Model"] + " | ");
                    Console.Write(bil["Årgang"] + " | ");
                    Console.Write(bil["Km"] + " | ");
                    Console.Write(bil["Brændstoftype"] + " | ");
                    Console.Write(bil["EjerID"] + " | ");
                    Console.Write(bil["Opretdato"] + " | ");
                    Console.WriteLine();
                }
            }
        }
    }
}
