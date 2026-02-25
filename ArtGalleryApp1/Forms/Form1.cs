using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class Form1 : Form
    {
        // ================= USER INFO =================
        private string currentUserName;
        private int? currentUserAge;
        private string currentUserGender;

        public string CurrentUserName => currentUserName;

        // ================= FONTS =================
        PrivateFontCollection fonts = new PrivateFontCollection();
        PrivateFontCollection syneFonts = new PrivateFontCollection();

        Font bauProMedium;
        Font syneBoldFont;

        // ================= TOP RIGHT USER =================
        PictureBox pbUser;
        Panel panelUserHover;
        Label lblUserName;
        Label lblUserInfo;
        Label lblAppTitle;

        public Form1(string userName, int? userAge, string userGender, bool welcomeBack)
        {
            InitializeComponent();
            DoubleBuffered = true;

            currentUserName = userName;
            currentUserAge = userAge;
            currentUserGender = userGender;

            LoadCustomFont();
            LoadSyneBoldFont();
            SetupNavbar();
            SetupUserArea(welcomeBack);

            LoadPage(new HomeControl());
        }

        // ================= FONTS =================
        void LoadCustomFont()
        {
            fonts.AddFontFile(Application.StartupPath + @"\Fonts\BauPro-Medium.ttf");
            bauProMedium = new Font(fonts.Families[0], 10);
        }

        void LoadSyneBoldFont()
        {
            syneFonts.AddFontFile(Application.StartupPath + @"\Fonts\Syne-Bold.ttf");
            syneBoldFont = new Font(syneFonts.Families[0], 20f, FontStyle.Bold);
        }

        // ================= NAVBAR =================
        void SetupNavbar()
        {
            SetupNavButton(btnHome, () => LoadPage(new HomeControl()));
            SetupNavButton(btnUserArtwork, () => LoadPage(new UserArtworksControl()));
            SetupNavButton(btnArtworks, () => LoadPage(new ArtworksControl()));
            SetupNavButton(btnArtists, () => LoadPage(new ArtistsControl()));
            SetupNavButton(btnAbout, () => LoadPage(new AboutControl()));
            SetupNavButton(btnCategories, () => LoadPage(new CategoriesControl()));
        }

        void SetupNavButton(Button btn, Action action)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.OldLace;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                btn.ForeColor = Color.Goldenrod;
                btn.Invalidate();
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.ForeColor = Color.OldLace;
                btn.Invalidate();
            };

            btn.Click += (s, e) => action();
        }

        // ================= USER AREA (TOP RIGHT) =================
        void SetupUserArea(bool welcomeBack)
        {
            // 🔹 USER ICON
            pbUser = new PictureBox
            {
                Image = Properties.Resources.user1, // 🔥 Resources
                Size = new Size(23, 23),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(btnUserArtworks.Width - 48, 21)
            };
            btnUserArtworks.Controls.Add(pbUser);
            pbUser.BringToFront();

            // 🔹 APP TITLE (SOLUNA – BİRAZ DAHA SOLDA)
            lblAppTitle = new Label
            {
                Text = "ArtGallery",
                AutoSize = true,
                Font = syneBoldFont,
                ForeColor = Color.FromArgb(235, 233, 207),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            lblAppTitle.Location = new Point(pbUser.Left - lblAppTitle.Width - 74, 16);
            btnUserArtworks.Controls.Add(lblAppTitle);
            lblAppTitle.BringToFront();

            // 🔹 HOVER PANEL (FORM ÜZERİNDE)
            panelUserHover = new Panel
            {
                Size = new Size(180, 55),
                BackColor = Color.FromArgb(235, 233, 207),
                Visible = false
            };
            Controls.Add(panelUserHover);
            panelUserHover.BringToFront();

            panelUserHover.Location = new Point(
                btnUserArtworks.Right - panelUserHover.Width - 20,
                btnUserArtworks.Bottom + 4
            );

            lblUserName = new Label
            {
                AutoSize = true,
                Font = bauProMedium,
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(8, 6)
            };

            lblUserInfo = new Label
            {
                AutoSize = true,
                Font = bauProMedium,
                ForeColor = Color.FromArgb(90, 90, 90),
                Location = new Point(8, 28)
            };

            lblUserName.Text = currentUserName;
            lblUserInfo.Text = welcomeBack
                ? "Welcome Back!"
                : currentUserAge.HasValue
                    ? $"{currentUserAge} / {currentUserGender}"
                    : currentUserGender;

            panelUserHover.Controls.Add(lblUserName);
            panelUserHover.Controls.Add(lblUserInfo);

            pbUser.MouseEnter += (s, e) => panelUserHover.Visible = true;
            pbUser.MouseLeave += (s, e) => panelUserHover.Visible = false;
            panelUserHover.MouseEnter += (s, e) => panelUserHover.Visible = true;
            panelUserHover.MouseLeave += (s, e) => panelUserHover.Visible = false;
        }

        // ================= PAGE LOAD =================
        public void LoadPage(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        // HOME → ADD ARTWORK
        public void GoToAddArtwork()
        {
            LoadPage(new AddArtworkControl());
        }
    }
}
