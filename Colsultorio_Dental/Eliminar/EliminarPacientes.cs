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

namespace Colsultorio_Dental.Eliminar
{
    public partial class EliminarPacientes : Form
    {
        public ConsultorioDentalDBEntities _context;
        public EliminarPacientes()
        {
            InitializeComponent();

            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            int clienid = Convert.ToInt32(textBox2.Text);

            Paciente clien = _context.Pacientes.FirstOrDefault(q => q.PacienteID.Equals(clienid));
            if (clien == null)
            {
                MessageBox.Show("EL paciente no existe.");
                return;
            }

            _context.Pacientes.Remove(clien);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado el paciente en la base de datos.");
            }
        
        
        
        }


        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EliminarPacientes_Load(object sender, EventArgs e)
        {
            textBox2.KeyPress += SoloNumeros;
        }
    }
}
