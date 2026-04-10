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
    public partial class EliminarMotivos : Form
    {
        public ConsultorioDentalDBEntities _context;
        public EliminarMotivos()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Debe introducir un ID válido.");
                return;
            }

            int motivoid = Convert.ToInt32(textBox1.Text);

            Motivo motivo = _context.Motivos.FirstOrDefault(q => q.MotivoID.Equals(motivoid));
            if (motivo == null)
            {
                MessageBox.Show("El motivo no existe.");
                return;
            }

            _context.Motivos.Remove(motivo);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha eliminado el motivo en la base de datos.");
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EliminarMotivos_Load(object sender, EventArgs e)
        {
            textBox1.KeyPress += SoloNumeros;
        }
    }
}
