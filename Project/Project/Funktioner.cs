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
        Biler Bil = new Biler();
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
            Console.Clear();
            Program.Kundemenu();
        }
        public void RedigerKunde(string id)
        {
            Console.Clear();
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
            Console.Clear();
            Program.Kundemenu();
        }
        public void KundeMuligheder()
        {
            string kunde;
            ConsoleKey kundeValg;
            bool ud = false;
            string valgKunde;
            Console.Write("\nVælg ID eller tryk på alt andet for at gå tilbage: ");
            valgKunde = Console.ReadLine();
            while (!ud)
            {
                kunde = sql.VælgKunde(valgKunde);
                if (kunde != "Findes Ikke")
                {
                    Console.WriteLine("[S] Slet kunde");
                    Console.WriteLine("[R] Redigere kunde");
                    Console.WriteLine("[B] Kundens biler");
                    kundeValg = Console.ReadKey(true).Key;
                    switch (kundeValg)
                    {
                        case ConsoleKey.S:
                            sql.SletKunde(kunde);
                            break;
                        case ConsoleKey.R:
                            RedigerKunde(kunde);
                            break;
                        case ConsoleKey.B:
                            sql.KundeBil(kunde);

                            Console.ReadKey();
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }
                }

                ud = true;
            }
        }
        #endregion
        #region Biler
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
                Bil.OpretBil(regnr, mærke, model, årgang, km, brnstoftype, ejer);
            }
            else
            {
                Console.WriteLine("Kunden findes ikke");
                Console.ReadKey(true);
                Program.Bilmenu();
            }
            Console.Clear();
            Program.Bilmenu();
        }
        public void RedigerBil(string id)
        {
            Console.Clear();
            Console.WriteLine("Hvad vil du ændre:");
            Console.WriteLine("[1] Registreringsnummer");
            Console.WriteLine("[2] Mærke");
            Console.WriteLine("[3] Model");
            Console.WriteLine("[4] Årgang");
            Console.WriteLine("[5] Kilometer");
            Console.WriteLine("[6] Brændstofstype");
            ConsoleKey menuValg = Console.ReadKey(true).Key;
            string nyt = "";
            string g = "";
            switch (menuValg)
            {
                case ConsoleKey.D1:
                    g = "Regnr";
                    Console.Write("Nyt regnr: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
                case ConsoleKey.D2:
                    g = "Mærke";
                    Console.Write("Nyt mærke: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
                case ConsoleKey.D3:
                    g = "Model";
                    Console.Write("Ny model: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
                case ConsoleKey.D4:
                    g = "Årgang";
                    Console.Write("Ny årgang: ");
                    if (int.TryParse(Console.ReadLine(), out int nyå)) ;
                    else
                    {
                        RedigerBil(id);
                    }
                    nyt = nyå.ToString();
                    break;
                case ConsoleKey.D5:
                    g = "Kilometer";
                    Console.Write("Ny antal km: ");
                    if (int.TryParse(Console.ReadLine(), out int nykm)) ;
                    else
                    {
                        RedigerBil(id);
                    }
                    nyt = nykm.ToString();
                    break;
                case ConsoleKey.D6:
                    g = "Brændstoftype";
                    Console.Write("Ny brændstoftype: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
            }
            Bil.RetBil(id, g, nyt);
            Console.Clear();
            Program.Bilmenu();
        }
        public void BilMuligheder()
        {
            string bil;
            ConsoleKey kundeValg;
            bool ud = false;
            string valgbil;
            Console.Write("\nVælg Registreringsnummer eller tryk på alt andet for at gå tilbage: ");
            valgbil = Console.ReadLine();
            while (!ud)
            {
                bil = Bil.VælgBil(valgbil);
                if (bil != "Findes Ikke")
                {
                    Console.WriteLine("[S] Slet bil");
                    Console.WriteLine("[R] Redigere bil");
                    Console.WriteLine("[B] Kundens biler");
                    kundeValg = Console.ReadKey(true).Key;
                    switch (kundeValg)
                    {
                        case ConsoleKey.S:
                            Bil.SletBil(bil);
                            break;
                        case ConsoleKey.R:
                            RedigerBil(bil);
                            break;
                        case ConsoleKey.B:
                            Bil.KundeBil(bil);

                            Console.ReadKey();
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }
                }

                ud = true;
            }
        }
        #endregion

    }
}
