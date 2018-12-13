using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Kunden
    {
        private string fnavn;

        public string Fnavn
        {
            get { return fnavn; }
        }

        private string enavn;

        public string Enavn
        {
            get { return enavn; }
        }

        private string adresse;

        public string Adresse
        {
            get { return adresse; }
        }

        private int alder;

        public int Alder
        {
            get { return alder; }
        }
        
        public Kunden(string fnavn, string enavn, string adresse, int alder)
        {
            this.fnavn = fnavn;
            this.enavn = enavn;
            this.adresse = adresse;
            this.alder = alder;
        }
    }
}
