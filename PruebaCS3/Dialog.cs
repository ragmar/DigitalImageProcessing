
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PruebaCS3
{

    public partial class Dialog : Form
    {

        public Dialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string z = this.textBoxFactor.Text;
            entradaExitosa = true;
            while (true)
            {
                if (z[0] != 48)
                    break;
                else
                    if (z.Length > 1)
                        z = z.Remove(0, 1);
                    else
                        break;
            }
            for (int a = 0; a < z.Length; a++)
                if (z[a] < 48 || 57 < z[a])
                    entradaExitosa = false;
            if (z.Length < 1 || 4 < z.Length)
                entradaExitosa = false;
            factor = 0.0;
            for (int a = z.Length - 1; a >= 0; a--)
                factor += (z[z.Length - 1 - a] - 48) * Math.Pow(10, a);
            if (factor < 1.0 || 1000.0 < factor)
                entradaExitosa = false;
            this.Close();
        }

        public double factor;
        public bool entradaExitosa;

    }

}
