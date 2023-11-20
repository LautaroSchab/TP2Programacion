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
    public partial class FormMdProveedor : Form
    {
        public Proveedor _Proveedor { get; set; }
        public FormMdProveedor()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FormMdProveedor_Load(object sender, EventArgs e)
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

            List<Proveedor> Lista = new CN_Proveedor().Listar();
            foreach (Proveedor item in Lista)
            {
                dgvdata.Rows.Add(new object[] {item.IdProveedor,item.Documento,item.RazonSocial
                });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void dgvdata_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int IRow = e.RowIndex;
            int IColum = e.ColumnIndex;

            if (IRow >= 0 && IColum > 0)
            {

                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvdata.Rows[IRow].Cells["Id"].Value.ToString()),
                    Documento = dgvdata.Rows[IRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvdata.Rows[IRow].Cells["RazonSocial"].Value.ToString()

                };
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
