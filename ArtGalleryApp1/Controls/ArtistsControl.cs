using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ArtGalleryApp1
{
    public partial class ArtistsControl : UserControl
    {
        Panel textPanel;

        PrivateFontCollection fontCollection;
        Font artistFont;

        Dictionary<Label, float> underlineAnim = new Dictionary<Label, float>();
        Dictionary<Label, Image> labelImages = new Dictionary<Label, Image>();

        Timer animTimer;
        Label activeLabel;

        Image currentBg;
        Image nextBg;
        float bgBlend = 1f;

        public ArtistsControl()
        {
            InitializeComponent();

            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;

            LoadFont();
            SetupTextPanel();
            SetupArtists();
            SetupInitialBackground();
            SetupAnimation();
        }

        // ================= FONT =================
        void LoadFont()
        {
            fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "fonts",
                    "Syne-Bold.ttf"
                )
            );

            artistFont = new Font(
                fontCollection.Families[0],
                18f,
                FontStyle.Regular
            );
        }

        // ================= TEXT PANEL =================
        void SetupTextPanel()
        {
            textPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            Controls.Add(textPanel);
            textPanel.BringToFront();
        }

        // ================= ARTISTS =================
        void SetupArtists()
        {
            var artists = new (string name, Image img)[]
            {
                ("Vincent van Gogh", Properties.Resources.cafe1),
                ("Leonardo da Vinci", Properties.Resources.mona11),
                ("Pablo Picasso", Properties.Resources.guernica1),
                ("Salvador Dalí", Properties.Resources.persistence1),
                ("Edvard Munch", Properties.Resources.mona11),
                ("Johannes Vermeer", Properties.Resources.pearl1),
                ("Rembrandt", Properties.Resources.nightwatch1),
                ("Gustav Klimt", Properties.Resources.kiss1),
                ("Grant Wood", Properties.Resources.gothic1),
                ("Sandro Botticelli", Properties.Resources.librty1),
                ("Diego Velázquez", Properties.Resources.lasmeninas1),
                ("Eugène Delacroix", Properties.Resources.liberty1),
                ("James McNeill Whistler", Properties.Resources.sess)
            };

            int startX = 90;
            int startY = 160;
            int colGap = 420;
            int rowGap = 46;

            for (int i = 0; i < artists.Length; i++)
            {
                int col = i % 2;
                int row = i / 2;

                Label lbl = new Label
                {
                    Text = artists[i].name,
                    Font = artistFont,
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand,
                    AutoSize = false,
                    Size = new Size(420, 36),
                    Location = new Point(
                        startX + col * colGap,
                        startY + row * rowGap
                    )
                };

                underlineAnim[lbl] = 0f;
                labelImages[lbl] = artists[i].img;

                lbl.MouseEnter += (s, e) =>
                {
                    activeLabel = lbl;
                    nextBg = labelImages[lbl];
                    bgBlend = 0f;
                };

                lbl.MouseLeave += (s, e) =>
                {
                    activeLabel = null;
                };

                lbl.Paint += DrawUnderline;
                textPanel.Controls.Add(lbl);
            }
        }

        // ================= INITIAL BG =================
        void SetupInitialBackground()
        {
            if (labelImages.Count > 0)
                currentBg = new List<Image>(labelImages.Values)[0];
        }

        // ================= ANIMATION =================
        void SetupAnimation()
        {
            animTimer = new Timer { Interval = 16 };
            animTimer.Tick += (s, e) =>
            {
                foreach (var lbl in new List<Label>(underlineAnim.Keys))
                {
                    float target = (lbl == activeLabel) ? 1f : 0f;
                    // ALT ÇİZGİ HIZI ARTIRILDI
                    underlineAnim[lbl] += (target - underlineAnim[lbl]) * 0.6f; // eskisi 0.35f
                    lbl.Invalidate();
                }

                if (nextBg != null && bgBlend < 1f)
                {
                    // ARKA PLAN FADE HIZI ARTIRILDI
                    bgBlend += 6.92f; // eskisi 0.06f
                    if (bgBlend >= 1f)
                    {
                        bgBlend = 1f;
                        currentBg = nextBg;
                        nextBg = null;
                    }
                    Invalidate();
                }
            };
            animTimer.Start();
        }

        // ================= DRAW UNDERLINE =================
        void DrawUnderline(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            float p = underlineAnim[lbl];
            if (p <= 0.01f) return;

            int textWidth = TextRenderer.MeasureText(lbl.Text, lbl.Font).Width;
            int y = lbl.Height - 4;
            int w = (int)(textWidth * p);

            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(pen, 0, y, w, y);
            }
        }

        // ================= BACKGROUND FADE =================
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (currentBg == null && nextBg == null)
            {
                base.OnPaintBackground(e);
                return;
            }

            e.Graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            if (currentBg != null)
                e.Graphics.DrawImage(currentBg, ClientRectangle);

            if (nextBg != null)
            {
                using (ImageAttributes ia = new ImageAttributes())
                {
                    ColorMatrix cm = new ColorMatrix();
                    cm.Matrix33 = bgBlend;
                    ia.SetColorMatrix(cm);

                    e.Graphics.DrawImage(
                        nextBg,
                        ClientRectangle,
                        0, 0, nextBg.Width, nextBg.Height,
                        GraphicsUnit.Pixel,
                        ia
                    );
                }
            }
        }
    }
}
