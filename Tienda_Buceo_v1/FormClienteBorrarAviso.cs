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
    public partial class FormClienteBorrarAviso : Form
    {
        //FormPantallaPrincipal formPantallaInicial;
        FormClienteBorrar formClienteBorrar;


        public FormClienteBorrarAviso(FormClienteBorrar F)
        {
            InitializeComponent();

            formClienteBorrar = F;
        }


        private void button_salir_no_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button_salir_si_Click(object sender, EventArgs e)
        {
            // Ejecutamos la orden de borrar.
            Hide();
            formClienteBorrar.dardeBaja();
        }
    }
}
