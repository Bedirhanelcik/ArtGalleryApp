using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class AboutControl : UserControl
    {
        PictureBox bg;
        Panel overlay, centerPanel;
        Label lblTitle, lblText, lblFooter, lblNext;

        PrivateFontCollection fonts;
        Font titleFont, textFont, footerFont;
        Image bgImage;

        int index = 0;

        string[] titles =
        {
            "About Art Gallery App",
            "Art & Meaning",
            "Art & Emotion"
        };

        string[] texts =
        {
            "Art Gallery App is a digital space created to explore timeless artworks, artists, and artistic meaning.",
            "“Art enables us to find ourselves and lose ourselves at the same time.”\n— Thomas Merton",
            "“Every artist dips his brush in his own soul and paints his own nature into his pictures.”\n— Henry Ward Beecher"
        };

        public AboutControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            Load += AboutControl_Load;
        }

        private void AboutControl_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            Controls.Clear();
            BuildUI();
            LoadAssets();
            ApplyAssets();

            ResumeLayout();
        }

        // ================= UI =================
        void BuildUI()
        {
            bg = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Black
            };
            Controls.Add(bg);

            overlay = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(120, 0, 0, 0)
            };
            bg.Controls.Add(overlay);

            centerPanel = new Panel
            {
                Size = new Size(760, 360),
                BackColor = Color.Transparent
            };
            overlay.Controls.Add(centerPanel);

            lblTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 70,
                TextAlign = ContentAlignment.BottomCenter,
                ForeColor = Color.White
            };

            lblText = new Label
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(60, 25, 60, 25),
                TextAlign = ContentAlignment.TopCenter,
                ForeColor = Color.Gainsboro
            };

            lblFooter = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.LightGray,
                Text = "Art Gallery App"
            };

            centerPanel.Controls.Add(lblText);
            centerPanel.Controls.Add(lblTitle);
            centerPanel.Controls.Add(lblFooter);

            lblNext = new Label
            {
                Text = "→",
                Width = 50,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Right   // 🔥 KRİTİK
            };

            lblNext.Click += (s, e) =>
            {
                index = (index + 1) % titles.Length;
                UpdateContent();
            };

            overlay.Controls.Add(lblNext);
            overlay.Resize += (s, e) =>
            {
                CenterPanel();
                PositionNext();
            };

            CenterPanel();
            PositionNext();
        }

        // ================= ASSETS =================
        void LoadAssets()
        {
            fonts = new PrivateFontCollection();

            string fontDir = Path.Combine(Application.StartupPath, "Fonts");
            fonts.AddFontFile(Path.Combine(fontDir, "Syne-Bold.ttf"));
            fonts.AddFontFile(Path.Combine(fontDir, "Montaga-Regular.ttf"));

            titleFont  = new Font(fonts.Families[0], 22, FontStyle.Bold);
            textFont   = new Font(fonts.Families[1], 15);
            footerFont = new Font(fonts.Families[1], 12);

            string imgPath = Path.Combine(Application.StartupPath, "Images", "About", "arkp.jpg");
            bgImage = Image.FromFile(imgPath);
        }

        // ================= APPLY =================
        void ApplyAssets()
        {
            bg.Image = bgImage;

            lblTitle.Font  = titleFont;
            lblText.Font   = textFont;
            lblFooter.Font = footerFont;
            lblNext.Font   = titleFont;

            UpdateContent();
            PositionNext();
        }

        void UpdateContent()
        {
            lblTitle.Text = titles[index];
            lblText.Text  = texts[index];
        }

        void CenterPanel()
        {
            centerPanel.Left = (overlay.Width - centerPanel.Width) / 2;
            centerPanel.Top  = (overlay.Height - centerPanel.Height) / 2;
        }

        // 🔥 OK TUŞUNUN GERÇEK KONUMU
        void PositionNext()
        {
            lblNext.Left = overlay.Width - lblNext.Width - 20;
            lblNext.Top  = (overlay.Height - lblNext.Height) / 2;
        }
    }
}
