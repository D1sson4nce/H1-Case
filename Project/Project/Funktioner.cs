using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Funktioner
    {
        Kunder sql = new Kunder();
        public void OpretKunde()
        {
            Console.WriteLine("Opret en ny kunde");
            Console.Write("Fornavn: ");
            string fnavn = Console.ReadLine();
            foreach(char c in fnavn)
            {
                if (int.TryParse(c.ToString(), out int i))
                {
                    Console.Clear();
                    OpretKunde();
                }
            }
            Console.Write("Efternavn: ");
            string enavn = Console.ReadLine();
            foreach (char c in enavn)
            {
                if (int.TryParse(c.ToString(), out int i))
                {
                    Console.Clear();
                    OpretKunde();
                }
            }
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Alder: ");
            if (int.TryParse(Console.ReadLine(), out int alder)) ;
            else
            {
                Console.Clear();
                OpretKunde();
            }
            sql.OpretBruger(fnavn, enavn, adresse, alder);
        }
    }
}
