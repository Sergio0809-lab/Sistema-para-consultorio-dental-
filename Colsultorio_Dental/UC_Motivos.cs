using Colsultorio_Dental.Actualizar;
using Colsultorio_Dental.Agregar;
using Colsultorio_Dental.Datos;
using Colsultorio_Dental.Eliminar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Colsultorio_Dental
{
    public partial class UC_Motivos : UserControl
    {
        public ConsultorioDentalDBEntities _context;
        public UC_Motivos()
        {
            InitializeComponent();
            _context = new ConsultorioDentalDBEntities();
        }

        private void UC_Motivos_Load(object sender, EventArgs e)
        {
            dgvDentistas.Dock = DockStyle.Fill;
            dgvDentistas.BackgroundColor = Color.White;
            dgvDentistas.BorderStyle = BorderStyle.None;

            dgvDentistas.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDentistas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);

            dgvDentistas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 153);
            dgvDentistas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvDentistas.EnableHeadersVisualStyles = false;


            EstiloBoton(btnAgregar, Color.FromArgb(40, 167, 69));
            EstiloBoton(btnActualizar, Color.FromArgb(0, 123, 255));
            EstiloBoton(btnEliminar, Color.FromArgb(220, 53, 69));
            EstiloBoton(btnCargar, Color.FromArgb(108, 117, 125));
            EstiloBoton(btnExportarCSV, Color.FromArgb(25, 135, 84));
            EstiloBoton(btnExportarPDF, Color.FromArgb(192, 57, 43));


            CargarMotivos();
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



        private void CargarMotivos()
        {
            using (var db = new ConsultorioDentalDBEntities())
            {
                var lista = db.Motivos
                    .Select(m => new
                    {
                        m.MotivoID,
                        m.Descripcion,
                        Citas = db.Citas.Count(c => c.MotivoID == m.MotivoID) 
                    })
                    .ToList();

                dgvDentistas.DataSource = null;
                dgvDentistas.DataSource = lista;
            }
        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarMotivos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarMotivos Agregar = new ActualizarMotivos();
            Agregar.StartPosition = FormStartPosition.CenterScreen;
            Agregar.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMotivos Agregar = new AgregarMotivos();
            Agregar.StartPosition = FormStartPosition.CenterScreen;
            Agregar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarMotivos Agregar = new EliminarMotivos();
            Agregar.StartPosition = FormStartPosition.CenterScreen;
            Agregar.ShowDialog();
        }




        private void ExportarMotivosPDF()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "Reporte_Motivos.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.Open();

              
                Paragraph titulo = new Paragraph("Reporte de Motivos\n\n",
                    FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

               
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100;

               
                tabla.SetWidths(new float[] { 20f, 50f, 30f });

                
                string[] headers = { "ID", "Descripción", "Citas" };

                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header));
                    cell.BackgroundColor = new BaseColor(0, 102, 153); 
                    cell.Phrase.Font.Color = BaseColor.WHITE;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    tabla.AddCell(cell);
                }

                
                foreach (DataGridViewRow row in dgvDentistas.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells["MotivoID"].Value?.ToString() ?? "")));

                       
                        string descripcion = row.Cells["Descripcion"].Value?.ToString() ?? "";
                        descripcion = descripcion.Replace(",", " ");
                        tabla.AddCell(new PdfPCell(new Phrase(descripcion)));

                        
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells["Citas"].Value?.ToString() ?? "0")));
                    }
                }

                doc.Add(tabla);

                doc.Close();

                MessageBox.Show("PDF de Motivos exportado correctamente ");
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarMotivosPDF();
        }
    }
}
