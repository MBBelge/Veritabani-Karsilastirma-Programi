namespace Staj5
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Giris2BTN = new System.Windows.Forms.Button();
            this.Giris1SifreTBX = new System.Windows.Forms.TextBox();
            this.Giris2SifreTBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VeritabaniListe1CBX = new System.Windows.Forms.ComboBox();
            this.VeritabaniListe2CBX = new System.Windows.Forms.ComboBox();
            this.Tip1CBX = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Tip2CBX = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Giris1BTN = new System.Windows.Forms.Button();
            this.BaslatBTN = new System.Windows.Forms.Button();
            this.Giris1SunucuAdiTBX = new System.Windows.Forms.TextBox();
            this.Giris2SunucuAdiTBX = new System.Windows.Forms.TextBox();
            this.KullaniciAdi2CBX = new System.Windows.Forms.TextBox();
            this.KullaniciAdi1CBX = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Giris2BTN
            // 
            this.Giris2BTN.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Giris2BTN.ForeColor = System.Drawing.Color.Black;
            this.Giris2BTN.Location = new System.Drawing.Point(355, 124);
            this.Giris2BTN.Margin = new System.Windows.Forms.Padding(2);
            this.Giris2BTN.Name = "Giris2BTN";
            this.Giris2BTN.Size = new System.Drawing.Size(173, 23);
            this.Giris2BTN.TabIndex = 11;
            this.Giris2BTN.Text = "Giriş Yap";
            this.Giris2BTN.UseVisualStyleBackColor = false;
            this.Giris2BTN.Click += new System.EventHandler(this.Giris2BTN_Click);
            // 
            // Giris1SifreTBX
            // 
            this.Giris1SifreTBX.BackColor = System.Drawing.Color.Silver;
            this.Giris1SifreTBX.Location = new System.Drawing.Point(86, 100);
            this.Giris1SifreTBX.Margin = new System.Windows.Forms.Padding(2);
            this.Giris1SifreTBX.Name = "Giris1SifreTBX";
            this.Giris1SifreTBX.PasswordChar = '*';
            this.Giris1SifreTBX.Size = new System.Drawing.Size(174, 20);
            this.Giris1SifreTBX.TabIndex = 4;
            this.Giris1SifreTBX.TextChanged += new System.EventHandler(this.SecimDegisti1);
            // 
            // Giris2SifreTBX
            // 
            this.Giris2SifreTBX.BackColor = System.Drawing.Color.Silver;
            this.Giris2SifreTBX.Location = new System.Drawing.Point(355, 100);
            this.Giris2SifreTBX.Margin = new System.Windows.Forms.Padding(2);
            this.Giris2SifreTBX.Name = "Giris2SifreTBX";
            this.Giris2SifreTBX.PasswordChar = '*';
            this.Giris2SifreTBX.Size = new System.Drawing.Size(173, 20);
            this.Giris2SifreTBX.TabIndex = 10;
            this.Giris2SifreTBX.Text = "N3h1r2013";
            this.Giris2SifreTBX.TextChanged += new System.EventHandler(this.SecimDegisti2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sunucu Adı: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Şifre: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sunucu 1: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sunucu 2:";
            // 
            // VeritabaniListe1CBX
            // 
            this.VeritabaniListe1CBX.BackColor = System.Drawing.Color.Silver;
            this.VeritabaniListe1CBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VeritabaniListe1CBX.FormattingEnabled = true;
            this.VeritabaniListe1CBX.Location = new System.Drawing.Point(86, 151);
            this.VeritabaniListe1CBX.Margin = new System.Windows.Forms.Padding(2);
            this.VeritabaniListe1CBX.Name = "VeritabaniListe1CBX";
            this.VeritabaniListe1CBX.Size = new System.Drawing.Size(174, 21);
            this.VeritabaniListe1CBX.TabIndex = 6;
            this.VeritabaniListe1CBX.SelectedIndexChanged += new System.EventHandler(this.VeritabaniListe1CBX_SelectedIndexChanged);
            // 
            // VeritabaniListe2CBX
            // 
            this.VeritabaniListe2CBX.BackColor = System.Drawing.Color.Silver;
            this.VeritabaniListe2CBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VeritabaniListe2CBX.FormattingEnabled = true;
            this.VeritabaniListe2CBX.Location = new System.Drawing.Point(355, 151);
            this.VeritabaniListe2CBX.Margin = new System.Windows.Forms.Padding(2);
            this.VeritabaniListe2CBX.Name = "VeritabaniListe2CBX";
            this.VeritabaniListe2CBX.Size = new System.Drawing.Size(173, 21);
            this.VeritabaniListe2CBX.TabIndex = 12;
            this.VeritabaniListe2CBX.SelectedIndexChanged += new System.EventHandler(this.VeritabaniListe2CBX_SelectedIndexChanged);
            // 
            // Tip1CBX
            // 
            this.Tip1CBX.BackColor = System.Drawing.Color.Silver;
            this.Tip1CBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tip1CBX.FormattingEnabled = true;
            this.Tip1CBX.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.Tip1CBX.Location = new System.Drawing.Point(86, 49);
            this.Tip1CBX.Margin = new System.Windows.Forms.Padding(2);
            this.Tip1CBX.Name = "Tip1CBX";
            this.Tip1CBX.Size = new System.Drawing.Size(174, 21);
            this.Tip1CBX.TabIndex = 2;
            this.Tip1CBX.SelectedIndexChanged += new System.EventHandler(this.TurSecimDegisti1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(320, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Şifre: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(287, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sunucu Adı: ";
            // 
            // Tip2CBX
            // 
            this.Tip2CBX.BackColor = System.Drawing.Color.Silver;
            this.Tip2CBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tip2CBX.FormattingEnabled = true;
            this.Tip2CBX.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.Tip2CBX.Location = new System.Drawing.Point(355, 49);
            this.Tip2CBX.Margin = new System.Windows.Forms.Padding(2);
            this.Tip2CBX.Name = "Tip2CBX";
            this.Tip2CBX.Size = new System.Drawing.Size(173, 21);
            this.Tip2CBX.TabIndex = 8;
            this.Tip2CBX.SelectedIndexChanged += new System.EventHandler(this.TurSecimDegisti2);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(53, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tür: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(324, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tür: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Kullanıcı Adı: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(286, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Kullanıcı Adı: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 154);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Veritabanı Adı: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(273, 154);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Veritabanı Adı: ";
            // 
            // Giris1BTN
            // 
            this.Giris1BTN.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Giris1BTN.ForeColor = System.Drawing.Color.Black;
            this.Giris1BTN.Location = new System.Drawing.Point(86, 124);
            this.Giris1BTN.Margin = new System.Windows.Forms.Padding(2);
            this.Giris1BTN.Name = "Giris1BTN";
            this.Giris1BTN.Size = new System.Drawing.Size(174, 23);
            this.Giris1BTN.TabIndex = 5;
            this.Giris1BTN.Text = "Giriş Yap";
            this.Giris1BTN.UseVisualStyleBackColor = false;
            this.Giris1BTN.Click += new System.EventHandler(this.Giris1BTN_Click);
            // 
            // BaslatBTN
            // 
            this.BaslatBTN.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BaslatBTN.ForeColor = System.Drawing.Color.Black;
            this.BaslatBTN.Location = new System.Drawing.Point(11, 176);
            this.BaslatBTN.Margin = new System.Windows.Forms.Padding(2);
            this.BaslatBTN.Name = "BaslatBTN";
            this.BaslatBTN.Size = new System.Drawing.Size(523, 30);
            this.BaslatBTN.TabIndex = 14;
            this.BaslatBTN.Text = "Başlat";
            this.BaslatBTN.UseVisualStyleBackColor = false;
            this.BaslatBTN.Click += new System.EventHandler(this.BaslatBTN_Click);
            // 
            // Giris1SunucuAdiTBX
            // 
            this.Giris1SunucuAdiTBX.BackColor = System.Drawing.Color.Silver;
            this.Giris1SunucuAdiTBX.Location = new System.Drawing.Point(86, 24);
            this.Giris1SunucuAdiTBX.Name = "Giris1SunucuAdiTBX";
            this.Giris1SunucuAdiTBX.Size = new System.Drawing.Size(174, 20);
            this.Giris1SunucuAdiTBX.TabIndex = 1;
            this.Giris1SunucuAdiTBX.TextChanged += new System.EventHandler(this.SecimDegisti1);
            // 
            // Giris2SunucuAdiTBX
            // 
            this.Giris2SunucuAdiTBX.BackColor = System.Drawing.Color.Silver;
            this.Giris2SunucuAdiTBX.Location = new System.Drawing.Point(355, 24);
            this.Giris2SunucuAdiTBX.Name = "Giris2SunucuAdiTBX";
            this.Giris2SunucuAdiTBX.Size = new System.Drawing.Size(173, 20);
            this.Giris2SunucuAdiTBX.TabIndex = 7;
            this.Giris2SunucuAdiTBX.TextChanged += new System.EventHandler(this.SecimDegisti2);
            // 
            // KullaniciAdi2CBX
            // 
            this.KullaniciAdi2CBX.BackColor = System.Drawing.Color.Silver;
            this.KullaniciAdi2CBX.Location = new System.Drawing.Point(355, 75);
            this.KullaniciAdi2CBX.Name = "KullaniciAdi2CBX";
            this.KullaniciAdi2CBX.Size = new System.Drawing.Size(173, 20);
            this.KullaniciAdi2CBX.TabIndex = 9;
            this.KullaniciAdi2CBX.Text = "orcaAdmin";
            this.KullaniciAdi2CBX.TextChanged += new System.EventHandler(this.SecimDegisti2);
            // 
            // KullaniciAdi1CBX
            // 
            this.KullaniciAdi1CBX.BackColor = System.Drawing.Color.Silver;
            this.KullaniciAdi1CBX.Location = new System.Drawing.Point(86, 75);
            this.KullaniciAdi1CBX.Name = "KullaniciAdi1CBX";
            this.KullaniciAdi1CBX.Size = new System.Drawing.Size(174, 20);
            this.KullaniciAdi1CBX.TabIndex = 3;
            this.KullaniciAdi1CBX.TextChanged += new System.EventHandler(this.SecimDegisti1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Staj5.Properties.Resources.redtrans;
            this.pictureBox2.Location = new System.Drawing.Point(333, 127);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Staj5.Properties.Resources.redtrans;
            this.pictureBox1.Location = new System.Drawing.Point(64, 127);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(545, 214);
            this.Controls.Add(this.KullaniciAdi1CBX);
            this.Controls.Add(this.KullaniciAdi2CBX);
            this.Controls.Add(this.Giris2SunucuAdiTBX);
            this.Controls.Add(this.Giris1SunucuAdiTBX);
            this.Controls.Add(this.BaslatBTN);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tip2CBX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Tip1CBX);
            this.Controls.Add(this.VeritabaniListe2CBX);
            this.Controls.Add(this.VeritabaniListe1CBX);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Giris2SifreTBX);
            this.Controls.Add(this.Giris1SifreTBX);
            this.Controls.Add(this.Giris2BTN);
            this.Controls.Add(this.Giris1BTN);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Giris2BTN;
        private System.Windows.Forms.TextBox Giris1SifreTBX;
        private System.Windows.Forms.TextBox Giris2SifreTBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox VeritabaniListe1CBX;
        private System.Windows.Forms.ComboBox VeritabaniListe2CBX;
        private System.Windows.Forms.ComboBox Tip1CBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Tip2CBX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Giris1BTN;
        private System.Windows.Forms.Button BaslatBTN;
        private System.Windows.Forms.TextBox Giris1SunucuAdiTBX;
        private System.Windows.Forms.TextBox Giris2SunucuAdiTBX;
        private System.Windows.Forms.TextBox KullaniciAdi2CBX;
        private System.Windows.Forms.TextBox KullaniciAdi1CBX;
    }
}