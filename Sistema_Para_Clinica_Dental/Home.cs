using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Para_Clinica_Dental
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void dentistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dentista Doctor = new Dentista();
            Doctor.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pacientes pacientes = new Pacientes();
            pacientes.ShowDialog();
        }

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Citas cliente = new Citas();
            cliente.ShowDialog();
        }
    }
}
