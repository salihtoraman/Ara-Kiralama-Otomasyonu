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

namespace AracKiralama
{
    public partial class MusteriEkleme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");
        public MusteriEkleme()
        {
            InitializeComponent();
        }

        private void MusteriEkle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Musteri_Ekle", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double TC = Convert.ToDouble(txtTc.Text);
            string AdSoyad = Convert.ToString(txtAdSoyad.Text);
            double Telefon = Convert.ToDouble(txtTelefon.Text);
            string Adres = Convert.ToString(txtAdres.Text);
            string Mail = Convert.ToString(txtMail.Text);
            DateTime DogumTarihi = Convert.ToDateTime(txtDogumTarihi.Text);
            string DogumYeri = Convert.ToString(txtDogumYeri.Text);
            string EhliyetNo = Convert.ToString(txtEhliyetNo.Text);
            DateTime AlisTarihi = Convert.ToDateTime(txtAlısTarihi.Text);
            string AlisYeri = Convert.ToString(txtAlısYeri.Text);
            DateTime EhGecerlilikTarihi = Convert.ToDateTime(txtEhGecerlilikTarihi.Text);
            double KrediKartNo = Convert.ToDouble(txtKartNo.Text);
            DateTime GecerlilikTarihi = Convert.ToDateTime("01."+comboBox1.Text +"."+ comboBox2.Text);
            string CVV = Convert.ToString(txtCVV.Text);

            SqlCommand komut = new SqlCommand($"INSERT INTO Musteri_Ekle(TC,AdSoyad,Telefon,Adres,Mail,DogumTarihi,DogumYeri,EhliyetNo,AlisTarihi,AlisYeri,EhGecerlilikTarihi,KrediKartNo,GecerlilikTarihi,CVV) \r VALUES ({txtTc.Text} ,'{txtAdSoyad.Text}' , {txtTelefon.Text} , '{txtAdres.Text}' , '{txtMail.Text}' , '{txtDogumTarihi.Text}' , '{txtDogumYeri.Text}' , '{txtEhliyetNo.Text}' , '{txtAlısTarihi.Text}' , '{txtAlısYeri.Text}', '{txtEhGecerlilikTarihi.Text}' , {txtKartNo.Text} , '{"01." + comboBox1.Text + "." + comboBox2.Text}' , '{txtCVV.Text}')");

            komut.Connection = baglanti;
            baglanti.Open();
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                MessageBox.Show("Müşteri eklendi");
                MusteriEkle();
            }
            else
            {
                MessageBox.Show("Müşteri Eklenemedi");
                baglanti.Close();
            }
            eklenti2 = 0;
        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MusteriEkleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
