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

    public partial class TresPorTres : Form
    {

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            pulsoAceptar = true;
            this.Close();
        }

        public TresPorTres()
        {
            InitializeComponent();
            int b, c;
            b = c = 0;
            for (int a = 0; a < 9; ++a)
            {
                if (a == 3 || a == 6)
                {
                    b++;
                    c = 0;
                }
                this.nud[a] = new System.Windows.Forms.NumericUpDown();
                ((System.ComponentModel.ISupportInitialize)(this.nud[a])).BeginInit();
                this.nud[a].Location = new System.Drawing.Point(60 * (c + 1), 35 * (b + 1));
                this.nud[a].Name = "NUD[" + a + "]";
                this.nud[a].Size = new System.Drawing.Size(50, 25);
                this.nud[a].TabIndex = a + 1;
                this.nud[a].Minimum = -100;
                this.nud[a].Value = 0;
                this.nud[a].Maximum = 100;
                ((System.ComponentModel.ISupportInitialize)(this.nud[a])).EndInit();
                c++;
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Controls.Add(this.buttonAceptar);
            for (int a = 8; a >= 0; --a)
                this.Controls.Add(this.nud[a]);
            this.Controls.Add(this.labelIndicaciones);
            pulsoAceptar = false;
        }

        public bool pulsoAceptar;

    }
}
