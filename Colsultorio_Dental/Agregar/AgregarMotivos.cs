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
    public partial class AgregarMotivos : Form
    {
        public ConsultorioDentalDBEntities _context;
        public AgregarMotivos()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void btnActualizarMotivos_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("La descripcion está incorrecta o vacia.");
                return;
            }



            Motivo motivo = new Motivo()
            {

                Descripcion = textBox2.Text,

            };

            _context.Motivos.Add(motivo);

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha insertado el Motivo en la base de datos.");
            }
        }
    }
}
