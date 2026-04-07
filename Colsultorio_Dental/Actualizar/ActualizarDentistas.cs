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
    public partial class ActualizarDentistas : Form
    {
        public ConsultorioDentalDBEntities _context;
        public ActualizarDentistas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
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
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("La especialidad está incorrecta o vaci.");
                return;
            }


            int dentistaid = Convert.ToInt32(textBox3.Text);

            Dentista denti = _context.Dentistas.FirstOrDefault(q => q.DentistaID.Equals(dentistaid));
            if (denti == null)
            {
                MessageBox.Show("El Dentista no  existe.");
                return;
            }



            denti.NombreCompleto= textBox1.Text;
            denti.Especialidad= textBox2.Text;
            denti.Telefono= maskedTextBox1.Text;



            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el motivo en la base de datos.");
            }
        }
    }
}
