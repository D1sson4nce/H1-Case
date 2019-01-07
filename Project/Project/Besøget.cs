using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Besøget
    {
        // En property som holder en string variable af bilen
        private string bil;

        public string Bil
        {
            get { return bil; }
        }

        // En property som holder en string variable af datoen
        private string dato;

        public string Dato
        {
            get { return dato; }
        }

        // En public constructor som samler bilens og datoens værdier
        public Besøget(string bil, string dato)
        {
            this.bil = bil;
            this.dato = dato;
        }
        
    }
}
