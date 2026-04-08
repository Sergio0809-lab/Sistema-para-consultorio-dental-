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
    public partial class AgregarCitas : Form
    {
        public ConsultorioDentalDBEntities _context;
        public AgregarCitas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        public void cargarCmbCategorias()
        {

            var pacientes = _context.Pacientes.Select(p => new
            {
                ID = p.PacienteID,
                Nombre = p.NombreCompleto
            }).ToList();

            comboBox1.DataSource = pacientes;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID";


            var dentistas = _context.Dentistas.Select(d => new
            {
                ID = d.DentistaID,
                Nombre = d.NombreCompleto
            }).ToList();

            comboBox2.DataSource = dentistas;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ID";


            
            var motivos = _context.Motivos.Select(m => new
            {
                ID = m.MotivoID,
                Nombre = m.Descripcion
            }).ToList();

            comboBox3.DataSource = motivos;
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "ID";




            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new object[] { 30, 45, 60, 90 });
            comboBox4.SelectedIndex = -1;
        }

        private void AgregarCitas_Load(object sender, EventArgs e)
        {
            cargarCmbCategorias();
        }
    }
}
