using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Besøget
    {
        private string bil;

        public string Bil
        {
            get { return bil; }
        }

        private string dato;

        public string Dato
        {
            get { return dato; }
        }

        public Besøget(string bil, string dato)
        {
            this.bil = bil;
            this.dato = dato;
        }
    }
}
