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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormReportedeCompras : Form
    {
        public FormReportedeCompras()
        {
            InitializeComponent();
        }

        private void FormReportedeCompras_Load(object sender, EventArgs e)
        {
            List<Proveedor> lista = new CN_Proveedor().Listar();
            CboProveedor.Items.Add(new OpcionesCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Proveedor item in lista) 
            {
                CboProveedor.Items.Add(new OpcionesCombo() { Valor = item.IdProveedor, Texto = item.RazonSocial });
            }
            CboProveedor.DisplayMember = "Texto";
            CboProveedor.ValueMember = "Valor";
            CboProveedor.SelectedIndex = 0;

            
            foreach (DataGridViewColumn Columna in dgvdata.Columns)
            {
                comboBoxdgv.Items.Add(new OpcionesCombo() { Valor = Columna.Name, Texto = Columna.HeaderText });
            }
            comboBoxdgv.DisplayMember = "Texto";
            comboBoxdgv.ValueMember = "Valor";
            comboBoxdgv.SelectedIndex = 0;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdProveedor = Convert.ToInt32(((OpcionesCombo) CboProveedor.SelectedItem).Valor.ToString());
            List<ReporteCompra> lista = new List<ReporteCompra>();
            lista = new CN_Reporte().Compra(textFechaInicio.Value.ToString(), textFechaFin.Value.ToString(), IdProveedor);

            dgvdata.Rows.Clear();
            foreach (ReporteCompra rc in lista) 
            {
                dgvdata.Rows.Add(new object[] {
                    rc.FechaRegistro,
                    rc.TipoDocumento,
                    rc.NumeroDocumento,
                    rc.MontoTotal,
                    rc.UsuarioRegistro,
                    rc.DocumentoProveedor,
                    rc.RazonSocial,
                    rc.CodigoProducto,
                    rc.NombreProducto,
                    rc.Categoria,
                    rc.PrecioCompra,
                    rc.PrecioVenta,
                    rc.Cantidad,
                    rc.SubTotal

                });
            
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
                    
                        dt.Columns.Add(columna.HeaderText, typeof(string));

                }
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)

                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString(),

                        });
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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

        private void btnBuscarPor_Click(object sender, EventArgs e)
        {
            string ColumnaFiltro = ((OpcionesCombo)comboBoxdgv.SelectedItem).Valor.ToString();
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
