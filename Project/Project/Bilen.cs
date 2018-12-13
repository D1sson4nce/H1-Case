using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Bilen
    {
        private string regnr;

        public string Regnr
        {
            get { return regnr; }
        }

        private string mærke;

        public string Mærke
        {
            get { return mærke; }
        }

        private string model;

        public string Model
        {
            get { return model; }
        }

        private int årgang;

        public int Årgang
        {
            get { return årgang; }
        }

        private double km;

        public double Km
        {
            get { return km; }
        }

        private string brnstoftype;

        public string Brnstoftype
        {
            get { return brnstoftype; }
        }

        private int ejer;

        public int Ejer
        {
            get { return ejer; }
        }

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
