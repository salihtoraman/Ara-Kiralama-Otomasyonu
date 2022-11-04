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
    public partial class Arac_Listeleme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = .; Initial Catalog = AracKiralama; user = sa; password = 1234");
        public Arac_Listeleme()
        {
            InitializeComponent();
        }
        private void AracGuncelleme()
        {
            SqlDataAdapter daa = new SqlDataAdapter("SELECT * FROM Arac_Kayit", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string TC = Convert.ToString(textBox1.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"SELECT * FROM Arac_Kayit WHERE Plaka='{textBox1.Text}'");
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlDataAdapter daa = new SqlDataAdapter($"SELECT * FROM Arac_Kayit WHERE Plaka='{textBox1.Text}'", baglanti);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView1.DataSource = dtt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Arac_ID= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string Plaka = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            int Gunluk_Kira_Ucreti  = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
            DateTime Sigorta_Bitis_Tarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value);
            DateTime Muayne_Bitis_Tarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[10].Value);

            baglanti.Open();
            SqlCommand komut = new SqlCommand($"UPDATE Arac_Kayit SET Gunluk_Kira_Ucreti = {textBox3.Text} , Sigorta_Bitis_Tarihi = '{textBox4.Text}' , Muayne_Bitis_Tarihi = '{textBox7.Text}'");

            komut.Connection = baglanti;
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {

                AracGuncelleme();
                MessageBox.Show("Araç Bilgileri Güncellendi");

            }
            else
            {
                MessageBox.Show("Araç Bilgisi Güncellenmedi");
                baglanti.Close();
            }
            AracGuncelleme();
            eklenti2 = 0;
        }

        private void Arac_Listeleme_Load(object sender, EventArgs e)
        {
            AracGuncelleme();
            //DataGridViewImageColumn kolon1 = new DataGridViewImageColumn();
            //dataGridView1.Columns.Add(kolon1);
            //dataGridView1.Rows[10].Cells[dataGridView1.Columns.Count - 1].Value = Image.FromFile("images/Koala.jpg");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Arac_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {
                MessageBox.Show("Tıkladığın yerin ID'si YOK BİLADEEEERRRRRR");
            }
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Gunluk_Kira_Ucreti"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Sigorta_Bitis_Tarihi"].Value);
            textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Muayne_Bitis_Tarihi"].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Arac_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            SqlCommand komut = new SqlCommand($"DELETE Arac_Kayit WHERE Arac_ID = '{Arac_ID}'", baglanti);
            komut.Connection = baglanti;
            int eklenti2 = komut.ExecuteNonQuery();
            baglanti.Close();

            if (eklenti2 > 0)
            {
                MessageBox.Show("Araç Kaydı Silindi");
                AracGuncelleme();
            }
            else
            {
                MessageBox.Show("Araç Kaydı Silinmedi");
                baglanti.Close();
            }
            eklenti2 = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Arac_Listeleme_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }
    }
}
