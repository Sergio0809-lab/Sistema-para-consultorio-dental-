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
    public partial class EliminarDentistas : Form
    {
        public ConsultorioDentalDBEntities _context;
        public EliminarDentistas()
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

            int dentisid = Convert.ToInt32(textBox2.Text);

            Dentista dentis = _context.Dentistas.FirstOrDefault(q => q.DentistaID.Equals(dentisid));
            if (dentis == null)
            {
                MessageBox.Show("EL Dentista no existe.");
                return;
            }

            _context.Dentistas.Remove(dentis);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado el dentista en la base de datos.");
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EliminarDentistas_Load(object sender, EventArgs e)
        {
            textBox2.KeyPress += SoloNumeros;
        }
    }
}
