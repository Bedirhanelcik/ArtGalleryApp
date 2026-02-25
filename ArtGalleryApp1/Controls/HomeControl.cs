using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class HomeControl : UserControl
    {
        PrivateFontCollection fonts = new PrivateFontCollection();

        Button btnAddArtwork;
        Timer hoverTimer = new Timer();
        float hoverProgress = 0f;
        bool hoverIn = false;

        public HomeControl()
        {
            InitializeComponent();

            // BACKGROUND
            string gifPath = Path.Combine(Application.StartupPath, "Images", "home.gif");
            if (File.Exists(gifPath))
            {
                pictureBoxBg.Image = Image.FromFile(gifPath);
                pictureBoxBg.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            labelSlogan.Parent =
            labelTitle.Parent =
            labelSub.Parent = pictureBoxBg;

            labelSlogan.BackColor =
            labelTitle.BackColor =
            labelSub.BackColor = Color.Transparent;

            LoadFont();

            labelSlogan.Font = new Font(fonts.Families[0], 14, FontStyle.Bold);
            labelTitle.Font = new Font(fonts.Families[0], 38, FontStyle.Bold);
            labelSub.Font = new Font(fonts.Families[0], 26, FontStyle.Bold);

            labelSlogan.ForeColor =
            labelTitle.ForeColor =
            labelSub.ForeColor = Color.FromArgb(235, 233, 207);

            labelSlogan.Text = "MODERN DIGITAL MUSEUMS";
            labelTitle.Text = "The Professional";
            labelSub.Text = "Art Painting";

            pictureBoxBg.Resize += (s, e) => CenterAll();

            CreateButton();
            CenterAll();
        }

        void LoadFont()
        {
            fonts.AddFontFile(Path.Combine(Application.StartupPath, "Fonts", "Syne-Bold.ttf"));
        }

        void CenterAll()
        {
            int cx = pictureBoxBg.Width / 2;
            int cy = pictureBoxBg.Height / 2;

            labelSlogan.Location = new Point(cx - labelSlogan.Width / 2, cy - 70);
            labelTitle.Location = new Point(cx - labelTitle.Width / 2, cy - 45);
            labelSub.Location = new Point(cx - labelSub.Width / 2, cy + 18);

            btnAddArtwork.Location = new Point(
                cx - btnAddArtwork.Width / 2,
                labelSub.Bottom + 18
            );
        }

        void CreateButton()
        {
            btnAddArtwork = new Button
            {
                Cursor = Cursors.Hand,
                Text = "ADD ARTWORK",
                Size = new Size(126, 38),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.FromArgb(235, 233, 207)
            };

            btnAddArtwork.FlatAppearance.BorderSize = 0;
            btnAddArtwork.Parent = pictureBoxBg;

            PrivateFontCollection bau = new PrivateFontCollection();
            bau.AddFontFile(Path.Combine(Application.StartupPath, "Fonts", "Inter-VariableFont_opsz,wght.ttf"));
            btnAddArtwork.Font = new Font(bau.Families[0], 9.5f);

            btnAddArtwork.Paint += Button_Paint;

            hoverTimer.Interval = 3;
            hoverTimer.Tick += HoverTimer_Tick;

            btnAddArtwork.MouseEnter += (s, e) => { hoverIn = true; hoverTimer.Start(); };
            btnAddArtwork.MouseLeave += (s, e) => { hoverIn = false; hoverTimer.Start(); };

            btnAddArtwork.Click += BtnAddArtwork_Click;

            pictureBoxBg.Controls.Add(btnAddArtwork);
            btnAddArtwork.BringToFront();
        }

        void HoverTimer_Tick(object sender, EventArgs e)
        {
            float speed = 0.15f;
            hoverProgress = hoverIn
                ? Math.Min(1f, hoverProgress + speed)
                : Math.Max(0f, hoverProgress - speed);

            btnAddArtwork.Invalidate();

            if (hoverProgress == 0f || hoverProgress == 1f)
                hoverTimer.Stop();
        }

        void Button_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = btnAddArtwork.ClientRectangle;

            using (SolidBrush baseBrush = new SolidBrush(Color.FromArgb(235, 233, 207)))
                e.Graphics.FillRectangle(baseBrush, r);

            int hoverWidth = (int)(r.Width * hoverProgress);
            if (hoverWidth > 0)
                e.Graphics.FillRectangle(Brushes.Goldenrod, 0, 0, hoverWidth, r.Height);

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            TextRenderer.DrawText(
                e.Graphics,
                btnAddArtwork.Text,
                btnAddArtwork.Font,
                r,
                btnAddArtwork.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void BtnAddArtwork_Click(object sender, EventArgs e)
        {
            if (FindForm() is Form1 f)
                f.GoToAddArtwork();
        }

        // 🔧 DESIGNER İÇİN ZORUNLU
        private void pictureBoxBg_Click(object sender, EventArgs e) { }
    }
}
