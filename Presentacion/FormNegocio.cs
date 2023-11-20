using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormNegocio : Form
    {
        public FormNegocio()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public Image byteToImage(byte[] ImageBytes) 
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(ImageBytes, 0, ImageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        
        }

        private void FormNegocio_Load(object sender, EventArgs e)
        {
            bool Obtenido = true;
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out Obtenido);

            if (Obtenido)
                PicLogo.Image = byteToImage(byteimage);

            Negocio Datos = new CN_Negocio().ObtenerDatos();

            txtNombreNegocio.Text = Datos.Nombre;
            txtRuc.Text = Datos.RUC;
            txtDireccion.Text = Datos.Direccion;

        }

        private void BtnSubir_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            //oOpenFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png;*.JPEG IMAGE;";
            oOpenFileDialog.Filter = "Todos los archivos|*.*";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK) 
            {
                byte[] byteimage =File.ReadAllBytes(oOpenFileDialog.FileName);
                bool Respuesta = new CN_Negocio().ActualizarLogo(byteimage,out Mensaje);

                if (Respuesta)
                {
                    PicLogo.Image = byteToImage(byteimage);

                }
                else
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtNombreNegocio.Text,
                RUC= txtRuc.Text,
                Direccion=txtDireccion.Text

            };

            bool Respuesta = new CN_Negocio().GuardarDatos(obj, out Mensaje);
            if (Respuesta)
            {
                MessageBox.Show("Los cambios fueron guardados", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("No se pudieron guardar los cambios", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
