using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace Tienda_Buceo_v1
{
    public partial class Form4 : Form
    {
        Form2 formPantallaInicial;

        // La línea que guarda la IP del servidor, usuario y contraseña.
        String cadenaConexión;

        // Conector que almacena la conexión de la BBDD.
        MySqlConnection conexion;

        // Comando que quiero que se ejecute.
        MySqlCommand comando;

        // Consulta
        String sentenciaSQL;

        // Resultado de la consulta.
        MySqlDataReader resultado;

        

        // El siguietne boolean lo vamos a utilizar para mostrar los mensajes de error.
        Boolean mensajeError = false;

        public Form4(Form2 F)
        {
            InitializeComponent();

            formPantallaInicial = F;

            comboBox_titulacion.Items.Add("DISCOVERY SCUBA DIVER");
            comboBox_titulacion.Items.Add("OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("ADVANCE OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("RESCUE DIVER");
            comboBox_titulacion.Items.Add("DIVEMASTER");
            comboBox_titulacion.Items.Add("INSTRUCTOR");

            ActiveControl = textBox_nombre;

            try
            {
                cadenaConexión = "Server = " + formPantallaInicial.nombreServidor +
                                "; Database = " + formPantallaInicial.nombreBBDD +
                                "; Uid = " + formPantallaInicial.nombreUsuario +
                                "; Pwd = " + formPantallaInicial.contraseñaUsuario +
                                "; Port = " + formPantallaInicial.puertoConexion + ";";
                conexion = new MySqlConnection(cadenaConexión);
            }
            catch {}

        }

        /*
         * Este método nos va a permitir dejar todos los canpos vacios.
         */ 
        private void borrarDatos() 
        {
            // Procedemos a borrar todos los campos.
            textBox_nombre.Text = "";
            textBox_apellido1.Text = "";
            textBox_apellido2.Text = "";
            textBox_telefonoFijo.Text = "";
            textBox_telefonoMovil.Text = "";
            textBox_correoElectronico.Text = "";
            comboBox_titulacion.Text = "";
            label_resultado.Text = "";

            // Ponemos en el color por defecto las celdas.
            textBox_nombre.BackColor = System.Drawing.SystemColors.Window;
            textBox_apellido1.BackColor = System.Drawing.SystemColors.Window;
            textBox_apellido2.BackColor = System.Drawing.SystemColors.Window;

            mensajeError = false;
        }


        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            Hide();
            borrarDatos();
            formPantallaInicial.Show();
        }

        private void boton_Borrar_Click(object sender, EventArgs e)
        {
            borrarDatos();
        }

        /*
         * Cuando pulsemos este botón,
         */ 
        private void boton_nuevoUsuario_Click(object sender, EventArgs e)
        {
            // Lo primero que vamos a hacer es pasar todos los campos a mayusculas.
            textoAMayusculas();
            

                if (textBox_nombre.Text != "")
                {
                    if (textBox_apellido1.Text != "")
                    {
                        if (textBox_apellido2.Text != "")
                        {
                            // Si hemos llegado hasta aqui, ejecutamos la sentencia SQL de INSERTAR.
                            // Iniciamos la conexion.
                            conexion.Open();

                            // Aqui hariamos la consulta.
                            sentenciaSQL = "INSERT INTO sql27652.clientes VALUES (0," +
                                "'" + textBox_nombre.Text + "',"+
                                "'" + textBox_apellido1.Text + "',"+
                                "'" + textBox_apellido2.Text + "'," +
                                "" +  textBox_telefonoFijo.Text + "," +
                                "" + textBox_telefonoMovil.Text + "," +
                                "'" + textBox_correoElectronico.Text + "'," +
                                "null,null,1)";
                            /*
                             * Seria mejor pasarlo por String independientes, para en el caso de no poner
                             * telefonos o lo que sea, ponerlo como null y pasarlo.
                             * Algo asi:
                             * if (textBox_telefonoMovil.Text.Equals("")) { textBox_telefonoMovil.Text = null; }
                             */




                            comando = new MySqlCommand(sentenciaSQL, conexion);
                            comando.ExecuteNonQuery();

                            conexion.Close();
                            
                            // Mostramos un texto para informar de la operación.
                            label_resultado.Text = "Usuario dado de alta correctamente";
                        }
                    }
                }
            pintarCeldasObligatoriasVacias();
        }

        private void textoAMayusculas()
        {
            textBox_nombre.Text = textBox_nombre.Text.ToUpper();
            textBox_apellido1.Text = textBox_apellido1.Text.ToUpper();
            textBox_apellido2.Text = textBox_apellido2.Text.ToUpper();
            textBox_correoElectronico.Text = textBox_correoElectronico.Text.ToUpper();
        }

        /*
         * Este método pintara con otro color los campos que sean obligatorios de rellenar y esten vacios.
         */ 
        private void pintarCeldasObligatoriasVacias()
        {

            if (textBox_nombre.Text == "")
            {
                textBox_nombre.BackColor = System.Drawing.Color.Yellow;
                mensajeError = true;
            }
            else{
                textBox_nombre.BackColor = System.Drawing.SystemColors.Window;
            }

            if (textBox_apellido1.Text == "")
            {
                textBox_apellido1.BackColor = System.Drawing.Color.Yellow;
                mensajeError = true;
            }
            else{
                textBox_apellido1.BackColor = System.Drawing.SystemColors.Window;
            }

            if (textBox_apellido2.Text == "")
            {
                textBox_apellido2.BackColor = System.Drawing.Color.Yellow;
                mensajeError = true;
            }
            else{
                textBox_apellido2.BackColor = System.Drawing.SystemColors.Window;
            }

            if (mensajeError) {
                // Mostramos un mensaje de advertencia
                label_resultado.Text = "Atención, rellenar las celdas en amarillo";
            }

            // Volvemos a dejar en false el boolean para mostrar el mensaje de error.
            mensajeError = false;
        }
    }
}
