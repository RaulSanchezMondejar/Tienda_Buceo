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
    public partial class FormClienteBusqueda : Form
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

        ListViewItem item1;
    

        public FormClienteBusqueda(FormPantallaPrincipal F)
        {
            InitializeComponent();

            formPantallaInicial = F;

            // Introducimos las siguientes campos del desplegable.
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
            catch {}
            
            // Marcamos como activo el campo de número Cliente.
            ActiveControl = textBox_numCliente;
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
            textBox_numCliente.Text = "";
            textBox_nombre.Text = "";
            textBox_apellido1.Text = "";
            textBox_apellido2.Text = "";
            textBox_telefonoFijo.Text = "";
            textBox_telefonoMovil.Text = "";
            textBox_correoElectronico.Text = "";
            comboBox_titulacion.Text = "";

            listView1.Items.Clear();
            label2.Text = "";

            comboBox_titulacion.SelectedIndex = -1;

            try
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\0.png");
            }
            catch { } 
        }

        private void textoAMayusculas()
        {
            textBox_nombre.Text = textBox_nombre.Text.ToUpper();
            textBox_apellido1.Text = textBox_apellido1.Text.ToUpper();
            textBox_apellido2.Text = textBox_apellido2.Text.ToUpper();
            textBox_correoElectronico.Text = textBox_correoElectronico.Text.ToUpper();
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
            if ((textBox_numCliente.Text != "") || (textBox_nombre.Text != "") || (textBox_apellido1.Text != "") || (textBox_apellido2.Text != "")
                || (textBox_telefonoFijo.Text != "") || (textBox_telefonoMovil.Text != "") || (textBox_correoElectronico.Text != "")
                || (comboBox_titulacion.Text != ""))
            {

                // Lo primero que vamos a hacer es pasar todos los campos a mayusculas.
                textoAMayusculas();

                try { pictureBox1.Image = new Bitmap(@"\Fotos\0.png"); }
                catch { }

                // Aqui hariamos la consulta.
                sentenciaSQL = "SELECT * FROM sql27652.clientes WHERE ";
                Boolean masDeUnCampo = false;
                foreach (Control x in this.Controls)
                {
                    if ((x is TextBox) || (x is ComboBox))
                    {
                        String nombreCajaTexto = x.Name;
                        String campo = obtenerValorCampo(x);
                        String columna = "";
                        Boolean esNumero = false;
                        Console.WriteLine(">> Leyendo el campo: " + campo);
                        if ((campo != "") && (campo != "-1"))
                        {
                            if (nombreCajaTexto.Equals("textBox_numCliente"))
                            {
                                columna = "id_cliente";
                                esNumero = true;
                            }
                            else if (nombreCajaTexto.Equals("textBox_nombre"))
                            {
                                columna = "nombre";
                            }
                            else if (nombreCajaTexto.Equals("textBox_apellido1"))
                            {
                                columna = "apellido1";
                            }
                            else if (nombreCajaTexto.Equals("textBox_apellido2"))
                            {
                                columna = "apellido2";
                            }
                            else if (nombreCajaTexto.Equals("textBox_telefonoFijo"))
                            {
                                columna = "telefono_fijo";
                            }
                            else if (nombreCajaTexto.Equals("textBox_telefonoMovil"))
                            {
                                columna = "telefono_movil";
                            }
                            else if (nombreCajaTexto.Equals("textBox_correoElectronico"))
                            {
                                columna = "correo_electronico";
                            }
                            else if (nombreCajaTexto.Equals("comboBox_titulacion"))
                            {
                                columna = "titulacion";
                            }

                            Console.WriteLine(">> Leyendo el campo: " + columna);
                            if (masDeUnCampo)
                            {
                                sentenciaSQL += " AND ";
                            }
                            else
                            {
                                masDeUnCampo = true;
                            }

                            if (esNumero)
                            {
                                sentenciaSQL += columna + " = " + campo;
                            }
                            else
                            {
                                sentenciaSQL += columna + " = '" + campo + "'";
                            }

                        }
                    }
                }

                try
                {
                    // Iniciamos la conexion.
                    conexion.Open();
                    comando = new MySqlCommand(sentenciaSQL, conexion);
                    resultado = comando.ExecuteReader();
                    Console.WriteLine(">> Realizando la consulta: " + sentenciaSQL);
                    listView1.Items.Clear();
                    int numResultados = 0;
                    while (resultado.Read())
                    {
                        item1 = new ListViewItem(resultado["id_cliente"].ToString());
                        item1.SubItems.Add(resultado["nombre"].ToString());
                        item1.SubItems.Add(resultado["apellido1"].ToString());
                        item1.SubItems.Add(resultado["apellido2"].ToString());
                        item1.SubItems.Add(resultado["telefono_fijo"].ToString());
                        item1.SubItems.Add(resultado["telefono_movil"].ToString());
                        item1.SubItems.Add(resultado["correo_electronico"].ToString());

                        int datoAuxiliar = Int32.Parse(resultado["titulacion"].ToString());
                        switch (datoAuxiliar)
                        {
                            case 1: item1.SubItems.Add("DISCOVERY SCUBA DIVER"); break;
                            case 2: item1.SubItems.Add("OPEN WATER DIVER"); break;
                            case 3: item1.SubItems.Add("ADVANCE OPEN WATER DIVER"); break;
                            case 4: item1.SubItems.Add("RESCUE DIVER"); break;
                            case 5: item1.SubItems.Add("DIVEMASTER"); break;
                            case 6: item1.SubItems.Add("INSTRUCTOR"); break;
                            case 0: item1.SubItems.Add("SIN TITULACION"); break;
                            default: item1.SubItems.Add("SIN TITULACION"); break;
                        }

                        listView1.Items.AddRange(new ListViewItem[] { item1 });
                        numResultados++;
                    }
                    if (numResultados > 0)
                    {
                        label2.Text = "Se han encontrado los siguientes resultados:";
                        if (numResultados == 1)
                        {
                            insertarFoto();
                        }
                    }
                    else
                    {
                        label2.Text = "No se ha encontrado ningún resultado";
                    }
                    conexion.Close();
                }
                catch
                {
                    mostrarMensajaError();
                }
            }
            else {
                borrarDatos();
                MessageBox.Show("Error: No se ha insertado ningun dato de busqueda");
                ActiveControl = textBox_numCliente;
            }
        }


        private void mostrarMensajaError()
        {
            label1.Text = "Sin conexión con la BBDD";
            textBox_numCliente.Visible = false;
            boton_Borrar.Visible = false;
            boton_Buscar.Visible = false;
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
            label_numCliente.Visible = false;
            label2.Visible = false;
            listView1.Visible = false;

            this.MaximumSize = new System.Drawing.Size(800, 345);
            this.MinimumSize = new System.Drawing.Size(800, 345);
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



        //metodo para obtener el valor de un campo del formulario de tipo textBox o comboBox
        public String obtenerValorCampo(Control x)
        {
            String campo;
            if (x is TextBox)
            {
                campo = ((TextBox)x).Text;
            }
            else
            {
                campo = ((ComboBox)x).SelectedIndex.ToString();
            }
            return campo;
        }

        private void insertarFoto()
        {
            int numeroClienteFoto;
            if (textBox_numCliente.Text == "")
            {
                numeroClienteFoto = Int32.Parse(listView1.Items[0].SubItems[0].Text);
            }
            else
            {
                numeroClienteFoto = Int32.Parse(textBox_numCliente.Text);
            }

            try{
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\" + numeroClienteFoto + ".png");
                
            }
            catch {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\0.png");
            }   
        }
    }
}
