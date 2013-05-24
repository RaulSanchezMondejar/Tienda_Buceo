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
    public partial class FormClienteHistorialMail : Form
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

        String idmensaje = "0";


        public FormClienteHistorialMail(FormPantallaPrincipal F)
        {
            InitializeComponent();

            formPantallaInicial = F;


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

            hayarHistorialCorreosElectronicos();
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
            comboBoxHistorial.SelectedIndex = -1;
            textBoxPara.Text = "";
            textBoxAsunto.Text = "";
            richTextBoxCuerpo.Text = "";
        }



        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            Close();
            borrarDatos();
            formPantallaInicial.Show();
        }

        private void boton_Borrar_Click(object sender, EventArgs e)
        {
            if (textBoxPara.Text.Length != 0) {
                habilitarBotones();
            }
        }

        private void habilitarBotones() 
        {
            textBoxAsunto.Enabled = true;
            textBoxPara.Enabled = true;
            richTextBoxCuerpo.Enabled = true;
            buttonReenviar.Enabled = true;
            buttonColorFuente.Enabled = true;
            buttonTipoFuente.Enabled = true;
            botonEditar.Enabled = true;
        }

        private void deshabilitarBotones()
        {
            textBoxAsunto.Enabled = false;
            textBoxPara.Enabled = false;
            richTextBoxCuerpo.Enabled = false;
            buttonReenviar.Enabled = false;
            buttonColorFuente.Enabled = false;
            buttonTipoFuente.Enabled = false;
            botonEditar.Enabled = false;
        }


        private void mostrarMensajaError()
        {
            MessageBox.Show("Error: No ha conexión con la BBDD, pongase en contacto\ncon el departamento de Informática");
        }


        private void hayarHistorialCorreosElectronicos()
        {
            comboBoxHistorial.Items.Clear();
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT * FROM sql27652.mensaje;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    String cadena = "0000" + resultado.GetString("id_mensaje");

                    int tamañoCadena = Convert.ToInt32(cadena.Length);

                    string palabraCortada = cadena.Substring(tamañoCadena - 4, 4);

                    comboBoxHistorial.Items.Add(palabraCortada + " - " + resultado.GetString("fecha") + " - " + resultado.GetString("asunto"));
                }
                conexion.Close();
            }
            catch
            {
                mostrarMensajaError();
            }
            borrarDatos();
        }


        private void buttonColorFuente_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void buttonTipoFuente_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void buttonReenviar_Click(object sender, EventArgs e)
        {
            if (textBoxPara.Text.Length != 0)
            {
                if (textBoxAsunto.Text.Length != 0)
                {
                    if (richTextBoxCuerpo.Text.Length != 0)
                    {
                        try
                        {
                            // Iniciamos la conexion.
                            conexion.Open();

                            // Aqui hariamos la consulta.
                            sentenciaSQL =  "INSERT INTO sql27652.mensaje VALUES ( 0 ," +
                                            "'" + textBoxAsunto.Text + "'," +
                                            "'" + textBoxPara.Text + "'," +
                                            "'" + richTextBoxCuerpo.Text + "'," +
                                            "DATE_ADD(NOW(), INTERVAL 2 HOUR))";

                            comando = new MySqlCommand(sentenciaSQL, conexion);
                            comando.ExecuteNonQuery();
                            conexion.Close();
                            deshabilitarBotones();
                            MessageBox.Show("Correo Reenviado Correcamente");
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

        private void buttonBusquedaPersonalizada_Click(object sender, EventArgs e)
        {
            deshabilitarBotones();

            idmensaje = comboBoxHistorial.Text.Substring(0,4);

            try
            {
                // Iniciamos la conexion.
                conexion.Open();

                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT * FROM sql27652.mensaje WHERE id_mensaje = " +
                                idmensaje + ";";
                
                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                { 
                    textBoxAsunto.Text = resultado["asunto"].ToString();
                    textBoxPara.Text = resultado["para"].ToString();
                    richTextBoxCuerpo.Text = resultado["cuerpo"].ToString();

                }

                conexion.Close();
                botonEditar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("ERROR: Operación no realizada al no haber conexión con el servidor\n" +
                                "si la incidencia persiste contactar con el departamento de Informática");
            }
        }

        private void buttonRecargarHistorial_Click(object sender, EventArgs e)
        {
            hayarHistorialCorreosElectronicos();
        }
    }
}

