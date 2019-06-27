namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SalidaRespuesta = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Operar = new System.Windows.Forms.Button();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.ConvertDecimal = new System.Windows.Forms.Button();
            this.ConvertBinario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SalidaRespuesta
            // 
            this.SalidaRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalidaRespuesta.Location = new System.Drawing.Point(194, 10);
            this.SalidaRespuesta.Name = "SalidaRespuesta";
            this.SalidaRespuesta.Size = new System.Drawing.Size(280, 31);
            this.SalidaRespuesta.TabIndex = 4;
            this.SalidaRespuesta.Text = "0";
            this.SalidaRespuesta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //this.SalidaRespuesta.Click += new System.EventHandler(this.SalidaRespuesta_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(35, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(224, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 39);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(327, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 38);
            this.textBox2.TabIndex = 2;
            // 
            // Operar
            // 
            this.Operar.Location = new System.Drawing.Point(35, 105);
            this.Operar.Name = "Operar";
            this.Operar.Size = new System.Drawing.Size(143, 34);
            this.Operar.TabIndex = 3;
            this.Operar.Text = "Operar";
            this.Operar.UseVisualStyleBackColor = true;
            this.Operar.Click += new System.EventHandler(this.Operar_Click);
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(194, 105);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(121, 34);
            this.Limpiar.TabIndex = 5;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(327, 105);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(147, 34);
            this.Cerrar.TabIndex = 6;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // ConvertDecimal
            // 
            this.ConvertDecimal.Location = new System.Drawing.Point(35, 164);
            this.ConvertDecimal.Name = "ConvertDecimal";
            this.ConvertDecimal.Size = new System.Drawing.Size(211, 35);
            this.ConvertDecimal.TabIndex = 7;
            this.ConvertDecimal.Text = "Convertir a Decimal";
            this.ConvertDecimal.UseVisualStyleBackColor = true;
            this.ConvertDecimal.Click += new System.EventHandler(this.ConvertDecimal_Click);
            // 
            // ConvertBinario
            // 
            this.ConvertBinario.Location = new System.Drawing.Point(252, 164);
            this.ConvertBinario.Name = "ConvertBinario";
            this.ConvertBinario.Size = new System.Drawing.Size(222, 35);
            this.ConvertBinario.TabIndex = 8;
            this.ConvertBinario.Text = "Covertir a Binario";
            this.ConvertBinario.UseVisualStyleBackColor = true;
            this.ConvertBinario.Click += new System.EventHandler(this.ConvertBinario_Click);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 217);
            this.Controls.Add(this.ConvertBinario);
            this.Controls.Add(this.ConvertDecimal);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Operar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SalidaRespuesta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Jose Arias  del Curso 2°A";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SalidaRespuesta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Operar;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button ConvertDecimal;
        private System.Windows.Forms.Button ConvertBinario;
    }
}

