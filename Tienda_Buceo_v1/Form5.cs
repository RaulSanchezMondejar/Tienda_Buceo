using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Buceo_v1
{
    public partial class Form5 : Form
    {
        Form2 formPantallaInicial;


        public Form5(Form2 F)
        {
            InitializeComponent();

            formPantallaInicial = F;
        }


        private void button_salir_no_Click(object sender, EventArgs e)
        {
            Hide();
            formPantallaInicial.Show();
        }

        private void button_salir_si_Click(object sender, EventArgs e)
        {
            formPantallaInicial.salirAplicacion();
        }
    }
}
