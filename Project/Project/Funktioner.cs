using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Funktioner
    {
        #region Kunder
        public void OpretKunde()
        {
            Console.Clear();
            Console.WriteLine("Opret en ny kunde");
            Console.Write("Fornavn: ");
            string fnavn = Console.ReadLine();
            if (fnavn.Length < 1) { OpretKunde(); }
            if (fnavn.Length > 20)
            {
                Console.WriteLine("Maks 20 tegn i fornavn");
                Console.ReadKey();
                OpretKunde();
            }
            foreach(char c in fnavn)
            {
                if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                {
                    Console.WriteLine("Ingen tal i fornavn");
                    Console.ReadKey();
                    OpretKunde();
                }
            }
            Console.Write("Efternavn: ");
            string enavn = Console.ReadLine();
            if (enavn.Length < 1) { OpretKunde(); }
            if (enavn.Length > 40)
            {
                Console.WriteLine("Maks 40 tegn i efternavn");
                Console.ReadKey();
                OpretKunde();
            }
            foreach (char c in enavn)
            {
                if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                {
                    Console.WriteLine("Ingen tal i efternavn");
                    Console.ReadKey();
                    OpretKunde();
                }
            }
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            if (adresse.Length > 80)
            {
                Console.WriteLine("Maks 80 tegn i adresse");
                Console.ReadKey();
                OpretKunde();
            }
            Console.Write("Alder: ");
            if (int.TryParse(Console.ReadLine(), out int alder)) ;
            else
            {
                Console.WriteLine("Ingen bogstaver i alder");
                Console.ReadKey();
                OpretKunde();
            }
            Kunder.OpretBruger(fnavn, enavn, adresse, alder);
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
                    if (nyt.Length > 20)
                    {
                        Console.WriteLine("Maks 20 tegn i fornavn");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    foreach (char c in nyt)
                    {
                        if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                        {
                            Console.WriteLine("Ingen tal i navn");
                            Console.ReadKey();
                            RedigerKunde(id);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    g = "Efternavn";
                    Console.Write("Nyt efternavn: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerKunde(id); }
                    if (nyt.Length > 40)
                    {
                        Console.WriteLine("Maks 40 tegn i efternavn");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    foreach (char c in nyt)
                    {
                        if (int.TryParse(c.ToString(), out int i) || c.ToString() == " ")
                        {
                            Console.WriteLine("Ingen tal i navn");
                            Console.ReadKey();
                            RedigerKunde(id);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    g = "Adresse";
                    Console.Write("Ny adresse: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length > 80)
                    {
                        Console.WriteLine("Maks 80 tegn i adresse");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    break;
                case ConsoleKey.D4:
                    g = "Alder";
                    Console.Write("Ny alder: ");
                    if (int.TryParse(Console.ReadLine(), out int nyalder)) ;
                    else
                    {
                        Console.WriteLine("Ingen bogstaver i alder");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    nyt = nyalder.ToString();
                    break;
            }
            Kunder.RetKunde(id,g,nyt);
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
                kunde = Kunder.VælgKunde(valgKunde);
                if (kunde != "Findes Ikke")
                {
                    Console.WriteLine("[1] Slet kunde");
                    Console.WriteLine("[2] Redigere kunde");
                    Console.WriteLine("[3] Vis Kundens biler");
                    kundeValg = Console.ReadKey(true).Key;
                    switch (kundeValg)
                    {
                        case ConsoleKey.D1:
                            Kunder.SletKunde(kunde);
                            break;
                        case ConsoleKey.D2:
                            RedigerKunde(kunde);
                            break;
                        case ConsoleKey.D3:
                            Kunder.KundeBil(kunde);
                            BilMuligheder();
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
            if (regnr.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("Bil Mærke: ");
            string mærke = Console.ReadLine();
            if (mærke.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("Bil Model: ");
            string model = Console.ReadLine();
            if (model.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
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
            if (brnstoftype.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("EjerID: ");
            if (int.TryParse(Console.ReadLine(), out int ejer)) ;
            else
            {
                OpretBil();
            }
            if (Kunder.FindKunde(ejer))
            {
                Biler.OpretBil(regnr, mærke, model, årgang, km, brnstoftype, ejer);
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
                    if (nyt.Length > 255)
                    {
                        Console.WriteLine("Ikke længere end 255 tegn");
                        Console.ReadKey();
                        RedigerBil(id);
                    }
                    break;
                case ConsoleKey.D2:
                    g = "Mærke";
                    Console.Write("Nyt mærke: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length > 255)
                    {
                        Console.WriteLine("Ikke længere end 255 tegn");
                        Console.ReadKey();
                        RedigerBil(id);
                    }
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
                case ConsoleKey.D3:
                    g = "Model";
                    Console.Write("Ny model: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length > 255)
                    {
                        Console.WriteLine("Ikke længere end 255 tegn");
                        Console.ReadKey();
                        RedigerBil(id);
                    }
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
                    if (nyt.Length > 255)
                    {
                        Console.WriteLine("Ikke længere end 255 tegn");
                        Console.ReadKey();
                        RedigerBil(id);
                    }
                    if (nyt.Length < 1) { RedigerBil(id); }
                    break;
            }
            Biler.RetBil(id, g, nyt);
            Console.Clear();
            Program.Bilmenu();
        }

        public void BilMuligheder()
        {
            string bil;
            ConsoleKey bilValg;
            bool ud = false;
            string valgbil;
            Console.Write("\nVælg Registreringsnummer eller tryk på alt andet for at gå tilbage: ");
            valgbil = Console.ReadLine();
            while (!ud)
            {
                bil = Biler.VælgBil(valgbil);
                if (bil != "Findes Ikke")
                {
                    Console.WriteLine("\n[1] Slet bil");
                    Console.WriteLine("[2] Redigere bil");
                    Console.WriteLine("[3] Opret Besøgstid til bilen");
                    Console.WriteLine("[4] Vis Bilens Værkstedsbesøg");
                    bilValg = Console.ReadKey(true).Key;
                    switch (bilValg)
                    {
                        case ConsoleKey.D1:
                            Biler.SletBil(bil);
                            break;
                        case ConsoleKey.D2:
                            RedigerBil(bil);
                            break;
                        case ConsoleKey.D3:
                            OpretBesøg(bil, true);

                            Console.Clear();
                            Console.WriteLine("Besøgstid er nu oprettet");

                            Console.ReadKey();

                            Console.Clear();
                            break;
                        case ConsoleKey.D4:
                            Besøg.BilBesøg(bil);
                            BilMuligheder();
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }
                }

                ud = true;
            }
        }
        #endregion

        #region Besøg
        public void OpretBesøg(string bilValg, bool retOrOpret)
        {
            int datoDag = 0;
            int datoMåned = 0;
            int datoÅr = 0;
            int datoTimer = 0;
            int datoMinutter = 0;
            bool trueDate = false;
            string dato = null;
            while (trueDate == false)
            {
                do
                {
                    Console.Clear();

                    // Dagen på ugen
                    Console.Write("Skriv dagens dato for besøget [DD]: ");
                    try
                    {
                        datoDag = Convert.ToInt32(Console.ReadLine());
                        if (datoDag > 31 || datoDag < 1)
                        {
                            Console.WriteLine("Dagens dato er indtastet forkert!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Convert.ToString(datoDag);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dagens dato er skrevet forkert!");
                        Console.ReadLine();
                        break;
                    }

                    // Måneden på året
                    Console.Write("Skriv månedens dato for besøget [MM]: ");
                    try
                    {
                        datoMåned = Convert.ToInt32(Console.ReadLine());
                        if (datoMåned > 12 || datoMåned < 1)
                        {
                            Console.WriteLine("Måneden er indtastet forkert!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Convert.ToString(datoMåned);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Måneden er skrevet forkert!");
                        Console.ReadLine();
                        break;
                    }

                    // Året på besøget
                    Console.Write("Skriv året for besøget [YYYY]: ");
                    try
                    {
                        datoÅr = Convert.ToInt32(Console.ReadLine());
                        if (datoÅr > 9999 || datoÅr < 1000)
                        {
                            Console.WriteLine("Året er indtastet forkert!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Convert.ToString(datoÅr);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Året må kun indeholde tal!");
                        Console.ReadLine();
                        break;
                    }


                    // Timer på klokkeslettet
                    Console.Write("Skriv timeslettet for besøget [TT]: ");
                    try
                    {
                        datoTimer = Convert.ToInt32(Console.ReadLine());
                        if (datoTimer > 23 || datoTimer < 0)
                        {
                            Console.WriteLine("Timerne er indtastet forkert!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Convert.ToString(datoTimer);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Timerne er skrevet forkert!");
                        Console.ReadLine();
                        break;
                    }

                    // Minutter på klokkeslettet
                    Console.Write("Skriv minutslettet for besøget [MM]: ");
                    try
                    {
                        datoMinutter = Convert.ToInt32(Console.ReadLine());
                        if (datoMinutter > 59 || datoMinutter < 0)
                        {
                            Console.WriteLine("Datoen er indtastet forkert!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Convert.ToString(datoMinutter);
                            trueDate = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Minutterne er skrevet forkert!");
                        Console.ReadLine();
                        break;
                    }



                    dato = $"{datoDag.ToString("00")}-{datoMåned.ToString("00")}-{datoÅr.ToString("0000")} {datoTimer.ToString("00")}:{datoMinutter.ToString("00")}";

                } while (trueDate == false);

                if (trueDate)
                {
                    if (retOrOpret)
                    {
                        Besøg.OpretBesøg(bilValg, dato);
                    }
                    else
                    {
                        Besøg.RetBesøg(bilValg, dato);
                    }
                }
            }
        }
            

        public void BesøgMuligheder()
        {
            string besøger;
            ConsoleKey besøgValg;
            bool ud = false;
            string valgBesøg;
            Console.Write("\nVælg ID eller tryk på alt andet for at gå tilbage: ");
            valgBesøg = Console.ReadLine();
            while (!ud)
            {
                besøger = Besøg.VælgBesøg(valgBesøg);
                if (besøger != "Findes Ikke")
                {
                    Console.WriteLine("\n[1] Slet Besøg");
                    Console.WriteLine("[2] Redigere Besøg");
                    besøgValg = Console.ReadKey(true).Key;
                    switch (besøgValg)
                    {
                        case ConsoleKey.D1:
                            Besøg.SletBesøg(besøger);
                            break;
                        case ConsoleKey.D2:
                            OpretBesøg(besøger, false);
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
