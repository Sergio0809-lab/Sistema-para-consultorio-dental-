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
    
    public partial class ActualizarPacientes : Form
    {
        public ConsultorioDentalDBEntities _context;
        public ActualizarPacientes()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El nombre está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }

          

            int pacienteid = Convert.ToInt32(textBox2.Text);

            Paciente paciente = _context.Pacientes.FirstOrDefault(q => q.PacienteID.Equals(pacienteid));
            if (paciente == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }

            paciente.NombreCompleto = textBox1.Text;
            paciente.Telefono = maskedTextBox1.Text;
            


            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el paciente en la base de datos.");
            }
        }
    }
}
