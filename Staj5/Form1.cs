using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Xml;
using System.Net.Mail;
using System.Net;

namespace Staj5
{
    public partial class AnaForm : Form
    {
        //Global Değişkenler
        /*------------------------------------------------------------------------------------*/
        SqlConnection baglanti2;
        SqlConnection baglanti1;

        SqlCommand komut1;
        SqlCommand komut2;

        SqlDataReader dr1;
        SqlDataReader dr2;

        public string server1 { get; set; }
        public string server2 { get; set; }
        public string kullaniciAdi1 { get; set; }
        public string kullaniciAdi2 { get; set; }
        public string sifre1 { get; set; }
        public string sifre2 { get; set; }
        public string veritabani1 { get; set; }
        public string veritabani2 { get; set; }
        public string girisTipi1 { get; set; }
        public string girisTipi2 { get; set; }

        string tabloSecim1;
        string tabloSecim2;

        string kolonSecim1;
        string kolonSecim2;

        string degiskenSecim1;
        string degiskenSecim2;

        public string baglanti1string;
        public string baglanti2string;

        DateTime baslangic;
        DateTime simdi;
        TimeSpan bekleme;

        int durum = 0;

        //Thread için ayarlar
        bool threadbitir = false;

        private static EventWaitHandle threadbeklet = new ManualResetEvent(initialState: true);

        /*------------------------------------------------------------------------------------*/

        public AnaForm()
        {
            InitializeComponent();

            this.Cursor = Cursors.WaitCursor;

            ListBox.CheckForIllegalCrossThreadCalls = false;

            Thread thread1 = new Thread(new ThreadStart(Baslangic));

            thread1.Start();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
        }

        public bool Test()
        {
            //Veritabanı 1 Bağlantı Testi
            using (baglanti1 = new SqlConnection(baglanti1string))
            {
                try
                {
                    baglanti1.Open();
                    komut1 = new SqlCommand("SELECT 1", baglanti1);
                    komut1.ExecuteReader();
                }
                //Bağlantı hatası mesajı
                catch (SqlException)
                {
                    var result = MessageBox.Show(this, baglanti1.DataSource + " veritabanında bağlantı hatası oluştu! Tekrar dene?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button2);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            Test();
                            break;
                        case DialogResult.No:
                            Environment.Exit(1);
                            break;
                    }
                }
            }

            //Veritabanı 2 Bağlantı Testi
            using (baglanti2 = new SqlConnection(baglanti2string))
            {
                try
                {
                    baglanti2.Open();
                    komut2 = new SqlCommand("SELECT 1", baglanti2);
                    komut2.ExecuteReader();
                }
                //Bağlantı hatası mesajı
                catch (SqlException)
                {
                    var result = MessageBox.Show(this, baglanti2.DataSource + " veritabanında bağlantı hatası oluştu! Tekrar dene?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button2);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            Test();
                            break;
                        case DialogResult.No:
                            Environment.Exit(1);
                            break;
                    }
                }
            }
            return true;
        }

