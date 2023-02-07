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

namespace Stajj
{
    public partial class StajX : Form
    {
        public StajX()
        {
            InitializeComponent();
        }
        void temizle()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13.Text = "";
            txt1.Focus();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\FALCONX;Initial Catalog=Staj;Integrated Security=True");
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stajDataSet1.Stajeks' table. You can move, or remove it, as needed.
            this.stajeksTableAdapter1.Fill(this.stajDataSet1.Stajeks);
            // TODO: This line of code loads data into the 'stajDataSet.Stajeks' table. You can move, or remove it, as needed.
           

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into  Stajeks (Adi, Soyadi,Sehir,İlce,FirmaAdi,FirmaAlani,OkulNumarasi,TC,Telefon,StajaBaslamaTarihi,StajBitisTarihi,StajYapilanGunSayisi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt1.Text);
            komut.Parameters.AddWithValue("@p2", txt2.Text);
            komut.Parameters.AddWithValue("@p3", txt3.Text);
            komut.Parameters.AddWithValue("@p4", txt4.Text);
            komut.Parameters.AddWithValue("@p5", txt5.Text);
            komut.Parameters.AddWithValue("@p6", txt6.Text);
            komut.Parameters.AddWithValue("@p7", txt7.Text);
            komut.Parameters.AddWithValue("@p8", txt8.Text);
            komut.Parameters.AddWithValue("@p9", txt9.Text);
            komut.Parameters.AddWithValue("@p10",txt10.Text);
            komut.Parameters.AddWithValue("@p11",txt11.Text);
            komut.Parameters.AddWithValue("@p12",txt12.Text);
            
          

            komut.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("Öğrenci Eklendi ");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txt14.Text = "";
            this.stajeksTableAdapter1.Fill(this.stajDataSet1.Stajeks);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Stajeks where Adi like '%" + txt14.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            btn6.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from Stajeks where Sira=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", txt13.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi ");
            
               
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = btn6.SelectedCells[0].RowIndex;
            txt13.Text = btn6.Rows[secim].Cells[0].Value.ToString();
            txt1.Text = btn6.Rows[secim].Cells[1].Value.ToString();
            txt2.Text = btn6.Rows[secim].Cells[2].Value.ToString();
            txt3.Text = btn6.Rows[secim].Cells[3].Value.ToString();
            txt4.Text = btn6.Rows[secim].Cells[4].Value.ToString();
            txt5.Text = btn6.Rows[secim].Cells[5].Value.ToString();
            txt6.Text = btn6.Rows[secim].Cells[6].Value.ToString();
            txt7.Text = btn6.Rows[secim].Cells[7].Value.ToString();
            txt8.Text = btn6.Rows[secim].Cells[8].Value.ToString();
            txt9.Text = btn6.Rows[secim].Cells[9].Value.ToString();
            txt10.Text = btn6.Rows[secim].Cells[10].Value.ToString();
            txt11.Text = btn6.Rows[secim].Cells[11].Value.ToString();
            txt12.Text = btn6.Rows[secim].Cells[12].Value.ToString();
            


        }

        private void btn4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Stajeks Set Adi=@p1, Soyadi=@p2,Sehir=@p3,İlce=@p4,FirmaAdi=@p5,FirmaAlani=@p6,OkulNumarasi=@p7,TC=@p8,Telefon=@p9,StajaBaslamaTarihi=@p10,StajBitisTarihi=@p11,StajYapilanGunSayisi=@p12 where Sira=@p13", baglanti);
            guncelle.Parameters.AddWithValue("@p1", txt1.Text);
            guncelle.Parameters.AddWithValue("@p2", txt2.Text);
            guncelle.Parameters.AddWithValue("@p3", txt3.Text);
            guncelle.Parameters.AddWithValue("@p4", txt4.Text);
            guncelle.Parameters.AddWithValue("@p5", txt5.Text);
            guncelle.Parameters.AddWithValue("@p6", txt6.Text);
            guncelle.Parameters.AddWithValue("@p7", txt7.Text);
            guncelle.Parameters.AddWithValue("@p8", txt8.Text);
            guncelle.Parameters.AddWithValue("@p9", txt9.Text);
            guncelle.Parameters.AddWithValue("@p10", txt10.Text);
            guncelle.Parameters.AddWithValue("@p11", txt11.Text);
            guncelle.Parameters.AddWithValue("@p12", txt12.Text);
            guncelle.Parameters.AddWithValue("@p13", txt13.Text);

            guncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Öğrenci Güncellenmesi Tamamlandı ");
        }

        private void btn5_Click(object sender, EventArgs e)
        {

            temizle();
            }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Stajeks where Adi like '%" + txt14.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            btn6.DataSource = ds.Tables[0];
            baglanti.Close();
           
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 git = new Form4();
            git.Show();
           
        }
    }
    }
    

