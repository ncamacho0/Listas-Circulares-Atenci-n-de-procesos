using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_Circulares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Random miProceso = new Random();
        Procesador p1 = new Procesador();

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            int procesadorLibre = 0, contProcesos = 0, ciclosDeAtencion = 0;
            txtResultados.Text = "";
            txtProcesos.Text = "";

            for (int i = 1; i <= 200; i++)
            {
                if (miProceso.Next(0, 101) <= 25)
                {
                    contProcesos++;
                    Proceso procesoNuevo = new Proceso();
                    p1.push(procesoNuevo);
                    txtProcesos.Text += "Proceso #" + contProcesos + " con " + procesoNuevo.ciclosDeProceso + " ciclos " + Environment.NewLine;
                    ciclosDeAtencion = procesoNuevo.ciclosDeProceso;
                }

                if (p1.verificarSiHayProcesos() == null)
                    procesadorLibre++;
                else
                    p1.pop(p1.procesar());
            }
            txtResultados.Text = "Procesador libre: " + procesadorLibre + Environment.NewLine+ "Numero max de procesos: "+contProcesos +Environment.NewLine+ "Procesos pendientes: " + p1.tProcesosFinal() + Environment.NewLine + "Ciclos necesarios " + p1.ciclosNecesarios()+Environment.NewLine+ "Ciclos atendidos"+ p1.atendidos()+ Environment.NewLine;
        }
    }

}
