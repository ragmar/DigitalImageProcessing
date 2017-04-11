namespace PruebaCS3
{
    partial class SietePorSiete
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "SietePorSiete";
            this.Size = new System.Drawing.Size(700, 700);

            this.labelIndicaciones = new System.Windows.Forms.Label();
            this.nud = new System.Windows.Forms.NumericUpDown[49];
            this.buttonAceptar = new System.Windows.Forms.Button();

            this.labelIndicaciones.TabIndex = 0;
            this.buttonAceptar.TabIndex = 50;
            this.SuspendLayout();

            this.labelIndicaciones.AutoSize = true;
            this.labelIndicaciones.Location = new System.Drawing.Point(10, 10);
            this.labelIndicaciones.Name = "labelIndicaciones";
            this.labelIndicaciones.Text = "Por favor, indique la matriz para aplicar la convolucion:";

            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.AutoSize = true;
            this.buttonAceptar.Location = new System.Drawing.Point(60, 280);
            this.buttonAceptar.Size = new System.Drawing.Size(50, 25);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);

        }

        #endregion

        public System.Windows.Forms.Label labelIndicaciones;
        public System.Windows.Forms.NumericUpDown[] nud;
        public System.Windows.Forms.Button buttonAceptar;

    }
}
