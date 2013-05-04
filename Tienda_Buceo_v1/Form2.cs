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
    public partial class Form2 : Form
    {
        Form1 formularioEntrada;
        Form3 formularioBusquedaCliente;
        Form4 formularioNuevoCliente;

        /*
         * Declaramos las siguientes variables para la conexión a la BBDD, para que nos sea más cómodo su utilización.
         */
        public String nombreServidor = "sql2.freesqldatabase.com";
        public String nombreBBDD = "sql27652";
        public String puertoConexion = "3306";
        public String nombreUsuario = "sql27652";
        public String contraseñaUsuario = "aD1*bC3%";



        public Form2(Form1 F)
        {
            InitializeComponent();

            formularioEntrada = F;

            // Creamos el formulario principal.
            formularioBusquedaCliente = new Form3(this);

            // Creamos el formulario busqueda cliente.
            formularioNuevoCliente = new Form4(this);
        }

        private void boton_Salir_Click(object sender, EventArgs e)
        {
            formularioEntrada.Close();
        }

        private void boton_busquedaCliente_Click(object sender, EventArgs e)
        {
            Hide();
            formularioBusquedaCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioBusquedaCliente.Show();
        }

        private void boton_nuevoCliente_Click(object sender, EventArgs e)
        {
            Hide();
            formularioNuevoCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioNuevoCliente.Show();
        }

        private void button_cerrarSesion_Click(object sender, EventArgs e)
        {
            Hide();
            formularioEntrada.StartPosition = FormStartPosition.CenterScreen;
            formularioEntrada.Show();
        }

    }
}
