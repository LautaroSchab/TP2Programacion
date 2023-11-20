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
    public partial class FormCompras : Form
    {
        private USUARIO _Usuario;
        public FormCompras(USUARIO OUsuario = null)
        {
            _Usuario = OUsuario;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            

            CboDocumento.Items.Add(new OpcionesCombo() { Valor = "Boleta", Texto = "Boleta" });
            CboDocumento.Items.Add(new OpcionesCombo() { Valor = "Factura", Texto = "Factura" });
            CboDocumento.DisplayMember = "Texto";
            CboDocumento.ValueMember = "Valor";
            CboDocumento.SelectedIndex = 0;

            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            textIdProveedor.Text = "0";
            txtIdProducto.Text = "0";

        }

        private void btnbuscarProveedor1_Click(object sender, EventArgs e)
        {
            using (var Modal = new FormMdProveedor()) 
            {
                var Result= Modal.ShowDialog();
                if (Result == DialogResult.OK)
                {
                    textIdProveedor.Text = Modal._Proveedor.IdProveedor.ToString();
                    textnumeroDocumento.Text = Modal._Proveedor.Documento;
                    textRazonSocial.Text = Modal._Proveedor.RazonSocial;


                }
                else 
                {
                    textnumeroDocumento.Select();
                
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
                    txtPrecioCompra.Select();


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
                Producto OProdructo = new CN_Producto().Listar().Where(p => p.Codigo == txtCodProducto.Text && p.Estado==true).FirstOrDefault();
                if (OProdructo != null)
                {
                    txtCodProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = OProdructo.IdProducto.ToString();
                    txtProducto.Text = OProdructo.Nombre;
                    txtPrecioCompra.Select();
                }
                else 
                {
                    txtCodProducto.BackColor = System.Drawing.Color.MistyRose;
                    textIdProducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal PrecioCompra = 0;
            decimal PrecioVenta = 0;
            bool Producto_Existe = false;

            if (int.Parse(txtIdProducto.Text) == 0) 
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out PrecioCompra)) 
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;

            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out PrecioVenta))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
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
                dgvdata.Rows.Add(new object[] {

                    txtIdProducto.Text,
                    txtProducto.Text,
                    PrecioCompra.ToString("0.00"),
                    PrecioVenta.ToString("0.00"),
                    cantidadnumericupdown.Value.ToString(),
                    (cantidadnumericupdown.Value * PrecioCompra).ToString("0.00"),
                    
                });
                CalcularTotal();
                LimpiarProducto();
                txtCodProducto.Select();
            }
        }

        private void LimpiarProducto() 
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Text = "";
            txtCodProducto.BackColor = System.Drawing.Color.White;
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            cantidadnumericupdown.Value = 1;
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
            textTotalPagar.Text=total.ToString("0.00");
        
        
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 6)
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
                    dgvdata.Rows.RemoveAt(indice);
                    CalcularTotal();
                  
                }

            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else 
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void iconButton4_Click(object sender, EventArgs e) //Boton Registrar
        {
            if (Convert.ToInt32(textIdProveedor.Text) == 0) 
            {
                MessageBox.Show("Debe seleccionar un proveedor", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            DataTable EDetalle_Compra = new DataTable();
            EDetalle_Compra.Columns.Add("IdProducto", typeof(int));
            EDetalle_Compra.Columns.Add("PrecioCompra", typeof(decimal));
            EDetalle_Compra.Columns.Add("Precioventa", typeof(decimal));
            EDetalle_Compra.Columns.Add("Cantidad", typeof(int));
            EDetalle_Compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                EDetalle_Compra.Rows.Add(new object[]
                {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    row.Cells["PrecioCompra"].Value.ToString(),
                    row.Cells["Precioventa"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()


                });
            }

            
            
            int IdCorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", IdCorrelativo);
           

            Compra OCompra = new Compra()
            {
                /*OUsuario = new USUARIO() { IdUsuario = _Usuario.IdUsuario },
                OProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(textIdProveedor.Text) },
                TipoDocumento = ((OpcionesCombo)CboTipDocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(textTotalPagar.Text)*/
                OUsuario = new USUARIO()
                {
                    IdUsuario = _Usuario != null ? _Usuario.IdUsuario : 0 // Asegúrate de que _Usuario no sea nulo
                },
                OProveedor = new Proveedor()
                {
                    IdProveedor = !string.IsNullOrEmpty(textIdProveedor.Text) ? Convert.ToInt32(textIdProveedor.Text) : 0 // Asegúrate de que textIdProveedor no esté vacío
                },
                TipoDocumento = CboDocumento.SelectedItem != null ? ((OpcionesCombo)CboDocumento.SelectedItem).Texto : string.Empty, // Asegúrate de que CboTipoDocumento.SelectedItem no sea nulo
                NumeroDocumento = numerodocumento, // Asegúrate de que numerodocumento esté definido
                MontoTotal = !string.IsNullOrEmpty(textTotalPagar.Text) ? Convert.ToDecimal(textTotalPagar.Text) : 0 // Asegúrate de que textTotalPagar no esté vacío
            };
            string Mensaje = string.Empty;
            bool Respuesta = new CN_Compra().Registrar(OCompra,EDetalle_Compra, out Mensaje);

            if (Respuesta)
            {
                var Result = MessageBox.Show("Numero de compra generada:\n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);

                }
                textIdProveedor.Text = "0";
                textnumeroDocumento.Text = "";
                textRazonSocial.Text = "";
                dgvdata.Rows.Clear();
                CalcularTotal();
            }
            else 
            {
                MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
        }
    }
}
