
namespace PruebaCS3
{
    partial class Dialogo
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
            this.Text = "Dialogo";
            this.labelIndicaciones = new System.Windows.Forms.Label();
            this.textBoxFactor = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelIndicaciones.TabIndex = 0;
            this.textBoxFactor.TabIndex = 1;
            this.buttonAceptar.TabIndex = 2;
            this.SuspendLayout();
            this.labelIndicaciones.AutoSize = true;
            this.labelIndicaciones.Location = new System.Drawing.Point(0, 0);
            this.labelIndicaciones.Name = "labelIndicaciones";
            this.labelIndicaciones.Text = "Por favor, introduzca un numero entero entre 1 y 1000:";
            this.textBoxFactor.AutoSize = true;
            this.textBoxFactor.Location = new System.Drawing.Point(0, 30);
            this.textBoxFactor.Name = "textBoxWidth";
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.AutoSize = true;
            this.buttonAceptar.Location = new System.Drawing.Point(0, 60);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxFactor);
            this.Controls.Add(this.labelIndicaciones);
        }

        #endregion

        public System.Windows.Forms.Label labelIndicaciones;
        public System.Windows.Forms.TextBox textBoxFactor;
        public System.Windows.Forms.Button buttonAceptar;

    }
}
