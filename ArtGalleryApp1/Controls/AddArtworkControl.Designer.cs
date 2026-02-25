namespace ArtGalleryApp1
{
    partial class AddArtworkControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.Panel();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureArtwork = new System.Windows.Forms.PictureBox();
            this.lblUploadHint = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ArtworkOwner = new System.Windows.Forms.Label();
            this.txtArtworkOwner = new System.Windows.Forms.MaskedTextBox();
            this.ArtworkName = new System.Windows.Forms.Label();
            this.txtArtworkName = new System.Windows.Forms.MaskedTextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnSaveArtwork = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelTop.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelCard);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1280, 720);
            this.panelTop.TabIndex = 0;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.lblDesc);
            this.panelCard.Controls.Add(this.divider);
            this.panelCard.Controls.Add(this.panelImage);
            this.panelCard.Controls.Add(this.UserName);
            this.panelCard.Controls.Add(this.txtUserName);
            this.panelCard.Controls.Add(this.ArtworkOwner);
            this.panelCard.Controls.Add(this.txtArtworkOwner);
            this.panelCard.Controls.Add(this.ArtworkName);
            this.panelCard.Controls.Add(this.txtArtworkName);
            this.panelCard.Controls.Add(this.btnAddImage);
            this.panelCard.Controls.Add(this.btnSaveArtwork);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(30);
            this.panelCard.Size = new System.Drawing.Size(1280, 720);
            this.panelCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Submit Your Art";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDesc.Location = new System.Drawing.Point(30, 65);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(260, 16);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Enter artwork details for gallery submission";
            // 
            // divider
            // 
            this.divider.BackColor = System.Drawing.Color.LightGray;
            this.divider.Location = new System.Drawing.Point(30, 90);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(1000, 1);
            this.divider.TabIndex = 2;
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelImage.Controls.Add(this.pictureArtwork);
            this.panelImage.Controls.Add(this.lblUploadHint);
            this.panelImage.Location = new System.Drawing.Point(30, 130);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(411, 245);
            this.panelImage.TabIndex = 3;
            // 
            // pictureArtwork
            // 
            this.pictureArtwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureArtwork.Location = new System.Drawing.Point(0, 0);
            this.pictureArtwork.Name = "pictureArtwork";
            this.pictureArtwork.Size = new System.Drawing.Size(411, 245);
            this.pictureArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureArtwork.TabIndex = 0;
            this.pictureArtwork.TabStop = false;
            // 
            // lblUploadHint
            // 
            this.lblUploadHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUploadHint.ForeColor = System.Drawing.Color.Gray;
            this.lblUploadHint.Location = new System.Drawing.Point(0, 0);
            this.lblUploadHint.Name = "lblUploadHint";
            this.lblUploadHint.Size = new System.Drawing.Size(411, 245);
            this.lblUploadHint.TabIndex = 1;
            this.lblUploadHint.Text = "Upload image";
            this.lblUploadHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(465, 130);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(76, 16);
            this.UserName.TabIndex = 4;
            this.UserName.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(465, 155);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 22);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // ArtworkOwner
            // 
            this.ArtworkOwner.AutoSize = true;
            this.ArtworkOwner.Location = new System.Drawing.Point(695, 130);
            this.ArtworkOwner.Name = "ArtworkOwner";
            this.ArtworkOwner.Size = new System.Drawing.Size(76, 16);
            this.ArtworkOwner.TabIndex = 6;
            this.ArtworkOwner.Text = "Artist Name";
            // 
            // txtArtworkOwner
            // 
            this.txtArtworkOwner.Location = new System.Drawing.Point(695, 155);
            this.txtArtworkOwner.Name = "txtArtworkOwner";
            this.txtArtworkOwner.Size = new System.Drawing.Size(200, 22);
            this.txtArtworkOwner.TabIndex = 7;
            // 
            // ArtworkName
            // 
            this.ArtworkName.AutoSize = true;
            this.ArtworkName.Location = new System.Drawing.Point(465, 200);
            this.ArtworkName.Name = "ArtworkName";
            this.ArtworkName.Size = new System.Drawing.Size(91, 16);
            this.ArtworkName.TabIndex = 8;
            this.ArtworkName.Text = "Artwork Name";
            // 
            // txtArtworkName
            // 
            this.txtArtworkName.Location = new System.Drawing.Point(465, 225);
            this.txtArtworkName.Name = "txtArtworkName";
            this.txtArtworkName.Size = new System.Drawing.Size(430, 22);
            this.txtArtworkName.TabIndex = 9;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(465, 270);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 33);
            this.btnAddImage.TabIndex = 10;
            this.btnAddImage.Text = "Upload File";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnSaveArtwork
            // 
            this.btnSaveArtwork.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaveArtwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveArtwork.ForeColor = System.Drawing.Color.White;
            this.btnSaveArtwork.Location = new System.Drawing.Point(465, 330);
            this.btnSaveArtwork.Name = "btnSaveArtwork";
            this.btnSaveArtwork.Size = new System.Drawing.Size(420, 45);
            this.btnSaveArtwork.TabIndex = 11;
            this.btnSaveArtwork.Text = "Save Artwork";
            this.btnSaveArtwork.UseVisualStyleBackColor = false;
            this.btnSaveArtwork.Click += new System.EventHandler(this.btnSaveArtwork_Click);
            // 
            // AddArtworkControl
            // 
            this.Controls.Add(this.panelTop);
            this.Name = "AddArtworkControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.panelTop.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureArtwork;
        private System.Windows.Forms.Label lblUploadHint;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Panel divider;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label ArtworkOwner;
        private System.Windows.Forms.MaskedTextBox txtArtworkOwner;
        private System.Windows.Forms.Label ArtworkName;
        private System.Windows.Forms.MaskedTextBox txtArtworkName;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnSaveArtwork;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
