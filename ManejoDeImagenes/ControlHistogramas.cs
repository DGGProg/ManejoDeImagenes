using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejoDeImagenes
{
    public partial class ControlHistogramas : UserControl
    {

        private int[][] canales;

        public int[][] Canales
        {
            get
            {
                return canales;
            }
            set
            {
                if (value != null)
                {
                    canales = value;
                }
            }
        }

        public ControlHistogramas()
        {
            InitializeComponent();
        }

        public int GeneraHistograma()
        {
            int error=0;

            int[] R = canales[0];
            int[] G = canales[1];
            int[] B = canales[2];

            int maximo = 0;
            if (System.Linq.Enumerable.Max(R) > System.Linq.Enumerable.Max(G))
            {
                maximo = System.Linq.Enumerable.Max(R);
            }
            else
            {
                maximo = System.Linq.Enumerable.Max(G);
            }
            if (maximo < System.Linq.Enumerable.Max(B))
            {
                maximo = System.Linq.Enumerable.Max(B);
            }

            Histograma_1.Series.Clear();
            Histograma_2.Series.Clear();
            Histograma_3.Series.Clear();

            Histograma_1.ChartAreas[0].AxisY.Minimum = 0;
            Histograma_1.ChartAreas[0].AxisY.Maximum = maximo;
            Histograma_2.ChartAreas[0].AxisY.Minimum = 0;
            Histograma_2.ChartAreas[0].AxisY.Maximum = maximo;
            Histograma_3.ChartAreas[0].AxisY.Minimum = 0;
            Histograma_3.ChartAreas[0].AxisY.Maximum = maximo;
            Histograma_1.ChartAreas[0].AxisX.Minimum = 0;
            Histograma_1.ChartAreas[0].AxisX.Maximum = 255;
            Histograma_2.ChartAreas[0].AxisX.Minimum = 0;
            Histograma_2.ChartAreas[0].AxisX.Maximum = 255;
            Histograma_3.ChartAreas[0].AxisX.Minimum = 0;
            Histograma_3.ChartAreas[0].AxisX.Maximum = 255;

            Histograma_1.DataBindTable(R);
            Histograma_2.DataBindTable(G);
            Histograma_3.DataBindTable(B);

            //Nota: tambien se puede llenar manualmente cada punto
            //Series Canal1 = Histograma_1.Series.Add("R");
            //Series Canal2 = Histograma_2.Series.Add("G");
            //Series Canal3 = Histograma_3.Series.Add("B");

            //for (int i = 0; i < 256; i++)
            //{
            //    Canal1.Points.Add(R[i]);
            //    Canal2.Points.Add(G[i]);
            //    Canal3.Points.Add(B[i]);
            //}

            return error;
        }
    }
}
