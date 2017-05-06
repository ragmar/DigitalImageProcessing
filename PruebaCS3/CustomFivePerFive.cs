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
    public partial class CustomFivePerFive : Form
    {
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            pulsoAceptar = true;
            this.Close();
        }

        public CustomFivePerFive()
        {
            InitializeComponent();
            int b, c;
            b = c = 0;
            for (int a = 0; a < 25; ++a)
            {
                if (a == 5 || a == 10 || a == 15 || a == 20)
                {
                    b++;
                    c = 0;
                }
                this.numericUpDown[a] = new System.Windows.Forms.NumericUpDown();
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown[a])).BeginInit();
                this.numericUpDown[a].Location = new System.Drawing.Point(60 * (c + 1), 35 * (b + 1));
                this.numericUpDown[a].Name = "NUD[" + a + "]";
                this.numericUpDown[a].Size = new System.Drawing.Size(50, 25);
                this.numericUpDown[a].TabIndex = a + 1;
                this.numericUpDown[a].Minimum = -100;
                this.numericUpDown[a].Value = 0;
                this.numericUpDown[a].Maximum = 100;
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDown[a])).EndInit();
                c++;
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Controls.Add(this.buttonOk);
            for (int a = 24; a >= 0; --a)
                this.Controls.Add(this.numericUpDown[a]);
            this.Controls.Add(this.labelIndications);
            pulsoAceptar = false;
        }

        public bool pulsoAceptar;

    }
}
