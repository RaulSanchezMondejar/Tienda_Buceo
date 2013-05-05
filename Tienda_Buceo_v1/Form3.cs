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
    public partial class Form3 : Form
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

        ListViewItem item1;
    

        public Form3(Form2 F)
        {
            InitializeComponent();

            formPantallaInicial = F;

            // Introducimos las siguientes campos.
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

            try
            {
                pictureBox1.Image = new Bitmap(@"\Fotos\0.png");
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
            // Lo primero que vamos a hacer es pasar todos los campos a mayusculas.
            textoAMayusculas();

            try {pictureBox1.Image = new Bitmap(@"\Fotos\0.png");}
            catch{} 

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
                    item1.SubItems.Add(resultado["titulacion"].ToString());
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
            catch (Exception)
            {
                Console.WriteLine("Se ha producido un error al realizar la consulta: " + sentenciaSQL);
            }

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
                numeroClienteFoto = 0;
            }
            else
            {
                numeroClienteFoto = Int32.Parse(textBox_numCliente.Text);
            }

            try{
                //pictureBox1.Image = new Bitmap(@"D:\Fotos\" + numeroClienteFoto + ".png");
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\" + numeroClienteFoto + ".png");
                
            }
            catch {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Fotos\\0.png");
            }   
        }
    }
}
