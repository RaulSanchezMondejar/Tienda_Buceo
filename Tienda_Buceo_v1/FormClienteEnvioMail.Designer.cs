namespace Tienda_Buceo_v1
{
    partial class FormClienteEnvioMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClienteEnvioMail));
            this.label1 = new System.Windows.Forms.Label();
            this.label_apellido2 = new System.Windows.Forms.Label();
            this.textBoxAsunto = new System.Windows.Forms.TextBox();
            this.labelAsunto = new System.Windows.Forms.Label();
            this.boton_Borrar = new System.Windows.Forms.Button();
            this.botonBuscarPorTitulacion = new System.Windows.Forms.Button();
            this.boton_cancelar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBoxPara = new System.Windows.Forms.TextBox();
            this.comboBox_titulacion = new System.Windows.Forms.ComboBox();
            this.labelDireccionDestino = new System.Windows.Forms.Label();
            this.comboBoxUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBusquedaPersonalizada = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.buttonColorFuente = new System.Windows.Forms.Button();
            this.buttonTipoFuente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(778, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Envio Mail a Clientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_apellido2
            // 
            this.label_apellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_apellido2.Location = new System.Drawing.Point(18, 163);
            this.label_apellido2.Name = "label_apellido2";
            this.label_apellido2.Size = new System.Drawing.Size(67, 24);
            this.label_apellido2.TabIndex = 5;
            this.label_apellido2.Text = "Para:";
            // 
            // textBoxAsunto
            // 
            this.textBoxAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAsunto.Location = new System.Drawing.Point(118, 220);
            this.textBoxAsunto.Name = "textBoxAsunto";
            this.textBoxAsunto.Size = new System.Drawing.Size(639, 22);
            this.textBoxAsunto.TabIndex = 14;
            // 
            // labelAsunto
            // 
            this.labelAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsunto.Location = new System.Drawing.Point(18, 223);
            this.labelAsunto.Name = "labelAsunto";
            this.labelAsunto.Size = new System.Drawing.Size(67, 24);
            this.labelAsunto.TabIndex = 13;
            this.labelAsunto.Text = "Asunto:";
            // 
            // boton_Borrar
            // 
            this.boton_Borrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_Borrar.Location = new System.Drawing.Point(334, 526);
            this.boton_Borrar.Name = "boton_Borrar";
            this.boton_Borrar.Size = new System.Drawing.Size(75, 23);
            this.boton_Borrar.TabIndex = 17;
            this.boton_Borrar.Text = "Borrar";
            this.boton_Borrar.UseVisualStyleBackColor = true;
            this.boton_Borrar.Click += new System.EventHandler(this.boton_Borrar_Click);
            // 
            // botonBuscarPorTitulacion
            // 
            this.botonBuscarPorTitulacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscarPorTitulacion.Location = new System.Drawing.Point(284, 93);
            this.botonBuscarPorTitulacion.Name = "botonBuscarPorTitulacion";
            this.botonBuscarPorTitulacion.Size = new System.Drawing.Size(75, 23);
            this.botonBuscarPorTitulacion.TabIndex = 18;
            this.botonBuscarPorTitulacion.Text = "Insertar";
            this.botonBuscarPorTitulacion.UseVisualStyleBackColor = true;
            this.botonBuscarPorTitulacion.Click += new System.EventHandler(this.boton_Buscar_Click);
            // 
            // boton_cancelar
            // 
            this.boton_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_cancelar.Location = new System.Drawing.Point(253, 526);
            this.boton_cancelar.Name = "boton_cancelar";
            this.boton_cancelar.Size = new System.Drawing.Size(75, 23);
            this.boton_cancelar.TabIndex = 20;
            this.boton_cancelar.Text = "Cancelar";
            this.boton_cancelar.UseVisualStyleBackColor = true;
            this.boton_cancelar.Click += new System.EventHandler(this.boton_cancelar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 319);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(736, 183);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // textBoxPara
            // 
            this.textBoxPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPara.Location = new System.Drawing.Point(118, 144);
            this.textBoxPara.Multiline = true;
            this.textBoxPara.Name = "textBoxPara";
            this.textBoxPara.Size = new System.Drawing.Size(639, 58);
            this.textBoxPara.TabIndex = 26;
            // 
            // comboBox_titulacion
            // 
            this.comboBox_titulacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_titulacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_titulacion.FormattingEnabled = true;
            this.comboBox_titulacion.Location = new System.Drawing.Point(21, 93);
            this.comboBox_titulacion.Name = "comboBox_titulacion";
            this.comboBox_titulacion.Size = new System.Drawing.Size(257, 24);
            this.comboBox_titulacion.TabIndex = 16;
            // 
            // labelDireccionDestino
            // 
            this.labelDireccionDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccionDestino.Location = new System.Drawing.Point(18, 78);
            this.labelDireccionDestino.Name = "labelDireccionDestino";
            this.labelDireccionDestino.Size = new System.Drawing.Size(260, 24);
            this.labelDireccionDestino.TabIndex = 15;
            this.labelDireccionDestino.Text = "Busqueda Por Titulación";
            // 
            // comboBoxUsuario
            // 
            this.comboBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUsuario.FormattingEnabled = true;
            this.comboBoxUsuario.Location = new System.Drawing.Point(418, 93);
            this.comboBoxUsuario.Name = "comboBoxUsuario";
            this.comboBoxUsuario.Size = new System.Drawing.Size(257, 24);
            this.comboBoxUsuario.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Busqueda Personalizada:";
            // 
            // buttonBusquedaPersonalizada
            // 
            this.buttonBusquedaPersonalizada.Location = new System.Drawing.Point(682, 93);
            this.buttonBusquedaPersonalizada.Name = "buttonBusquedaPersonalizada";
            this.buttonBusquedaPersonalizada.Size = new System.Drawing.Size(75, 23);
            this.buttonBusquedaPersonalizada.TabIndex = 29;
            this.buttonBusquedaPersonalizada.Text = "Insertar";
            this.buttonBusquedaPersonalizada.UseVisualStyleBackColor = true;
            this.buttonBusquedaPersonalizada.Click += new System.EventHandler(this.buttonBusquedaPersonalizada_Click);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviar.Location = new System.Drawing.Point(418, 526);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 30;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonColorFuente
            // 
            this.buttonColorFuente.Location = new System.Drawing.Point(21, 279);
            this.buttonColorFuente.Name = "buttonColorFuente";
            this.buttonColorFuente.Size = new System.Drawing.Size(105, 23);
            this.buttonColorFuente.TabIndex = 31;
            this.buttonColorFuente.Text = "Elegir Color";
            this.buttonColorFuente.UseVisualStyleBackColor = true;
            this.buttonColorFuente.Click += new System.EventHandler(this.buttonColorFuente_Click);
            // 
            // buttonTipoFuente
            // 
            this.buttonTipoFuente.Location = new System.Drawing.Point(132, 279);
            this.buttonTipoFuente.Name = "buttonTipoFuente";
            this.buttonTipoFuente.Size = new System.Drawing.Size(112, 23);
            this.buttonTipoFuente.TabIndex = 32;
            this.buttonTipoFuente.Text = "Elegir Fuente";
            this.buttonTipoFuente.UseVisualStyleBackColor = true;
            this.buttonTipoFuente.Click += new System.EventHandler(this.buttonTipoFuente_Click);
            // 
            // FormClienteEnvioMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTipoFuente);
            this.Controls.Add(this.buttonColorFuente);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.buttonBusquedaPersonalizada);
            this.Controls.Add(this.comboBoxUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPara);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.boton_cancelar);
            this.Controls.Add(this.botonBuscarPorTitulacion);
            this.Controls.Add(this.boton_Borrar);
            this.Controls.Add(this.comboBox_titulacion);
            this.Controls.Add(this.labelDireccionDestino);
            this.Controls.Add(this.textBoxAsunto);
            this.Controls.Add(this.labelAsunto);
            this.Controls.Add(this.label_apellido2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormClienteEnvioMail";
            this.Text = "Envio Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_apellido2;
        private System.Windows.Forms.TextBox textBoxAsunto;
        private System.Windows.Forms.Label labelAsunto;
        private System.Windows.Forms.Button boton_Borrar;
        private System.Windows.Forms.Button botonBuscarPorTitulacion;
        private System.Windows.Forms.Button boton_cancelar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBoxPara;
        private System.Windows.Forms.ComboBox comboBox_titulacion;
        private System.Windows.Forms.Label labelDireccionDestino;
        private System.Windows.Forms.ComboBox comboBoxUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBusquedaPersonalizada;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button buttonColorFuente;
        private System.Windows.Forms.Button buttonTipoFuente;
    }
}