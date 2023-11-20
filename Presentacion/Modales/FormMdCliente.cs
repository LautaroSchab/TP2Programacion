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
    public partial class FormMdCliente : Form
    {
        public Cliente _Cliente { get; set; }
        public FormMdCliente()
        {
            InitializeComponent();
        }

        private void FormMdCliente_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                   CboBusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, Texto = columna.HeaderText });
               
            }
            CboBusqueda.DisplayMember = "Texto";
            CboBusqueda.ValueMember = "Valor";
            CboBusqueda.SelectedIndex = 0;

            List<Cliente> Lista = new CN_Cliente().Listar();
            foreach (Cliente item in Lista)
            {
                if (item.Estado) 
                {
                    dgvdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });
                }
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IRow = e.RowIndex;
            int IColum = e.ColumnIndex;

            if (IRow >= 0 && IColum > 0)
            {

                _Cliente = new Cliente()
                {
                    
                    Documento = dgvdata.Rows[IRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgvdata.Rows[IRow].Cells["NombreCompleto"].Value.ToString(),
                    

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
