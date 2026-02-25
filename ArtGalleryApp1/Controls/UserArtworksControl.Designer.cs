namespace ArtGalleryApp1
{
    partial class UserArtworksControl
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelScrol = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelScrol
            // 
            this.panelScrol.AutoScroll = true;
            this.panelScrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrol.Location = new System.Drawing.Point(0, 0);
            this.panelScrol.Name = "panelScrol";
            this.panelScrol.Size = new System.Drawing.Size(1280, 720);
            this.panelScrol.TabIndex = 0;
            
            // 
            // UserArtworksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelScrol);
            this.Name = "UserArtworksControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelScrol;
    }
}
