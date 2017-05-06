namespace DigitalImageProcessing
{
    partial class MosaicDialog
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
            this.labelIndicationsImageDB = new System.Windows.Forms.Label();
            this.labelIndicationsPixel = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.numericW = new System.Windows.Forms.NumericUpDown();
            this.numericH = new System.Windows.Forms.NumericUpDown();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIndicaciones
            // 
            this.labelIndicationsImageDB.AutoSize = true;
            this.labelIndicationsImageDB.Location = new System.Drawing.Point(0, 0);
            this.labelIndicationsImageDB.Name = "labelIndicationsImageDB";
            this.labelIndicationsImageDB.Size = new System.Drawing.Size(216, 26);
            this.labelIndicationsImageDB.TabIndex = 0;
            this.labelIndicationsImageDB.Text = "Chose the path to the image database. Example:\nC:\\Journey\\Manhattan";
            // 
            // labelIndicaciones2
            // 
            this.labelIndicationsPixel.AutoSize = true;
            this.labelIndicationsPixel.Location = new System.Drawing.Point(0, 80);
            this.labelIndicationsPixel.Name = "labelIndicationsPixel";
            this.labelIndicationsPixel.Size = new System.Drawing.Size(247, 26);
            this.labelIndicationsPixel.TabIndex = 2;
            this.labelIndicationsPixel.Text = "Write, in pixeles, the width and height in which \nthe images shoulds scale form the " +
                "database:";
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
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.Location = new System.Drawing.Point(0, 160);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            this.buttonOpen.Location = new System.Drawing.Point(107, 40);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(109, 23);
            this.buttonOpen.TabIndex = 8;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // Opciones1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.numericH);
            this.Controls.Add(this.numericW);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelIndicationsPixel);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelIndicationsImageDB);
            this.Name = "MosaicDialog";
            this.Text = "Mosaic Precalculation";
            ((System.ComponentModel.ISupportInitialize)(this.numericW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIndicationsImageDB;
        private System.Windows.Forms.Label labelIndicationsPixel;
        public System.Windows.Forms.TextBox textBoxPath;
        public System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.NumericUpDown numericW;
        public System.Windows.Forms.NumericUpDown numericH;

    }
}
