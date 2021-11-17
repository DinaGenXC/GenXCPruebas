
namespace GenXCPruebas.Forms
{
    partial class CopyCarpetasArchivos
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
            this.btnCopiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(65, 114);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(95, 23);
            this.btnCopiar.TabIndex = 0;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // CopyCarpetasArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 159);
            this.Controls.Add(this.btnCopiar);
            this.Name = "CopyCarpetasArchivos";
            this.Text = "CopyCarpetasArchivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CopyCarpetasArchivos_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopiar;
    }
}