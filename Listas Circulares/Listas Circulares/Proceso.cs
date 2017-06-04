using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares
{
    class Proceso
    {
        public Proceso siguente { get; set; }
        private int _ciclosProceso;
        static Random miRandom = new Random();
        public int ciclosDeProceso { get { return _ciclosProceso; } }

        public Proceso()
        {
            _ciclosProceso = miRandom.Next(4, 13);
            siguente = null;
        }

        public int ciclosRestantes()
        {
            _ciclosProceso--;
            return _ciclosProceso;
        }

        public override string ToString()
        {
            return "Ciclos necesarios: " + _ciclosProceso + Environment.NewLine;
        }
    }
}
