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
    public partial class FormPantallaPrincipal : Form
    {
        FormEntrada formularioEntrada;
        FormClienteBusqueda formularioBusquedaCliente;
        FormClienteNuevo formularioNuevoCliente;
        FormSalirPrograma formularioSalir;
        FormClienteModificar formularioModificarCliente;
        FormClienteBorrar formularioBorrarCliente;
        FormClienteEnvioMail formularioEnvioMail;
        FormClienteHistorialMail formularioHistorialMail;
        


        /*
         * Declaramos las siguientes variables para la conexión a la BBDD, para que nos sea más cómodo su utilización.
         */
        public String nombreServidor = "sql2.freesqldatabase.com";
        //public String nombreServidor = "www.db4free.net"; //BBDD de BackUP
        public String nombreBBDD = "sql27652";
        public String puertoConexion = "3306";
        public String nombreUsuario = "sql27652";
        public String contraseñaUsuario = "aD1*bC3%";



        public FormPantallaPrincipal(FormEntrada F)
        {
            InitializeComponent();

            formularioEntrada = F;

            
        }

        public void salirAplicacion() 
        {
            formularioEntrada.Close();
        }


        private void boton_Salir_Click(object sender, EventArgs e)
        {
            formularioSalir = new FormSalirPrograma(this);
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
            formularioBusquedaCliente = new FormClienteBusqueda(this);
            formularioBusquedaCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioBusquedaCliente.Show();
        }

        private void nuevoCliente()
        {
            Hide();
            // Creamos el formulario busqueda cliente.
            formularioNuevoCliente = new FormClienteNuevo(this);
            formularioNuevoCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioNuevoCliente.Show();
        }

        private void modificarCliente() 
        {
            Hide();
            // Creamos el formulario principal.
            formularioModificarCliente = new FormClienteModificar(this);
            formularioModificarCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioModificarCliente.Show();
        }
        //Nuevo formulario boorar cliente
        private void borrarCliente()
        {
            Hide();
            // Creamos el formulario principal.
            formularioBorrarCliente = new FormClienteBorrar(this);
            formularioBorrarCliente.StartPosition = FormStartPosition.CenterScreen;
            formularioBorrarCliente.Show();
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

        private void borrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boton del menu
            borrarCliente();
        }

        private void envioMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enviarCorreos();
        }

        private void enviarCorreos()
        {
            Hide();
            formularioEnvioMail = new FormClienteEnvioMail(this);
            formularioEnvioMail.StartPosition = FormStartPosition.CenterScreen;
            formularioEnvioMail.Show();
        }

        private void historialMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            formularioHistorialMail = new FormClienteHistorialMail(this);
            formularioHistorialMail.StartPosition = FormStartPosition.CenterScreen;
            formularioHistorialMail.Show();
        }
    }
}