        public void Baslangic()
        {
            //baglantistring ayarlama

            if (girisTipi1 == "Windows Authentication")
            {
                baglanti1string = string.Format("Connect Timeout=1;Server={0};Database={1};Integrated Security=True;", server1, veritabani1);
            }
            else
            {
                baglanti1string = string.Format("Connect Timeout=1;Server={0};Database={1};User Id={2}; Password={3};", server1, veritabani1, kullaniciAdi1, sifre1);
            }

            if (girisTipi2 == "Windows Authentication")
            {
                baglanti2string = string.Format("Connect Timeout=1;Server={0};Database={1};Integrated Security=True;", server2, veritabani2);
            }
            else
            {
                baglanti2string = string.Format("Connect Timeout=1;Server={0};Database={1};User Id={2}; Password={3};", server2, veritabani2, kullaniciAdi2, sifre2);
            }

            //Bilgiler Labelleri Ayarlama
            KullaniciAdi1LBL.Text = kullaniciAdi1;
            KullaniciAdi2LBL.Text = kullaniciAdi2;
            Server1LBL.Text = server1;
            Server2LBL.Text = server2;
            Tip1LBL.Text = girisTipi1;
            Tip2LBL.Text = girisTipi2;
            Veritabani1LBL.Text = veritabani1;
            Veritabani2LBL.Text = veritabani2;

            KullaniciAdi2LBL.BringToFront();
            label19.BringToFront();
            Server2LBL.BringToFront();
            label18.BringToFront();
            Tip2LBL.BringToFront();
            label17.BringToFront();
            Veritabani2LBL.BringToFront();
            label16.BringToFront();

            //Bağlantı Testi
            if (Test())
            {
                try
                {

                    baglanti1 = new SqlConnection(baglanti1string);
                    baglanti2 = new SqlConnection(baglanti2string);

                    Cursor.Current = Cursors.WaitCursor;

                    komut1 = new SqlCommand("SELECT name FROM sys.Tables order by name", baglanti1);
                    komut2 = new SqlCommand("SELECT name FROM sys.Tables order by name", baglanti2);

                    //Bağlantı başlangıcı
                    baglanti1.Open();
                    baglanti2.Open();

                    dr1 = komut1.ExecuteReader();

                    //Veritabanı 1 tablo ismi alma
                    while (dr1.Read())
                    {
                        Table1LBX.Items.Add((dr1["name"]).ToString());
                    }

                    dr1.Close();
                    dr2 = komut2.ExecuteReader();

                    //Veritabanı 2 tablo ismi alma
                    while (dr2.Read())
                    {
                        Table2LBX.Items.Add((dr2["name"]).ToString());
                    }

                    dr2.Close();

                    //Form devrede
                    this.Enabled = true;

                    //Bağlantı sonu
                    baglanti1.Close();
                    baglanti2.Close();

                    //Form başlangıcı
                    TabloSecGBX.Enabled = true;
                    Table1LBX.Enabled = true;
                    Table2LBX.Enabled = true;
                    KarsilastirBTN.Enabled = true;
                    BTVITYK_LBX.Enabled = true;
                    ITVBTYK_LBX.Enabled = true;

                    KolonKarsilastirBTN.Enabled = true;
                    BTVITYD_LBX.Enabled = true;
                    ITVBTYD_LBX.Enabled = true;
                    OD_LBX.Enabled = true;
                    KolonAdi_TB.Enabled = true;
                    Kolon2Adi_TB.Enabled = true;
                    KolonDegeri_TB.Enabled = true;
                    KolonDegeri2_TB.Enabled = true;
                    Tablo1Adi_TB.Enabled = true;
                    Tablo2Adi_TB.Enabled = true;
                    GirdiKarsilastirBTN.Enabled = true;
                }
                //Genel hata çıkışı
                catch (Exception x)
                {
                    MessageBox.Show(this, "Hata: " + x);
                }

                this.Cursor = Cursors.Default;
            }
            Thread.CurrentThread.Abort();
        }

        public void TabloKarsilastir()
        {
            //Bağlantı testi
            if (Test())
            {
                //Tablo ve değer bölümü devredışı
                KolonSecGBX.Enabled = false;
                DegerSecGBX.Enabled = false;
                KarsilastirGBX.Enabled = false;

                Cursor.Current = Cursors.WaitCursor;

                //Kullanıcı hata konrolü
                if (Table1LBX.Items.Count == 0 || Table2LBX.Items.Count == 0)
                {
                    MessageBox.Show(this, "Tablo yüklenemedi veya boş! Bağlantını kontrol edin.");
                }
                else if (tabloSecim1 == null || tabloSecim2 == null)
                {
                    MessageBox.Show(this, "Tablo seçiniz.");
                }
                else
                {
                    //Kolonları temizle
                    BTVITYK_LBX.DataSource = null;
                    ITVBTYK_LBX.DataSource = null;

                    BTVITYD_LBX.DataSource = null;
                    ITVBTYD_LBX.DataSource = null;
                    OD_LBX.DataSource = null;
                    KarsilastirmaDGV.DataSource = null;

                    BTVITYK_LBX.Items.Clear();
                    ITVBTYK_LBX.Items.Clear();
                    BTVITYD_LBX.Items.Clear();
                    ITVBTYD_LBX.Items.Clear();
                    OD_LBX.Items.Clear();
                    KarsilastirmaDGV.Rows.Clear();

                    kolonSecim1 = null;
                    kolonSecim2 = null;

                    KolonAdi_TB.Clear();
                    Kolon2Adi_TB.Clear();
                    KolonDegeri_TB.Clear();
                    KolonDegeri2_TB.Clear();

                    try
                    {
                        //Değişken tanımları
                        baglanti1 = new SqlConnection(baglanti1string);
                        baglanti2 = new SqlConnection(baglanti2string);

                        List<string> list1 = new List<string>();
                        List<string> list2 = new List<string>();

                        komut1 = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tabloSecim1 + "' AND TABLE_SCHEMA = 'dbo' ORDER BY COLUMN_NAME", baglanti1);
                        komut2 = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tabloSecim2 + "' AND TABLE_SCHEMA = 'dbo' ORDER BY COLUMN_NAME", baglanti2);

                        //Bağlantı başlangıcı
                        baglanti2.Open();
                        baglanti1.Open();

                        dr1 = komut1.ExecuteReader();

                        //Tablo 1 kolon ismi alma
                        while (dr1.Read())
                        {
                            list1.Add((dr1["COLUMN_NAME"]).ToString());
                        }

                        dr1.Close();

                        dr2 = komut2.ExecuteReader();

                        //Tablo 2 kolon ismi alma
                        while (dr2.Read())
                        {
                            list2.Add((dr2["COLUMN_NAME"]).ToString());
                        }

                        dr2.Close();

                        //Karşılaştırma
                        var firstNotSecond = list1.Except(list2).ToList();
                        var secondNotFirst = list2.Except(list1).ToList();

                        BTVITYK_LBX.DataSource = firstNotSecond;
                        ITVBTYK_LBX.DataSource = secondNotFirst;

                        var q = list1.Where(item => list2.Select(item2 => item2).Contains(item));
                        var y = list1.Except(list2);

                        foreach (var i in q)
                        {
                            checkedListBox1.Items.Add(i);
                            OK_CBX.Items.Add(i);
                        }

                        baglanti1.Close();
                        baglanti2.Close();

                        KolonSecGBX.Enabled = true;

                        KarsilastirBTN.Enabled = true;
                    }
                    //Genel hata çıkışı
                    catch (Exception x)
                    {
                        MessageBox.Show(this, "Hata: " + x);

                        KarsilastirBTN.Enabled = true;
                    }
                }
            }

