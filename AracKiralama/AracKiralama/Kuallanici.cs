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
    public partial class Kuallanici : Form
    {
        public Kuallanici()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");

        public int ID { get; set; }
        public string Kullanici_Ad { get; set; }
        public string Sifre { get; set; }
        public void kullanici()
        {


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand komut = new SqlCommand("select *from Kullanici", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            List<Kuallanici> products = new List<Kuallanici>();
            while (reader.Read())
            {
                Kuallanici pr = new Kuallanici
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Kullanici_Ad = reader["Kullanici_Ad"].ToString(),
                    Sifre = reader["Sifre"].ToString()
                };
                products.Add(pr);
                

            }
            reader.Close();
            if (Kullanici_Ad=="sa" && Sifre == "123")
            {
                Form1 frm = new Form1();
                this.Hide();
                frm.Show();

            }
            baglanti.Close();
            
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand komut = new SqlCommand("select *from Kullanici", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            List<Kuallanici> products = new List<Kuallanici>();
            while (reader.Read())
            {
                Kuallanici pr = new Kuallanici
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Kullanici_Ad = reader["Kullanici_Ad"].ToString(),
                    Sifre = reader["Sifre"].ToString()

                };
                products.Add(pr);
                if (pr.Kullanici_Ad == textBox1.Text && pr.Sifre == textBox2.Text)
                {
                    Form1 frm = new Form1();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Yanlış kullanıcı adı veya şifre!");
                }

            }
            reader.Close();
            baglanti.Close();
        }
    }
}
