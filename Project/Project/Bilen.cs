using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Bilen
    {
        // En property som holder en string variable af bilens registreringsnummer
        private string regnr;

        public string Regnr
        {
            get { return regnr; }
        }

        // En property som holder en string variable af bilens mærke
        private string mærke;

        public string Mærke
        {
            get { return mærke; }
        }

        // En property som holder en string variable af bilens model
        private string model;

        public string Model
        {
            get { return model; }
        }

        // En property som holder en int variable af bilens årgang
        private int årgang;

        public int Årgang
        {
            get { return årgang; }
        }

        // En property som holder en double variable af hvor langt bilen har kørt
        private double km;

        public double Km
        {
            get { return km; }
        }

        // En property som holder en string variable af bilens brændstofstype
        private string brnstoftype;

        public string Brnstoftype
        {
            get { return brnstoftype; }
        }

        // En property som holder en int variable af bilens ejer ID
        private int ejer;

        public int Ejer
        {
            get { return ejer; }
        }

        // En public constructor som samler alle bilens informationer
        public Bilen (string regnr, string mærke, string model, int årgang, double km, string brnstoftype, int ejer)
        {
            this.regnr = regnr;
            this.mærke = mærke;
            this.model = model;
            this.årgang = årgang;
            this.km = km;
            this.brnstoftype = brnstoftype;
            this.ejer = ejer;
        }
        
    }
}
