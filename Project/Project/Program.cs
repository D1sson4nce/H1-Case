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

            Console.WriteLine("1. Kunder");
            Console.WriteLine("2. Biler");

            int menuValg = Convert.ToInt32(Console.ReadKey().Key);
            switch (menuValg)
            {
                case 1:
                    Console.WriteLine("Kunde menu");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Bil menu");
                    Console.ReadKey();
                    break;

            }

            Console.ReadKey();
        }
    }
}
