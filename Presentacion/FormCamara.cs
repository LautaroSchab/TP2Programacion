using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;

namespace Presentacion
{
    public partial class FormCamara : Form
    {
        private Mat Frame;
        private VideoCapture Camara;
        public FormCamara()
        {
            InitializeComponent();
        }

        private void FormCamara_Load(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camara = new VideoCapture();
            timer1.Interval = 40;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            Camara.Start();
            if (!timer1.Enabled) timer1.Enabled = true;
            timer1.Start();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (Camara.IsOpened)
            {
                Camara.Stop();
                Camara.Dispose(); // Liberar recursos de la cámara
            }
            pictureBox1.Image = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Camara.IsOpened)
            {
                Camara.Read(Frame);
                pictureBox1.Image = Frame.ToBitmap();
            }
        }
    }
}
