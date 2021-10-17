
namespace Cliente_temperatura
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CaF = new System.Windows.Forms.RadioButton();
            this.FaC = new System.Windows.Forms.RadioButton();
            this.TemperaturaBox = new System.Windows.Forms.TextBox();
            this.Resultado = new System.Windows.Forms.Label();
            this.Enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Convertidor de Temperatura";
            // 
            // CaF
            // 
            this.CaF.AutoSize = true;
            this.CaF.Location = new System.Drawing.Point(27, 78);
            this.CaF.Name = "CaF";
            this.CaF.Size = new System.Drawing.Size(236, 24);
            this.CaF.TabIndex = 1;
            this.CaF.TabStop = true;
            this.CaF.Text = "De celsius (ºC) a Fahrenheit (ºF)";
            this.CaF.UseVisualStyleBackColor = true;
            // 
            // FaC
            // 
            this.FaC.AutoSize = true;
            this.FaC.Location = new System.Drawing.Point(27, 108);
            this.FaC.Name = "FaC";
            this.FaC.Size = new System.Drawing.Size(236, 24);
            this.FaC.TabIndex = 2;
            this.FaC.TabStop = true;
            this.FaC.Text = "De Fahrenheit (ºF) a celsius (ºC)";
            this.FaC.UseVisualStyleBackColor = true;
            // 
            // TemperaturaBox
            // 
            this.TemperaturaBox.Location = new System.Drawing.Point(298, 93);
            this.TemperaturaBox.Name = "TemperaturaBox";
            this.TemperaturaBox.Size = new System.Drawing.Size(331, 27);
            this.TemperaturaBox.TabIndex = 3;
            // 
            // Resultado
            // 
            this.Resultado.AutoSize = true;
            this.Resultado.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Resultado.Location = new System.Drawing.Point(401, 164);
            this.Resultado.Name = "Resultado";
            this.Resultado.Size = new System.Drawing.Size(124, 35);
            this.Resultado.TabIndex = 4;
            this.Resultado.Text = "Resultado";
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(121, 164);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(115, 43);
            this.Enviar.TabIndex = 5;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 237);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.TemperaturaBox);
            this.Controls.Add(this.FaC);
            this.Controls.Add(this.CaF);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton CaF;
        private System.Windows.Forms.RadioButton FaC;
        private System.Windows.Forms.TextBox TemperaturaBox;
        private System.Windows.Forms.Label Resultado;
        private System.Windows.Forms.Button Enviar;
    }
}

