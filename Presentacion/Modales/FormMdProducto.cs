using CapaEntidad;
using CapaNegocio;
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

namespace Presentacion.Modales
{
    public partial class FormMdProducto : Form
    {
        public Producto _Producto { get; set; }
        public FormMdProducto()
        {
            InitializeComponent();
        }

        private void FormMdProducto_Load(object sender, EventArgs e)
        {
          
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true )
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
                dgvdata.Rows.Add(new object[] {
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.OCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta
                   
                });
            }

        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IRow = e.RowIndex;
            int IColum = e.ColumnIndex;

            if (IRow >= 0 && IColum > 0)
            {

                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvdata.Rows[IRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvdata.Rows[IRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvdata.Rows[IRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvdata.Rows[IRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgvdata.Rows[IRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvdata.Rows[IRow].Cells["PrecioVenta"].Value.ToString()),

                };
                this.DialogResult = DialogResult.OK;
                this.Close();

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
    }
}
