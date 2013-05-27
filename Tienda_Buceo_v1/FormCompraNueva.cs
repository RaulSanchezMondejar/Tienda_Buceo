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
    public partial class FormCompraNueva : Form
    {
        FormPantallaPrincipal formPantallaInicial;
        FormCompraNuevaAviso formCompraNuevaAviso;

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

        ListViewItem item1;

        String chorizaco;

        String vid_articulo = "";
        String vcategoria = "";
        String vmarca = "";
        String vprecio = "";

        Boolean masDeUnArticulo = false;


        public FormCompraNueva(FormPantallaPrincipal F)
        {
            InitializeComponent();

            formPantallaInicial = F;


            // Configuramos los eventos de teclado para poder utilizarlos.
            textBox_numCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_apellido1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_apellido2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_correoElectronico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_telefonoFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            textBox_telefonoMovil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);

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

            hayarNumeroTicket();
            rellenarComboBoxUsuarios();
            rellenarArticulos();

            comboBoxArticulo.SelectedIndex = -1;
            comboBoxListadoUsuarios.SelectedIndex = -1;

            // Marcamos como activo el campo nombre Cliente.
            //ActiveControl = textBox_nombre;
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
            listView1.Items.Clear();
            comboBoxArticulo.SelectedIndex = -1;
            textBoxCantidad.Text = "";

            mensajeError = false;
            masDeUnArticulo = false;
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
        private void boton_nuevoCompra_Click(object sender, EventArgs e)
        {
            if (masDeUnArticulo)
            {
                // Abrimos el formulario de advertencia
                formCompraNuevaAviso = new FormCompraNuevaAviso(this);
                formCompraNuevaAviso.StartPosition = FormStartPosition.CenterScreen;
                formCompraNuevaAviso.Show();

            }
            else {
                MessageBox.Show("Es necesario insertar mínimo un articulo.");
            }
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
                //label_resultado.Text = "Atención, rellenar las celdas en amarillo";
            }

            // Volvemos a dejar en false el boolean para mostrar el mensaje de error.
            mensajeError = false;
        }

        private void hayarNumeroTicket (){ 
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT MAX(id_compra) AS Dato FROM sql27652.compra;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                if (resultado.Read())
                {
                    textBoxNumTicket.Text = (resultado.GetInt32(0) + 1).ToString();
                }

                conexion.Close();
            }
            catch 
            {
                mostrarMensajaError();
            }  
        }

        private void rellenarArticulos()
        {
            try
            {
                // Iniciamos la conexion.
                conexion.Open();

                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT id_articulo, categoria, marca, precio FROM sql27652.articulos;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    String cadena = "0000" + resultado.GetString("id_articulo");

                    int tamañoCadena = Convert.ToInt32(cadena.Length);

                    string palabraCortada = cadena.Substring(tamañoCadena - 4, 4);
                 

                    comboBoxArticulo.Items.Add(palabraCortada + " - " +
                                                      resultado.GetString("categoria") + " - " +
                                                      resultado.GetString("marca") + " - " +
                                                      resultado.GetString("precio"));



                }
                conexion.Close();
            }
            catch
            {
                mostrarMensajaError();
            }
        }


        private void rellenarComboBoxUsuarios()
        {
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT id_cliente,nombre,apellido1,apellido2,telefono_fijo,telefono_movil,correo_electronico FROM sql27652.clientes;";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    String cadena = "0000" + resultado.GetString("id_cliente");

                    int tamañoCadena = Convert.ToInt32(cadena.Length);

                    String palabraCortada = cadena.Substring(tamañoCadena - 4, 4);

                    comboBoxListadoUsuarios.Items.Add(palabraCortada + " - " +
                                                      resultado.GetString("nombre") + " - " + 
                                                      resultado.GetString("apellido1") + " - " +
                                                      resultado.GetString("apellido2") + " - " +
                                                      resultado.GetString("correo_electronico"));
                                                       
                
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
            MessageBox.Show("Error: No ha conexión con la BBDD, pongase en contacto\ncon el departamento de Informática");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxListadoUsuarios.SelectedIndex != -1)
            {
                rellenarCamposUsuario();
            }
            else{
                MessageBox.Show("Es necesario seleccionar previamente un usuario.");
            }
        }

        private void rellenarCamposUsuario()
        {
            if (comboBoxListadoUsuarios.SelectedIndex != -1)
            {
                String idmensaje = comboBoxListadoUsuarios.Text.Substring(0, 4);

                try
                {
                    // Iniciamos la conexion.
                    conexion.Open();
                    // Aqui hariamos la consulta.
                    sentenciaSQL = "SELECT id_cliente,nombre,apellido1,apellido2,telefono_fijo,telefono_movil,correo_electronico " +
                                   "FROM sql27652.clientes " +
                                   "WHERE id_cliente = " + idmensaje + ";";

                    comando = new MySqlCommand(sentenciaSQL, conexion);
                    resultado = comando.ExecuteReader();

                    if (resultado.Read())
                    {
                        textBox_numCliente.Text = resultado.GetString("id_cliente");
                        textBox_nombre.Text = resultado.GetString("nombre");
                        textBox_apellido1.Text = resultado.GetString("apellido1");
                        textBox_apellido2.Text = resultado.GetString("apellido2");
                        textBox_correoElectronico.Text = resultado.GetString("correo_electronico");
                        textBox_telefonoFijo.Text = resultado.GetInt32("telefono_fijo").ToString();
                        textBox_telefonoMovil.Text = resultado.GetInt32("telefono_movil").ToString();
                    }
                    conexion.Close();
                }
                catch
                {
                    mostrarMensajaError();
                }
            }   
        }

        private void buttonAñadirAlCarro_Click(object sender, EventArgs e)
        {
            if ((comboBoxArticulo.SelectedIndex != -1) && (textBoxCantidad.Text != ""))
            {
                String id_articulo = comboBoxArticulo.Text.Substring(0, 4);

                try
                {
                    // Iniciamos la conexion.
                    conexion.Open();
                    // Aqui hariamos la consulta.
                    sentenciaSQL = "SELECT id_articulo, categoria, marca, precio FROM sql27652.articulos " +
                                   "WHERE id_articulo = " + id_articulo + ";";

                    comando = new MySqlCommand(sentenciaSQL, conexion);
                    resultado = comando.ExecuteReader();

                    if (resultado.Read())
                    {
                        String cadena = "0000" + resultado.GetString("id_articulo");

                        int tamañoCadena = Convert.ToInt32(cadena.Length);

                        String palabraCortada = cadena.Substring(tamañoCadena - 4, 4);

                        vid_articulo = resultado["id_articulo"].ToString();
                        vcategoria = resultado["categoria"].ToString();
                        vmarca = resultado["marca"].ToString();
                        vprecio = resultado["precio"].ToString();

                        item1 = new ListViewItem(vid_articulo);
                        item1.SubItems.Add(vcategoria);
                        item1.SubItems.Add(vmarca);
                        item1.SubItems.Add(vprecio);
                        item1.SubItems.Add(textBoxCantidad.Text);

                        listView1.Items.AddRange(new ListViewItem[] { item1 });

                        if (masDeUnArticulo)
                        {
                            chorizaco += ",(" + textBoxNumTicket.Text + "," + vid_articulo + ",'" + vcategoria + "','" + vmarca + "'," + vprecio + "," + textBoxCantidad.Text +
                                        "," + textBox_numCliente.Text + ")";
                        }
                        else 
                        {
                            chorizaco = "(" + textBoxNumTicket.Text + "," + vid_articulo + ",'" + vcategoria + "','" + vmarca + "'," + vprecio + "," + textBoxCantidad.Text +
                                        "," + textBox_numCliente.Text + ")";
                        }

                        masDeUnArticulo = true;

                        comboBoxArticulo.SelectedIndex = -1;
                        textBoxCantidad.Text = "";
                    }
                    conexion.Close();
                }
                catch
                {
                    mostrarMensajaError();
                }
            }
        }

        public void realizarInsercionTabla()
        {
            try
            {
                // Iniciamos la conexion.
                conexion.Open();
                // Aqui hariamos la consulta.
                sentenciaSQL = "INSERT INTO sql27652.compra VALUES" + chorizaco + ";";

                comando = new MySqlCommand(sentenciaSQL, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Pedido realizado correctamente");

            }
            catch {
                mostrarMensajaError();
            }

        }


    }
}
