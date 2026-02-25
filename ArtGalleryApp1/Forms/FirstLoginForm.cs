using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGalleryApp1
{
    public partial class FirstLoginForm : Form
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=ArtGalleryDB;Trusted_Connection=True;Encrypt=False;";

        public FirstLoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FirstLoginForm_Load(object sender, EventArgs e)
        {
            // AGE
            cmbAge.Items.Clear();
            for (int i = 15; i <= 90; i++)
                cmbAge.Items.Add(i);

            // GENDER
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });

            // PLACEHOLDER
            txtNamesurname.Text = "Name, Surname";
            txtNamesurname.ForeColor = Color.Gray;

            txtNamesurname.GotFocus += (s, ev) =>
            {
                if (txtNamesurname.Text == "Name, Surname")
                {
                    txtNamesurname.Text = "";
                    txtNamesurname.ForeColor = Color.Black;
                }
            };

            txtNamesurname.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNamesurname.Text))
                {
                    txtNamesurname.Text = "Name, Surname";
                    txtNamesurname.ForeColor = Color.Gray;
                }
            };
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            string fullName = txtNamesurname.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName) || fullName == "Name, Surname")
            {
                MessageBox.Show("Lütfen ad ve soyad girin.");
                return;
            }

            int? age = cmbAge.SelectedItem != null ? Convert.ToInt32(cmbAge.SelectedItem) : (int?)null;
            string gender = cmbGender.SelectedItem?.ToString();

            bool welcomeBack = false;

            // SQL kontrol ve ekleme
            await Task.Run(() =>
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Önce kullanıcı var mı kontrol et
                        using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Users WHERE FullName=@n", con))
                        {
                            checkCmd.Parameters.AddWithValue("@n", fullName);
                            int count = (int)checkCmd.ExecuteScalar();
                            welcomeBack = count > 0;
                        }

                        // Yoksa ekle
                        if (!welcomeBack)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO dbo.Users (FullName, Age, Gender, CreatedAt)
                                  VALUES (@n, @a, @g, GETDATE())", con))
                            {
                                cmd.Parameters.AddWithValue("@n", fullName);
                                cmd.Parameters.AddWithValue("@a", age.HasValue ? (object)age.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@g", string.IsNullOrWhiteSpace(gender) ? (object)DBNull.Value : gender);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() =>
                        MessageBox.Show("SQL Hatası: " + ex.Message)));
                }
            });

            // Form1 aç ve kullanıcı bilgilerini gönder
            this.Invoke((Action)(() =>
            {
                Form1 main = new Form1(fullName, age, gender, welcomeBack);
                main.Show();
                this.Hide();
            }));
        }
    }
}
