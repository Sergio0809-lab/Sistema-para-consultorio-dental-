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
    public partial class ActualizarMotivos : Form
    {
        public ConsultorioDentalDBEntities _context;
        public ActualizarMotivos()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El ID está incorrecto o vacio.");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("La descripcion está incorrecta o vacia.");
                return;
            }



            int motivoid = Convert.ToInt32(textBox1.Text);

            Motivo motivo  = _context.Motivos.FirstOrDefault(q => q.MotivoID.Equals(motivoid));
            if (motivo == null)
            {
                MessageBox.Show("Cliente no existe.");
                return;
            }


           
            motivo.Descripcion = textBox2.Text;
           


            int rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Se ha actualizado el cliente en la base de datos.");
            }
        }

        private void ActualizarMotivos_Load(object sender, EventArgs e)
        {
            //dataGridView1.Dock = DockStyle.Fill;
            //dataGridView1.BackgroundColor = Color.White;
            //dataGridView1.BorderStyle = BorderStyle.None;

            //dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //dataGridView1.EnableHeadersVisualStyles = false;


            
            EstiloBoton(btnActualizarMotivos, Color.FromArgb(0, 123, 255));

            _context = new ConsultorioDentalDBEntities();

            var listaMotivos = _context.Motivos.ToList();

            //dataGridView1.DataSource = listaMotivos;


        }



        private void EstiloBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 35;
            btn.Cursor = Cursors.Hand;
        }
    }



}
