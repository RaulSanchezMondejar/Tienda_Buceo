namespace Tienda_Buceo_v1
{
    partial class FormClienteHistorialMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClienteHistorialMail));
            this.label1 = new System.Windows.Forms.Label();
            this.label_apellido2 = new System.Windows.Forms.Label();
            this.textBoxAsunto = new System.Windows.Forms.TextBox();
            this.labelAsunto = new System.Windows.Forms.Label();
            this.boton_cancelar = new System.Windows.Forms.Button();
            this.richTextBoxCuerpo = new System.Windows.Forms.RichTextBox();
            this.textBoxPara = new System.Windows.Forms.TextBox();
            this.comboBoxHistorial = new System.Windows.Forms.ComboBox();
            this.labelHistoricoMail = new System.Windows.Forms.Label();
            this.buttonBusquedaPersonalizada = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.buttonColorFuente = new System.Windows.Forms.Button();
            this.buttonTipoFuente = new System.Windows.Forms.Button();
            this.botonEditar = new System.Windows.Forms.Button();
            this.buttonReenviar = new System.Windows.Forms.Button();
            this.buttonRecargarHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(778, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Historial Envio Mail a Clientes";
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
            this.textBoxAsunto.Enabled = false;
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
            // richTextBoxCuerpo
            // 
            this.richTextBoxCuerpo.Enabled = false;
            this.richTextBoxCuerpo.Location = new System.Drawing.Point(21, 319);
            this.richTextBoxCuerpo.Name = "richTextBoxCuerpo";
            this.richTextBoxCuerpo.Size = new System.Drawing.Size(736, 183);
            this.richTextBoxCuerpo.TabIndex = 25;
            this.richTextBoxCuerpo.Text = "";
            // 
            // textBoxPara
            // 
            this.textBoxPara.Enabled = false;
            this.textBoxPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPara.Location = new System.Drawing.Point(118, 144);
            this.textBoxPara.Multiline = true;
            this.textBoxPara.Name = "textBoxPara";
            this.textBoxPara.Size = new System.Drawing.Size(639, 58);
            this.textBoxPara.TabIndex = 26;
            // 
            // comboBoxHistorial
            // 
            this.comboBoxHistorial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHistorial.FormattingEnabled = true;
            this.comboBoxHistorial.Location = new System.Drawing.Point(14, 85);
            this.comboBoxHistorial.Name = "comboBoxHistorial";
            this.comboBoxHistorial.Size = new System.Drawing.Size(257, 24);
            this.comboBoxHistorial.TabIndex = 28;
            // 
            // labelHistoricoMail
            // 
            this.labelHistoricoMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistoricoMail.Location = new System.Drawing.Point(11, 70);
            this.labelHistoricoMail.Name = "labelHistoricoMail";
            this.labelHistoricoMail.Size = new System.Drawing.Size(260, 24);
            this.labelHistoricoMail.TabIndex = 27;
            this.labelHistoricoMail.Text = "Busqueda Historico Correos:";
            // 
            // buttonBusquedaPersonalizada
            // 
            this.buttonBusquedaPersonalizada.Location = new System.Drawing.Point(278, 85);
            this.buttonBusquedaPersonalizada.Name = "buttonBusquedaPersonalizada";
            this.buttonBusquedaPersonalizada.Size = new System.Drawing.Size(75, 23);
            this.buttonBusquedaPersonalizada.TabIndex = 29;
            this.buttonBusquedaPersonalizada.Text = "Mostrar";
            this.buttonBusquedaPersonalizada.UseVisualStyleBackColor = true;
            this.buttonBusquedaPersonalizada.Click += new System.EventHandler(this.buttonBusquedaPersonalizada_Click);
            // 
            // buttonColorFuente
            // 
            this.buttonColorFuente.Enabled = false;
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
            this.buttonTipoFuente.Enabled = false;
            this.buttonTipoFuente.Location = new System.Drawing.Point(132, 279);
            this.buttonTipoFuente.Name = "buttonTipoFuente";
            this.buttonTipoFuente.Size = new System.Drawing.Size(112, 23);
            this.buttonTipoFuente.TabIndex = 32;
            this.buttonTipoFuente.Text = "Elegir Fuente";
            this.buttonTipoFuente.UseVisualStyleBackColor = true;
            this.buttonTipoFuente.Click += new System.EventHandler(this.buttonTipoFuente_Click);
            // 
            // botonEditar
            // 
            this.botonEditar.Enabled = false;
            this.botonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEditar.Location = new System.Drawing.Point(334, 526);
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.Size = new System.Drawing.Size(75, 23);
            this.botonEditar.TabIndex = 17;
            this.botonEditar.Text = "Editar";
            this.botonEditar.UseVisualStyleBackColor = true;
            this.botonEditar.Click += new System.EventHandler(this.boton_Borrar_Click);
            // 
            // buttonReenviar
            // 
            this.buttonReenviar.Enabled = false;
            this.buttonReenviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReenviar.Location = new System.Drawing.Point(418, 526);
            this.buttonReenviar.Name = "buttonReenviar";
            this.buttonReenviar.Size = new System.Drawing.Size(75, 23);
            this.buttonReenviar.TabIndex = 30;
            this.buttonReenviar.Text = "Reenviar";
            this.buttonReenviar.UseVisualStyleBackColor = true;
            this.buttonReenviar.Click += new System.EventHandler(this.buttonReenviar_Click);
            // 
            // buttonRecargarHistorial
            // 
            this.buttonRecargarHistorial.Location = new System.Drawing.Point(620, 85);
            this.buttonRecargarHistorial.Name = "buttonRecargarHistorial";
            this.buttonRecargarHistorial.Size = new System.Drawing.Size(137, 23);
            this.buttonRecargarHistorial.TabIndex = 33;
            this.buttonRecargarHistorial.Text = "Recargar Historial";
            this.buttonRecargarHistorial.UseVisualStyleBackColor = true;
            this.buttonRecargarHistorial.Click += new System.EventHandler(this.buttonRecargarHistorial_Click);
            // 
            // FormClienteHistorialMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRecargarHistorial);
            this.Controls.Add(this.buttonTipoFuente);
            this.Controls.Add(this.buttonColorFuente);
            this.Controls.Add(this.buttonReenviar);
            this.Controls.Add(this.buttonBusquedaPersonalizada);
            this.Controls.Add(this.comboBoxHistorial);
            this.Controls.Add(this.labelHistoricoMail);
            this.Controls.Add(this.textBoxPara);
            this.Controls.Add(this.richTextBoxCuerpo);
            this.Controls.Add(this.boton_cancelar);
            this.Controls.Add(this.botonEditar);
            this.Controls.Add(this.textBoxAsunto);
            this.Controls.Add(this.labelAsunto);
            this.Controls.Add(this.label_apellido2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormClienteHistorialMail";
            this.Text = "Historial Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_apellido2;
        private System.Windows.Forms.TextBox textBoxAsunto;
        private System.Windows.Forms.Label labelAsunto;
        private System.Windows.Forms.Button boton_cancelar;
        private System.Windows.Forms.RichTextBox richTextBoxCuerpo;
        private System.Windows.Forms.TextBox textBoxPara;
        private System.Windows.Forms.ComboBox comboBoxHistorial;
        private System.Windows.Forms.Label labelHistoricoMail;
        private System.Windows.Forms.Button buttonBusquedaPersonalizada;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button buttonColorFuente;
        private System.Windows.Forms.Button buttonTipoFuente;
        private System.Windows.Forms.Button botonEditar;
        private System.Windows.Forms.Button buttonReenviar;
        private System.Windows.Forms.Button buttonRecargarHistorial;
    }
}