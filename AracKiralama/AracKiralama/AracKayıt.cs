using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AracKiralama
{
    public partial class AracKayıt : Form
    {
        public AracKayıt()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");

        private void AracEkle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Arac_Kayit", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        private void AracKayıt_Load(object sender, EventArgs e)
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
            string Plaka = Convert.ToString(textBox1.Text);
            string Marka = Convert.ToString(textBox2.Text);
            string Model = Convert.ToString(textBox3.Text);
            string Yil = Convert.ToString(textBox4.Text);
            string Renk = Convert.ToString(textBox5.Text);
            string Yakit = Convert.ToString(textBox6.Text);
            int Gunluk_Kira_Ucreti = Convert.ToInt32(textBox7.Text);
            DateTime Sigorta_Bitis_Tarihi = Convert.ToDateTime(textBox8.Text);
            DateTime Muayne_Bitis_Tarihi = Convert.ToDateTime(textBox9.Text);
            string Resim = Convert.ToString(pictureBox1.ImageLocation);

            SqlCommand komut = new SqlCommand($"INSERT INTO Arac_Kayit(Plaka,Marka,Model,Yil,Renk,Yakit,Gunluk_Kira_Ucreti,Sigorta_Bitis_Tarihi,Muayne_Bitis_Tarihi,Resim) \r VALUES ('{Plaka}' ,'{Marka}' , '{Model}' , '{Yil}' , '{Renk}' , '{Yakit}' , {Gunluk_Kira_Ucreti} , '{Sigorta_Bitis_Tarihi}' , '{Muayne_Bitis_Tarihi}' , '{Resim}')");
            komut.Connection = baglanti;
            baglanti.Open();
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                MessageBox.Show("Araç kayıt yapıldı");
                AracEkle();
            }
            else
            {
                MessageBox.Show("Hatalı kayıt");
                baglanti.Close();
            }
            eklenti2 = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            pictureBox1.ImageLocation = ofd.FileName;
        }

        private void AracKayıt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
