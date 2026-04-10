namespace Colsultorio_Dental.Eliminar
{
    partial class EliminarPacientes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnActualizarMotivos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnActualizarMotivos);
            this.groupBox1.Location = new System.Drawing.Point(48, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 190);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(32, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inserte Id a eliminar ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 22);
            this.textBox2.TabIndex = 7;
            // 
            // btnActualizarMotivos
            // 
            this.btnActualizarMotivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnActualizarMotivos.Location = new System.Drawing.Point(56, 110);
            this.btnActualizarMotivos.Name = "btnActualizarMotivos";
            this.btnActualizarMotivos.Size = new System.Drawing.Size(127, 49);
            this.btnActualizarMotivos.TabIndex = 4;
            this.btnActualizarMotivos.Text = "Guardar";
            this.btnActualizarMotivos.UseVisualStyleBackColor = true;
            this.btnActualizarMotivos.Click += new System.EventHandler(this.btnActualizarMotivos_Click);
            // 
            // EliminarPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 285);
            this.Controls.Add(this.groupBox1);
            this.Name = "EliminarPacientes";
            this.Text = "EliminarPacientes";
            this.Load += new System.EventHandler(this.EliminarPacientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnActualizarMotivos;
    }
}