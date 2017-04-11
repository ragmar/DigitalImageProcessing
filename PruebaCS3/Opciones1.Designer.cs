namespace PruebaCS3
{
    partial class Opciones1
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
            this.labelIndicaciones = new System.Windows.Forms.Label();
            this.labelIndicaciones2 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.numericW = new System.Windows.Forms.NumericUpDown();
            this.numericH = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIndicaciones
            // 
            this.labelIndicaciones.AutoSize = true;
            this.labelIndicaciones.Location = new System.Drawing.Point(0, 0);
            this.labelIndicaciones.Name = "labelIndicaciones";
            this.labelIndicaciones.Size = new System.Drawing.Size(216, 26);
            this.labelIndicaciones.TabIndex = 0;
            this.labelIndicaciones.Text = "Indique la ruta de la base de datos. Ejemplo:\nC:\\Viajes\\Manhattan";
            // 
            // labelIndicaciones2
            // 
            this.labelIndicaciones2.AutoSize = true;
            this.labelIndicaciones2.Location = new System.Drawing.Point(0, 80);
            this.labelIndicaciones2.Name = "labelIndicaciones2";
            this.labelIndicaciones2.Size = new System.Drawing.Size(247, 26);
            this.labelIndicaciones2.TabIndex = 2;
            this.labelIndicaciones2.Text = "Indique, en pixeles, el ancho y el alto al cual desea\nescalar las imagenes de la " +
                "base de datos:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(0, 40);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.AutoSize = true;
            this.buttonAceptar.Location = new System.Drawing.Point(0, 160);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 5;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // numericW
            // 
            this.numericW.Location = new System.Drawing.Point(3, 122);
            this.numericW.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericW.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericW.Name = "numericW";
            this.numericW.Size = new System.Drawing.Size(97, 20);
            this.numericW.TabIndex = 6;
            this.numericW.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericH
            // 
            this.numericH.Location = new System.Drawing.Point(107, 122);
            this.numericH.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericH.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericH.Name = "numericH";
            this.numericH.Size = new System.Drawing.Size(109, 20);
            this.numericH.TabIndex = 7;
            this.numericH.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Opciones1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericH);
            this.Controls.Add(this.numericW);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.labelIndicaciones2);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelIndicaciones);
            this.Name = "Opciones1";
            this.Text = "Precalculo";
            ((System.ComponentModel.ISupportInitialize)(this.numericW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIndicaciones;
        private System.Windows.Forms.Label labelIndicaciones2;
        public System.Windows.Forms.TextBox textBoxPath;
        public System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.NumericUpDown numericW;
        public System.Windows.Forms.NumericUpDown numericH;

    }
}
