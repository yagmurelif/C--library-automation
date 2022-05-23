using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//veritabanı için
using System.Text.RegularExpressions; //güvenli parola
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection
         ("Provider= Microsoft.Ace.Oledb.12.0 ; Data Source= Database2.accdb");
        private void kitap_goster()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter kullanicilari_listele = new OleDbDataAdapter
                    ("select kodu AS[KİTAP KODU], kategori AS[KİTAP KATEGORİSİ], kitap_adi AS[KİTAP ADI] , yazar AS[KİTAP YAZARI], basim_yer_tarih AS[BASIM YERİ ve TARİHİ], isbn_no AS[İSBN] from kitap ", baglantim);

                DataSet dshafiza = new DataSet();
                kullanicilari_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();


            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "KARE HATA MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();

            }
        }

        private void combo()
        {
            try
            {
                
                OleDbCommand komut = new OleDbCommand();
                komut.CommandText = "SELECT *from kitap";
                komut.Connection = baglantim;
                komut.CommandType = CommandType.Text;
                OleDbDataReader dr;
                baglantim.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["kitap_adi"]);
                }
                baglantim.Close();
              
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "KARE HATA MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            kitap_goster();
            combo();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length == 5)
            {

                baglantim.Open();
                OleDbCommand selectSorgu = new OleDbCommand("select * from kitap where kodu= '" + maskedTextBox1.Text + "'", baglantim);

                OleDbDataReader kayit_okuma = selectSorgu.ExecuteReader();
                while (kayit_okuma.Read())
                {
                    kayit_arama_durumu = true;
                    
                    maskedTextBox1.Text = kayit_okuma.GetValue(0).ToString();
                    comboBox3.Text = kayit_okuma.GetValue(1).ToString();
                    comboBox2.Text = kayit_okuma.GetValue(2).ToString();
                    maskedTextBox3.Text = kayit_okuma.GetValue(3).ToString();
                    maskedTextBox5.Text = kayit_okuma.GetValue(4).ToString();
                    maskedTextBox4.Text = kayit_okuma.GetValue(5).ToString();
                   
                    break;
                }
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Aranan Kayit Bulunamadı!!!", "Ulusal Kutup Bilim Seferi ve Faaliyetleri Kişi Veri Tabanı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                baglantim.Close();

            }
            else if ()



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
