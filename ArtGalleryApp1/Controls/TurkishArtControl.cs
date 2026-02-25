using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public class TurkishArtControl : UserControl
    {
        FlowLayoutPanel flow;
        Timer animTimer;

        PrivateFontCollection troover = new PrivateFontCollection();
        PrivateFontCollection baupro = new PrivateFontCollection();

        Font eserFont;
        Font tarihFont;

        const int WM_MOUSEWHEEL = 0x020A;

        class AnimState
        {
            public float Progress = 0f;
            public int StartOffset = 40;
            public bool Done = false;
        }

        public TurkishArtControl()
        {
            Size = new Size(1280, 720);
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

            eserFont = new Font(troover.Families[0], 16f);
            tarihFont = new Font(baupro.Families[0], 8f);
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

        // ✅ GERÇEK VE KONTROLLÜ SCROLL
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL && flow != null)
            {
                int delta = (short)((m.WParam.ToInt32() >> 16) & 0xffff);

                int speed;

                if (delta < 0)
                {
                    // ⬇️ AŞAĞI → DAHA YAVAŞ
                    speed = 30;
                }
                else
                {
                    // ⬆️ YUKARI → YAVAŞ AMA DAHA SERİ
                    speed = 15;
                }

                int newValue = flow.VerticalScroll.Value - (delta / speed);

                newValue = Math.Max(
                    flow.VerticalScroll.Minimum,
                    Math.Min(flow.VerticalScroll.Maximum, newValue)
                );

                flow.VerticalScroll.Value = newValue;
                return; // default scroll iptal
            }

            base.WndProc(ref m);
        }

        void CreateGallery()
        {
            int itemWidth = 340;
            int imageHeight = 240;

            var data = new (string img, string eser, string sanatci, string tarih)[]
            {
                ("Image1","Kaplumbağa Terbiyecisi","Osman Hamdi Bey","1842-1910"),
                ("Image2","Göl Kenarı","Hoca Ali Rıza","1858-1930"),
                ("Image3","Narlar ve Ayvalar","Şeker Ahmet Paşa","1841-1907"),
                ("Image4","Üsküdar","İbrahim Çallı","1882-1960"),
                ("Image5","Tophane","Bedri Rahmi Eyüboğlu","1911-1973"),
                ("Image6","Sara","Mahmut Cûda","1904-1987"),
                ("Image7","Caz Orkestrası","Fikret Mualla","1903-1967"),
                ("Image8","Üç Güzeller","Nuri İyem","1915-2005"),
                ("Image9","Uzun Yürüyüş","Abidin Dino","1913-1993"),
                ("Image10","Peçeli Kadın","Mihri Müşfik Hanım","1886-1954"),
                ("Image11","Şezlongda Pembeli Kadın","Nazmi Ziya Güran","1881-1937"),
                ("Image12","Dinleti","İbrahim Balaban","1921-2019")
            };

            for (int i = 0; i < data.Length; i++)
            {
                bool rightItem = i % 2 == 1;

                Panel item = new Panel
                {
                    Size = new Size(itemWidth, imageHeight + 115),
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

                item.Controls.Add(MakeLabel(data[i].eser, eserFont, Color.Black, imageHeight + 8));
                item.Controls.Add(MakeLabel(data[i].sanatci, eserFont, Color.FromArgb(120, 120, 120), imageHeight + 36));
                item.Controls.Add(MakeLabel(data[i].tarih, tarihFont, Color.FromArgb(160, 160, 160), imageHeight + 66));

                flow.Controls.Add(item);
            }
        }

        // ilk görünüş slide-up (dokunulmadı)
        void SetupAnimation()
        {
            animTimer = new Timer { Interval = 16 };
            animTimer.Tick += (s, e) =>
            {
                foreach (Panel item in flow.Controls)
                {
                    AnimState st = item.Tag as AnimState;
                    if (st.Done) continue;

                    Rectangle r = flow.RectangleToClient(
                        item.RectangleToScreen(item.ClientRectangle));

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
                Height = 26,
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
                UseCompatibleTextRendering = true
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                eserFont?.Dispose();
                tarihFont?.Dispose();
                animTimer?.Dispose();
                flow?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
