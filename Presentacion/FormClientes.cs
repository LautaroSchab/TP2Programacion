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

namespace Presentacion
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Cliente obj = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtID.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionesCombo)CboEstado.SelectedItem).Valor) == 1 ? true : false


            };
            if (obj.IdCliente == 0)
            {
                int Idgenerado = new CN_Cliente().Registrar(obj, out Mensaje);
                if (Idgenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",Idgenerado, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text,txtTelefono.Text,
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
                bool Resultado = new CN_Cliente().Editar(obj, out Mensaje);
                if (Resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtID.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtID.Text) != 0)
            {
                if (MessageBox.Show("¿desea eliminar el Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Cliente obj = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtID.Text)

                    };
                    bool Respuesta = new CN_Cliente().Eliminar(obj, out Mensaje);
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

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CboEstado.Items.Add(new OpcionesCombo() { Valor = 1, Texto = "Activo" });
            CboEstado.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "No Activo" });
            CboEstado.DisplayMember = "Texto";
            CboEstado.ValueMember = "Valor";
            CboEstado.SelectedIndex = 0;

            List<Rol> ListaRol = new CN_Rol().Listar();


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
            List<Cliente> Lista = new CN_Cliente().Listar();
            foreach (Cliente item in Lista)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdCliente,item.Documento,item.NombreCompleto,item.Correo, item.Telefono,
                   
                    item.Estado == true ?1 :0,
                    item.Estado == true ?"Activo": "No Activo"
                });
            }


        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            CboEstado.SelectedIndex = 0;
            txtDocumento.Select();
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
                    txtDocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();
                    

                    foreach (OpcionesCombo oc in CboEstado.Items)

                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["Estado"].Value))
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
    }
}
