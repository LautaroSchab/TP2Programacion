using CapaEntidad;
using CapaNegocio;
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
using iTextSharp.tool.xml;
using System.IO;

namespace Presentacion
{
    public partial class Formdetallecompra : Form
    {
        public Formdetallecompra()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra OCompra = new CN_Compra().ObtenerCompra(txtBusqueda.Text);
            if (OCompra.IdCompra != 0) 
            {
                textnumeroDocumento.Text = OCompra.NumeroDocumento;
                textFecha.Text = OCompra.FechaRegistro;
                texttipoDocumento.Text = OCompra.TipoDocumento;
                textUsuario.Text = OCompra.OUsuario.NombreCompleto;
                textDocProveedor.Text = OCompra.OProveedor.Documento;
                textNombreProveedor.Text = OCompra.OProveedor.RazonSocial;

                dgvdata.Rows.Clear();
                foreach (Detalle_Compra dc in OCompra.ODetalleCompra)
                {
                    dgvdata.Rows.Add(new object[] { dc.OProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }
                textMontoTotal.Text = OCompra.MontoTotal.ToString("0.00");
                
            }
          
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            textFecha.Text = "";
            texttipoDocumento.Text = "";
            textUsuario.Text = "";
            textDocProveedor.Text = "";
            textNombreProveedor.Text = "";
            txtBusqueda.Text = "";

            dgvdata.Rows.Clear();
            textMontoTotal.Text = "0.00";
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (texttipoDocumento.Text == "") 
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string Texto_Html = Properties.Resources.PlantillaCompra_html.ToString();
            Negocio Odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", Odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", Odatos.RUC.ToUpper());
            Texto_Html = Texto_Html.Replace("@direcnegocio", Odatos.Direccion.ToUpper());

            Texto_Html = Texto_Html.Replace("@tipodocumento", texttipoDocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtBusqueda.Text);

            Texto_Html = Texto_Html.Replace("@docproveedor", textDocProveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", textNombreProveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", textFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", textUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows) 
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", textMontoTotal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtBusqueda.Text);
            savefile.Filter = "Pdf Files | *.pdf";

            if(savefile.ShowDialog()== DialogResult.OK) 
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create)) 
                {
                    Document PdfDoc = new Document(PageSize.A4,25,25,25,25);
                    PdfWriter writer = PdfWriter.GetInstance(PdfDoc, stream);
                    PdfDoc.Open();

                    bool Obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out Obtenido);

                    if (Obtenido) 
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(PdfDoc.Left,PdfDoc.GetTop(51));
                        PdfDoc.Add(img);
                    }

                    try
                    {
                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfDoc, sr);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al convertir HTML a PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    PdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Formdetallecompra_Load(object sender, EventArgs e)
        {

        }
    }
}
