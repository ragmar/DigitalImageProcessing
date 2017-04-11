
namespace PruebaCS3
{
    partial class Informacion
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
            this.labelDimTitulo = new System.Windows.Forms.Label();
            this.labelDimensiones = new System.Windows.Forms.Label();
            this.labelColTitulo = new System.Windows.Forms.Label();
            this.labelColores = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDimTitulo
            // 
            this.labelDimTitulo.AutoSize = true;
            this.labelDimTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelDimTitulo.Name = "labelDimTitulo";
            this.labelDimTitulo.Size = new System.Drawing.Size(141, 13);
            this.labelDimTitulo.TabIndex = 0;
            this.labelDimTitulo.Text = "Dimensions (Width x Heght):";
            // 
            // labelDimensiones
            // 
            this.labelDimensiones.AutoSize = true;
            this.labelDimensiones.Location = new System.Drawing.Point(0, 30);
            this.labelDimensiones.Name = "labelDimensiones";
            this.labelDimensiones.Size = new System.Drawing.Size(30, 13);
            this.labelDimensiones.TabIndex = 1;
            this.labelDimensiones.Text = "1 x 1";
            // 
            // labelColTitulo
            // 
            this.labelColTitulo.AutoSize = true;
            this.labelColTitulo.Location = new System.Drawing.Point(0, 60);
            this.labelColTitulo.Name = "labelColTitulo";
            this.labelColTitulo.Size = new System.Drawing.Size(125, 13);
            this.labelColTitulo.TabIndex = 2;
            this.labelColTitulo.Text = "Number of unique colors:";
            // 
            // labelColores
            // 
            this.labelColores.AutoSize = true;
            this.labelColores.Location = new System.Drawing.Point(0, 90);
            this.labelColores.Name = "labelColores";
            this.labelColores.Size = new System.Drawing.Size(13, 13);
            this.labelColores.TabIndex = 3;
            this.labelColores.Text = "1";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAceptar.Location = new System.Drawing.Point(0, 120);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 4;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // Informacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.labelColores);
            this.Controls.Add(this.labelColTitulo);
            this.Controls.Add(this.labelDimensiones);
            this.Controls.Add(this.labelDimTitulo);
            this.Name = "Informacion";
            this.Text = "Informacion";
            this.Load += new System.EventHandler(this.ImageInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDimTitulo;
        private System.Windows.Forms.Label labelDimensiones;
        private System.Windows.Forms.Label labelColTitulo;
        private System.Windows.Forms.Label labelColores;
        private System.Windows.Forms.Button buttonAceptar;

    }
}
