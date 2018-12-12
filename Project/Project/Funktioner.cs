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
        Biler bil = new Biler();
        #region Kunder
        public void OpretKunde()
        {
            Console.Clear();
            Console.WriteLine("Opret en ny kunde");
            Console.Write("Fornavn: ");
            string fnavn = Console.ReadLine();
            if (fnavn.Length < 1) { OpretKunde(); }
            foreach(char c in fnavn)
            {
                if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                {
                    OpretKunde();
                }
            }
            Console.Write("Efternavn: ");
            string enavn = Console.ReadLine();
            if (enavn.Length < 1) { OpretKunde(); }
            foreach (char c in enavn)
            {
                if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                {
                    OpretKunde();
                }
            }
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Alder: ");
            if (int.TryParse(Console.ReadLine(), out int alder)) ;
            else
            {
                OpretKunde();
            }
            sql.OpretBruger(fnavn, enavn, adresse, alder);
            Program.Kundemenu();
        }
        public void RedigerKunde(string id)
        {
            Console.WriteLine("Hvad vil du ændre:");
            Console.WriteLine("[1] Fornavn");
            Console.WriteLine("[2] Efternavn");
            Console.WriteLine("[3] Adresse");
            Console.WriteLine("[4] Alder");
            ConsoleKey menuValg = Console.ReadKey(true).Key;
            string nyt = "";
            string g = "";
            switch (menuValg)
            {
                case ConsoleKey.D1:
                    g = "Fornavn";
                    Console.Write("Nyt fornavn: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerKunde(id); }
                    foreach (char c in nyt)
                    {
                        if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                        {
                            RedigerKunde(id);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    g = "Efternavn";
                    Console.Write("Nyt efternavn: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerKunde(id); }
                    foreach (char c in nyt)
                    {
                        if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                        {
                            RedigerKunde(id);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    g = "Adresse";
                    Console.Write("Ny adresse: ");
                    nyt = Console.ReadLine();
                    break;
                case ConsoleKey.D4:
                    g = "Alder";
                    Console.Write("Ny alder: ");
                    if (int.TryParse(Console.ReadLine(), out int nyalder)) ;
                    else
                    {
                        RedigerKunde(id);
                    }
                    nyt = nyalder.ToString();
                    break;
            }
            sql.RetKunde(id,g,nyt);
        }
        #endregion
        public void OpretBil()
        {
            Console.Clear();
            Console.WriteLine("Opret en ny bil");
            Console.Write("Registreringsnummer: ");
            string regnr = Console.ReadLine();
            Console.Write("Bil Mærke: ");
            string mærke = Console.ReadLine();
            Console.Write("Bil Model: ");
            string model = Console.ReadLine();
            Console.Write("Årgang: ");
            if (int.TryParse(Console.ReadLine(), out int årgang)) ;
            else
            {
                OpretBil();
            }
            Console.Write("Kilometer: ");
            if (double.TryParse(Console.ReadLine(), out double km)) ;
            else
            {
                OpretBil();
            }
            Console.Write("Brændstofstype: ");
            string brnstoftype = Console.ReadLine();
            Console.Write("EjerID: ");
            if (int.TryParse(Console.ReadLine(), out int ejer)) ;
            else
            {
                OpretBil();
            }
            if (sql.FindKunde(ejer))
            {
                bil.OpretBil(regnr, mærke, model, årgang, km, brnstoftype, ejer);
            }
            else
            {
                Console.WriteLine("Kunden findes ikke");
                Console.ReadKey(true);
                Program.Bilmenu();
            }
        }
    }
}
