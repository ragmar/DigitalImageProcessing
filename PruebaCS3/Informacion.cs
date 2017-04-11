
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PruebaCS3
{

    public partial class Informacion : Form
    {

        Manejador imageHandler;

        public Informacion(Manejador imageHandler)
        {
            this.imageHandler = imageHandler;
            InitializeComponent();
        }

        private void ImageInfo_Load(object sender, EventArgs e)
        {
            labelDimensiones.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
            labelColores.Text = "" + imageHandler.colors;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
