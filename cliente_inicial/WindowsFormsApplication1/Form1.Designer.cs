namespace WindowsFormsApplication1
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
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numServicios = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.crearFormularioBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 336);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 40);
            this.button3.TabIndex = 14;
            this.button3.Text = "Desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numServicios
            // 
            this.numServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numServicios.Location = new System.Drawing.Point(423, 159);
            this.numServicios.Name = "numServicios";
            this.numServicios.Size = new System.Drawing.Size(214, 91);
            this.numServicios.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Número de Servicios";
            // 
            // crearFormularioBtn
            // 
            this.crearFormularioBtn.Location = new System.Drawing.Point(39, 174);
            this.crearFormularioBtn.Name = "crearFormularioBtn";
            this.crearFormularioBtn.Size = new System.Drawing.Size(279, 82);
            this.crearFormularioBtn.TabIndex = 18;
            this.crearFormularioBtn.Text = "Crear Formulario";
            this.crearFormularioBtn.UseVisualStyleBackColor = true;
            this.crearFormularioBtn.Click += new System.EventHandler(this.crearFormularioBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 409);
            this.Controls.Add(this.crearFormularioBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numServicios);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label numServicios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button crearFormularioBtn;
    }
}

