using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hovedmenu
            while (true)
            {                
                Console.Clear();
                Console.WriteLine("Hovedmenu");
                Console.WriteLine();
                Console.WriteLine("[1] Kunder");
                Console.WriteLine("[2] Biler");
                Console.WriteLine("[ESC] Tryk ESC for at lukke");

                Console.Write("Valg: ");
                ConsoleKey menuValg = Console.ReadKey(true).Key;
                Console.Clear();
                switch (menuValg)
                {
                    case ConsoleKey.D1:
                        Kundemenu();
                        break;
                    case ConsoleKey.D2:
                        Bilmenu();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void Kundemenu()
        {
            while (true)
            {
                Console.Clear();
                Kunder sql = new Kunder();
                Funktioner fejlHånd = new Funktioner();
                Console.WriteLine("Kunde menu");
                Console.WriteLine();
                Console.WriteLine("[1] Opret kunde");
                Console.WriteLine("[2] Søg efter kunde");
                Console.WriteLine("[3] Liste over kunder");
                Console.WriteLine("[ESC] Tryk ESC for at lukke");
                Console.Write("Valg: ");
                ConsoleKey menuValg = Console.ReadKey(true).Key;
                Console.Clear();
                switch (menuValg)
                {
                    case ConsoleKey.D1:
                        fejlHånd.OpretKunde();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Søg efter kunde med vilkårlig info");
                        Console.Write("Søg: ");
                        string search = Console.ReadLine();
                        sql.KundeSøgning(search);
                        fejlHånd.KundeMuligheder();
                        break;

                    case ConsoleKey.D3:
                        sql.KundeListe();
                        fejlHånd.KundeMuligheder();
                        break;

                    // Sender personen tilbage til hovedmenuen
                    case ConsoleKey.Escape:
                        Main(null);
                        break;
                }
            }
        }

        public static void Bilmenu()
        {
            while (true)
            {
                Console.Clear();
                Funktioner fejlHånd = new Funktioner();
                Biler biler = new Biler();
                Console.WriteLine("Bil menu");
                Console.WriteLine();
                Console.WriteLine("[1] Opret bil");
                Console.WriteLine("[2] Søg efter bil");
                Console.WriteLine("[3] Liste over biler");
                Console.WriteLine("[ESC] Tryk ESC for at lukke");
                Console.Write("Valg: ");
                ConsoleKey menuValg = Console.ReadKey(true).Key;
                Console.Clear();
                switch (menuValg)
                {
                    case ConsoleKey.D1:
                        fejlHånd.OpretBil();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Søg efter kunde med vilkårlig info");
                        Console.Write("Søg: ");
                        string bil = Console.ReadLine();
                        biler.BilSøgning(bil);
                        fejlHånd.BilMuligheder();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        biler.BilListe();
                        fejlHånd.BilMuligheder();
                        Console.ReadKey();
                        break;

                    // Sender personen tilbage til hovedmenuen
                    case ConsoleKey.Escape:
                        Main(null);
                        break;
                }
            }
        }
    }
}