            TabloSecGBX.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        public void KolonKarsilastir()
        {
            //Bağlantı testi
            if (Test())
            {
                Cursor.Current = Cursors.WaitCursor;

                KolonDegeri_TB.Clear();

                KarsilastirmaDGV.DataSource = null;
                KarsilastirmaDGV.Rows.Clear();

                //Kullanıcı hatası kontrolü
                if (BTVITYK_LBX.Items.Count == 0 && ITVBTYK_LBX.Items.Count == 0 && OK_CBX.Items.Count == 0)
                {
                    MessageBox.Show(this, "Önce Tablo Karşılaştırması Yapınız.");
                }
                else if (OK_CBX.SelectedItem != null || (BTVITYK_LBX.SelectedItem != null && ITVBTYK_LBX.SelectedItem != null))
                {
                    //Değerler temizleme
                    BTVITYD_LBX.DataSource = null;
                    ITVBTYD_LBX.DataSource = null;
                    OD_LBX.DataSource = null;

                    BTVITYD_CBX.DataSource = null;
                    ITVBTY_CBX.DataSource = null;
                    OD_CBX.DataSource = null;

                    BTVITYD_LBX.Items.Clear();
                    ITVBTYD_LBX.Items.Clear();
                    OD_LBX.Items.Clear();

                    BTVITYD_CBX.Items.Clear();
                    ITVBTY_CBX.Items.Clear();
                    OD_CBX.Items.Clear();

                    //Değerler devredışı
                    DegerSecGBX.Enabled = false;
                    KarsilastirGBX.Enabled = false;

                    try
                    {
                        //Değişken tanımlamaları
                        baglanti1 = new SqlConnection(baglanti1string);
                        baglanti2 = new SqlConnection(baglanti2string);

                        List<string> list1 = new List<string>();
                        List<string> list2 = new List<string>();

                        //Bağlantı başlangıcı
                        baglanti1.Open();
                        baglanti2.Open();

                        //Kolon 1 den değer alma
                        string commandText = String.Format("SELECT {0} FROM {1}", kolonSecim1, tabloSecim1);

                        using (baglanti1)
                        {
                            komut1 = new SqlCommand(commandText, baglanti1);

                            dr1 = komut1.ExecuteReader();

                            while (dr1.Read())
                            {
                                list1.Add((dr1[kolonSecim1]).ToString());
                            }

                            dr1.Close();
                        }

                        //Kolon 2 den değer alma
                        string commandText2 = String.Format("SELECT {0} FROM {1}", kolonSecim2, tabloSecim2);

                        komut2 = new SqlCommand(commandText2, baglanti2);

                        dr2 = komut2.ExecuteReader();

                        while (dr2.Read())
                        {
                            list2.Add((dr2[kolonSecim2]).ToString());
                        }

                        dr2.Close();

                        //Karşılaştırma
                        var firstNotSecond = list1.Except(list2).ToList();
                        var secondNotFirst = list2.Except(list1).ToList();

                        BTVITYD_LBX.DataSource = firstNotSecond;
                        BTVITYD_CBX.DataSource = firstNotSecond;

                        ITVBTYD_LBX.DataSource = secondNotFirst;
                        ITVBTY_CBX.DataSource = secondNotFirst;

                        var q = list1.Where(item => list2.Select(item2 => item2).Contains(item));
                        var y = list1.Except(list2);

                        foreach (var i in q)
                        {
                            OD_LBX.Items.Add(i);
                            OD_CBX.Items.Add(i);
                        }

                        //Bağlantı sonu
                        baglanti1.Close();
                        baglanti2.Close();

                        //Değerler devrede
                        DegerSecGBX.Enabled = true;
                        KarsilastirGBX.Enabled = true;

                        OtoKarsilastirBekletBTN.Enabled = false;
                        OtoKarsilastirDevamBTN.Enabled = false;
                        OtoKarsilastirDurdurBTN.Enabled = false;

                        KolonKarsilastirBTN.Enabled = true;

                    }
                    //Genel hata çıkışı
                    catch (Exception x)
                    {
                        MessageBox.Show(this, "Hata: " + x);

                        KolonKarsilastirBTN.Enabled = true;
                    }
                }
                //Kullanıcı Hata Kontrolü
                else
                {
                    MessageBox.Show(this, "Kolon Listesinden Kolon Seçiniz.");

                    KolonKarsilastirBTN.Enabled = true;
                }

                Cursor.Current = Cursors.Default;
            }
        }

