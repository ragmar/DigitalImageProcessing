
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DigitalImageProcessing
{

    public partial class Information : Form
    {

        MainController imageHandler;

        public Information(MainController imageHandler)
        {
            this.imageHandler = imageHandler;
            InitializeComponent();
        }

        private void ImageInfo_Load(object sender, EventArgs e)
        {
            labelDimension.Text = imageHandler.CurrentBitmap.Width + " x " + imageHandler.CurrentBitmap.Height;
            labelColor.Text = "" + imageHandler.colors;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
