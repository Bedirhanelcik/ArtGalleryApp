using System.Windows.Forms;

namespace ArtGalleryApp1
{
    partial class ModernArtControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ModernArtControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ModernArtControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
