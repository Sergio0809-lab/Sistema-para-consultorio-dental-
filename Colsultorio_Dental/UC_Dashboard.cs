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
    public partial class UC_Dashboard : UserControl
    {
        public ConsultorioDentalDBEntities _context;
        public UC_Dashboard()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }




        private void CargarCitasHoy()
        {
            using (var db = new ConsultorioDentalDBEntities())
            {
                var hoy = DateTime.Today;

                var lista = db.Citas
                    .Where(c => c.Fecha == hoy)
                    .Select(c => new
                    {
                        c.CitaID,
                        Paciente = c.Paciente.NombreCompleto,
                        Dentista = c.Dentista.NombreCompleto,
                        Motivo = c.Motivo.Descripcion,
                        Hora = c.Hora,
                        c.Duracion
                    })
                    .OrderBy(c => c.Hora)
                    .ToList();

                dgvDashboard.DataSource = lista;
            }
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            dgvDashboard.Dock = DockStyle.Fill;
            dgvDashboard.BackgroundColor = Color.White;
            dgvDashboard.BorderStyle = BorderStyle.None;

            dgvDashboard.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDashboard.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvDashboard.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvDashboard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvDashboard.EnableHeadersVisualStyles = false;
            lblBienvenida.Text = "Citas activas para Hoy";


            CargarCitasHoy();
        }
    }
}
