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

namespace Colsultorio_Dental.Agregar
{
    public partial class AgregarPacientes : Form
    {
        public ConsultorioDentalDBEntities _context;
        public AgregarPacientes()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
       

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




            Paciente paciente = new Paciente()
            {

                
                NombreCompleto = textBox1.Text,
                Telefono = maskedTextBox1.Text
                
            };

            _context.Pacientes.Add(paciente);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado el paciente en la base de datos.");
            }
        }
    }
}
