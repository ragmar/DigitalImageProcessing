using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalImageProcessing
{
    public partial class Texto : Form
    {
        public Texto()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string z;
            entradaExitosa = true;
            /****************************************/
            z = this.textBoxN.Text;
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
            factorN = 0.0;
            for (int a = z.Length - 1; a >= 0; a--)
                factorN += (z[z.Length - 1 - a] - 48) * Math.Pow(10, a);
            if (factorN < 1 || 10000 < factorN)
                entradaExitosa = false;
            /****************************************/
            this.Close();
        }

        public double factorM;
        public double factorN;
        public bool entradaExitosa;

    }
}