        public void OtomatikKarsilastir()
        {
            //Bağlantı testi
            if (Test())
            {
                KarsilastirmaDGV.ScrollBars = ScrollBars.None;

                //Kullanıcı hatası kontrolü
                if (KolonAdi_TB.Text == "" || OD_LBX.Items.Count == 0)
                {
                    MessageBox.Show(this, "Önce değer seçiniz.");
                }
                else
                {
                    try
                    {
                        //Değişken tanımlamaları
                        baglanti1 = new SqlConnection(baglanti1string);
                        baglanti2 = new SqlConnection(baglanti2string);

                        kolonSecim1 = KolonAdi_TB.Text;
                        kolonSecim2 = KolonAdi_TB.Text;

                        string sonuc1 = null;
                        string sonuc2 = null;

                        KarsilastirmaDGV.DataSource = null;
                        KarsilastirmaDGV.Rows.Clear();

                        List<string> kolonListesi = /*OK_CBX.Items.Cast<String>().ToList();*/ checkedListBox1.CheckedItems.OfType<string>().ToList();
                        List<string> degerListesi = OD_LBX.Items.Cast<String>().ToList();

                        //Karşılaştırma DataGridView hazırlama
                        KarsilastirmaDGV.Columns.Add("deger", "Değer");
                        KarsilastirmaDGV.Columns.Add("kolon", "Kolon Adı");
                        KarsilastirmaDGV.Columns.Add("tablo1deger", "Tablo 1 Değer");
                        KarsilastirmaDGV.Columns.Add("tablo2deger", "Tablo 2 Değer");

                        KarsilastirmaDGV.AutoGenerateColumns = true;

                        //Bağlantı başlangıcı
                        baglanti2.Open();
                        baglanti1.Open();

                        //ProgressBar sonu ayarı
                        DurumPB.Maximum = degerListesi.Count;
                        durumLBL.Text = "0/0";

                        baslangic = DateTime.Now;

                        for (int j = 0; j < degerListesi.Count; j++)
                        {
                            //Bekleme süresinin geçen toplam süreden çıkarılması için.
                            simdi = DateTime.Now;

                            //Beklet tuşuna basıldığında thread burada bekleyecektir.
                            threadbeklet.WaitOne();

                            //Bekleme süresi toplam süreden çıkarılır.
                            bekleme += DateTime.Now - simdi;

                            //Durdur tuşuna basıldığında thread buradan çıkacaktır.
                            if (threadbitir == true)
                            {
                                Thread.CurrentThread.Abort();
                            }

                            //Bütün kolonlar için ayrı sorgu yapan döngü
                            for (int i = 0; i < kolonListesi.Count; i++)
                            {
                                GecenSureLBL.Text = String.Format("{0:hh\\:mm\\:ss}", DateTime.Now - baslangic - bekleme);

                                //İlk tablodan sonuç alma
                                string komutText1 = String.Format("SELECT {0} FROM {1} WHERE {2} = @degerListesi", kolonListesi[i], tabloSecim1, kolonSecim1);

                                komut1 = new SqlCommand(komutText1, baglanti1);

                                //Parametre ekleme 1
                                SqlParameter param = new SqlParameter();
                                param.ParameterName = "@degerListesi";
                                param.Value = degerListesi[j].ToString();

                                komut1.Parameters.Add(param);

                                dr1 = komut1.ExecuteReader();

                                while (dr1.Read())
                                {
                                    sonuc1 = dr1[kolonListesi[i]].ToString();
                                }

                                dr1.Close();

                                //İkinci tablodan sonuç alma
                                string komutText2 = String.Format("SELECT {0} FROM {1} WHERE {2} = @degerListesi", kolonListesi[i], tabloSecim2, kolonSecim2);

                                komut2 = new SqlCommand(komutText2, baglanti2);

                                //Parametre ekleme 2
                                SqlParameter param2 = new SqlParameter();
                                param2.ParameterName = "@degerListesi";
                                param2.Value = degerListesi[j].ToString();

                                komut2.Parameters.Add(param2);

                                dr2 = komut2.ExecuteReader();

                                while (dr2.Read())
                                {
                                    sonuc2 = dr2[kolonListesi[i]].ToString();
                                }

                                dr2.Close();

                                //Sonuç karşılaştırma
                                if (sonuc1 != sonuc2)
                                {
                                    KarsilastirmaDGV.Rows.Add(degerListesi[j], kolonListesi[i], sonuc1, sonuc2);
                                }
                            }

                            //Değer Ayracı
                            KarsilastirmaDGV.Rows.Add("----------------------------------------", "----------------------------------------", "----------------------------------------", "----------------------------------------");

                            //ProgressBar ve Label Arttırma
                            durum++;
                            durumLBL.Text = string.Format(durum.ToString() + " / " + degerListesi.Count.ToString());

                            //DurumPB.Value++;
                        };
                    }
                    //Durdur butonu çıkışı
                    catch (ThreadAbortException)
                    {
                        MessageBox.Show(this, "İşlem kullanıcı tarafından durduruldu.");
                    }
                    //Sql hata çıkışı
                    catch (SqlException)
                    {
                        MessageBox.Show(this, "Girilen değer veritabanında bulunamadı.");
                    }
                    //Diğer hatalar için çıkış
                    catch (Exception x)
                    {
                        MessageBox.Show(this, "Hata: " + x);
                    }

                    //Bağlantı bitişi
                    baglanti2.Close();
                    baglanti1.Close();

                    KarsilastirmaDGV.ScrollBars = ScrollBars.Both;
                }
            }
        }

