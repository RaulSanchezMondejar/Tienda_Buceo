namespace Tienda_Buceo_v1
{
    partial class Form5
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_salir_si = new System.Windows.Forms.Button();
            this.button_salir_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿ Desea salir del programa ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_salir_si
            // 
            this.button_salir_si.Location = new System.Drawing.Point(158, 72);
            this.button_salir_si.Name = "button_salir_si";
            this.button_salir_si.Size = new System.Drawing.Size(75, 23);
            this.button_salir_si.TabIndex = 1;
            this.button_salir_si.Text = "SI";
            this.button_salir_si.UseVisualStyleBackColor = true;
            this.button_salir_si.Click += new System.EventHandler(this.button_salir_si_Click);
            // 
            // button_salir_no
            // 
            this.button_salir_no.Location = new System.Drawing.Point(52, 72);
            this.button_salir_no.Name = "button_salir_no";
            this.button_salir_no.Size = new System.Drawing.Size(75, 23);
            this.button_salir_no.TabIndex = 2;
            this.button_salir_no.Text = "NO";
            this.button_salir_no.UseVisualStyleBackColor = true;
            this.button_salir_no.Click += new System.EventHandler(this.button_salir_no_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.ControlBox = false;
            this.Controls.Add(this.button_salir_no);
            this.Controls.Add(this.button_salir_si);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_salir_si;
        private System.Windows.Forms.Button button_salir_no;
    }
}