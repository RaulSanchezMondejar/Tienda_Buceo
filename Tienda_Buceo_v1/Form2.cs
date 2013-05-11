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
        Form5 formularioSalir;
        Form6 formularioModificarCliente;

        /*
         * Declaramos las siguientes variables para la conexión a la BBDD, para que nos sea más cómodo su utilización.
         */
        public String nombreServidor = "sql2.freesqldatabase.com";
        //public String nombreServidor = "www.db4free.net"; //BBDD de BackUP
        public String nombreBBDD = "sql27652";
        public String puertoConexion = "3306";
        public String nombreUsuario = "sql27652";
        public String contraseñaUsuario = "aD1*bC3%";



        public Form2(Form1 F)
        {
            InitializeComponent();

            formularioEntrada = F;

            formularioSalir = new Form5(this);

        }

        public void salirAplicacion() 
        {
            formularioEntrada.Close();
        }

        private void boton_Salir_Click(object sender, EventArgs e)
        {
            formularioSalir.StartPosition = FormStartPosition.CenterScreen;
            formularioSalir.Show();
        }

        private void boton_busquedaCliente_Click(object sender, EventArgs e)
        {
            busquedaCliente();    
        }

        private void boton_nuevoCliente_Click(object sender, EventArgs e)
        {
            nuevoCliente();
        }

        private void busquedaCliente()
        {
            Hide();
            // Creamos el formulario principal.
            formularioBusquedaCliente = new Form3(this);
            formularioBusquedaCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioBusquedaCliente.Show();
        }

        private void nuevoCliente()
        {
            Hide();
            // Creamos el formulario busqueda cliente.
            formularioNuevoCliente = new Form4(this);
            formularioNuevoCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioNuevoCliente.Show();
        }

        private void modificarCliente() 
        {
            Hide();
            // Creamos el formulario principal.
            formularioModificarCliente = new Form6(this);
            formularioModificarCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioModificarCliente.Show();
        }

        private void button_cerrarSesion_Click(object sender, EventArgs e)
        {
            Hide();
            formularioEntrada.StartPosition = FormStartPosition.CenterScreen;
            formularioEntrada.Show();
        }

        private void busquedaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            busquedaCliente();  
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoCliente();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarCliente();
        }

        private void busquedaComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
