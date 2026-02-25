using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class ArtworksControl : UserControl
    {
        Timer openAnimTimer = new Timer();
        int animStep = 0;
        int animTotal = 20;

        // 🔥 HOVER TOOLTIP SİSTEMİ
        Timer hoverTimer = new Timer();
        Panel hoverPanel;
        Label hoverLabel;
        Label activeLabel;

        string[] titles =
        {
            "Starry Night","Mona Lisa","Guernica","The Persistence of Memory","The Scream",
            "Girl with a Pearl Earring","The Night Watch","The Kiss","American Gothic",
            "The Birth of Venus","Las Meninas","The Last Supper","Liberty Leading the People",
            "Whistler’s Mother","Cafe Terrace at Night"
        };

        string[] artists =
        {
            "Vincent van Gogh","Leonardo da Vinci","Pablo Picasso","Salvador Dalí","Edvard Munch",
            "Johannes Vermeer","Rembrandt","Gustav Klimt","Grant Wood","Sandro Botticelli",
            "Diego Velázquez","Leonardo da Vinci","Eugène Delacroix",
            "James McNeill Whistler","Vincent van Gogh"
        };

        string[] years =
        {
            "1889","1503","1937","1931","1893","1665","1642","1908",
            "1930","1486","1656","1498","1830","1871","1888"
        };

        string[] descriptions =
   {
    "A night sky alive with emotioan.",
    "The most iconic portrait in art history.",
    "A dramatic and symbolic masterpiece that reveals the devastating horrors of war.",
    "A surreal exploration of time, showing how reality and perception can melt away.",
    "A haunting expression of human anxiety, fear, and inner emotional conflict.",
    "A simple yet deeply mysterious portrait that captures quiet elegance and intimacy.",
    "A monumental Baroque masterpiece known for its dramatic light, movement, and realism.",
    "A passionate celebration of love, intimacy, and luxury through gold and ornament.",
    "A striking depiction of traditional American rural life and cultural identity.",
    "An idealized vision of beauty and harmony inspired by the spirit of the Renaissance.",
    "A complex scene portraying royal life, perspective, and the role of the artist.",
    "One of the most influential religious artworks, symbolizing faith and sacrifice.",
    "A powerful image of revolution, freedom, and the fight for human rights.",
    "A calm and emotional portrait symbolizing motherhood, dignity, and simplicity.",
    "A vivid night view capturing the warm lights and atmosphere of Paris after dark."
};


        string[] images =
        {
            @"Images\Artworks\stary.jpg",@"Images\Artworks\mona.jpg",@"Images\Artworks\guernica.jpg",
            @"Images\Artworks\persistence.jpg",@"Images\Artworks\scream.jpg",
            @"Images\Artworks\pearl.jpg",@"Images\Artworks\nightwatch.jpg",
            @"Images\Artworks\kiss.jpg",@"Images\Artworks\gothic.jpg",
            @"Images\Artworks\venus.jpg",@"Images\Artworks\lasmeninas.jpg",
            @"Images\Artworks\lastsuper.jpg",@"Images\Artworks\liberty.jpg",
            @"Images\Artworks\whistler.jpg",@"Images\Artworks\cafe.jpg"
        };

        public ArtworksControl()
        {
            InitializeComponent();
            this.Load += ArtworksControl_Load;
        }

        private void ArtworksControl_Load(object sender, EventArgs e)
        {
            panelScroll.AutoScroll = true;
            panelScroll.Padding = new Padding(0, 0, 0, 1500);
            panelScroll.Controls.Clear();

            // 🔥 HOVER PANEL OLUŞTUR
            hoverPanel = new Panel
            {
                Size = new Size(300, 120),
                BackColor = Color.FromArgb(35, 35, 35),
                Visible = false
            };

            hoverLabel = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(12)
            };

            hoverPanel.Controls.Add(hoverLabel);
            this.Controls.Add(hoverPanel);
            hoverPanel.BringToFront();

            hoverTimer.Interval = 0150;
            hoverTimer.Tick += HoverTimer_Tick;

            for (int i = 0; i < titles.Length; i++)
            {
                panelScroll.Controls.Add(
                    CreateArtworkItem(titles[i], artists[i], years[i], images[i], descriptions[i])
                );
            }

            StartOpenAnimation();
        }

        private void StartOpenAnimation()
        {
            animStep = 0;
            openAnimTimer.Interval = 15;
            openAnimTimer.Tick += (s, e) =>
            {
                animStep++;
                panelScroll.Top = 30 - (int)(Math.Sin((double)animStep / animTotal * Math.PI / 2) * 30);
                if (animStep >= animTotal) openAnimTimer.Stop();
            };
            openAnimTimer.Start();
        }

        private Panel CreateArtworkItem(string title, string artist, string year, string imagePath, string desc)
        {
            Panel item = new Panel
            {
                Height = 220,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            PictureBox pic = new PictureBox
            {
                Size = new Size(160, 200),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            string fullPath = Path.Combine(Application.StartupPath, imagePath);
            if (File.Exists(fullPath))
                pic.Image = Image.FromFile(fullPath);

            Label lblTitle = new Label
            {
                Text = title,
                Location = new Point(180, 35),
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };

            Label lblArtist = new Label
            {
                Text = artist,
                Location = new Point(180, 70),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.LightGray,
                AutoSize = true
            };

            Label lblRead = new Label
            {
                Text = "Read more",
                Location = new Point(180, 110),
                ForeColor = Color.Goldenrod,
                Cursor = Cursors.Hand,
                AutoSize = true
            };

            // 🔥 HOVER LOGIC
            lblRead.MouseEnter += (s, e) =>
            {
                lblRead.Font = new Font(lblRead.Font, FontStyle.Underline);
                lblRead.ForeColor = Color.Khaki;

                activeLabel = lblRead;
                hoverLabel.Text = $"{title}\n{artist} ({year})\n\n{desc}";

                Point pos = lblRead.PointToScreen(new Point(0, lblRead.Height + 6));
                pos = this.PointToClient(pos);
                hoverPanel.Location = pos;

                hoverTimer.Start();
            };

            lblRead.MouseLeave += (s, e) =>
            {
                lblRead.Font = new Font(lblRead.Font, FontStyle.Regular);
                lblRead.ForeColor = Color.Goldenrod;

                hoverTimer.Stop();
                hoverPanel.Visible = false;
            };

            item.Controls.Add(pic);
            item.Controls.Add(lblTitle);
            item.Controls.Add(lblArtist);
            item.Controls.Add(lblRead);

            return item;
        }

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            hoverTimer.Stop();
            hoverPanel.Visible = true;
        }
    }
}
