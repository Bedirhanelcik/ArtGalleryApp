using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class ModernArtControl : UserControl
    {
        FlowLayoutPanel flow;
        Timer animTimer;

        PrivateFontCollection troover = new PrivateFontCollection();
        PrivateFontCollection baupro = new PrivateFontCollection();

        Font titleFont;
        Font dateFont;

        const int WM_MOUSEWHEEL = 0x020A;

        class AnimState
        {
            public float Progress = 0f;
            public int StartOffset = 40;
            public bool Done = false;
        }

        public ModernArtControl()
        {
            InitializeComponent(); // ⚠️ ÇOK ÖNEMLİ
            BackColor = Color.White;
            AutoScaleMode = AutoScaleMode.None;

            LoadFonts();
            CreateLayout();
            CreateGallery();
            SetupAnimation();
        }

        void LoadFonts()
        {
            troover.AddFontFile(Application.StartupPath + @"\Fonts\Trooverc.otf");
            baupro.AddFontFile(Application.StartupPath + @"\Fonts\BauPro-Medium.ttf");

            titleFont = new Font(troover.Families[0], 16f);
            dateFont = new Font(baupro.Families[0], 10f);
        }

        void CreateLayout()
        {
            flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.White,
                Padding = new Padding(30, 30, 20, 30)
            };

            flow.HorizontalScroll.Visible = false;
            Controls.Add(flow);
        }

        // ⬇️ daha yavaş / ⬆️ biraz daha hızlı scroll
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL && flow != null)
            {
                int delta = (short)((m.WParam.ToInt32() >> 16) & 0xffff);
                int speed = delta < 0 ? 30 : 15;

                int newValue = flow.VerticalScroll.Value - (delta / speed);
                newValue = Math.Max(flow.VerticalScroll.Minimum,
                           Math.Min(flow.VerticalScroll.Maximum, newValue));

                flow.VerticalScroll.Value = newValue;
                return;
            }
            base.WndProc(ref m);
        }

        void CreateGallery()
        {
            int itemWidth = 340;
            int imageHeight = 240;

            var data = new (string img, string line1, string line2, string date)[]
            {
                ("a1","Art Basel Miami Beach","Booth H32","December 3 - 7, 2025"),
                ("a2","Frieze London 2025","—","October 15 - 19, 2025"),
                ("a3","The Armory Show 2025","Anne Buckwalter, Sheree Hovsepian, Arghavan Khosravi, Talia Levitt, Sarah Martin-Nuss","September 4 - 7, 2025"),
                ("a4","Art Basel Miami Beach","—","December 4 - 8, 2024"),
                ("a5","NADA NY","Arghavan Khosravi, Bernadette Despujols, Hilary Harnischfeger, Sacha Ingber, Talia Levitt","May 2 - 5, 2024"),
                ("a6","Frieze Los Angeles","Sheree Hovsepian, Erica Mao, Curtis Talwst Santiago","February 29 - March 3, 2024"),
                ("a7","Felix Los Angeles","a selection of gallery artists","February 28 - March 3, 2024"),
                ("a8","NADA New York","Sacha Ingber, Talia Levitt, Joshua Petker","May 18 - 21, 2023"),
                ("a9","Art Basel Miami Beach","Bernadette Despujols, Sheree Hovsepian, Curtis Talwst Santiago","November 29 - December 3, 2022"),
                ("a10","Kiaf Seoul","Bianca Beck, Strauss Bourque-LaFrance, Anne Buckwalter, Erica Mao","September 2 - 6, 2022"),
                ("a11","Frieze London","Arghavan Khosravi, Hilary Pecis, Maryam Hoseini, Hana Yilma Godine, Roger White","October 13 - 17, 2021"),
                ("a12","FIAC","Sheree Hovsepian, Curtis Talwst Santiago","October 20 - 24, 2021")
            };

            for (int i = 0; i < data.Length; i++)
            {
                bool rightItem = i % 2 == 1;

                Panel item = new Panel
                {
                    Size = new Size(itemWidth, imageHeight + 130),
                    Margin = rightItem
                        ? new Padding(160, 10, 10, 40)
                        : new Padding(10, 10, 10, 40),
                    BackColor = Color.White,
                    Tag = new AnimState(),
                    Padding = new Padding(0, 40, 0, 0)
                };

                item.Controls.Add(new PictureBox
                {
                    Size = new Size(itemWidth, imageHeight),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = (Image)Properties.Resources.ResourceManager.GetObject(data[i].img)
                });

                item.Controls.Add(MakeLabel(data[i].line1, titleFont, Color.Black, imageHeight + 8));
                item.Controls.Add(MakeLabel(data[i].line2, titleFont, Color.FromArgb(120, 120, 120), imageHeight + 36));
                item.Controls.Add(MakeLabel(data[i].date, dateFont, Color.FromArgb(160, 160, 160), imageHeight + 70));

                flow.Controls.Add(item);
            }
        }

        void SetupAnimation()
        {
            animTimer = new Timer { Interval = 16 };
            animTimer.Tick += (s, e) =>
            {
                foreach (Panel item in flow.Controls)
                {
                    AnimState st = item.Tag as AnimState;
                    if (st.Done) continue;

                    Rectangle r = flow.RectangleToClient(item.RectangleToScreen(item.ClientRectangle));

                    if (r.Top < flow.ClientRectangle.Bottom - 80)
                    {
                        st.Progress += 0.12f;
                        if (st.Progress >= 1f)
                        {
                            st.Progress = 1f;
                            st.Done = true;
                        }

                        int y = (int)(st.StartOffset * (1f - st.Progress));
                        item.Padding = new Padding(0, y, 0, 0);
                    }
                }
            };
            animTimer.Start();
        }

        Label MakeLabel(string text, Font font, Color color, int top)
        {
            return new Label
            {
                Text = text,
                Font = font,
                ForeColor = color,
                Top = top,
                Left = 0,
                Width = 340,
                Height = 28,
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
                UseCompatibleTextRendering = true
            };
        }
    }
}