        public void GirdiKarsilastir()
        {
            //Bağlantı testi
            if (Test())
            {
                //Otomatik karşılaştırma devredışı bırakılır
                OtomatikKarsilastirBTN.Enabled = false;
                OtoKarsilastirBekletBTN.Enabled = false;
                OtoKarsilastirDevamBTN.Enabled = false;
                OtoKarsilastirDurdurBTN.Enabled = false;

                Cursor.Current = Cursors.WaitCursor;

                //Kullanıcı hata kontrolü
                if (KolonAdi_TB.Text == "" || KolonDegeri_TB.Text == "")
                {
                    MessageBox.Show(this, "Kolon adı ve kolon değeri giriniz!");

                    OtomatikKarsilastirBTN.Enabled = true;
                    OtoKarsilastirBekletBTN.Enabled = true;
                    OtoKarsilastirDevamBTN.Enabled = true;
                    OtoKarsilastirDurdurBTN.Enabled = true;

                    GirdiKarsilastirBTN.Enabled = true;
                }
                else
                {
                    try
                    {
                        //Değişken tanımları
                        baglanti1 = new SqlConnection(baglanti1string);
                        baglanti2 = new SqlConnection(baglanti2string);

                        string deger1 = null;
                        string deger2 = null;
                        string karsilastirma = null;

                        kolonSecim1 = KolonAdi_TB.Text;
                        kolonSecim2 = KolonAdi_TB.Text;
                        degiskenSecim1 = KolonDegeri_TB.Text;
                        degiskenSecim2 = KolonDegeri2_TB.Text;

                        List<string> list3 = OK_CBX.Items.Cast<String>().ToList();

                        //Karşılaştırma DataGridView Temizleme
                        KarsilastirmaDGV.DataSource = null;
                        KarsilastirmaDGV.Rows.Clear();
                        KarsilastirmaDGV.Columns.Clear();

                        //Karşılaştırma DataGridView Hazırlama
                        KarsilastirmaDGV.Columns.Add("kolonadi", "Kolon");
                        KarsilastirmaDGV.Columns.Add("tablo1deger", "Tablo 1 Değer");
                        KarsilastirmaDGV.Columns.Add("tablo2deger", "Tablo 2 Değer");
                        KarsilastirmaDGV.Columns.Add("Karsilastirma", "Karşılaştırma");

                        //Bağlantı başlangıcı
                        baglanti2.Open();
                        baglanti1.Open();

                        //Kolon sayısı kadar işlem
                        for (int i = 0; i < list3.Count; i++)
                        {
                            //Değişken tanımlamaları
                            string commandText = String.Format("SELECT {0} FROM {1} WHERE {2} = @degisken", list3[i], tabloSecim1, kolonSecim1);

                            komut1 = new SqlCommand(commandText, baglanti1);

                            //Parametre ekleme 1
                            SqlParameter param1 = new SqlParameter();
                            param1.ParameterName = "@degisken";
                            param1.Value = degiskenSecim1;

                            komut1.Parameters.Add(param1);

                            dr1 = komut1.ExecuteReader();

                            //Tablo 1 den okuma
                            while (dr1.Read())
                            {
                                deger1 = dr1[list3[i]].ToString();
                            }

                            dr1.Close();

                            //Değişken tanımlamaları
                            string commandText2 = String.Format("SELECT {0} FROM {1} WHERE {2} = @degisken", list3[i], tabloSecim2, kolonSecim2);

                            komut2 = new SqlCommand(commandText2, baglanti2);

                            //Parametre ekleme 2
                            SqlParameter param2 = new SqlParameter();
                            param2.ParameterName = "@degisken";
                            param2.Value = degiskenSecim2;

                            komut2.Parameters.Add(param2);

                            dr2 = komut2.ExecuteReader();

                            //Tablo 2 den okuma
                            while (dr2.Read())
                            {
                                deger2 = dr2[list3[i]].ToString();
                            }

                            dr2.Close();

                            //Değer karşılaştırma
                            if (deger1 == deger2)
                                karsilastirma = "Aynı";
                            else
                                karsilastirma = "Farklı";

                            //Karşılaştırma DataGridView Ekleme
                            KarsilastirmaDGV.Rows.Add(list3[i], deger1, deger2, karsilastirma);

                            //Karşılaştırma kolon rengi ayarı
                            if (karsilastirma == "Aynı")
                                KarsilastirmaDGV.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.LightGreen;
                            else
                                KarsilastirmaDGV.Rows[i].Cells[3].Style.BackColor = System.Drawing.Color.Salmon;

                            GirdiKarsilastirBTN.Enabled = true;
                        };

                        //Bağlantı sonu
                        baglanti2.Close();
                        baglanti1.Close();
                    }
                    //SQL bağlantı hata çıkışı
                    catch (SqlException)
                    {
                        MessageBox.Show(this, "Girilen değer veritabanında bulunamadı.");

                        GirdiKarsilastirBTN.Enabled = true;
                    }
                    //Genel hata çıkışı
                    catch (Exception x)
                    {
                        MessageBox.Show(this, "Hata: " + x);

                        GirdiKarsilastirBTN.Enabled = true;
                    }
                }

                //Otomatik karşılaştırma devrede
                OtomatikKarsilastirBTN.Enabled = true;
                OtoKarsilastirBekletBTN.Enabled = true;
                OtoKarsilastirDevamBTN.Enabled = true;
                OtoKarsilastirDurdurBTN.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
        }

        private DataTable DGVTabloOlustur(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        public void Otomasyon()
        {


            OtomatikKarsilastir();

            DataTable dT = DGVTabloOlustur(KarsilastirmaDGV);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);

            string x = String.Format("{0:hh\\.mm\\.ss}", DateTime.Now);

            string filename = string.Format("{0}.xml", x);

            string location = Path.Combine(Application.StartupPath, filename);

            using (XmlTextWriter xmlWrite = new XmlTextWriter(location, System.Text.Encoding.UTF8))
            {
                dS.WriteXml(xmlWrite);
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply@program.net");
            mail.To.Add("mbb3393@gmail.com");
            mail.Attachments.Add(new Attachment(location));
            mail.Body = DateTime.Now.ToString();

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("mbb3393@gmail.com", "EbZeGrIk8");

            smtp.Send(mail);

            counter = 10;
        }

        private System.Windows.Forms.Timer timer1;
        private int counter = 10;

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
        }

        private void KarsilastirBTN_Click(object sender, EventArgs e)
        {
            KarsilastirBTN.Enabled = false;

            Thread thread = new Thread(new ThreadStart(TabloKarsilastir));
            thread.Start();

            //tab next ekle
            tabControl1.SelectedIndex++;
        }

        private void KolonKarsilastirBTN_Click(object sender, EventArgs e)
        {
            KolonKarsilastirBTN.Enabled = false;

            Thread thread = new Thread(new ThreadStart(KolonKarsilastir));
            thread.Start();

            tabControl1.SelectedIndex++;
        }

        private void GirdiKarsilastirBTN_Click(object sender, EventArgs e)
        {
            GirdiKarsilastirBTN.Enabled = false;

            Thread thread = new Thread(new ThreadStart(GirdiKarsilastir));
            thread.Start();
        }

        private void OtomatikKarsilastirBTN_Click(object sender, EventArgs e)
        {

            baslangic = DateTime.Now;

            DurumPB.Value = 0;

            threadbitir = false;

            KarsilastirmaDGV.DataSource = null;

            KarsilastirmaDGV.Rows.Clear();
            KarsilastirmaDGV.Columns.Clear();

            GirdiKarsilastirBTN.Enabled = false;
            KarsilastirBTN.Enabled = false;
            KolonKarsilastirBTN.Enabled = false;
            KolonAdi_TB.Enabled = false;
            Kolon2Adi_TB.Enabled = false;
            Tablo1Adi_TB.Enabled = false;
            Tablo2Adi_TB.Enabled = false;
            OK_CBX.Enabled = false;
            ITVBTYK_LBX.Enabled = false;
            BTVITYK_LBX.Enabled = false;

            OtomatikKarsilastirBTN.Enabled = false;
            OtoKarsilastirDevamBTN.Enabled = false;
            OtoKarsilastirDurdurBTN.Enabled = true;
            OtoKarsilastirBekletBTN.Enabled = true;

            Thread thread = new Thread(new ThreadStart(OtomatikKarsilastir));
            thread.Start();

            tabControl1.SelectedIndex++;
        }

        private void Table1LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabloSecim1 = Table1LBX.SelectedItem.ToString();
            Tablo1Adi_TB.Text = tabloSecim1.ToString();
            KolonAdi_TB.Clear();
            KolonDegeri_TB.Clear();
        }

