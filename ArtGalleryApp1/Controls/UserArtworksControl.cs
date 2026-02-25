using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class UserArtworksControl : UserControl
    {
        string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=ArtGalleryDB;Trusted_Connection=True;Encrypt=False;";

        string currentUser = "";

        public UserArtworksControl()
        {
            InitializeComponent();
            Load += UserArtworksControl_Load;
            BackColor = Color.FromArgb(235, 233, 207); // galeri tonu
        }

        private void UserArtworksControl_Load(object sender, EventArgs e)
        {
            if (FindForm() is Form1 f)
                currentUser = f.CurrentUserName;

            LoadArtworks();
        }

        // ================= LOAD ARTWORKS (3 COLUMN – CENTERED) =================
        private void LoadArtworks()
        {
            panelScrol.Controls.Clear();
            panelScrol.AutoScroll = true;

            int columns = 3;

            int itemWidth = 300;   // 🔥 biraz büyüdü
            int itemHeight = 400;
            int gap = 40;          // 🔥 boşluk arttı

            int totalWidth = (itemWidth * columns) + (gap * (columns - 1));
            int startX = (panelScrol.Width - totalWidth) / 2;
            if (startX < 20) startX = 20; // güvenlik

            int x = startX;
            int y = 30;
            int col = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT ArtworkID, UserName, ArtworkName, ArtworkOwner, ImagePath
                    FROM Artworks
                    ORDER BY CreatedDate DESC", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int artworkId = (int)dr["ArtworkID"];
                        string ownerUser = dr["UserName"].ToString();
                        string artworkName = dr["ArtworkName"].ToString();
                        string artworkOwner = dr["ArtworkOwner"].ToString();
                        string imagePath = dr["ImagePath"].ToString();

                        Panel item = new Panel
                        {
                            Size = new Size(itemWidth, itemHeight),
                            Location = new Point(x, y),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // 🔥 HAFİF HOVER
                        item.MouseEnter += (s, e) =>
                            item.BackColor = Color.FromArgb(248, 248, 248);
                        item.MouseLeave += (s, e) =>
                            item.BackColor = Color.White;

                        PictureBox pic = new PictureBox
                        {
                            Height = 230,
                            Dock = DockStyle.Top,
                            SizeMode = PictureBoxSizeMode.Zoom
                        };

                        if (File.Exists(imagePath))
                        {
                            byte[] bytes = File.ReadAllBytes(imagePath);
                            using (MemoryStream ms = new MemoryStream(bytes))
                                pic.Image = Image.FromStream(ms);
                        }

                        Label lblName = new Label
                        {
                            Text = artworkName,
                            Dock = DockStyle.Top,
                            Height = 36,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 11, FontStyle.Bold)
                        };

                        Label lblOwner = new Label
                        {
                            Text = artworkOwner,
                            Dock = DockStyle.Top,
                            Height = 28,
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = Color.DimGray
                        };

                        item.Controls.Add(lblOwner);
                        item.Controls.Add(lblName);
                        item.Controls.Add(pic);

                        // 🔒 SADECE KENDİ ESERİ
                        if (ownerUser == currentUser)
                        {
                            Button btnUpdate = CreateTextButton("Update");
                            btnUpdate.Click += (s, e) =>
                            {
                                EditArtworkForm editForm = new EditArtworkForm(
                                    artworkId,
                                    artworkName,
                                    artworkOwner,
                                    imagePath,
                                    connectionString
                                );

                                if (editForm.ShowDialog() == DialogResult.OK)
                                    LoadArtworks();
                            };

                            Button btnDelete = CreateTextButton("Delete");
                            btnDelete.ForeColor = Color.DarkRed;
                            btnDelete.Click += (s, e) =>
                            {
                                DeleteArtwork(artworkId, imagePath);
                                LoadArtworks();
                            };

                            item.Controls.Add(btnDelete);
                            item.Controls.Add(btnUpdate);
                        }

                        panelScrol.Controls.Add(item);

                        // ===== GRID =====
                        col++;

                        if (col == columns)
                        {
                            col = 0;
                            x = startX;
                            y += itemHeight + gap;
                        }
                        else
                        {
                            x += itemWidth + gap;
                        }
                    }
                }
            }
        }

        // ================= DELETE =================
        private void DeleteArtwork(int id, string imagePath)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM Artworks WHERE ArtworkID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }

        // ================= BUTTON STYLE =================
        private Button CreateTextButton(string text)
        {
            Button b = new Button
            {
                Text = text,
                Dock = DockStyle.Bottom,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Goldenrod,
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}
