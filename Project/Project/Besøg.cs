using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    static class Besøg
    {

        // En metode som man bruger til at finde en bils værkstedsophold
        static public void BilBesøg(string id)
        {
            // Ny datatable instance
            Use.Dt = new DataTable();
            // using holder forbindelsen åben indtil den er færdig
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                // SQL adapter som holder SQL kommandoen som vælger alle biler med det indtastede ID fra værkstedsophold
                Use.Ada = new SqlDataAdapter("select * from Værkstedsophold where Bil = '" + id + "'", Use.Con);
                // Adapter som fylder datatable med data
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("\nBesøgs ID | Besøgsdag\n");

                // foreach som kører igennem hele listen med data og udskriver den
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

        // Metode som man bruger til at oprette et nyt besøg på værkstedet
        static public void OpretBesøg(string bilValg, string dato)
        {
            // using holder forbindelsen åben indtil den er færdig
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                // Et nyt object som indeholder den bil man har valgt og dagens dato
                Besøget besøget = new Besøget(bilValg, dato);

                Use.Con.Open();
                string sql = "";
                // Nyt objekt af en SQL adapter
                Use.Ada = new SqlDataAdapter();

                // En string som holder SQL kommandoen
                sql = "insert into Værkstedsophold values('" + besøget.Bil + "', '" + besøget.Dato + "')";

                // Her indsætter man kommandoen til databasen med adapteren
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                // Her udfører man kommandoen med adapteren
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        // En metode som man bruger til at rette et besøg på værkstedet
        static public void RetBesøg(string id, string dato)
        {
            // using holder forbindelsen åben indtil den er færdig
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                // Nyt objekt af en SQL adapter
                Use.Ada = new SqlDataAdapter();

                // En string som holder SQL kommandoen
                sql = "update Værkstedsophold set Besøgsdato = '" + dato + "'  where ID = '" + id + "'";

                // Her indsætter man kommandoen til databasen med adapteren
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                // Her udfører man kommandoen med adapteren
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        // En metode som man bruger til at vælge et bestemt besøg på værkstedet
        static public string VælgBesøg(string valgID)
        {
            Console.Clear();
            Use.Dt = new DataTable();
            // using holder forbindelsen åben indtil den er færdig
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                // SQL adapter som holder SQL kommandoen som vælger alle biler med det indtastede ID fra værkstedsophold
                Use.Ada = new SqlDataAdapter("select * from Værkstedsophold", Use.Con);
                // Adapter som fylder datatable med data
                Use.Ada.Fill(Use.Dt);

                // foreach som kører igennem hele listen med data og udskriver den
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
            // Metoden retunerer "Findes Ikke", hvis det valgte besøg ikke findes i databasen
            return "Findes Ikke";
        }

        // En metode som man bruger til at slette et besøg på værkstedet
        static public void SletBesøg (string id)
        {
            // using holder forbindelsen åben indtil den er færdig
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                // Nyt objekt af en SQL adapter
                Use.Ada = new SqlDataAdapter();

                // En string som holder SQL kommandoen
                sql = "delete from Værkstedsophold where ID = " + id;

                // Her indsætter man kommandoen til databasen med adapteren
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                // Her udfører man kommandoen med adapteren
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }
    }
}
