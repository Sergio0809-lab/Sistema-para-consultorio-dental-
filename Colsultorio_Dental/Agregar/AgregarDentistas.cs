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
    public partial class AgregarDentistas : Form
    {
        public ConsultorioDentalDBEntities _context;
        public AgregarDentistas()
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
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("La especialidad está incorrecta o vaci.");
                return;
            }
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("El telefono está incorrecto o vacio.");
                return;
            }


            Dentista dentista = new Dentista()
            {


                NombreCompleto = textBox1.Text,
                Especialidad = textBox2.Text,
                Telefono = maskedTextBox1.Text

            };



            _context.Dentistas.Add(dentista);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado el dentista en la base de datos.");
            }






        }
    }
}
