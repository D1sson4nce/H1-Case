using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hovedmenu");
            Console.WriteLine();
            Console.WriteLine("1. Kunder");
            Console.WriteLine("2. Biler");

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
            }

            Console.ReadKey();
        }

        public static void Kundemenu()
        {
            Console.WriteLine("Kunde menu");
            Console.WriteLine();
            Console.WriteLine("1. Opret kunde");
            Console.WriteLine("2. Søg efter kunde");
            Console.WriteLine("3. Liste over kunder");
        }

        public static void Bilmenu()
        {
            Console.WriteLine("Bil menu");
        }
    }
}
