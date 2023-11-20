using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using CapaEntidad;


using CapaNegocio;
using FontAwesome.Sharp;

namespace Presentacion
{
    public partial class inicio : Form
    {
        private static USUARIO usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        private DateTime inicioSesion; 
        private Timer timer;
        public inicio(USUARIO objusuario = null)
        {
            if (objusuario == null) usuarioActual = new USUARIO() { NombreCompleto = "admin predefinido", IdUsuario = 1 };
            else usuarioActual = objusuario;
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconMenu in menuStrip1.Items)
            {
                bool encontrado = ListaPermisos.Any(l => l.NombreMenu == iconMenu.Name);
                if (encontrado== false) 
                {
                    iconMenu.Visible = false;
                }

            }



            lblusuario.Text = usuarioActual.NombreCompleto;
            IniciarSesion();
        }
        private void IniciarSesion()
        {
            inicioSesion = DateTime.Now;

            // Inicia el temporizador
            timer.Start();
        }
        private void CerrarSesion()
        {
            // Detiene el temporizador al cerrar sesión
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calcula el tiempo transcurrido desde el inicio de sesión
            TimeSpan tiempoTranscurrido = DateTime.Now - inicioSesion;

            // Formatea el tiempo sin milisegundos
            string tiempoFormateado = $"{tiempoTranscurrido.Hours:D2}:{tiempoTranscurrido.Minutes:D2}:{tiempoTranscurrido.Seconds:D2}";

            // Actualiza el tiempo en tu formulario
            labelTiempoTranscurrido.Text = $"Tiempo transcurrido: {tiempoFormateado}";

            // Puedes realizar otras acciones periódicas aquí si es necesario
        }

        private void iconMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrirForm(IconMenuItem menu, Form formulario) 
        {
            if (MenuActivo != null) 
            {
                MenuActivo.BackColor = Color.White;
            
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null) 
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.LightGray;

            contenedor1.Controls.Add(formulario);
            formulario.Show();
        }
        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirForm((IconMenuItem)sender,new FormUsuarios());
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirForm(menumantenedor, new FormCategoria());
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirForm(menumantenedor, new FormProducto());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirForm(menuventas, new FormVentas(usuarioActual));
        }

        private void submenudetalleventa_Click(object sender, EventArgs e)
        {
            AbrirForm(menuventas, new FormDetalleventa());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirForm(menucompras, new FormCompras(usuarioActual));
        }

        private void submenudetallecompra_Click(object sender, EventArgs e)
        {
            AbrirForm(menucompras, new Formdetallecompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirForm((IconMenuItem)sender, new FormClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirForm((IconMenuItem)sender, new FormProveedores());
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirForm(menumantenedor, new FormNegocio());
        }

       

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(menureportes, new FormReportedeCompras());
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(menureportes, new FormReportedeVentas());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {

                // Cierra el formulario actual
                this.Close();

                // Crea una instancia del formulario al que deseas volver
                InicioSesion formularioAnterior = new InicioSesion();

                // Muestra el formulario anterior
                formularioAnterior.Show();
            }
        }

        private void Camaras_Click(object sender, EventArgs e)
        {
            AbrirForm(Camaras, new FormCamara());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
 

}
