namespace Colsultorio_Dental
{
    partial class Home
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
            this.pnlSlidebar = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnDentistas = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnMotivos = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlSlidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSlidebar
            // 
            this.pnlSlidebar.Controls.Add(this.btnDashboard);
            this.pnlSlidebar.Controls.Add(this.btnPacientes);
            this.pnlSlidebar.Controls.Add(this.btnDentistas);
            this.pnlSlidebar.Controls.Add(this.btnCitas);
            this.pnlSlidebar.Controls.Add(this.btnMotivos);
            this.pnlSlidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSlidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSlidebar.Name = "pnlSlidebar";
            this.pnlSlidebar.Size = new System.Drawing.Size(220, 597);
            this.pnlSlidebar.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(3, 36);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(108, 42);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(12, 97);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(99, 38);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnDentistas
            // 
            this.btnDentistas.Location = new System.Drawing.Point(12, 169);
            this.btnDentistas.Name = "btnDentistas";
            this.btnDentistas.Size = new System.Drawing.Size(99, 23);
            this.btnDentistas.TabIndex = 2;
            this.btnDentistas.Text = "Dentistas";
            this.btnDentistas.UseVisualStyleBackColor = true;
            this.btnDentistas.Click += new System.EventHandler(this.btnDentistas_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(12, 270);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(99, 23);
            this.btnCitas.TabIndex = 4;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnMotivos
            // 
            this.btnMotivos.Location = new System.Drawing.Point(12, 223);
            this.btnMotivos.Name = "btnMotivos";
            this.btnMotivos.Size = new System.Drawing.Size(99, 23);
            this.btnMotivos.TabIndex = 3;
            this.btnMotivos.Text = "Motivos";
            this.btnMotivos.UseVisualStyleBackColor = true;
            this.btnMotivos.Click += new System.EventHandler(this.btnMotivos_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.plnMenu);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(917, 61);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(130, 31);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Dashboard";
            // 
            // plnMenu
            // 
            this.plnMenu.AutoSize = true;
            this.plnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.plnMenu.Location = new System.Drawing.Point(0, 0);
            this.plnMenu.Name = "plnMenu";
            this.plnMenu.Size = new System.Drawing.Size(917, 0);
            this.plnMenu.TabIndex = 5;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(220, 61);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(917, 536);
            this.pnlContenedor.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 597);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSlidebar);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnlSlidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSlidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnMotivos;
        private System.Windows.Forms.Button btnDentistas;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel plnMenu;
        private System.Windows.Forms.Label lblTitulo;
    }
}

