namespace PruebaCS3
{
    partial class Dimensions
    {

        private System.ComponentModel.IContainer componente = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (componente != null))
            {
                componente.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.componente = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Dialog";
            this.labelIndications = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelIndications.TabIndex = 0;
            this.textBoxM.TabIndex = 1;
            this.textBoxN.TabIndex = 2;
            this.buttonOk.TabIndex = 3;
            this.SuspendLayout();
            this.labelIndications.AutoSize = true;
            this.labelIndications.Location = new System.Drawing.Point(0, 0);
            this.labelIndications.Name = "labelIndications";
            this.labelIndications.Text = "Please, insert integer numbers between 1 and 10000:";
            this.textBoxM.AutoSize = true;
            this.textBoxM.Location = new System.Drawing.Point(0, 30);
            this.textBoxM.Name = "textBoxM";
            this.textBoxN.AutoSize = true;
            this.textBoxN.Location = new System.Drawing.Point(0, 60);
            this.textBoxN.Name = "textBoxN";
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.Location = new System.Drawing.Point(0, 90);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.labelIndications);
        }

        #endregion

        public System.Windows.Forms.Label labelIndications;
        public System.Windows.Forms.TextBox textBoxM;
        public System.Windows.Forms.TextBox textBoxN;
        public System.Windows.Forms.Button buttonOk;

    }
}