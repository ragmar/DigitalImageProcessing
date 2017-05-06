
namespace DigitalImageProcessing
{
    partial class Information
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
            this.labelTittleDim = new System.Windows.Forms.Label();
            this.labelDimension = new System.Windows.Forms.Label();
            this.labelTittleCol = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDimTitulo
            // 
            this.labelTittleDim.AutoSize = true;
            this.labelTittleDim.Location = new System.Drawing.Point(0, 0);
            this.labelTittleDim.Name = "labelTittleDim";
            this.labelTittleDim.Size = new System.Drawing.Size(141, 13);
            this.labelTittleDim.TabIndex = 0;
            this.labelTittleDim.Text = "Dimensions (Width x Heght):";
            // 
            // labelDimensiones
            // 
            this.labelDimension.AutoSize = true;
            this.labelDimension.Location = new System.Drawing.Point(0, 30);
            this.labelDimension.Name = "labelDimension";
            this.labelDimension.Size = new System.Drawing.Size(30, 13);
            this.labelDimension.TabIndex = 1;
            this.labelDimension.Text = "1 x 1";
            // 
            // labelColTitulo
            // 
            this.labelTittleCol.AutoSize = true;
            this.labelTittleCol.Location = new System.Drawing.Point(0, 60);
            this.labelTittleCol.Name = "labelTittleCol";
            this.labelTittleCol.Size = new System.Drawing.Size(125, 13);
            this.labelTittleCol.TabIndex = 2;
            this.labelTittleCol.Text = "Number of unique colors:";
            // 
            // labelColores
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(0, 90);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(13, 13);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "1";
            // 
            // buttonAceptar
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(0, 120);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Informacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelTittleCol);
            this.Controls.Add(this.labelDimension);
            this.Controls.Add(this.labelTittleDim);
            this.Name = "Information";
            this.Text = "Information";
            this.Load += new System.EventHandler(this.ImageInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTittleDim;
        private System.Windows.Forms.Label labelDimension;
        private System.Windows.Forms.Label labelTittleCol;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button buttonOk;

    }
}
