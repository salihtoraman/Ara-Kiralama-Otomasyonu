using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AracKiralama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriEkleme ar = new MusteriEkleme();
            this.Hide();
            ar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MusteriListeleme ml = new MusteriListeleme();
            this.Hide();
            ml.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            AracKayıt ar = new AracKayıt();
            this.Hide();
            ar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Arac_Listeleme al = new Arac_Listeleme();
            this.Hide();
            al.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Sozlesme frm = new Sozlesme();
            this.Hide();
            frm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://hgsmusteri.ptt.gov.tr/hgs.jsf");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.turkiye.gov.tr/emniyet-arac-plakasina-yazilan-ceza-sorgulama");
        }
    }
}