        private void Table2LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabloSecim2 = Table2LBX.SelectedItem.ToString();
            Tablo2Adi_TB.Text = tabloSecim2.ToString();
            Kolon2Adi_TB.Clear();
            KolonDegeri2_TB.Clear();
        }

        private void OC_LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BTVITYK_LBX.SelectedIndex = -1;
                ITVBTYK_LBX.SelectedIndex = -1;
                kolonSecim1 = OK_CBX.SelectedItem.ToString();
                kolonSecim2 = OK_CBX.SelectedItem.ToString();
                KolonAdi_TB.Text = OK_CBX.SelectedItem.ToString();
                KolonDegeri_TB.Clear();
                Kolon2Adi_TB.Text = OK_CBX.SelectedItem.ToString();
                KolonDegeri2_TB.Clear();

            }
            catch
            {
                kolonSecim1 = null;
                kolonSecim2 = null;
                KolonAdi_TB.Clear();
                KolonDegeri_TB.Clear();
                Kolon2Adi_TB.Clear();
                KolonDegeri2_TB.Clear();
            }
        }

        private void BTVITYC_LBX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                kolonSecim1 = BTVITYK_LBX.SelectedItem.ToString();
                KolonAdi_TB.Text = BTVITYK_LBX.SelectedItem.ToString();
            }
            catch
            {
                kolonSecim1 = null;
                KolonAdi_TB.Text = "";
            }
        }

        private void ITVBTYC_LBX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                kolonSecim2 = ITVBTYK_LBX.SelectedItem.ToString();
                Kolon2Adi_TB.Text = ITVBTYK_LBX.SelectedItem.ToString();
            }
            catch
            {
                kolonSecim2 = null;
                Kolon2Adi_TB.Text = "";
            }
        }

        private void OV_LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            KolonDegeri_TB.Text = OD_LBX.SelectedItem.ToString();
            KolonDegeri2_TB.Text = OD_LBX.SelectedItem.ToString();

            OD_CBX.SelectedItem = OD_LBX.SelectedItem;
        }

        private void BTVITYV_LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KolonDegeri_TB.Text = BTVITYD_LBX.SelectedItem.ToString();
            }
            catch
            {
                KolonDegeri_TB.Text = "";
            }
        }

        private void ITVBTYV_LBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KolonDegeri2_TB.Text = ITVBTYD_LBX.SelectedItem.ToString();
            }
            catch
            {
                KolonDegeri2_TB.Text = "";
            }
        }

        private void OtoKarsilastirDurdurBTN_Click(object sender, EventArgs e)
        {
            threadbitir = true;

            threadbeklet.Set();

            GirdiKarsilastirBTN.Enabled = true;
            KarsilastirBTN.Enabled = true;
            KolonKarsilastirBTN.Enabled = true;
            KolonAdi_TB.Enabled = true;
            Kolon2Adi_TB.Enabled = true;
            Tablo1Adi_TB.Enabled = true;
            Tablo2Adi_TB.Enabled = true;
            OK_CBX.Enabled = true;
            ITVBTYK_LBX.Enabled = true;
            BTVITYK_LBX.Enabled = true;
            OtomatikKarsilastirBTN.Enabled = true;
            OtoKarsilastirDurdurBTN.Enabled = false;
            OtoKarsilastirDevamBTN.Enabled = false;
            OtoKarsilastirBekletBTN.Enabled = false;

            KarsilastirmaDGV.ScrollBars = ScrollBars.Both;
        }

        private void OtoKarsilastirBekletBTN_Click(object sender, EventArgs e)
        {
            threadbeklet.Reset();

            OtoKarsilastirDurdurBTN.Enabled = true;
            OtoKarsilastirDevamBTN.Enabled = true;
            OtoKarsilastirBekletBTN.Enabled = false;

            KarsilastirmaDGV.ScrollBars = ScrollBars.Both;
        }

        private void OtoKarsilastirDevamBTN_Click(object sender, EventArgs e)
        {
            threadbeklet.Set();

            OtoKarsilastirDevamBTN.Enabled = false;
            OtoKarsilastirBekletBTN.Enabled = true;
            OtoKarsilastirDurdurBTN.Enabled = true;

            KarsilastirmaDGV.ScrollBars = ScrollBars.None;
        }

        private void OV_CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            KolonDegeri_TB.Text = OD_CBX.SelectedItem.ToString();
            KolonDegeri2_TB.Text = OD_CBX.SelectedItem.ToString();

            OD_LBX.SelectedItem = OD_CBX.SelectedItem;
        }

        private void ITVBTY_CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            KolonDegeri2_TB.Text = ITVBTY_CBX.SelectedItem.ToString();

            ITVBTYD_LBX.SelectedItem = ITVBTY_CBX.SelectedItem;
        }

        private void BTVITY_CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            KolonDegeri_TB.Text = BTVITYD_CBX.SelectedItem.ToString();

            BTVITYD_LBX.SelectedItem = BTVITYD_CBX.SelectedItem;
        }

        private void TekrarGirisBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dT = DGVTabloOlustur(KarsilastirmaDGV);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);

            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "|*.xml";
            kaydet.OverwritePrompt = true;
            kaydet.CreatePrompt = true;

            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                using (XmlTextWriter xmlWrite = new XmlTextWriter(kaydet.FileName, System.Text.Encoding.UTF8))
                {
                    dS.WriteXml(xmlWrite);
                }
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply@program.net");
                mail.To.Add("berkbinnur@hotmail.com");
                mail.Attachments.Add(new Attachment(kaydet.FileName));
                mail.Body = DateTime.Now.ToString();

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("mbb3393@gmail.com", "EbZeGrIk8");

                smtp.Send(mail);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ac = new OpenFileDialog();
                ac.Filter = "|*.xml";
                if (ac.ShowDialog() == DialogResult.OK)
                {
                    XmlReader xmlFile;
                    xmlFile = XmlReader.Create(ac.FileName, new XmlReaderSettings());
                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlFile);
                    KarsilastirmaDGV.Rows.Clear();
                    KarsilastirmaDGV.Columns.Clear();
                    KarsilastirmaDGV.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }

        private void OK_CBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            BTVITYK_LBX.SelectedIndex = -1;
            ITVBTYK_LBX.SelectedIndex = -1;
            kolonSecim1 = OK_CBX.SelectedItem.ToString();
            kolonSecim2 = OK_CBX.SelectedItem.ToString();
            KolonAdi_TB.Text = OK_CBX.SelectedItem.ToString();
            KolonDegeri_TB.Clear();
            Kolon2Adi_TB.Text = OK_CBX.SelectedItem.ToString();
            KolonDegeri2_TB.Clear();

            //}
            //catch
            //{
            //    kolonSecim1 = null;
            //    kolonSecim2 = null;
            //    KolonAdi_TB.Clear();
            //    KolonDegeri_TB.Clear();
            //    Kolon2Adi_TB.Clear();
            //    KolonDegeri2_TB.Clear();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (counter == 0)
            {
                Otomasyon();
            }

        }
    }
}