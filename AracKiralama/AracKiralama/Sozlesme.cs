using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AracKiralama
{
    public partial class Sozlesme : Form
    {
        public Sozlesme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");
        private void Sozlesme_Ekle()
        {
            SqlDataAdapter dae1 = new SqlDataAdapter("SELECT * FROM Sozlesme_Ekle", baglanti);
            DataTable dte1 = new DataTable();
            dae1.Fill(dte1);
            dataGridView1.DataSource = dte1;
            baglanti.Close();
        }
        private void Sozlesme_Load(object sender, EventArgs e)
        {
            Sozlesme_Ekle();
            button1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double Odenecek_Fiyat = Convert.ToDouble(textBox2.Text);
            DateTime Alis_Tarihi = Convert.ToDateTime(textBox3.Text);
            DateTime Veris_Tarihi = Convert.ToDateTime(textBox4.Text);
            //string TC = Convert.ToString(textBox5.Text);
            //string Plaka = Convert.ToString(textBox6.Text);

            baglanti.Open();
            string MemberStr = "select Arac_ID from Arac_Kayit where Plaka=@Plaka";
            SqlCommand Member = new SqlCommand(MemberStr, baglanti);
            Member.Parameters.AddWithValue("@Plaka", textBox6.Text);
            SqlDataReader dr2 = Member.ExecuteReader();
            int Arac = 0;
            if (dr2.Read())
            {
                Arac = Convert.ToInt32(dr2["Arac_ID"]);
                //MessageBox.Show(ID.ToString());
                baglanti.Close();
            }
            baglanti.Close();
            baglanti.Open();
            string MemberStr2 = "select Musteri_ID from Musteri_Ekle where TC=@TC";
            SqlCommand Member2 = new SqlCommand(MemberStr2, baglanti);
            Member2.Parameters.AddWithValue("@TC", textBox5.Text);
            SqlDataReader dr22 = Member2.ExecuteReader();
            int Mus = 0;
            if (dr22.Read())
            {
                Mus = Convert.ToInt32(dr22["Musteri_ID"]);
                //MessageBox.Show(Mus.ToString());
                baglanti.Close();
            }
            baglanti.Close();



            SqlCommand komut = new SqlCommand($"INSERT INTO Sozlesme_Ekle(Arac_ID,Musteri_ID,Odenecek_Fiyat,Alis_Tarihi,VerisTarihi)  \r VALUES ({Arac},{Mus},{Odenecek_Fiyat} , '{Alis_Tarihi}' , '{Veris_Tarihi}')");


            komut.Connection = baglanti;
            baglanti.Open();
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                MessageBox.Show("Sözleşme kaydı yapıldı");
                Sozlesme_Ekle();
            }
            else
            {
                MessageBox.Show("Sözleşme kaydedilmedi");
                baglanti.Close();
            }
            eklenti2 = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string TC = Convert.ToString(textBox8.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"SELECT * FROM Musteri_Ekle WHERE TC='{textBox8.Text}'");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT * FROM Musteri_Ekle WHERE TC='{textBox8.Text}'", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Plaka = Convert.ToString(textBox7.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"SELECT * FROM Arac_Kayit WHERE Plaka='{textBox7.Text}'");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT * FROM Arac_Kayit WHERE Plaka='{textBox7.Text}'", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Plaka = Convert.ToString(textBox6.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"SELECT Gunluk_Kira_Ucreti FROM Arac_Kayit WHERE Plaka='{textBox6.Text}'");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT Gunluk_Kira_Ucreti as 'Günlük Kira' FROM Arac_Kayit WHERE Plaka='{textBox6.Text}'", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;
            baglanti.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Arac_ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Tıkladığın yerin ID'si YOK BİLADEEEERRRRRR");
            }
            textBox1.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            DateTime al = Convert.ToDateTime(textBox3.Text);
            DateTime ver = Convert.ToDateTime(textBox4.Text);
            TimeSpan gun = ver - al;
            string bu = gun.Days.ToString();
            double bu2 = Convert.ToDouble(bu);
            //int Kira_Suresi = ver - al;
            double kira = Convert.ToDouble(textBox1.Text);
            double toplam = bu2 * kira;
            textBox2.Text = Convert.ToString(toplam);
        }

        private void Sozlesme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Sozlesme_Leave(object sender, EventArgs e)
        {
            
        }

        private void Sozlesme_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://arackiralama.egm.gov.tr/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void label9_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
