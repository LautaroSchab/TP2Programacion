using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("¿desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Producto obj = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtID.Text)

                    };
                    bool Respuesta = new CN_Producto().Eliminar(obj, out Mensaje);
                    if (Respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }




            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Producto obj = new Producto()
            {
                IdProducto = Convert.ToInt32(txtID.Text),
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                OCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionesCombo)CboCategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionesCombo)CboEstado.SelectedItem).Valor) == 1 ? true : false


            };
            if (obj.IdProducto == 0)
            {
                int Idgenerado = new CN_Producto().Registrar(obj, out Mensaje);
                if (Idgenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",
                    Idgenerado,
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDescripcion.Text,
                    ((OpcionesCombo)CboCategoria.SelectedItem).Valor.ToString(),
                    ((OpcionesCombo)CboCategoria.SelectedItem).Texto.ToString(),
                    "0",
                    "0.00",
                    "0.00",
                    ((OpcionesCombo)CboEstado.SelectedItem).Valor.ToString(),
                    ((OpcionesCombo)CboEstado.SelectedItem).Texto.ToString(),
                });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }


            }
            else
            {
                bool Resultado = new CN_Producto().Editar(obj, out Mensaje);
                if (Resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtID.Text;
                    row.Cells["Codigo"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["descripcion"].Value = txtDescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionesCombo)CboCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionesCombo)CboCategoria.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionesCombo)CboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionesCombo)CboEstado.SelectedItem).Texto.ToString();
                    Limpiar();

                }
                else
                {
                    MessageBox.Show(Mensaje);

                }
            }
        }

        private void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            CboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            CboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });
            CboEstado.DisplayMember = "Texto";
            CboEstado.ValueMember = "Valor";
            CboEstado.SelectedIndex = 0;

            List<Categoria> ListaCategoria = new CN_Categoria().Listar();
            foreach (Categoria item in ListaCategoria)
            {
                CboCategoria.Items.Add(new OpcionesCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            CboCategoria.DisplayMember = "Texto";
            CboCategoria.ValueMember = "Valor";
            CboCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    CboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            CboBusqueda.DisplayMember = "Texto";
            CboBusqueda.ValueMember = "Valor";
            CboBusqueda.SelectedIndex = 0;

            //mostar todos los usuarios
            List<Producto> Lista = new CN_Producto().Listar();
            foreach (Producto item in Lista)
            {
                dgvdata.Rows.Add(new object[] {"", 
                    item.IdProducto, 
                    item.Codigo, 
                    item.Nombre, 
                    item.Descripcion, 
                    item.OCategoria.IdCategoria,
                    item.OCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado == true ?1 :0,
                    item.Estado == true ?"Activo": "No Activo"
                });
            }
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            CboCategoria.SelectedIndex = 0;
            CboEstado.SelectedIndex = 0;
            txtCodigo.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.icons4.Width;
                var h = Properties.Resources.icons4.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;


                e.Graphics.DrawImage(Properties.Resources.icons4, new Rectangle(x, y, w, h));
                e.Handled = true;


            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtCodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtNombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvdata.Rows[indice].Cells["descripcion"].Value.ToString();
                    
                    foreach (OpcionesCombo oc in CboCategoria.Items)

                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = CboCategoria.Items.IndexOf(oc);
                            CboCategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionesCombo oc in CboEstado.Items)

                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = CboEstado.Items.IndexOf(oc);
                            CboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }




                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpcionesCombo)CboBusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;

                    }
                    else
                    {
                        row.Visible = false;
                    }
                }

            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;

            }
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));

                }
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)

                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString(),

                        });
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {

                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
        }
    }
}
