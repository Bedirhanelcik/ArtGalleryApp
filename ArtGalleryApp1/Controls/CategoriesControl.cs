using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class CategoriesControl : UserControl
    {
        PrivateFontCollection fonts = new PrivateFontCollection();

        Font titleFont;
        Font textFont;
        Font arrowFont;

        const int CARD_WIDTH = 287;
        const int CARD_HEIGHT = 540;
        const int CARD_GAP = 34;

        const int IMAGE_WIDTH = 270;
        const int IMAGE_HEIGHT = 190;

        public CategoriesControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(235, 233, 207);

            Load += CategoriesControl_Load;
            Resize += (s, e) => BuildUI();
        }

        private void CategoriesControl_Load(object sender, EventArgs e)
        {
            LoadFonts();
            BuildUI();
        }

        void LoadFonts()
        {
            try
            {
                string fontPath = Path.Combine(Application.StartupPath, "Fonts", "Syne-Medium.ttf");
                fonts.AddFontFile(fontPath);

                FontFamily family = fonts.Families[0];

                // 🔹 Başlık: biraz daha ince
                titleFont = new Font(family, 19, FontStyle.Regular);

                // 🔹 Alt yazılar: az kalın hissi
                textFont = new Font(family, 13, FontStyle.Regular);

                arrowFont = new Font(family, 17, FontStyle.Bold);
            }
            catch
            {
                titleFont = new Font("Segoe UI", 19, FontStyle.Regular);
                textFont  = new Font("Segoe UI", 13, FontStyle.Regular);
                arrowFont = new Font("Segoe UI", 17, FontStyle.Bold);
            }
        }

        void BuildUI()
        {
            Controls.Clear();

            Panel container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = BackColor
            };
            Controls.Add(container);

            int totalWidth = (CARD_WIDTH * 3) + (CARD_GAP * 2);
            int startX = (Width - totalWidth) / 2;
            int y = 35;

            container.Controls.Add(CreateCard(
                "Old Masters",
                "oldmasters.jpg",
                new[] { "Workshop featured paintings", "European history art classes", "Timeless masterpieces" },
                startX, y));

            container.Controls.Add(CreateCard(
                "Modern Art",
                "modernart.jpg",
                new[] { "Bold experimental works", "Iconic modern artists", "Creative freedom" },
                startX + CARD_WIDTH + CARD_GAP, y));

            container.Controls.Add(CreateCard(
                "Turkish Art",
                "turkishart.jpg",
                new[] { "Traditional & modern blend", "Cultural heritage", "Local master artists" },
                startX + (CARD_WIDTH + CARD_GAP) * 2, y));
        }

        Panel CreateCard(string title, string imageName, string[] items, int x, int y)
        {
            Panel card = new Panel
            {
                Width = CARD_WIDTH,
                Height = CARD_HEIGHT,
                Location = new Point(x, y),
                BackColor = Color.Transparent
            };

            // HEADER
            Panel header = new Panel { Dock = DockStyle.Top, Height = 42 };

            Label lblTitle = new Label
            {
                Text = title,
                Font = titleFont,
                ForeColor = Color.FromArgb(51, 51, 51),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblArrow = new Label
            {
                Text = "↗",
                Font = arrowFont,
                ForeColor = Color.FromArgb(51, 51, 51),
                Dock = DockStyle.Right,
                Width = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            // 🔥 GOLD HOVER
            lblArrow.MouseEnter += (s, e) => lblArrow.ForeColor = Color.Gold;
            lblArrow.MouseLeave += (s, e) => lblArrow.ForeColor = Color.FromArgb(51, 51, 51);

            lblArrow.Click += (s, e) =>
            {
                if (FindForm() is Form1 f)
                {
                    if (title == "Old Masters") f.LoadPage(new ArtworksControl());
                    if (title == "Modern Art") f.LoadPage(new ModernArtControl());
                    if (title == "Turkish Art") f.LoadPage(new TurkishArtControl());
                }
            };

            header.Controls.Add(lblTitle);
            header.Controls.Add(lblArrow);

            Panel thickLine = new Panel
            {
                Dock = DockStyle.Top,
                Height = 2,
                BackColor = Color.FromArgb(130, 130, 130)
            };

            // IMAGE
            Panel imageHolder = new Panel { Dock = DockStyle.Top, Height = IMAGE_HEIGHT + 30 };

            PictureBox pic = new PictureBox
            {
                Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT),
                Location = new Point((CARD_WIDTH - IMAGE_WIDTH) / 2, 15),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            string imgPath = Path.Combine(Application.StartupPath, "Images", "Categories", imageName);
            if (File.Exists(imgPath)) pic.Image = Image.FromFile(imgPath);

            imageHolder.Controls.Add(pic);

            // TEXTS
            Panel textPanel = new Panel { Dock = DockStyle.Fill };

            for (int i = items.Length - 1; i >= 0; i--)
            {
                textPanel.Controls.Add(new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 1,
                    BackColor = Color.FromArgb(190, 190, 190)
                });

                textPanel.Controls.Add(new Label
                {
                    Text = items[i],
                    Font = textFont,
                    ForeColor = Color.FromArgb(51, 51, 51),
                    Dock = DockStyle.Top,
                    Height = 38,
                    TextAlign = ContentAlignment.MiddleLeft
                });
            }

            card.Controls.Add(textPanel);
            card.Controls.Add(imageHolder);
            card.Controls.Add(thickLine);
            card.Controls.Add(header);

            return card;
        }
    }
}
