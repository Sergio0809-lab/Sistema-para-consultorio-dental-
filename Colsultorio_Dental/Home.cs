using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colsultorio_Dental
{
    
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            pnlSlidebar.BackColor = Color.FromArgb(0, 51, 102);
            pnlHeader.BackColor = Color.FromArgb(0, 102, 153);
            pnlContenedor.BackColor = Color.FromArgb(240, 248, 255);
        }




        private void EstilizarSidebar()
        {
            

            foreach (Control ctrl in pnlSlidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Width = pnlSlidebar.Width - 20;
                    btn.Height = 45;

                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(0, 51, 102);

                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(15, 0, 0, 0);

                    btn.Margin = new Padding(10, 5, 10, 5); 
                    btn.Cursor = Cursors.Hand;

                    pnlSlidebar.Controls.SetChildIndex(btnDashboard, 0);
                    pnlSlidebar.Controls.SetChildIndex(btnPacientes, 1);
                    pnlSlidebar.Controls.SetChildIndex(btnDentistas, 2);
                    pnlSlidebar.Controls.SetChildIndex(btnMotivos, 3);
                    pnlSlidebar.Controls.SetChildIndex(btnCitas, 4);
                    btn.MouseEnter += btn_MouseEnter;
                    btn.MouseLeave += btn_MouseLeave;


                }
            }
            }

        private void Home_Load(object sender, EventArgs e)
        {
             EstilizarSidebar();
            lblTitulo.Text = "Dashboard";
            AbrirModulo(new UC_Dashboard());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Dashboard";
            AbrirModulo(new UC_Dashboard());
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(0, 102, 153); 
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(0, 51, 102); 
        }



        private void AbrirModulo(UserControl modulo)
        {
            pnlContenedor.Controls.Clear();
            modulo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(modulo);
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Pacientes";
            AbrirModulo(new UC_Pacientes());
        }

        private void btnDentistas_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Dentistas";
            AbrirModulo(new UC_Dentistas());
        }

        private void btnMotivos_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Motivos";
            AbrirModulo(new UC_Motivos());
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Citas";
            AbrirModulo(new UC_Citas());
        }
    }







        














    
}
