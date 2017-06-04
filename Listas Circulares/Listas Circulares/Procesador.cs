using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares
{
    class Procesador
    {
        private Proceso inicio=null, final=null;
        private int tProcesos = 0, cNecesarios = 0, _atendidos = 0;
        public int atencion = 0;

        public Proceso verificarSiHayProcesos()
        {
            return inicio;
        }

        public int tProcesosFinal()
        {
            return tProcesos;
            
        }
        public int ciclosNecesarios()
        {
            return cNecesarios;
        }

        public int atendidos()
        {
            return _atendidos;
        }

        //Agregar m

        public void push(Proceso p)
        {
            if (inicio != null)
            {
                final.siguente = p;
                p.siguente = inicio;
                final = p;
            }
            else
            {
                inicio = p;
                p.siguente = inicio;
                final = p;           
            }
            tProcesos++;
            cNecesarios += p.ciclosDeProceso;
        }
         //Eliminar 
        public void pop(int ciclosRestantes)
        {
            bool val = false;
            if (ciclosRestantes == 0)
            { 
                if(inicio==null)
                    val = true;
                else if (inicio.siguente == inicio)
                {
                    inicio = null;
                    tProcesos--;
                    _atendidos++;                    
                }
                else
                {
                    inicio = inicio.siguente;
                    final.siguente = inicio;
                    tProcesos--;
                    _atendidos++;
                    inicio = inicio.siguente;
                    val = true;
                }
                if(val==false)
                    inicio = inicio.siguente;
            }
        }

        public int procesar()
        {
            int restantes;
            restantes = inicio.ciclosRestantes();
            atencion++;
            cNecesarios--;
            return restantes;
        }      
    }
}
