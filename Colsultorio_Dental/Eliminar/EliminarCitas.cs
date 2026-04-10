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
    public partial class EliminarCitas : Form
    {

        public ConsultorioDentalDBEntities _context;
        public EliminarCitas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
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

            _context.Citas.Remove(cita);

            int rowsAffected = _context.SaveChanges();

            if (rowsAffected > 0)
            {
                MessageBox.Show("La cita ha sido eliminada correctamente ");
            }


        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EliminarCitas_Load(object sender, EventArgs e)
        {
            textBox1.KeyPress += SoloNumeros;
        }
    }
}
