﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    static class Biler
    {

        static public void BilListe()
        {
            // en metode der viser alle biler i databasen
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1)) //bruger en streng fra Use klassen til at åbne databasen
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Fornavn, Efternavn, Biler.Opretdato from Biler join Kunder on EjerID = ID order by EjerID", Use.Con);
                Use.Ada.Fill(Use.Dt); // fylder et data table med informationerne fra databasen
                Console.WriteLine("Registreringsnummer | Mærke | Model | Årgang | KM | Brændstoftype | Ejer \n");

                foreach (DataRow bil in Use.Dt.Rows) //udskriver alle informationerne per bil fra data table Dt
                {
                    Console.Write(bil["Regnr"] + " | ");
                    Console.Write(bil["Mærke"] + " | ");
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

        static public void OpretBil(string regnr, string mærke, string model, int årgang, double km, string brnstoftype, int ejer)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1)) //bruger en streng fra Use klassen til at åbne databasen
            {
                Bilen bilen = new Bilen(regnr, mærke, model, årgang, km, brnstoftype, ejer);

                Use.Con.Open();
                Use.Ada = new SqlDataAdapter("select Regnr from Biler", Use.Con);
                Use.Ada.Fill(Use.Dt);
                bool bilFindes = false;
                // Tjekker om en bil findes i databasen, før bilen kan blive oprettet
                foreach (DataRow bil in Use.Dt.Rows)
                {
                    if (regnr == bil["Regnr"].ToString())
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
                    Use.Ada = new SqlDataAdapter();

                    sql = $"insert into Biler values ('{bilen.Regnr}', '{bilen.Mærke}', '{bilen.Model}', {bilen.Årgang}, {bilen.Km}, '{bilen.Brnstoftype}', {bilen.Ejer}, '{DateTime.Now.ToString("dd-MM-yyyy")}')";

                    Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                    Use.Ada.InsertCommand.ExecuteNonQuery();
                }
                // Hvis bilen findes i databasen, skal den oplyse det og afbryde aktionen
                else
                {
                    Console.WriteLine("Fejl. Registreringsnummeret er allerede registreret i databasen.");
                }
            }

            Console.ReadKey();
        }

        static public void BilSøgning(string bilSøg)
        {
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                Use.Ada = new SqlDataAdapter($"select * from Biler where Regnr like '{bilSøg}%'" +
                                             $"or Mærke like '{bilSøg}%'" +
                                             $"or Model like '{bilSøg}%'" +
                                             $"or Årgang like '{bilSøg}%'" +
                                             $"or Km like '{bilSøg}%'" +
                                             $"or Brændstoftype like '{bilSøg}%'" +
                                             $"or EjerID like '{bilSøg}%'", Use.Con);
                Use.Ada.Fill(Use.Dt);
                Console.WriteLine("Regnr | Mærke | Model | Årgang | Kilometer | Brændstoftype | Ejer ID | Oprettelses dato");
                //udskriver information om den bil brugeren har søgt efter
                foreach (DataRow bil in Use.Dt.Rows)
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

        static public string VælgBil(string valgID)
        {
            Console.Clear();
            Use.Dt = new DataTable();
            using (Use.Con = new SqlConnection(Use.StrCon1)) //bruger en streng fra Use klassen til at åbne databasen
            {
                Use.Con.Open();
                //vælger data fra databasen ved at bruge denne kommando i SQL
                Use.Ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, Fornavn, Efternavn, Biler.Opretdato from Biler join Kunder on EjerID = ID", Use.Con);
                Use.Ada.Fill(Use.Dt);

                foreach (DataRow bil in Use.Dt.Rows)
                {
                    if (valgID == bil["Regnr"].ToString()) //hvis en bil med indtastet regnr findes så udskrives informationen om bilen
                    {
                        Console.Write(bil["Regnr"] + " | ");
                        Console.Write(bil["Mærke"] + " | ");
                        Console.Write(bil["Model"] + " | ");
                        Console.Write(bil["Årgang"] + " | ");
                        Console.Write(bil["Km"] + " | ");
                        Console.Write(bil["Brændstoftype"] + " | ");
                        Console.Write(bil["Opretdato"] + " | ");
                        Console.WriteLine();
                        return valgID;
                    }
                }
            }
            return "Findes Ikke";
        }

        static public void SletBil(string regnr)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();

                //sletter bilen med det givne regnr fra Værkstedsophold
                sql = "delete from Værkstedsophold where Bil = '" + regnr + "'";
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();

                //sletter bilen med det givne regnr fra Biler
                sql = "delete from Biler where Regnr = '" + regnr + "'";
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
            }
        }

        static public void RetBil(string id, string info, string nyInfo)
        {
            using (Use.Con = new SqlConnection(Use.StrCon1))
            {
                Use.Con.Open();
                string sql = "";
                Use.Ada = new SqlDataAdapter();
                if (info == "Regnr")
                {
                    Use.Dt = new DataTable();
                    Use.Ada = new SqlDataAdapter("select Regnr, Mærke, Model, Årgang, Km, Brændstoftype, EjerID from Biler where Regnr = '" + id + "'", Use.Con);
                    Use.Ada.Fill(Use.Dt);

                    foreach (DataRow bil in Use.Dt.Rows) //udskriver alle informationerne per bil fra data table Dt
                    {
                        string mærke = bil["Mærke"].ToString();
                        string model = bil["Model"].ToString();
                        string strÅrgang = bil["Årgang"].ToString();
                        string strKm = bil["Km"].ToString();
                        string brnstof = bil["Brændstoftype"].ToString();
                        string strEjerId = bil["EjerID"].ToString();
                        int årgang = Convert.ToInt32(strÅrgang);
                        double km = Convert.ToDouble(strKm);
                        int ejerId = Convert.ToInt32(strEjerId);

                        sql = $"insert into Biler values ('{nyInfo}', '{mærke}', '{model}', {årgang}, {km}, '{brnstof}', {ejerId}, '{DateTime.Now.ToString("dd-MM-yyyy")}')";
                        Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                        Use.Ada.InsertCommand.ExecuteNonQuery();
                    }

                    Use.Ada = new SqlDataAdapter("select Regnr from Biler where Regnr = '" + id + "'", Use.Con);
                    Use.Ada.Fill(Use.Dt);

                    foreach (DataRow bilnr in Use.Dt.Rows)
                    {
                        sql = "update Værkstedsophold set Bil = '" + nyInfo + "'";
                        Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                        Use.Ada.InsertCommand.ExecuteNonQuery();
                    }

                    sql = "delete from Biler where Regnr = '" + id + "'";
                    Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                    Use.Ada.InsertCommand.ExecuteNonQuery();
                }
                else
                {
                //opdaterer bilen med det givne information ud fra regnr
                sql = "update Biler set " + info + " = '" + nyInfo + "'  where Regnr = '" + id + "'";
                Use.Ada.InsertCommand = new SqlCommand(sql, Use.Con);
                Use.Ada.InsertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
