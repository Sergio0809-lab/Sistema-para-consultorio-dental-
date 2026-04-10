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

namespace Colsultorio_Dental.Actualizar
{
    public partial class ActualizarCitas : Form
    {

        public ConsultorioDentalDBEntities _context;
        public ActualizarCitas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un paciente.");
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un dentista.");
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un motivo.");
                return;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la duración.");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El ID de la cita está vacío.");
                return;
            }

            int citaID = Convert.ToInt32(textBox1.Text);

            
            Cita cita = _context.Citas.FirstOrDefault(c => c.CitaID == citaID);

            if (cita == null)
            {
                MessageBox.Show("La cita no existe.");
                return;
            }

           
            DateTime fecha = dateTimePicker1.Value.Date;
            TimeSpan hora = dateTimePicker2.Value.TimeOfDay;
            int duracion = Convert.ToInt32(comboBox4.Text);

            cita.PacienteID = (int)comboBox1.SelectedValue;
            cita.DentistaID = (int)comboBox2.SelectedValue;
            cita.MotivoID = (int)comboBox3.SelectedValue;
            cita.Fecha = fecha;
            cita.Hora = hora;
            cita.Duracion = duracion;

            int rowsAffected = _context.SaveChanges();

            if (rowsAffected > 0)
            {
                MessageBox.Show("La cita ha sido actualizada correctamente ");
            }

        }

        private void ActualizarCitas_Load(object sender, EventArgs e)
        {
            cargarCmbCategorias();
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


    }
}
