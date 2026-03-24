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
    public partial class UC_Pacientes : UserControl
    {
        public UC_Pacientes()
        {
            InitializeComponent();
        }


        private void EstiloBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 35;
            btn.Cursor = Cursors.Hand;
        }




        private void UC_Pacientes_Load(object sender, EventArgs e)
        {
            dgvPacientes.Dock = DockStyle.Fill;
            dgvPacientes.BackgroundColor = Color.White;
            dgvPacientes.BorderStyle = BorderStyle.None;

            dgvPacientes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPacientes.EnableHeadersVisualStyles = false;


            EstiloBoton(btnAgregar, Color.FromArgb(40, 167, 69)); 
            EstiloBoton(btnActualizar, Color.FromArgb(0, 123, 255)); 
            EstiloBoton(btnEliminar, Color.FromArgb(220, 53, 69));
            EstiloBoton(btnCargar, Color.FromArgb(108, 117, 125));

        }
    }
}
