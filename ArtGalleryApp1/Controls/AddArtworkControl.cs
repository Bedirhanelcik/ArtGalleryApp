using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class AddArtworkControl : UserControl
    {
        private string selectedImagePath = "";

        string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=ArtGalleryDB;Trusted_Connection=True;Encrypt=False;";

        public AddArtworkControl()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 233, 207);
            this.Load += AddArtworkControl_Load;
        }

        private void AddArtworkControl_Load(object sender, EventArgs e)
        {
            if (FindForm() is Form1 f)
                txtUserName.Text = f.CurrentUserName;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog1.FileName;

                if (pictureArtwork.Image != null)
                {
                    pictureArtwork.Image.Dispose();
                    pictureArtwork.Image = null;
                }

                pictureArtwork.Image = Image.FromFile(selectedImagePath);
                lblUploadHint.Visible = false;
            }
        }

        private void btnSaveArtwork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArtworkName.Text))
            {
                MessageBox.Show("Artwork adı zorunludur.");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedImagePath))
            {
                MessageBox.Show("Lütfen bir resim seçin.");
                return;
            }

            string userName = txtUserName.Text;

            string folderPath = Path.Combine(Application.StartupPath, "UserArtworks");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string newFileName =
                $"{userName}_{Guid.NewGuid()}{Path.GetExtension(selectedImagePath)}";

            string destPath = Path.Combine(folderPath, newFileName);
            File.Copy(selectedImagePath, destPath, true);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Artworks
                    (UserName, ArtworkName, ArtworkOwner, ImagePath, CreatedDate)
                    OUTPUT INSERTED.ArtworkID
                    VALUES (@u,@n,@o,@i,GETDATE())", con);

                cmd.Parameters.AddWithValue("@u", userName);
                cmd.Parameters.AddWithValue("@n", txtArtworkName.Text.Trim());
                cmd.Parameters.AddWithValue("@o",
                    string.IsNullOrWhiteSpace(txtArtworkOwner.Text)
                        ? (object)DBNull.Value
                        : txtArtworkOwner.Text.Trim());
                cmd.Parameters.AddWithValue("@i", destPath);

                int newArtworkId = (int)cmd.ExecuteScalar();

                SqlCommand logCmd = new SqlCommand(@"
                    INSERT INTO UserActivity (UserName, Action, ArtworkID)
                    VALUES (@u, @a, @id)", con);

                logCmd.Parameters.AddWithValue("@u", userName);
                logCmd.Parameters.AddWithValue("@a", "Added Artwork");
                logCmd.Parameters.AddWithValue("@id", newArtworkId);

                logCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Artwork başarıyla kaydedildi ✅");

            txtArtworkName.Clear();
            txtArtworkOwner.Clear();
            pictureArtwork.Image = null;
            lblUploadHint.Visible = true;
            selectedImagePath = "";
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
