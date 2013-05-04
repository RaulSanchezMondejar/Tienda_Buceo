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
            Hide();
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

            // Iniciamos la conexion.
            conexion.Open();

            // Aqui hariamos la consulta.
            sentenciaSQL = "SELECT * FROM sql27652.clientes WHERE id_cliente LIKE 0" + textBox_numCliente.Text.ToString() + ";";


            comando = new MySqlCommand(sentenciaSQL, conexion);
            resultado = comando.ExecuteReader();

            listView1.Items.Clear();

            if (resultado.Read())
            {

                ListViewItem item1 = new ListViewItem(resultado["id_cliente"].ToString());
                item1.SubItems.Add(resultado["nombre"].ToString());
                item1.SubItems.Add(resultado["apellido1"].ToString());
                item1.SubItems.Add(resultado["apellido2"].ToString());
                item1.SubItems.Add(resultado["telefono_fijo"].ToString());
                item1.SubItems.Add(resultado["telefono_movil"].ToString());
                item1.SubItems.Add(resultado["correo_electronico"].ToString());
                item1.SubItems.Add(resultado["titulacion"].ToString());

                /*
                ListViewItem item2 = new ListViewItem(resultado["id_cliente"].ToString());
                item2.SubItems.Add(resultado["nombre"].ToString());
                item2.SubItems.Add(resultado["apellido1"].ToString());
                item2.SubItems.Add(resultado["apellido2"].ToString());
                item2.SubItems.Add(resultado["telefono_fijo"].ToString());
                item2.SubItems.Add(resultado["telefono_movil"].ToString());
                item2.SubItems.Add(resultado["correo_electronico"].ToString());
                item2.SubItems.Add(resultado["titulacion"].ToString());

                ListViewItem item3 = new ListViewItem(resultado["id_cliente"].ToString());
                item3.SubItems.Add(resultado["nombre"].ToString());
                item3.SubItems.Add(resultado["apellido1"].ToString());
                item3.SubItems.Add(resultado["apellido2"].ToString());
                item3.SubItems.Add(resultado["telefono_fijo"].ToString());
                item3.SubItems.Add(resultado["telefono_movil"].ToString());
                item3.SubItems.Add(resultado["correo_electronico"].ToString());
                item3.SubItems.Add(resultado["titulacion"].ToString());



                listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
                 */
                listView1.Items.AddRange(new ListViewItem[] { item1});

                conexion.Close();

                insertarFoto();
            }
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
                pictureBox1.Image = new Bitmap(@"D:\Fotos\" + numeroClienteFoto + ".png");      
            }
            catch {
                pictureBox1.Image = new Bitmap(@"\Fotos\0.png");
            }   
        }
    }
}
