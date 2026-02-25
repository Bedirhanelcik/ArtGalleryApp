namespace ArtGalleryApp1
{
    partial class HomeControl
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
            this.pictureBoxBg = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSub = new System.Windows.Forms.Label();
            this.labelSlogan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBg
            // 
            this.pictureBoxBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBg.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBg.Name = "pictureBoxBg";
            this.pictureBoxBg.Size = new System.Drawing.Size(1280, 720);
            this.pictureBoxBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBg.TabIndex = 0;
            this.pictureBoxBg.TabStop = false;
            this.pictureBoxBg.Click += new System.EventHandler(this.pictureBoxBg_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Location = new System.Drawing.Point(270, 194);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(44, 16);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "label1";
            // 
            // labelSub
            // 
            this.labelSub.AutoSize = true;
            this.labelSub.Location = new System.Drawing.Point(618, 352);
            this.labelSub.Name = "labelSub";
            this.labelSub.Size = new System.Drawing.Size(44, 16);
            this.labelSub.TabIndex = 2;
            this.labelSub.Text = "label2";
            // 
            // labelSlogan
            // 
            this.labelSlogan.AutoSize = true;
            this.labelSlogan.Location = new System.Drawing.Point(568, 325);
            this.labelSlogan.Name = "labelSlogan";
            this.labelSlogan.Size = new System.Drawing.Size(44, 16);
            this.labelSlogan.TabIndex = 3;
            this.labelSlogan.Text = "label3";
            // 
            // HomeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.labelSlogan);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelSub);
            this.Controls.Add(this.pictureBoxBg);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBg;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSub;
        private System.Windows.Forms.Label labelSlogan;
    }
}
