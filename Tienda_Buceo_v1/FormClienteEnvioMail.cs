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
    public partial class FormClienteEnvioMail : Form
    {
        FormPantallaPrincipal formPantallaInicial;

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


        public FormClienteEnvioMail(FormPantallaPrincipal F)
        {
            InitializeComponent();

            formPantallaInicial = F;

            // Introducimos las siguientes campos del desplegable.
            comboBox_titulacion.Items.Add("TODOS LOS CLIENTES");
            comboBox_titulacion.Items.Add("SIN TITULACION");
            comboBox_titulacion.Items.Add("DISCOVERY SCUBA DIVER");
            comboBox_titulacion.Items.Add("OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("ADVANCE OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("RESCUE DIVER");
            comboBox_titulacion.Items.Add("DIVEMASTER");
            comboBox_titulacion.Items.Add("INSTRUCTOR");


            // Conexión contra servidor de Datos MySQL.
            try
            {
                cadenaConexión = "Server = " + formPantallaInicial.nombreServidor +
                                "; Database = " + formPantallaInicial.nombreBBDD +
                                "; Uid = " + formPantallaInicial.nombreUsuario +
                                "; Pwd = " + formPantallaInicial.contraseñaUsuario +
                                "; Port = " + formPantallaInicial.puertoConexion + ";";
                conexion = new MySqlConnection(cadenaConexión);
            }
            catch { }

            hayarCorreosElectronicos();
        }


        /*
         * Este método nos va a permitir que cuando pulsemos el "Enter", sea lo mismo que pulsar el botón aceptar.
         */
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                // Si hemos llegado aquí es que hemos pulsado esa tecla.
                Close();
                borrarDatos();
                formPantallaInicial.Show();
            }
        }


        /*
         * Este método nos va a permitir dejar todos los canpos vacios.
         */
        private void borrarDatos()
        {
            // Procedemos a borrar todos los campos.
            textBoxAsunto.Text = "";
            comboBox_titulacion.SelectedIndex = -1;
            comboBoxUsuario.SelectedIndex = -1;
            textBoxPara.Text = "";
            textBoxAsunto.Text = "";
            richTextBox1.Text = "";
        }



        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            Close();
            borrarDatos();
            formPantallaInicial.Show();
        }

        private void boton_Borrar_Click(object sender, EventArgs e)
        {
            borrarDatos();
        }

        private void boton_Buscar_Click(object sender, EventArgs e)
        {
            // Solo vamos a lanzar la consulta si hay algun dato relleno
            if ((comboBox_titulacion.SelectedIndex != -1) || (comboBoxUsuario.SelectedIndex != -1))
            {
                String titulacion = "";
                switch (comboBox_titulacion.SelectedIndex)
                {
                    case 0: 
                        titulacion = "in (0,1,2,3,4,5,6)";
                    break;

                    case 1:
                        titulacion = " = 0";
                        break;

                    case 2: 
                        titulacion = " = 1";
                        break;

                    case 3: 
                        titulacion = " = 2";
                        break;

                    case 4: 
                        titulacion = " = 3";
                        break;

                    case 5: 
                        titulacion = " = 4";
                        break;

                    case 6: 
                        titulacion = " = 5";
                        break;

                    case 7: 
                        titulacion = " = 6";
                        break;
                }

                try
                {
                    // Iniciamos la conexion.
                    conexion.Open();

                    // Aqui hariamos la consulta.
                    sentenciaSQL = "SELECT correo_electronico FROM sql27652.clientes WHERE titulacion " + titulacion;

                    comando = new MySqlCommand(sentenciaSQL, conexion);
                    resultado = comando.ExecuteReader();
                    Console.WriteLine(">> Realizando la consulta: " + sentenciaSQL);
                    while (resultado.Read())
                    {
                        textBoxPara.Text += resultado.GetString("correo_electronico") + ";  ";
                    }

                    conexion.Close();
                }
                catch
                {
                    mostrarMensajaError();
                }
            }
            else
            {
                borrarDatos();
                MessageBox.Show("Error: No se ha insertado ningun dato de busqueda");
            }
        }


        private void mostrarMensajaError()
        {
            MessageBox.Show("Error: No ha conexión con la BBDD, pongase en contacto\ncon el departamento de Informática");
        }


        private void hayarCorreosElectronicos()
        {
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT correo_electronico FROM sql27652.clientes;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    comboBoxUsuario.Items.Add(resultado.GetString("correo_electronico"));
                }
                conexion.Close();
            }
            catch
            {
                mostrarMensajaError();
            }
        }

        private void buttonBusquedaPersonalizada_Click(object sender, EventArgs e)
        {
            textBoxPara.Text += comboBoxUsuario.Text + ";  ";
        }

        private void buttonColorFuente_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void buttonTipoFuente_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (textBoxPara.Text.Length != 0)
            {
                if (textBoxAsunto.Text.Length != 0)
                {
                    if (richTextBox1.Text.Length != 0)
                    {
                        try
                        {
                            // Iniciamos la conexion.
                            conexion.Open();

                            // Aqui hariamos la consulta.
                            sentenciaSQL =  "INSERT INTO sql27652.mensaje VALUES ( 0 ," +
                                            "'" + textBoxAsunto.Text + "'," +
                                            "'" + textBoxPara.Text + "'," +
                                            "'" + richTextBox1.Text + "'," +
                                            "DATE_ADD(NOW(), INTERVAL 2 HOUR))";

                            comando = new MySqlCommand(sentenciaSQL, conexion);
                            comando.ExecuteNonQuery();
                            conexion.Close();

                            borrarDatos();
                            MessageBox.Show("Correo Enviado Correcamente");
                        }

                        catch
                        {
                            MessageBox.Show("ERROR: Operación no realizada al no haber conexión con el servidor\n" +
                                            "si la incidencia persiste contactar con el departamento de Informática");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Es necesario introducir algo en el \"Cuerpo\"");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario introducir \"Asunto\"");
                }
            }
            else 
            {
                MessageBox.Show("Es necesario que exista por lo menos un destinatario en el campo \"Para\"");
            }
        }
    }
}

