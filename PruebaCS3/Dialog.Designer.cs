
namespace DigitalImageProcessing
{
    partial class Dialog
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
            this.textBoxFactor = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelIndications.TabIndex = 0;
            this.textBoxFactor.TabIndex = 1;
            this.buttonOk.TabIndex = 2;
            this.SuspendLayout();
            this.labelIndications.AutoSize = true;
            this.labelIndications.Location = new System.Drawing.Point(0, 0);
            this.labelIndications.Name = "labelIndications";
            this.labelIndications.Text = "Please, insert integer numbers between 1 and 1000:";
            this.textBoxFactor.AutoSize = true;
            this.textBoxFactor.Location = new System.Drawing.Point(0, 30);
            this.textBoxFactor.Name = "textBoxWidth";
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.AutoSize = true;
            this.buttonOk.Location = new System.Drawing.Point(0, 60);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxFactor);
            this.Controls.Add(this.labelIndications);
        }

        #endregion

        public System.Windows.Forms.Label labelIndications;
        public System.Windows.Forms.TextBox textBoxFactor;
        public System.Windows.Forms.Button buttonOk;

    }
}
