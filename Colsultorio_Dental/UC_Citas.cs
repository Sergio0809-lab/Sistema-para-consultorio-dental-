using Colsultorio_Dental.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colsultorio_Dental
{
    public partial class UC_Citas : UserControl
    {
        public ConsultorioDentalDBEntities _context;
        public UC_Citas()
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
            //_context = new ConsultorioDentalDBEntities();

            //var listaCitas = _context.Citas.ToList();

            //dgvCitas.DataSource = listaCitas;
            CargarCitas();
        }

        private void UC_Citas_Load(object sender, EventArgs e)
        {


            dgvCitas.Dock = DockStyle.Fill;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;

            dgvCitas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvCitas.EnableHeadersVisualStyles = false;


            EstiloBoton(btnAgregar, Color.FromArgb(40, 167, 69));
            EstiloBoton(btnActualizar, Color.FromArgb(0, 123, 255));
            EstiloBoton(btnEliminar, Color.FromArgb(220, 53, 69));
            EstiloBoton(btnCargar, Color.FromArgb(108, 117, 125));
            EstiloBoton(btnExportarCSV, Color.FromArgb(25, 135, 84)); 
            EstiloBoton(btnExportarPDF, Color.FromArgb(192, 57, 43)); 

       
        }





        private void CargarCitas()
        {
            using (var db = new ConsultorioDentalDBEntities())
            {
                var lista = db.Citas
                    .Select(c => new
                    {
                        c.CitaID,
                        c.PacienteID,
                        c.DentistaID,
                        c.Fecha,
                        c.Hora,
                        c.Duracion
                    })
                    .ToList()
                    .Select(c =>
                    {
                        DateTime fechaHoraCita = c.Fecha.Add(c.Hora);

                        string estado;
                        string tiempoRestante;

                        if (fechaHoraCita > DateTime.Now)
                        {
                            estado = "Vigente";
                            TimeSpan diff = fechaHoraCita - DateTime.Now;
                            tiempoRestante = $"{diff.Days}d {diff.Hours}h {diff.Minutes}m";
                        }
                        else if (fechaHoraCita <= DateTime.Now &&
                                 fechaHoraCita.AddMinutes(c.Duracion) >= DateTime.Now)
                        {
                            estado = "En proceso";
                            tiempoRestante = "En curso";
                        }
                        else
                        {
                            estado = "Finalizado";
                            tiempoRestante = "0";
                        }

                        return new
                        {
                            c.CitaID,
                            c.PacienteID,
                            c.DentistaID,
                            c.Fecha,
                            c.Hora,
                            c.Duracion,
                            Estado = estado,
                            TiempoRestante = tiempoRestante
                        };
                    })
                    .ToList();

                dgvCitas.DataSource = lista;
            }
        }




















    }
    
}
