namespace Tienda_Buceo_v1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.label_usuario = new System.Windows.Forms.Label();
            this.label_contrasena = new System.Windows.Forms.Label();
            this.textBox_contrasena = new System.Windows.Forms.TextBox();
            this.boton_entrar = new System.Windows.Forms.Button();
            this.boton_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_errorUsuarioContrasena = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(107, 51);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(127, 20);
            this.textBox_usuario.TabIndex = 0;
            this.textBox_usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_usuario
            // 
            this.label_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.Location = new System.Drawing.Point(18, 47);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(83, 24);
            this.label_usuario.TabIndex = 1;
            this.label_usuario.Text = "Usuario";
            this.label_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_contrasena
            // 
            this.label_contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contrasena.Location = new System.Drawing.Point(18, 73);
            this.label_contrasena.Name = "label_contrasena";
            this.label_contrasena.Size = new System.Drawing.Size(83, 24);
            this.label_contrasena.TabIndex = 3;
            this.label_contrasena.Text = "Contraseña";
            this.label_contrasena.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_contrasena
            // 
            this.textBox_contrasena.Location = new System.Drawing.Point(107, 77);
            this.textBox_contrasena.Name = "textBox_contrasena";
            this.textBox_contrasena.PasswordChar = '*';
            this.textBox_contrasena.Size = new System.Drawing.Size(127, 20);
            this.textBox_contrasena.TabIndex = 2;
            this.textBox_contrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // boton_entrar
            // 
            this.boton_entrar.Location = new System.Drawing.Point(159, 117);
            this.boton_entrar.Name = "boton_entrar";
            this.boton_entrar.Size = new System.Drawing.Size(75, 23);
            this.boton_entrar.TabIndex = 4;
            this.boton_entrar.Text = "Entrar";
            this.boton_entrar.UseVisualStyleBackColor = true;
            this.boton_entrar.Click += new System.EventHandler(this.boton_entrar_Click);
            // 
            // boton_salir
            // 
            this.boton_salir.Location = new System.Drawing.Point(78, 117);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(75, 23);
            this.boton_salir.TabIndex = 5;
            this.boton_salir.Text = "Salir";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Introducir Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_errorUsuarioContrasena
            // 
            this.label_errorUsuarioContrasena.ForeColor = System.Drawing.Color.DarkRed;
            this.label_errorUsuarioContrasena.Location = new System.Drawing.Point(12, 101);
            this.label_errorUsuarioContrasena.Name = "label_errorUsuarioContrasena";
            this.label_errorUsuarioContrasena.Size = new System.Drawing.Size(260, 13);
            this.label_errorUsuarioContrasena.TabIndex = 7;
            this.label_errorUsuarioContrasena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label_errorUsuarioContrasena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.boton_entrar);
            this.Controls.Add(this.label_contrasena);
            this.Controls.Add(this.textBox_contrasena);
            this.Controls.Add(this.label_usuario);
            this.Controls.Add(this.textBox_usuario);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Label label_contrasena;
        private System.Windows.Forms.TextBox textBox_contrasena;
        private System.Windows.Forms.Button boton_entrar;
        private System.Windows.Forms.Button boton_salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_errorUsuarioContrasena;
    }
}

