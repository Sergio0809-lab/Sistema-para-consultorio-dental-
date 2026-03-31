using Colsultorio_Dental.Datos;
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
    public partial class UC_Dentistas : UserControl
    {

        public ConsultorioDentalDBEntities _context;
        public UC_Dentistas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
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


        

        private void btnCargar_Click(object sender, EventArgs e)
        {

            _context = new ConsultorioDentalDBEntities();

            var listaDentistas = _context.Dentistas.ToList();

            dgvDentistas.DataSource = listaDentistas;
        }

        private void UC_Dentistas_Load(object sender, EventArgs e)
        {
            dgvDentistas.Dock = DockStyle.Fill;
            dgvDentistas.BackgroundColor = Color.White;
            dgvDentistas.BorderStyle = BorderStyle.None;

            dgvDentistas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDentistas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvDentistas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvDentistas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvDentistas.EnableHeadersVisualStyles = false;


            EstiloBoton(btnAgregar, Color.FromArgb(40, 167, 69));
            EstiloBoton(btnActualizar, Color.FromArgb(0, 123, 255));
            EstiloBoton(btnEliminar, Color.FromArgb(220, 53, 69));
            EstiloBoton(btnCargar, Color.FromArgb(108, 117, 125));
            EstiloBoton(btnExportarCSV, Color.FromArgb(25, 135, 84));
            EstiloBoton(btnExportarPDF, Color.FromArgb(192, 57, 43));
        }
    }
}
