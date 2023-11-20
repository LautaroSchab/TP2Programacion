using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml.Wordprocessing;
using Presentacion.Modales;
using Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class FormVentas : Form
    {
        private USUARIO _Usuario;
        public FormVentas(USUARIO OUsuario = null)
        {
            _Usuario = OUsuario;
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CboDocumento.Items.Add(new OpcionesCombo() { Valor = "Boleta", Texto = "Boleta" });
            CboDocumento.Items.Add(new OpcionesCombo() { Valor = "Factura", Texto = "Factura" });
            CboDocumento.DisplayMember = "Texto";
            CboDocumento.ValueMember = "Valor";
            CboDocumento.SelectedIndex = 0;

            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";

            textPagarcon.Text = "";
            textCambio.Text = "";
            textTotalPagar.Text = "0";
        }

        private void btnbuscarCliente_Click(object sender, EventArgs e)
        {
            using (var Modal = new FormMdCliente())
            {
                var Result = Modal.ShowDialog();
                if (Result == DialogResult.OK)
                {
                    textDocumentoCliente.Text = Modal._Cliente.Documento;
                    textNombreCliente.Text = Modal._Cliente.NombreCompleto;
                    txtCodProducto.Select();


                }
                else
                {
                    textDocumentoCliente.Select();

                }
            }
        }

        private void btnBuscarProducto1_Click(object sender, EventArgs e)
        {
            using (var Modal = new FormMdProducto())
            {
                var Result = Modal.ShowDialog();
                if (Result == DialogResult.OK)
                {
                    txtCodProducto.Text = Modal._Producto.Codigo;
                    txtIdProducto.Text = Modal._Producto.IdProducto.ToString();
                    txtProducto.Text = Modal._Producto.Nombre;
                    textPrecioProducto.Text = Modal._Producto.PrecioVenta.ToString("0.00");
                    textStockProducto.Text = Modal._Producto.Stock.ToString();
                    cantidadnumericupdown.Select();


                }
                else
                {
                    txtCodProducto.Select();

                }
            }
        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto OProdructo = new CN_Producto().Listar().Where(p => p.Codigo == txtCodProducto.Text && p.Estado == true).FirstOrDefault();
                if (OProdructo != null)
                {
                    txtCodProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = OProdructo.IdProducto.ToString();
                    txtProducto.Text = OProdructo.Nombre;
                    textPrecioProducto.Text= OProdructo.PrecioVenta.ToString("");
                    textStockProducto.Text=OProdructo.Stock.ToString();
                    cantidadnumericupdown.Select();
                }
                else
                {
                    txtCodProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    textPrecioProducto.Text = "";
                    textStockProducto.Text = "";
                    cantidadnumericupdown.Value = 1;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal Precio = 0;
            bool Producto_Existe = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(textPrecioProducto.Text, out Precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textPrecioProducto.Select();
                return;

            }

            if (Convert.ToInt32(textStockProducto.Text) < Convert.ToInt32(cantidadnumericupdown.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textStockProducto.Select();
                return;

            }
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    Producto_Existe = true;
                    break;

                }
            }
            if (!Producto_Existe)
            {
                string Mensaje = string.Empty;
                bool Respuesta = new CN_Venta().RestarStock(
                Convert.ToInt32(txtIdProducto.Text),
                Convert.ToInt32(cantidadnumericupdown.Value.ToString()));

                if (Respuesta) 
                {
                    dgvdata.Rows.Add(new object[] {

                    txtIdProducto.Text,
                    txtProducto.Text,
                    Precio.ToString("0.00"),
                    cantidadnumericupdown.Value.ToString(),
                    (cantidadnumericupdown.Value * Precio).ToString("0.00"),

                    });
                    CalcularTotal();
                    LimpiarProducto();
                    txtCodProducto.Select();
                }
                
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }

            }
            textTotalPagar.Text = total.ToString("0.00");


        }
        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Text = "";
            txtProducto.Text = "";
            textPrecioProducto.Text = "";
            textStockProducto.Text = "";
            cantidadnumericupdown.Value = 1;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.icons8.Width;
                var h = Properties.Resources.icons8.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;


                e.Graphics.DrawImage(Properties.Resources.icons8, new Rectangle(x, y, w, h));
                e.Handled = true;


            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    bool Respuesta = new CN_Venta().SumarStock(
                        Convert.ToInt32(dgvdata.Rows[indice].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(dgvdata.Rows[indice].Cells["Cantidad"].Value.ToString()));


                    if (Respuesta) 
                    {
                        dgvdata.Rows.RemoveAt(indice);
                        CalcularTotal();

                    }  
                    

                }

            }
        }

        private void textPrecioProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (textPrecioProducto.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;

                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }

                }

            }
        }

        private void textPagarcon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (textPagarcon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;

                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }

                }

            }
        }

        private void CalcularCambio() 
        {
            if (textTotalPagar.Text.Trim() == "") 
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal PagaCon;
            decimal Total = Convert.ToDecimal(textTotalPagar.Text);
            if(textPagarcon.Text.Trim()== "") 
            {
                textPagarcon.Text = "0";
            
            }
            if (decimal.TryParse(textPagarcon.Text.Trim(), out PagaCon)) 
            {
                if (PagaCon < Total)
                {
                    textCambio.Text = "0.00";

                }
                else 
                {
                    decimal Cambio = PagaCon - Total;
                    textCambio.Text = Cambio.ToString("0.00");
                
                }
            
            }
        }

        private void textPagarcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            if (textDocumentoCliente.Text == "") 
            {
                MessageBox.Show("Debe ingresar documento del cliente", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (textNombreCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Count<1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable EDetalle_Venta = new DataTable();
            EDetalle_Venta.Columns.Add("Producto", typeof(int));
            EDetalle_Venta.Columns.Add("PrecioVenta", typeof(decimal));
            EDetalle_Venta.Columns.Add("Cantidad", typeof(int));
            EDetalle_Venta.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                EDetalle_Venta.Rows.Add(new object[]
                {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()


                });
            }

            int IdCorrelativo = new CN_Venta().ObtenerCorrelativo();
            string NumeroDocumento = string.Format("{0:00000}",IdCorrelativo);
            CalcularCambio();
            /*Venta OVenta = new Venta()
            {
                OUsuario= new USUARIO() {IdUsuario = _Usuario.IdUsuario },
                TipoDocumento=((OpcionesCombo) CboDocumento.SelectedItem).Texto,
                NumeroDocumento=NumeroDocumento,
                DocumentoCliente= textDocumentoCliente.Text,
                NombreCliente=textNombreCliente.Text,
                MontoPago= Convert.ToInt32(textPagarcon.Text),
                MontoCambio= Convert.ToInt32(textCambio.Text),
                MontoTotal= Convert.ToInt32(textTotalPagar.Text),


            };*/
            Venta OVenta = new Venta
            {
                OUsuario = new USUARIO()
                {
                    IdUsuario = _Usuario != null ? _Usuario.IdUsuario : 0 // Asegúrate de que _Usuario no sea nulo
                },
                
                TipoDocumento = CboDocumento.SelectedItem != null ? ((OpcionesCombo)CboDocumento.SelectedItem).Texto : string.Empty, // Asegúrate de que CboTipoDocumento.SelectedItem no sea nulo
                NumeroDocumento = NumeroDocumento, // Asegúrate de que numerodocumento esté definido
                DocumentoCliente= textDocumentoCliente.Text,
                NombreCliente=textNombreCliente.Text,
                MontoCambio = !string.IsNullOrEmpty(textCambio.Text) ? Convert.ToDecimal(textCambio.Text) : 0,
                MontoPago = !string.IsNullOrEmpty(textPagarcon.Text) ? Convert.ToDecimal(textPagarcon.Text) : 0,
                MontoTotal = !string.IsNullOrEmpty(textTotalPagar.Text) ? Convert.ToDecimal(textTotalPagar.Text) : 0// Asegúrate de
            };

            
            string Mensaje = string.Empty;
            bool Respuesta = new CN_Venta().Registrar(OVenta, EDetalle_Venta, out Mensaje);

            if (Respuesta)
            {
                var Result = MessageBox.Show("Numero de Venta generada:\n" + NumeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    Clipboard.SetText(NumeroDocumento);

                }
                textDocumentoCliente.Text = "";
                textNombreCliente.Text = "";                
                dgvdata.Rows.Clear();
                CalcularTotal();
                textCambio.Text = "";
                textPagarcon.Text = "";
            }
            else
            {
                MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        
    }
}
