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
    public partial class FormClienteNuevo : Form
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

        // El siguietne boolean lo vamos a utilizar para mostrar los mensajes de error.
        Boolean mensajeError = false;

        Boolean imagenInsertada = false;

        // Esta varibale la declaramos para poderla llamar en el desplegable.
        int datoAuxiliar = 0;

        public FormClienteNuevo(FormPantallaPrincipal F)
        {
            InitializeComponent();

            formPantallaInicial = F;

            // Introducimos las siguientes campos en el desplegable.
            comboBox_titulacion.Items.Add("SIN TITULACION");
            comboBox_titulacion.Items.Add("DISCOVERY SCUBA DIVER");
            comboBox_titulacion.Items.Add("OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("ADVANCE OPEN WATER DIVER");
            comboBox_titulacion.Items.Add("RESCUE DIVER");
            comboBox_titulacion.Items.Add("DIVEMASTER");
            comboBox_titulacion.Items.Add("INSTRUCTOR");

            // Configuramos los eventos de teclado para poder utilizarlos.
            textBox_numCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_apellido1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_apellido2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_correoElectronico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_telefonoFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_telefonoMovil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            comboBox_titulacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);

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

            hayarNumeroCliente();

            // Marcamos como activo el campo nombre Cliente.
            ActiveControl = textBox_nombre;
        }

        /*
         * Este método nos va a permitir que cuando pulsemos el "Enter", sea lo mismo que pulsar el botón aceptar.
         */
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                // Si hemos llegado aquí es que hemos pulsado esa tecla.
                Hide();
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

            comboBox_titulacion.SelectedIndex = -1;

            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\0.png");
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

        /*
         * Cuando pulsemos este botón,
         */ 
        private void boton_nuevoUsuario_Click(object sender, EventArgs e)
        {
            // Lo primero que vamos a hacer es pasar todos los campos a mayusculas.
            textoAMayusculas();

            // Empiezan las comprobaciones.
            if (textBox_nombre.Text != "")
            {
                if (textBox_apellido1.Text != "")
                {
                    if (textBox_apellido2.Text != "")
                    { 
                        switch (comboBox_titulacion.Text)
                        {
                            case "DISCOVERY SCUBA DIVER": datoAuxiliar = 1; break;
                            case "OPEN WATER DIVER": datoAuxiliar = 2; break;
                            case "ADVANCE OPEN WATER DIVER": datoAuxiliar = 3; break;
                            case "RESCUE DIVER": datoAuxiliar = 4; break;
                            case "DIVEMASTER": datoAuxiliar = 5; break;
                            case "INSTRUCTOR": datoAuxiliar = 6; break;
                            case "SIN TITULACION": datoAuxiliar = 0; break;
                            default: datoAuxiliar = 0; break;
                        }

                        // Si hemos llegado hasta aqui, ejecutamos la sentencia SQL de INSERTAR.
                        try
                        {
                            /*
                             * Los siguientes if nos van a permitir en el caso de que algún campo
                             * este vacio, pasarlo como null a la consulta.
                             */
                            if (textBox_apellido2.Text.ToString().Length == 0)
                            {
                                textBox_apellido2.Text = "null";
                            }
                            if (textBox_telefonoFijo.Text.ToString().Length == 0)
                            {
                                textBox_telefonoFijo.Text = "null";
                            }
                            if (textBox_telefonoMovil.Text.ToString().Length == 0)
                            {
                                textBox_telefonoMovil.Text = "null";
                            }
                            if (textBox_correoElectronico.Text.ToString().Length == 0)
                            {
                                textBox_correoElectronico.Text = "null";
                            }

                            // Iniciamos la conexion.
                            conexion.Open();

                            // Aqui hariamos la consulta.
                            sentenciaSQL = "INSERT INTO sql27652.clientes VALUES (" +
                                    textBox_numCliente.Text + "," +
                                    "'" + textBox_nombre.Text + "'," +
                                    "'" + textBox_apellido1.Text + "'," +
                                    "'" + textBox_apellido2.Text + "'," +
                                    "" + textBox_telefonoFijo.Text + "," +
                                    "" + textBox_telefonoMovil.Text + "," +
                                    "'" + textBox_correoElectronico.Text + "'," +
                                    "null,null," + datoAuxiliar + ")";


                            comando = new MySqlCommand(sentenciaSQL, conexion);
                            comando.ExecuteNonQuery();
                            conexion.Close();

                            // Mostramos un texto para informar de la operación.
                            label_resultado.Text = "Usuario dado de alta correctamente";

                            if (imagenInsertada == true)
                            {
                                try
                                {
                                    pictureBox1.Image.Save(Application.StartupPath + "\\Fotos\\" + textBox_numCliente.Text + ".png");
                                    imagenInsertada = false;
                                }
                                catch { }

                            }
                        }
                        catch 
                        {
                            MessageBox.Show("ERROR: Operación no realizada al no haber conexión con el servidor\n" +
                                            "si la incidencia persiste contactar con el departamento de Informática");
                        }
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

        private void hayarNumeroCliente (){ 
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT MAX(id_cliente) AS Dato FROM sql27652.clientes;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                if (resultado.Read())
                {
                    textBox_numCliente.Text = (resultado.GetInt32(0) + 1).ToString();
                }
                conexion.Close();
            }
            catch 
            {
                mostrarMensajaError();
            }  
        }

        private void mostrarMensajaError()
        {
            label1.Text = "Sin conexión con la BBDD";
            textBox_numCliente.Visible = false;
            boton_nuevoUsuario.Visible = false;
            boton_Borrar.Visible = false;
            button_agregarFoto.Visible = false;
            textBox_nombre.Visible = false;
            textBox_apellido1.Visible = false;
            textBox_apellido2.Visible = false;
            textBox_telefonoFijo.Visible = false;
            textBox_telefonoMovil.Visible = false;
            textBox_correoElectronico.Visible = false;
            comboBox_titulacion.Visible = false;
            label_nombre.Visible = false;
            label_apellido1.Visible = false;
            label_apellido2.Visible = false;
            label_telefonoFijo.Visible = false;
            label_telefonoMovil.Visible = false;
            label_correoElectronico.Visible = false;
            label_titulacion.Visible = false;
            label_resultado.Visible = false;
            label_numCliente.Visible = false;


            boton_cancelar.SetBounds(250, 260, 250, 40);
            pictureBox1.SetBounds(250, 60, 700, 200);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

            try
            {
                pictureBox1.Image = global::Tienda_Buceo_v1.Properties.Resources.error;
            }
            catch { }

            MessageBox.Show("Error: No ha conexión con la BBDD, pongase en contacto\ncon el departamento de Informática");
        }


        private void button_agregarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Archivos de Imagen|*.png;*.jpg";
            abrirFoto.FileName = "";
            abrirFoto.Title = "Añadir foto en formato PNG o JPG";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                    String Direccion = abrirFoto.FileName;
                    pictureBox1.ImageLocation = Direccion;
                    imagenInsertada = true;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se ha podido leer el fichero del disco. Error Original: " + ex.Message);
                }
            }
        }
    }
}
