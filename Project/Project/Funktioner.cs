using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Funktioner
    {
        #region Kunder
        public void OpretKunde() // metode der bruges til at oprette kunder
        {
            Console.Clear();
            Console.WriteLine("Opret en ny kunde");
            Console.Write("Fornavn: ");
            string fnavn = Console.ReadLine();
            if (fnavn.Length < 1) { OpretKunde(); } //her tjekker den om fornavn er fin længde, både over 0 og under 20
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
                    //her tjekker den om der er tal i strengen, ved at gå igennem alle chars
                    Console.WriteLine("Ingen tal i fornavn");
                    Console.ReadKey();
                    OpretKunde();
                }
            }
            Console.Write("Efternavn: ");
            string enavn = Console.ReadLine();
            if (enavn.Length < 1) { OpretKunde(); } //her tjekker den om efternavn er fin længde, både over 0 og under 40
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
                    //her tjekker den om der er tal i strengen, ved at gå igennem alle chars
                    Console.WriteLine("Ingen tal i efternavn");
                    Console.ReadKey();
                    OpretKunde();
                }
            }
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            if (adresse.Length < 1) { OpretKunde(); }
            if (adresse.Length > 80) //her tjekker den om adressen er fin længde
            {
                Console.WriteLine("Maks 80 tegn i adresse");
                Console.ReadKey();
                OpretKunde();
            }
            Console.Write("Alder: ");
            if (int.TryParse(Console.ReadLine(), out int alder)) ; //her tjekker den om der er bogstaver i tallet
            else
            {
                Console.WriteLine("Ingen bogstaver i alder");
                Console.ReadKey();
                OpretKunde();
            }
            Kunder.OpretBruger(fnavn, enavn, adresse, alder); //kalder metoden OpretBruger i Kunder klassen, med de informationer brugeren har givet
            Console.Clear();
            Program.Kundemenu(); //går tilbage til kundemenuen
        }

        public void RedigerKunde(string id)
        {
            //dette er en "menu" hvor man har flere valg
            Console.Clear();
            Console.WriteLine("Hvad vil du ændre:");
            Console.WriteLine("[1] Fornavn");
            Console.WriteLine("[2] Efternavn");
            Console.WriteLine("[3] Adresse");
            Console.WriteLine("[4] Alder");
            ConsoleKey menuValg = Console.ReadKey(true).Key; //den læser hvilken tast man trykker, og laver det til en variabel
            string nyt = "";
            string g = "";
            switch (menuValg)
            {
                case ConsoleKey.D1: //hvilken tast man har trykket
                    g = "Fornavn";
                    Console.Write("Nyt fornavn: ");
                    nyt = Console.ReadLine();
                    if (nyt.Length < 1) { RedigerKunde(id); } //her tjekker den om fornavn er fin længde, både over 0 og under 20
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
                            //her tjekker den om der er tal i strengen, ved at gå igennem alle chars
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
                    if (nyt.Length < 1) { RedigerKunde(id); }//her tjekker den om efternavn er fin længde, både over 0 og under 40
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
                            //her tjekker den om der er tal i strengen, ved at gå igennem alle chars
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
                    if (nyt.Length < 1) { RedigerKunde(id); }
                    if (nyt.Length > 80) //her tjekker den om adressen er fin længde
                    {
                        Console.WriteLine("Maks 80 tegn i adresse");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    break;
                case ConsoleKey.D4:
                    g = "Alder";
                    Console.Write("Ny alder: ");
                    if (int.TryParse(Console.ReadLine(), out int nyalder)) ;//her tjekker den om der er bogstaver i tallet
                    else
                    {
                        Console.WriteLine("Ingen bogstaver i alder");
                        Console.ReadKey();
                        RedigerKunde(id);
                    }
                    nyt = nyalder.ToString();
                    break;
            }
            Kunder.RetKunde(id,g,nyt); // kalder metoden RetBruger i Kunder klassen, med de informationer brugeren har givet
            Console.Clear();
            Program.Kundemenu(); //går tilbage til kundemenuen
        }

        public void KundeMuligheder()
        {
            string kunde;
            ConsoleKey kundeValg;
            bool ud = false;
            string valgKunde;
            Console.Write("\nVælg ID eller tryk på alt andet for at gå tilbage: ");
            valgKunde = Console.ReadLine(); //brugerens valg
            while (!ud)
            {
                kunde = Kunder.VælgKunde(valgKunde);
                if (kunde != "Findes Ikke")
                {
                    Console.WriteLine("[1] Slet kunde");
                    Console.WriteLine("[2] Redigere kunde");
                    Console.WriteLine("[3] Vis Kundens biler");
                    kundeValg = Console.ReadKey(true).Key; //hvilken tast brugeren trykker på, som bliver brugt til at vælge
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

                ud = true; //går ud af loopet med denne bool
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
            if (regnr.Length < 1) { OpretBil(); }//her tjekker den om strengen er fin længde, både over 0 og under 255
            if (regnr.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("Bil Mærke: ");
            string mærke = Console.ReadLine();
            if (mærke.Length < 1) { OpretBil(); }//her tjekker den om strengen er fin længde, både over 0 og under 255
            if (mærke.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("Bil Model: ");
            string model = Console.ReadLine();
            if (model.Length < 1) { OpretBil(); }//her tjekker den om strengen er fin længde, både over 0 og under 255
            if (model.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("Årgang: ");
            if (int.TryParse(Console.ReadLine(), out int årgang)) ; //tjekker om der er bogstaver i tallet
            else
            {
                OpretBil();
            }
            Console.Write("Kilometer: ");
            if (double.TryParse(Console.ReadLine(), out double km)) ;//tjekker om der er bogstaver i tallet
            else
            {
                OpretBil();
            }
            Console.Write("Brændstofstype: ");
            string brnstoftype = Console.ReadLine();
            if (brnstoftype.Length < 1) { OpretBil(); }//her tjekker den om strengen er fin længde, både over 0 og under 255
            if (brnstoftype.Length > 255)
            {
                Console.WriteLine("Ikke længere end 255 tegn");
                Console.ReadKey();
                OpretBil();
            }
            Console.Write("EjerID: ");
            if (int.TryParse(Console.ReadLine(), out int ejer)) ;//tjekker om der er bogstaver i tallet
            else
            {
                OpretBil();
            }
            if (Kunder.FindKunde(ejer))//tjekker om der findes en kunde med det givne ejer id
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
            Program.Bilmenu(); //går tilbage til Bilmenu
        }

        public void RedigerBil(string id)
        {
            string g = null, nyt = null;
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Hvad vil du ændre:");
                Console.WriteLine("[1] Registreringsnummer");
                Console.WriteLine("[2] Mærke");
                Console.WriteLine("[3] Model");
                Console.WriteLine("[4] Årgang");
                Console.WriteLine("[5] Kilometer");
                Console.WriteLine("[6] Brændstofstype");
                ConsoleKey menuValg = Console.ReadKey(true).Key;//den læser hvilken tast man trykker, og laver det til en variabel, som bliver brugt til at vælge
                nyt = "";
                g = "";
                switch (menuValg)
                {
                    case ConsoleKey.D1:
                        g = "Regnr";
                        Console.Write("Nyt regnr: ");
                        nyt = Console.ReadLine();
                        if (nyt.Length < 1) { RedigerBil(id); }//her tjekker den om strengen er fin længde, både over 0 og under 255
                        if (nyt.Length > 255)
                        {
                            Console.WriteLine("Ikke længere end 255 tegn");
                            Console.ReadKey();
                            RedigerBil(id);
                        }

                        done = true;
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
                        if (nyt.Length < 1) { RedigerBil(id); }//her tjekker den om strengen er fin længde, både over 0 og under 255

                        done = true;
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
                        if (nyt.Length < 1) { RedigerBil(id); }//her tjekker den om strengen er fin længde, både over 0 og under 255

                        done = true;
                        break;
                    case ConsoleKey.D4:
                        g = "Årgang";
                        Console.Write("Ny årgang: ");
                        if (int.TryParse(Console.ReadLine(), out int nyå)) ;//her tjekker den om der er bogstaver i tallet
                        else
                        {
                            RedigerBil(id);
                        }
                        nyt = nyå.ToString();
                        done = true;
                        break;
                    case ConsoleKey.D5:
                        g = "Kilometer";
                        Console.Write("Ny antal km: ");
                        if (int.TryParse(Console.ReadLine(), out int nykm)) ;//her tjekker den om der er bogstaver i tallet
                        else
                        {
                            RedigerBil(id);
                        }
                        nyt = nykm.ToString();
                        done = true;
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
                        if (nyt.Length < 1) { RedigerBil(id); }//her tjekker den om strengen er fin længde, både over 0 og under 255
                        done = true;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
            Biler.RetBil(id, g, nyt); //finder bilen med id og giver den ny information
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
                bil = Biler.VælgBil(valgbil); //her finder den bilen ud fra hvad man har skrevet
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
                            BesøgMuligheder();
                            break;
                        case ConsoleKey.Escape:
                            break;
                    }
                }                
                ud = true; //går ud af loopet med boolen
            }
            Program.Bilmenu();
        }
        #endregion

        #region Besøg
        public void OpretBesøg(string bilValg, bool retOrOpret)
        {
            bool trueDate = false;
            string dato = null;

            Console.Clear();
            if (!trueDate)
            {
                // Dagen på ugen
                Console.Write("Skriv dagens dato for besøget [DD]: ");
                if (int.TryParse(Console.ReadLine(), out int datoDag))//tjekker om tallet indeholder bogstaver
                {
                    if (datoDag > 31 || datoDag < 1) //tjekker om tallet er i orden
                    {
                        Console.WriteLine("Dagens dato er indtastet forkert!");
                        Console.ReadKey();
                        OpretBesøg(bilValg, retOrOpret);
                    }
                }
                else
                {
                    Console.WriteLine("Dagens dato er indtastet forkert!");
                    Console.ReadKey();
                    OpretBesøg(bilValg, retOrOpret);
                }

                // Måneden på året
                Console.Write("Skriv månedens dato for besøget [MM]: ");
                if (int.TryParse(Console.ReadLine(), out int datoMåned))//tjekker om tallet indeholder bogstaver
                {
                    if (datoMåned > 12 || datoMåned < 1)//tjekker om tallet er i orden
                    {
                        Console.WriteLine("Måneden er indtastet forkert!");
                        Console.ReadKey();
                        OpretBesøg(bilValg, retOrOpret);
                    }
                }
                else
                {
                    Console.WriteLine("Måneden er indtastet forkert!");
                    Console.ReadKey();
                    OpretBesøg(bilValg, retOrOpret);
                }

                // Året på besøget
                Console.Write("Skriv året for besøget [YYYY]: ");
                if (int.TryParse(Console.ReadLine(), out int datoÅr))//tjekker om tallet indeholder bogstaver
                {
                    if (datoÅr > 9999 || datoÅr < 1000)//tjekker om tallet er i orden
                    {
                        Console.WriteLine("Året er indtastet forkert!");
                        Console.ReadKey();
                        OpretBesøg(bilValg, retOrOpret);
                    }
                }
                else
                {
                    Console.WriteLine("Året er indtastet forkert!");
                    Console.ReadKey();
                    OpretBesøg(bilValg, retOrOpret);
                }

                // Timer på klokkeslettet
                Console.Write("Skriv timeslettet for besøget [TT]: ");
                if (int.TryParse(Console.ReadLine(), out int datoTimer))//tjekker om tallet indeholder bogstaver
                {
                    if (datoTimer > 23 || datoTimer < 0)//tjekker om tallet er i orden
                    {
                        Console.WriteLine("Timerne er indtastet forkert!");
                        Console.ReadKey();
                        OpretBesøg(bilValg, retOrOpret);
                    }
                }
                else
                {
                    Console.WriteLine("Timerne er indtastet forkert!");
                    Console.ReadKey();
                    OpretBesøg(bilValg, retOrOpret);
                }

                // Minutter på klokkeslettet
                Console.Write("Skriv minutslettet for besøget [MM]: ");
                if (int.TryParse(Console.ReadLine(), out int datoMinutter))//tjekker om tallet indeholder bogstaver
                {
                    if (datoMinutter > 59 || datoMinutter < 0)//tjekker om tallet er i orden
                    {
                        Console.WriteLine("Minutter er indtastet forkert!");
                        Console.ReadKey();
                        OpretBesøg(bilValg, retOrOpret);
                    }
                }
                else
                {
                    Console.WriteLine("Minutter er indtastet forkert!");
                    Console.ReadKey();
                    OpretBesøg(bilValg, retOrOpret);
                }
                dato = $"{datoDag.ToString("00")}-{datoMåned.ToString("00")}-{datoÅr.ToString("0000")} {datoTimer.ToString("00")}:{datoMinutter.ToString("00")}";
                trueDate = true; //hvis man er nået hertil så er alt godt
            }
            
            if (trueDate && retOrOpret || !retOrOpret) //hvis man har indtastet information
            {
                //opretter eller retter ud fra boolen retOrOpret
                if (retOrOpret)
                {
                    Besøg.OpretBesøg(bilValg, dato);
                }
                else
                {
                    Besøg.RetBesøg(bilValg, dato);
                }
            }
            Console.WriteLine("Besøgstid er nu oprettet");
            Console.ReadKey();
            Console.Clear();
            Biler.BilListe();
            BilMuligheder(); //går tilbage til menuen
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
                besøger = Besøg.VælgBesøg(valgBesøg); //finder besøg som bruger søger efter
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
