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
    public partial class Form1 : Form
    {

        // Con este nombre llamaremos al formulario Pantalla Inicial.
        Form2 formPantallaInicial;


        public Form1()
        {
            InitializeComponent();

            // Creamos el formulario principal.
            formPantallaInicial = new Form2(this);

            // Configuramos los eventos de teclado para poder utilizarlos.
            textBox_contrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);

            // Marcamos como activo el cuadro de Introducción de usuario.
            ActiveControl = textBox_usuario;
            
        }
        /*
         * Cuando pulsemos este botón llamara al método entrar.
         */ 
        private void boton_entrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        /*
         * Cuando llamemos a este método, cerrara el programa.
         */ 
        private void boton_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * Este método nos va a permitir que cuando pulsemos el "Enter", sea lo mismo que pulsar el botón aceptar.
         */
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // char 13 representa a la tecla "Enter" (Intro).
            if (e.KeyChar == (char)13)
            {
                // Si hemos llegado aquí es que hemos pulsado esa tecla.
                entrar();
            }
        }

        /*
         * Este método va a ser llamado cuando pulsemos el botón de Entrar.
         * Lo que va a hacer es comprobar si el usuario y contraseña son correctos, y en el caso
         * de asi serlo, nos llevara a la Pantalla Principal. De no ser asi, nos mostrara un
         * mensaje de error en pantalla.
         */ 
        private void entrar() 
        {
            if (("root" == textBox_usuario.Text.ToLower()) && ("root" == textBox_contrasena.Text))
            {
                /*
                 * Si llegamos aqui es porque el usuario y contraseña son correctos.
                 * Se oculta este formulario, y se abre el Formulario Principal.
                 */
                label_errorUsuarioContrasena.Text = "";
                Hide();
                formPantallaInicial.StartPosition = FormStartPosition.CenterScreen;
                formPantallaInicial.label_usuario.Text = "Usuario: " + textBox_usuario.Text.ToLower().ToString();
                formPantallaInicial.Show();
            }
            else
            {
                // Si llegamos aqui es porque el usuario o contraseña no son correctos.
                label_errorUsuarioContrasena.Text = "Usuario y/o Contraseña incorrecta";
            }
            // Ponemos en blanco los campos de usuario y contraseña.
            textBox_usuario.Text = "";
            textBox_contrasena.Text = "";

            // Marcamos como activo el cuadro de Introducción de usuario.
            ActiveControl = textBox_usuario;
        }
    }
}
