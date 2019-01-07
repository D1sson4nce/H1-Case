using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Kunden
    {
        // En property som holder en string variable af kundens fornavn
        private string fnavn;

        public string Fnavn
        {
            get { return fnavn; }
        }

        // En property som holder en string variable af kundens efternavn
        private string enavn;

        public string Enavn
        {
            get { return enavn; }
        }

        // En property som holder en string variable af kundens adresse
        private string adresse;

        public string Adresse
        {
            get { return adresse; }
        }

        // En property som holder en int variable af kundens alder
        private int alder;

        public int Alder
        {
            get { return alder; }
        }

        // En public constructor som samler kundens informationer
        public Kunden(string fnavn, string enavn, string adresse, int alder)
        {
            this.fnavn = fnavn;
            this.enavn = enavn;
            this.adresse = adresse;
            this.alder = alder;
        }        
    }
}
