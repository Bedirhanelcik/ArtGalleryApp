namespace ArtGalleryApp1
{
    partial class EditArtworkForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureArtwork;
        private System.Windows.Forms.TextBox txtArtworkName;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.Label lblArtwork;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChangeImage;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureArtwork = new System.Windows.Forms.PictureBox();
            this.txtArtworkName = new System.Windows.Forms.TextBox();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.lblArtwork = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChangeImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureArtwork
            // 
            this.pictureArtwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureArtwork.Location = new System.Drawing.Point(30, 90);
            this.pictureArtwork.Name = "pictureArtwork";
            this.pictureArtwork.Size = new System.Drawing.Size(260, 300);
            this.pictureArtwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(320, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.Text = "Edit Artwork";
            // 
            // lblArtwork
            // 
            this.lblArtwork.Location = new System.Drawing.Point(320, 90);
            this.lblArtwork.Text = "Artwork Name";
            // 
            // txtArtworkName
            // 
            this.txtArtworkName.Location = new System.Drawing.Point(320, 115);
            this.txtArtworkName.Size = new System.Drawing.Size(300, 22);
            // 
            // lblArtist
            // 
            this.lblArtist.Location = new System.Drawing.Point(320, 160);
            this.lblArtist.Text = "Artist Name";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(320, 185);
            this.txtArtistName.Size = new System.Drawing.Size(300, 22);
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.Location = new System.Drawing.Point(30, 405);
            this.btnChangeImage.Size = new System.Drawing.Size(260, 35);
            this.btnChangeImage.Text = "Change Image";
            this.btnChangeImage.UseVisualStyleBackColor = true;
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, 245);
            this.btnSave.Size = new System.Drawing.Size(300, 45);
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditArtworkForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 470);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangeImage);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txtArtworkName);
            this.Controls.Add(this.lblArtwork);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureArtwork);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditArtworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Artwork";
            ((System.ComponentModel.ISupportInitialize)(this.pictureArtwork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
