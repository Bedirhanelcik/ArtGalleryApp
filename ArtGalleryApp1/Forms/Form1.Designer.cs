namespace ArtGalleryApp1
{
    partial class Form1
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUserArtworks = new System.Windows.Forms.Panel();
            this.btnUserArtwork = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnArtworks = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnArtists = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnUserArtworks.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUserArtworks
            // 
            this.btnUserArtworks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(38)))), ((int)(((byte)(26)))));
            this.btnUserArtworks.Controls.Add(this.btnUserArtwork);
            this.btnUserArtworks.Controls.Add(this.btnHome);
            this.btnUserArtworks.Controls.Add(this.btnCategories);
            this.btnUserArtworks.Controls.Add(this.btnArtworks);
            this.btnUserArtworks.Controls.Add(this.btnAbout);
            this.btnUserArtworks.Controls.Add(this.btnArtists);
            this.btnUserArtworks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserArtworks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserArtworks.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserArtworks.Location = new System.Drawing.Point(0, 0);
            this.btnUserArtworks.Name = "btnUserArtworks";
            this.btnUserArtworks.Size = new System.Drawing.Size(1262, 80);
            this.btnUserArtworks.TabIndex = 0;
            // 
            // btnUserArtwork
            // 
            this.btnUserArtwork.BackColor = System.Drawing.Color.Transparent;
            this.btnUserArtwork.FlatAppearance.BorderSize = 0;
            this.btnUserArtwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserArtwork.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserArtwork.ForeColor = System.Drawing.Color.OldLace;
            this.btnUserArtwork.Location = new System.Drawing.Point(592, 25);
            this.btnUserArtwork.Name = "btnUserArtwork";
            this.btnUserArtwork.Size = new System.Drawing.Size(136, 30);
            this.btnUserArtwork.TabIndex = 5;
            this.btnUserArtwork.Text = "User Artworks";
            this.btnUserArtwork.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHome.ForeColor = System.Drawing.Color.Transparent;
            this.btnHome.Location = new System.Drawing.Point(12, 22);
            this.btnHome.Name = "btnHome";
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.Size = new System.Drawing.Size(105, 37);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCategories.ForeColor = System.Drawing.Color.Transparent;
            this.btnCategories.Location = new System.Drawing.Point(203, 22);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(114, 37);
            this.btnCategories.TabIndex = 3;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = false;
            // 
            // btnArtworks
            // 
            this.btnArtworks.BackColor = System.Drawing.Color.Transparent;
            this.btnArtworks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArtworks.FlatAppearance.BorderSize = 0;
            this.btnArtworks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnArtworks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnArtworks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArtworks.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArtworks.ForeColor = System.Drawing.Color.Transparent;
            this.btnArtworks.Location = new System.Drawing.Point(323, 22);
            this.btnArtworks.Name = "btnArtworks";
            this.btnArtworks.Size = new System.Drawing.Size(109, 37);
            this.btnArtworks.TabIndex = 2;
            this.btnArtworks.Text = "Artworks";
            this.btnArtworks.UseVisualStyleBackColor = false;
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAbout.ForeColor = System.Drawing.Color.Transparent;
            this.btnAbout.Location = new System.Drawing.Point(110, 22);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(87, 37);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            // 
            // btnArtists
            // 
            this.btnArtists.BackColor = System.Drawing.Color.Transparent;
            this.btnArtists.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArtists.FlatAppearance.BorderSize = 0;
            this.btnArtists.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnArtists.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnArtists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArtists.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArtists.ForeColor = System.Drawing.Color.Transparent;
            this.btnArtists.Location = new System.Drawing.Point(416, 22);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(183, 37);
            this.btnArtists.TabIndex = 0;
            this.btnArtists.Text = "Famous Artists";
            this.btnArtists.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1262, 593);
            this.panelMain.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.btnUserArtworks);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ART GALLERY APP";
            this.btnUserArtworks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnUserArtworks;
        private System.Windows.Forms.Button btnArtists;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnArtworks;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnUserArtwork;
    }
}

