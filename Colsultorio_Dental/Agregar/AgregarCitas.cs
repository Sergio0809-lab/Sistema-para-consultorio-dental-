using Colsultorio_Dental.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colsultorio_Dental.Agregar
{
    public partial class AgregarCitas : Form
    {
        public ConsultorioDentalDBEntities _context;
        public AgregarCitas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void cargarCmbCategorias()
        {

            var pacientes = _context.Pacientes.Select(p => new
            {
                ID = p.PacienteID,
                Nombre = p.NombreCompleto
            }).ToList();

            comboBox1.DataSource = pacientes;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID";


            var dentistas = _context.Dentistas.Select(d => new
            {
                ID = d.DentistaID,
                Nombre = d.NombreCompleto
            }).ToList();

            comboBox2.DataSource = dentistas;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ID";


            
            var motivos = _context.Motivos.Select(m => new
            {
                ID = m.MotivoID,
                Nombre = m.Descripcion
            }).ToList();

            comboBox3.DataSource = motivos;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "ID";




            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new object[] { 30, 45, 60, 90 });
            comboBox4.SelectedIndex = -1;
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            cargarCmbCategorias();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un paciente");
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un dentista");
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un motivo");
                return;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la duración");
                return;
            }

            using (var db = new ConsultorioDentalDBEntities())
            {
                DateTime fecha = dateTimePicker1.Value.Date;
                TimeSpan hora = dateTimePicker2.Value.TimeOfDay;
                int duracion = int.Parse(comboBox4.Text);

                DateTime inicioNueva = fecha.Add(hora);
                DateTime finNueva = inicioNueva.AddMinutes(duracion);

                int dentistaId = (int)comboBox2.SelectedValue;

                bool existe = db.Citas.Any(c =>
                    c.DentistaID == dentistaId &&
                    DbFunctions.TruncateTime(c.Fecha) == fecha &&
                    (
                        inicioNueva < DbFunctions.AddMinutes(
                            DbFunctions.CreateDateTime(
                                c.Fecha.Year,
                                c.Fecha.Month,
                                c.Fecha.Day,
                                c.Hora.Hours,
                                c.Hora.Minutes,
                                c.Hora.Seconds
                            ), c.Duracion)
                        &&
                        finNueva > DbFunctions.CreateDateTime(
                            c.Fecha.Year,
                            c.Fecha.Month,
                            c.Fecha.Day,
                            c.Hora.Hours,
                            c.Hora.Minutes,
                            c.Hora.Seconds
                        )
                    )
                );

                if (existe)
                {
                    MessageBox.Show("El dentista ya tiene una cita en ese horario ❌");
                    return;
                }

                
                Cita nueva = new Cita()
                {
                    PacienteID = (int)comboBox1.SelectedValue,
                    DentistaID = dentistaId,
                    MotivoID = (int)comboBox3.SelectedValue,
                    Fecha = fecha,
                    Hora = hora,
                    Duracion = duracion,
                    FechaCreacion = DateTime.Now
                };

                db.Citas.Add(nueva);
                db.SaveChanges();
            }

            MessageBox.Show("Cita guardada correctamente ");

            
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;





        }
    }
}
