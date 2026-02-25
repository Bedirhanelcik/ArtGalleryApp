using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class EditArtworkForm : Form

    {
        private readonly int artworkId;
        private readonly string connectionString;
        private string imagePath;

        public EditArtworkForm(
            int id,
            string currentName,
            string currentArtist,
            string currentImagePath,
            string connStr)
        {
            InitializeComponent();

            artworkId = id;
            connectionString = connStr;
            imagePath = currentImagePath;

            txtArtworkName.Text = currentName;
            txtArtistName.Text = currentArtist;

            if (File.Exists(imagePath))
            {
                pictureArtwork.Image = Image.FromFile(imagePath);
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select new artwork image"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;

                if (pictureArtwork.Image != null)
                {
                    pictureArtwork.Image.Dispose();
                    pictureArtwork.Image = null;
                }

                pictureArtwork.Image = Image.FromFile(imagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArtworkName.Text))
            {
                MessageBox.Show("Artwork name is required.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Artworks
                    SET ArtworkName=@n,
                        ArtworkOwner=@o,
                        ImagePath=@i
                    WHERE ArtworkID=@id", con);

                cmd.Parameters.AddWithValue("@n", txtArtworkName.Text.Trim());
                cmd.Parameters.AddWithValue("@o", txtArtistName.Text.Trim());
                cmd.Parameters.AddWithValue("@i", imagePath);
                cmd.Parameters.AddWithValue("@id", artworkId);

                cmd.ExecuteNonQuery();
                SqlCommand logCmd = new SqlCommand(@"
    INSERT INTO UserActivity (UserName, Action, ArtworkID)
    VALUES (@u, @a, @id)", con);

                logCmd.Parameters.AddWithValue("@u", "SYSTEM");
                logCmd.Parameters.AddWithValue("@a", "Edited Artwork");
                logCmd.Parameters.AddWithValue("@id", artworkId);

                logCmd.ExecuteNonQuery();

            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
