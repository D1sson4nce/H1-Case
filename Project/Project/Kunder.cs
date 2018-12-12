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

        public void KundeListe()
        {
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select * from Kunder", use.con);
                use.ada.Fill(use.dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in use.dt.Rows)
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
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select * from Kunder where ID like '" + søgning + "%' " +
                "or Fornavn like '" + søgning + "%' " +
                "or Efternavn like '" + søgning + "%' " +
                "or Adresse like '" + søgning + "%' " +
                "or Alder like '" + søgning + "%' " + 
                "or Opretdato like '" + søgning + "%'", use.con);
                use.ada.Fill(use.dt);
                Console.WriteLine("ID | Navn | Adresse | Alder | Oprettelsesdato \n");

                foreach (DataRow kunde in use.dt.Rows)
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
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                string sql = "";
                use.ada = new SqlDataAdapter();

                sql = "insert into Kunder values('" + fornavn + "', '" + efternavn + "', '" + adresse + "', " + alder + ", '" + DateTime.Now.ToString("dd-MM-yyyy") + "')";

                use.ada.InsertCommand = new SqlCommand(sql, use.con);
                use.ada.InsertCommand.ExecuteNonQuery();
            }
        }
        
        public string VælgKunde(string valgID)
        {
            Console.Clear();
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select * from Kunder", use.con);
                use.ada.Fill(use.dt);

                foreach (DataRow kunde in use.dt.Rows)
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
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                string sql = "";
                use.ada = new SqlDataAdapter();

                sql = "delete from Biler where EjerID = " + id;
                use.ada.InsertCommand = new SqlCommand(sql, use.con);
                use.ada.InsertCommand.ExecuteNonQuery();

                sql = "delete from Kunder where ID = " + id;
                use.ada.InsertCommand = new SqlCommand(sql, use.con);
                use.ada.InsertCommand.ExecuteNonQuery();
            }
        }

        public void RetKunde(string id, string info, string nyInfo)
        {
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                string sql = "";
                use.ada = new SqlDataAdapter();

                sql = "update Kunder set " + info + " = '" + nyInfo + "'  where ID = " + id;
                use.ada.InsertCommand = new SqlCommand(sql, use.con);
                use.ada.InsertCommand.ExecuteNonQuery();

                
            }
        }

        public bool FindKunde(int id)
        {
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select ID from Kunder", use.con);
                use.ada.Fill(use.dt);

                foreach (DataRow kunde in use.dt.Rows)
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
            use.dt = new DataTable();
            using (use.con = new SqlConnection(use.StrCon1))
            {
                use.con.Open();
                use.ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Biler.Opretdato, ID from Biler join Kunder on EjerID = ID", use.con);
                use.ada.Fill(use.dt);
                Console.WriteLine("Registreringsnummer | Mærke | Model | Årgang | KM | Brændstoftype \n");

                foreach (DataRow bil in use.dt.Rows)
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
