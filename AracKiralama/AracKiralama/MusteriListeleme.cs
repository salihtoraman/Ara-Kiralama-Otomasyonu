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
    public partial class MusteriListeleme : Form
    {
        public MusteriListeleme()
        {
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");
        private void Guncelleme()
        {
            SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM Musteri_Ekle", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();

        }
        public void button1_Click(object sender, EventArgs e)
        {
           

            int Musteri_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            double Telefon = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value);
            string Adres = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            string Mail = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            double KrediKartNo = Convert.ToDouble(dataGridView1.CurrentRow.Cells[12].Value);
            DateTime GecerlilikTarih = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[13].Value);
            
            int CVV = Convert.ToInt32(dataGridView1.CurrentRow.Cells[14].Value);

            baglanti.Open();
            SqlCommand komut = new SqlCommand($"UPDATE Musteri_Ekle SET Telefon = {textBox3.Text} , Adres = '{textBox4.Text}' , Mail = '{textBox7.Text}' , KrediKartNo = '{textBox10.Text}' , GecerlilikTarih = '{"01." + comboBox1.Text + "." + comboBox2.Text}' , CVV = {textBox8.Text}  WHERE Musteri_ID = {Musteri_ID}");

            komut.Connection = baglanti;
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                
                Guncelleme();
                MessageBox.Show("Müşteri Bilgisi Güncellendi");
                //baglanti.Close();
               
            }
            else
            {
                MessageBox.Show("Müşteri Bilgisi Güncellenmedi");
                baglanti.Close();
            }
            Guncelleme();
            eklenti2 = 0;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int Musteri_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"DELETE Musteri_Ekle WHERE Musteri_ID = '{Musteri_ID}'", baglanti);
            komut.Connection = baglanti;
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                MessageBox.Show("Müşteri Silindi");
                Guncelleme();
            }
            else
            {
                MessageBox.Show("Müşteri Silinmedi");
                baglanti.Close();
            }
            eklenti2 = 0;
        }
        private void MusteriListeleme_Load(object sender, EventArgs e)
        {
            Guncelleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DateTime GecerlilikTarih = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[13].Value);
            //MessageBox.Show(GecerlilikTarih.ToString("yyyy-MM"));
            //string BirthDate = dTP_BirthDay.Value.ToString("yyyy-MM-dd");
            try
            {
                int Musteri_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Tıkladığın yerin ID'si YOK BİLADEEEERRRRRR");
            }
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefon"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Adres"].Value);
            textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Mail"].Value);
            textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["KrediKartNo"].Value);
            string tar = Convert.ToString(dataGridView1.CurrentRow.Cells["GecerlilikTarihi"].Value);
            if (tar.Length>18)
            {
                string ay = tar.Substring(tar.Length - 19, 1) + tar.Substring(tar.Length - 18, 1);
                string yil = tar.Substring(tar.Length - 11, 1) + tar.Substring(tar.Length - 10, 1);
                comboBox1.Text = Convert.ToString(ay);
                comboBox2.Text = Convert.ToString(yil);
            }
            else
            {
                string ay = "0"+tar.Substring(tar.Length - 18, 1);
                string yil = tar.Substring(tar.Length - 11, 1) + tar.Substring(tar.Length - 10, 1);
                comboBox1.Text = Convert.ToString(ay);
                comboBox2.Text = Convert.ToString(yil);
            }
            //string ay = tar.Substring(tar.Length - 19, 1) + tar.Substring(tar.Length - 18, 1);
            //string yil = tar.Substring(tar.Length -11, 1)+tar.Substring(tar.Length - 10, 1);
            //comboBox1.Text = Convert.ToString(ay);
            //comboBox2.Text = Convert.ToString(yil);
            textBox8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["CVV"].Value);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            string TC = Convert.ToString(textBox1.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"select *from Musteri_Ekle where TC='{textBox1.Text}'");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT * FROM Musteri_Ekle WHERE TC = '{textBox1.Text}'", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MusteriListeleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
