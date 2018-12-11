using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = DateTime.Now.ToString("dd-MM-yyyy");
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine(time);
                Console.WriteLine("Hovedmenu");
                Console.WriteLine();
                Console.WriteLine("1. Kunder");
                Console.WriteLine("2. Biler");
                Console.WriteLine("3. Tryk ESC for at lukke");

                Console.Write("Valg: ");
                ConsoleKey menuValg = Console.ReadKey().Key;
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
                        return;
                }
            }
        }

        public static void Kundemenu()
        {
            Kunder sql = new Kunder();
            Console.WriteLine("Kunde menu");
            Console.WriteLine();
            Console.WriteLine("1. Opret kunde");
            Console.WriteLine("2. Søg efter kunde");
            Console.WriteLine("3. Liste over kunder");
            Console.WriteLine("4. Tryk ESC for at lukke");
            Console.Write("Valg: ");
            ConsoleKey menuValg = Console.ReadKey().Key;
            Console.Clear();
            switch (menuValg)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("");
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("Søg efter kunde med vilkårlig info");
                    Console.Write("Søg: ");
                    string search = Console.ReadLine();
                    sql.KundeSøgning(search);
                    Console.ReadKey();
                    break;

                case ConsoleKey.D3:
                    sql.KundeListe();
                    Console.ReadKey();
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }

        public static void Bilmenu()
        {
            Kunder sql = new Kunder();
            Console.WriteLine("Bil menu");
            Console.WriteLine();
            Console.WriteLine("1. Opret bil");
            Console.WriteLine("2. Søg efter bil");
            Console.WriteLine("3. Liste over biler");
            Console.WriteLine("4. Tryk ESC for at lukke");
            Console.Write("Valg: ");
            ConsoleKey menuValg = Console.ReadKey().Key;
            Console.Clear();
            switch (menuValg)
            {
                case ConsoleKey.D1:

                    break;

                case ConsoleKey.D2:

                    break;

                case ConsoleKey.D3:

                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
    }
}
