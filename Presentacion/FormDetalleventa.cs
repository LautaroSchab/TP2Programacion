using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormDetalleventa : Form
    {
        public FormDetalleventa()
        {
            InitializeComponent();
        }
        private void FormDetalleventa_Load(object sender, EventArgs e)
        {
            txtBusqueda.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Venta OVenta = new CN_Venta().ObtenerVenta(txtBusqueda.Text);
            if (OVenta.IdVenta != 0)
            {
                textFecha.Text = OVenta.FechaRegistro;
                textnumeroDocumento.Text = OVenta.NumeroDocumento;
                texttipoDocumento.Text = OVenta.TipoDocumento;
                textUsuario.Text = OVenta.OUsuario.NombreCompleto;
                textDocCliente.Text = OVenta.DocumentoCliente;
                textNombreCliente.Text = OVenta.NombreCliente;

                dgvdata.Rows.Clear();
                foreach (Detalle_Venta dv in OVenta.ODetalleVenta)
                {
                    dgvdata.Rows.Add(new object[] { dv.OProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                }
                textMontoTotal.Text = OVenta.MontoTotal.ToString("0.00");
                textMontoPago.Text = OVenta.MontoPago.ToString("0.00");
                textMontoCambio.Text = OVenta.MontoCambio.ToString("0.00");

            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            textFecha.Text = "";
            texttipoDocumento.Text = "";
            textUsuario.Text = "";
            textDocCliente.Text = "";
            textNombreCliente.Text = "";

            dgvdata.Rows.Clear();
            textMontoTotal.Text = "0.00";
            textMontoPago.Text = "0.00";
            textMontoCambio.Text = "0.00";
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (texttipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string Texto_Html = Properties.Resources.PlantillaVenta_html.ToString();
            Negocio Odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", Odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", Odatos.RUC.ToUpper());
            Texto_Html = Texto_Html.Replace("@direcnegocio", Odatos.Direccion.ToUpper());

            Texto_Html = Texto_Html.Replace("@tipodocumento", texttipoDocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtBusqueda.Text);

            Texto_Html = Texto_Html.Replace("@doccliente", textDocCliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", textNombreCliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", textFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", textUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", textMontoTotal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", textMontoPago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", textMontoCambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtBusqueda.Text);
            savefile.Filter = "Pdf Files | *.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document PdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(PdfDoc, stream);
                    PdfDoc.Open();

                    bool Obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out Obtenido);

                    if (Obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(PdfDoc.Left, PdfDoc.GetTop(51));
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
    }
}
