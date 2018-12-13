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

        public void KundeListe()
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select * from Kunder", Use.Con);
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in Use.Dt.Rows)
                {
                    Console.Write(kunde["ID"] + " | ");
                    Console.Write(kunde["Fornavn"] + " ");
                    Console.Write(kunde["Efternavn"] + " | ");
                    Console.Write(kunde["Adresse"] + " | ");
                    Console.Write(kunde["Alder"] + " | ");
                    Console.Write(kunde["Opretdato"]);
                    Console.WriteLine();
                }
            }
        }

        public void KundeSøgning(string søgning)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select * from Kunder where ID like '" + søgning + "%' " +
                "or Fornavn like '" + søgning + "%' " +
                "or Efternavn like '" + søgning + "%' " +
                "or Adresse like '" + søgning + "%' " +
                "or Alder like '" + søgning + "%'", Use.Con);
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in Use.Dt.Rows)
                {
                    Console.Write(kunde["ID"] + " | ");
                    Console.Write(kunde["Fornavn"] + " ");
                    Console.Write(kunde["Efternavn"] + " | ");
                    Console.Write(kunde["Adresse"] + " | ");
                    Console.Write(kunde["Alder"] + " | ");
                    Console.Write(kunde["Opretdato"]);
                    Console.WriteLine();
                }
            }
        }

        public void OpretBruger(string fornavn, string efternavn, string adresse, int alder)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "insert into Kunder values('" + fornavn + "', '" + efternavn + "', '" + adresse + "', " + alder + ", '" + DateTime.Now.ToString("dd-MM-yyyy") + "')";

                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }
        
        public string VælgKunde(string valgID)
        {
            Console.Clear();
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select * from Kunder", Use.Con);
                Use.Ada.Fill(Use.Dt);

                foreach (DataRow kunde in Use.Dt.Rows)
                {
                    if (valgID == kunde["ID"].ToString())
                    {
                        Console.Write(kunde["ID"] + " | ");
                        Console.Write(kunde["Fornavn"] + " ");
                        Console.Write(kunde["Efternavn"] + " | ");
                        Console.Write(kunde["Adresse"] + " | ");
                        Console.Write(kunde["Alder"] + " | ");
                        Console.Write(kunde["Opretdato"]);
                        Console.WriteLine();
                        return valgID;
                    }
                }
            }
            return "Findes Ikke";
        }

        public void SletKunde(string id)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "delete from Biler where EjerID = " + id;
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();

                sql = "delete from Kunder where ID = " + id;
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        public void RetKunde(string id, string info, string nyInfo)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                sql = "update Kunder set " + info + " = '" + nyInfo + "'  where ID = " + id;
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        public bool FindKunde(int id)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select ID from Kunder", Use.Con);
                Use.Ada.Fill(Use.Dt);

                foreach (DataRow kunde in Use.Dt.Rows)
                {
                    if (id.ToString() == kunde["ID"].ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void KundeBil(string id)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Biler.Opretdato, ID from Biler join Kunder on EjerID = ID", Use.Con);
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("\nRegistreringsnummer | Mærke | Model | Årgang | KM | Brændstoftype | Oprettelsesdato \n");

                foreach (DataRow bil in Use.Dt.Rows)
                {
                    if (id == bil["ID"].ToString())
                    {
                        Console.Write(bil["Regnr"] + " | ");
                        Console.Write(bil["Mærke"] + " ");
                        Console.Write(bil["Model"] + " | ");
                        Console.Write(bil["Årgang"] + " | ");
                        Console.Write(bil["Km"] + " | ");
                        Console.Write(bil["Brændstoftype"] + " | ");
                        Console.Write(bil["Opretdato"]);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
