using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;


using System.Windows.Forms;

namespace camaras_de_vigilancia
{
    public partial class Form1 : Form
    {
        private Mat Frame;
        private VideoCapture Camara;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camara = new VideoCapture();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.stop();
            Camara.Stop();
            PictureBox.Image = null;
            timer
        }

        private void btnencender_Click(object sender, EventArgs e)
        {
            Camara.Start();
            if(!Timer.Enabled) timer1.Enabled = true;

        }
    }
}
