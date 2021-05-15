using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Staj5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            Tip1CBX.SelectedIndex = 0;
            Tip2CBX.SelectedIndex = 1;

            pictureBox1.Image = Staj5.Properties.Resources.redtrans;
            pictureBox2.Image = Staj5.Properties.Resources.redtrans;

        }
        string server1 = null;
        string server2 = null;
        string username1 = null;
        string username2 = null;
        string pass1 = null;
        string pass2 = null;
        string dbname1 = null;
        string dbname2 = null;
        string logintype1 = null;
        string logintype2 = null;
        bool check1 = false;
        bool check2 = false;

        private void TurSecimDegisti1(object sender,EventArgs a)
        {
            check1 = false;
            pictureBox1.Image = Staj5.Properties.Resources.redtrans;
            if(Tip1CBX.SelectedItem.ToString() == "Windows Authentication")
            {
                KullaniciAdi1CBX.Text = null;
                Giris1SifreTBX.Text = null;
                KullaniciAdi1CBX.Enabled = false;
                Giris1SifreTBX.Enabled = false;
                KullaniciAdi1CBX.BackColor = System.Drawing.Color.Gray;
                Giris1SifreTBX.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                KullaniciAdi1CBX.Text = null;
                Giris1SifreTBX.Text = null;
                KullaniciAdi1CBX.Enabled = true;
                Giris1SifreTBX.Enabled = true;
                KullaniciAdi1CBX.BackColor = System.Drawing.Color.Silver;
                Giris1SifreTBX.BackColor = System.Drawing.Color.Silver;
            }
        }

        private void TurSecimDegisti2(object sender, EventArgs a)
        {
            check2 = false;
            pictureBox2.Image = Staj5.Properties.Resources.redtrans;
            if (Tip2CBX.SelectedItem.ToString() == "Windows Authentication")
            {
                KullaniciAdi2CBX.Text = Giris2SunucuAdiTBX.Text;
                Giris2SifreTBX.Text = null;
                KullaniciAdi2CBX.Enabled = false;
                Giris2SifreTBX.Enabled = false;
                KullaniciAdi2CBX.BackColor = System.Drawing.Color.Gray;
                Giris2SifreTBX.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                KullaniciAdi2CBX.Enabled = true;
                Giris2SifreTBX.Enabled = true;
                KullaniciAdi2CBX.BackColor = System.Drawing.Color.Silver;
                Giris2SifreTBX.BackColor = System.Drawing.Color.Silver;
            }
        }

        private void SecimDegisti1(object sender, EventArgs e)
        {
            check1 = false;
            pictureBox1.Image = Staj5.Properties.Resources.redtrans;
        }

        private void SecimDegisti2(object sender, EventArgs e)
        {
            check2 = false;
            pictureBox2.Image = Staj5.Properties.Resources.redtrans;
        }

        private void Giris1BTN_Click(object sender, EventArgs e)
        {
            server1 = Giris1SunucuAdiTBX.Text;
            pass1 = Giris1SifreTBX.Text;
            username1 = KullaniciAdi1CBX.Text;

            VeritabaniListe1CBX.Items.Clear();

            check1 = false;

            try
            {
                if (Tip1CBX.Text == "Windows Authentication")
                {
                    SqlConnection connection = new SqlConnection(string.Format("Connect Timeout=2;Server={0};Database={1};Integrated Security=True", server1, dbname1));
                    SqlCommand komut = new SqlCommand("SELECT [name] FROM dbo.sysdatabases WHERE dbid > 4", connection);
                    connection.Open();
                    SqlDataReader dr = komut.ExecuteReader();
                    try
                    {
                        while (dr.Read())
                        {
                            check1 = true;
                            pictureBox1.Image = Staj5.Properties.Resources.greentrans;
                            logintype1 = "Windows Authentication";

                            VeritabaniListe1CBX.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
                    connection.Close();
                    }
                    catch
                    {
                        check1 = false;
                        pictureBox1.Image = Staj5.Properties.Resources.redtrans;
                        MessageBox.Show(this, "Girilen bilgiler hatalı.");
                    }
                    connection.Close();
                }
                else
                {
                    SqlConnection connection = new SqlConnection(string.Format("Connect Timeout=2;Server={0};Database={1};User Id={2}; Password={3};", server1, dbname1, username1, pass1));
                    SqlCommand komut = new SqlCommand("SELECT [name] FROM dbo.sysdatabases WHERE dbid > 4", connection);
                    connection.Open();
                    IDataReader dr = komut.ExecuteReader();
                    try
                    {
                        while (dr.Read())
                        {
                            check1 = true;
                            pictureBox1.Image = Staj5.Properties.Resources.greentrans;
                            logintype1 = "SQL Server Authentication";

                            VeritabaniListe1CBX.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
                    connection.Close();
                    }
                    catch
                    {
                        check1 = false;
                        pictureBox1.Image = Staj5.Properties.Resources.redtrans;
                        MessageBox.Show(this, "Girilen bilgiler hatalı.");
                    }
                    connection.Close();
                }
            }
            catch (SqlException x)
            {
                if (x.Number == -2)
                    MessageBox.Show("Veritabanı bağlantısı başarısız. Bağlantınızı kontrol edin.");
                else
                    MessageBox.Show(this, "Girilen bilgiler hatalı.( " + x.Message + " )");
            }
            catch (Exception x)
            {
                MessageBox.Show(this, "Hata: " + x.Message);
            }
        }

        private void Giris2BTN_Click(object sender, EventArgs e)
        {
            server2 = Giris2SunucuAdiTBX.Text;
            pass2 = Giris2SifreTBX.Text;
            username2 = KullaniciAdi2CBX.Text;

            VeritabaniListe2CBX.Items.Clear();

            check2 = false;
            
            try
            {
                if (Tip2CBX.Text == "Windows Authentication")
                {
                    SqlConnection connection = new SqlConnection(string.Format("Connect Timeout=2;Server={0};Database={1};Integrated Security=True", server2, dbname2));
                    SqlCommand komut = new SqlCommand("SELECT [name] FROM dbo.sysdatabases WHERE dbid > 4", connection);
                    connection.Open();
                    SqlDataReader dr = komut.ExecuteReader();
                    try
                    {
                        while(dr.Read())
                        {
                            check2 = true;
                            pictureBox2.Image = Staj5.Properties.Resources.greentrans;
                            logintype2 = "Windows Authentication";

                            VeritabaniListe2CBX.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
                    }
                    catch
                    {
                        check2 = false;
                        pictureBox2.Image = Staj5.Properties.Resources.redtrans;
                        MessageBox.Show(this, "Girilen bilgiler hatalı.");
                    }
                    connection.Close();
                }
                else
                {
                    SqlConnection connection = new SqlConnection(string.Format("Connect Timeout=2;Server={0};Database={1};User Id={2}; Password={3};", server2, dbname2, username2, pass2));
                    SqlCommand komut = new SqlCommand("SELECT [name] FROM dbo.sysdatabases WHERE dbid > 4", connection);
                    connection.Open();
                    SqlDataReader dr = komut.ExecuteReader();
                    try
                    {
                        while (dr.Read())
                        {
                            check2 = true;
                            pictureBox2.Image = Staj5.Properties.Resources.greentrans;
                            logintype2 = "SQL Server Authentication";

                            VeritabaniListe2CBX.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(this, "Hata: " + x.Message);
                    }
                    connection.Close();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(this, "Hata: " + x.Message);
            }
        }

        private void BaslatBTN_Click(object sender, EventArgs e)
        {
            if (check1 && check2)
                if (dbname1 != null && dbname2 != null)
                {
                    this.Hide();

                    using (AnaForm a = new AnaForm())
                    {
                        a.server1 = server1;
                        a.server2 = server2;
                        a.veritabani1 = dbname1;
                        a.veritabani2 = dbname2;
                        a.sifre1 = pass1;
                        a.sifre2 = pass2;
                        a.kullaniciAdi1 = username1;
                        a.kullaniciAdi2 = username2;
                        a.girisTipi1 = logintype1;
                        a.girisTipi2 = logintype2;

                        a.ShowDialog();
                    }

                    check1 = false;
                    pictureBox1.Image = Staj5.Properties.Resources.redtrans;

                    check2 = false;
                    pictureBox2.Image = Staj5.Properties.Resources.redtrans;

                    this.Show();

                     server1 = null;
                     server2 = null;
                     username1 = null;
                     username2 = null;
                     pass1 = null;
                     pass2 = null;
                     dbname1 = null;
                     dbname2 = null;
                     logintype1 = null;
                     logintype2 = null;
                     check1 = false;
                     check2 = false;
                }
                else MessageBox.Show(this, "İki veritabanı seçiniz."); 
                   
            else
                MessageBox.Show(this, "Önce giriş yapın.");
        }

        private void VeritabaniListe1CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbname1 = VeritabaniListe1CBX.SelectedItem.ToString();
        }

        private void VeritabaniListe2CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbname2 = VeritabaniListe2CBX.SelectedItem.ToString();
        }


    }
}