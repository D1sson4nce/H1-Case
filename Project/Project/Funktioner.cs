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
            Console.Write("Efternavn: ");
            string enavn = Console.ReadLine();
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Alder: ");
            int.TryParse(Console.ReadLine(), out int alder);
            //int alder = Convert.ToInt32(Console.ReadLine());
            sql.OpretBruger(fnavn, enavn, adresse, alder);
        }
    }
}
