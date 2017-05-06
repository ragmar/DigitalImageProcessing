namespace DigitalImageProcessing
{
    partial class ThreePerThree
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
            this.Text = "TresPorTres";
            this.Size = new System.Drawing.Size(300, 300);

            this.labelIndications = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown[9];
            this.buttonOk = new System.Windows.Forms.Button();

            this.labelIndications.TabIndex = 0;
            this.buttonOk.TabIndex = 10;
            this.SuspendLayout();

            this.labelIndications.AutoSize = true;
            this.labelIndications.Location = new System.Drawing.Point(10, 10);
            this.labelIndications.Name = "labelIndications";
            this.labelIndications.Text = "Please, create the matrix to apply the Convolution:";

            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.Location = new System.Drawing.Point(60, 140);
            this.buttonOk.Size = new System.Drawing.Size(50, 25);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);

        }

        #endregion

        public System.Windows.Forms.Label labelIndications;
        public System.Windows.Forms.NumericUpDown[] numericUpDown;
        public System.Windows.Forms.Button buttonOk;

    }
}
