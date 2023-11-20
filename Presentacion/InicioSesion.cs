using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace Presentacion
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar(object sender, EventArgs e)
        {
            USUARIO OUsuario = new CN_Usuario().Listar().Where(u=> u.Documento == textDocumento.Text && u.clave == textBox1.Text).FirstOrDefault();
            if (OUsuario != null)
            {
                inicio form = new inicio(OUsuario);
                form.Show(); /*muestra el fromulario de inicio*/
                this.Hide();/*cierra la pestaña de inicio de sesion*/
                form.FormClosing += cerrando;
            }
            else 
            {
                MessageBox.Show("no se encontro el usuario","mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

        }
        private void cerrando(object sender, FormClosingEventArgs e) 
        {
            textDocumento.Text = "";
            textBox1.Text = "";
            this.Show();
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
