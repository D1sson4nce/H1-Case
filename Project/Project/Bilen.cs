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
            set { regnr = value; }
        }

        private string mærke;

        public string Mærke
        {
            get { return mærke; }
            set { mærke = value; }
        }

        public Bilen (string regnr, string mærke, string model, int årgang, int km, string brnstoftype, int ejer)
        {

        }
    }
}
