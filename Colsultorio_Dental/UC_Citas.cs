using Colsultorio_Dental.Actualizar;
using Colsultorio_Dental.Agregar;
using Colsultorio_Dental.Datos;
using Colsultorio_Dental.Eliminar;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colsultorio_Dental
{
    public partial class UC_Citas : UserControl
    {
        public ConsultorioDentalDBEntities _context;
        public UC_Citas()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void UC_Citas_Load(object sender, EventArgs e)
        {


            dgvCitas.Dock = DockStyle.Fill;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;

            dgvCitas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvCitas.EnableHeadersVisualStyles = false;


            EstiloBoton(btnAgregar, Color.FromArgb(40, 167, 69));
            EstiloBoton(btnActualizar, Color.FromArgb(0, 123, 255));
            EstiloBoton(btnEliminar, Color.FromArgb(220, 53, 69));
            EstiloBoton(btnCargar, Color.FromArgb(108, 117, 125));
            EstiloBoton(btnExportarCSV, Color.FromArgb(25, 135, 84)); 
            EstiloBoton(btnExportarPDF, Color.FromArgb(192, 57, 43));
            CargarCitas();

        }





        private void CargarCitas()
        {
            using (var db = new ConsultorioDentalDBEntities())
            {
                var lista = db.Citas
                    .Select(c => new
                    {
                        c.CitaID,
                        c.PacienteID,
                        c.DentistaID,
                        c.Fecha,
                        c.Hora,
                        c.Duracion
                    })
                    .ToList()
                    .Select(c =>
                    {
                        DateTime fechaHoraCita = c.Fecha.Add(c.Hora);

                        string estado;
                        string tiempoRestante;

                        if (fechaHoraCita > DateTime.Now)
                        {
                            estado = "Vigente";
                            TimeSpan diff = fechaHoraCita - DateTime.Now;
                            tiempoRestante = $"{diff.Days}d {diff.Hours}h {diff.Minutes}m";
                        }
                        else if (fechaHoraCita <= DateTime.Now &&
                                 fechaHoraCita.AddMinutes(c.Duracion) >= DateTime.Now)
                        {
                            estado = "En proceso";
                            tiempoRestante = "En curso";
                        }
                        else
                        {
                            estado = "Finalizado";
                            tiempoRestante = "0";
                        }

                        return new
                        {
                            c.CitaID,
                            c.PacienteID,
                            c.DentistaID,
                            c.Fecha,
                            c.Hora,
                            c.Duracion,
                            Estado = estado,
                            TiempoRestante = tiempoRestante
                        };
                    })
                    .ToList();

                dgvCitas.DataSource = lista;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCitas agregar = new AgregarCitas();
            agregar.StartPosition = FormStartPosition.CenterScreen;
            agregar.ShowDialog();


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCitas actuliza = new ActualizarCitas();
            actuliza.StartPosition = FormStartPosition.CenterScreen;
            actuliza.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCitas elimina = new EliminarCitas();
            elimina.StartPosition = FormStartPosition.CenterScreen;
            elimina.ShowDialog();
        }


        private void ExportarPDF(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "Citas.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.Open();

                Paragraph titulo = new Paragraph("Citas\n\n",
                    FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);


                PdfPTable tabla = new PdfPTable(dgv.Columns.Count);
                tabla.WidthPercentage = 100;


                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText));
                    cell.BackgroundColor = new BaseColor(0, 102, 153);
                    cell.Phrase.Font.Color = BaseColor.WHITE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(cell);
                }


                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string texto = cell.Value?.ToString() ?? "";
                            tabla.AddCell(new Phrase(texto));
                        }
                    }
                }

                doc.Add(tabla);
                doc.Close();

                MessageBox.Show("PDF exportado correctamente ");
            }



        }


        private void ExportarCSV(DataGridView dgv)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Citas.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {

                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        sw.Write($"\"{dgv.Columns[i].HeaderText}\"");
                        if (i < dgv.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();


                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                string valor = row.Cells[i].Value?.ToString() ?? "";


                                valor = valor.Replace("\"", "\"\"");

                                sw.Write($"\"{valor}\"");

                                if (i < dgv.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show("CSV exportado correctamente ");
            }
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            ExportarCSV(dgvCitas);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF(dgvCitas);
        }
    }
    
}
