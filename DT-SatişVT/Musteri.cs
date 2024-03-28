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
namespace DT_SatişVT
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-USHOI74\INSTALL;Initial Catalog=SatisVT;Integrated Security=True");

        void Listele()
        {
            SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void Musteri_Load(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from iller", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                CmbSehir.Items.Add(dr["sehir"]);
            }
            baglanti.Close();
        }
        

        private void btn_listele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Musteri (MusteriAd,MusteriSoyad,MusteriSehir,MusteriBakiye) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", TextAd.Text);
            komut.Parameters.AddWithValue("@p2", TextSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TextBakiye.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Eklendi.");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextId.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TextAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TextSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TextBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("delete from Musteri where MusteriId=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TextId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Silindi.");
            Listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Musteri set  MusteriAd=@p1, MusteriSoyad=@p2, MusteriSehir=@p3, MusteriBakiye=@p4 where MusteriId=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", TextAd.Text);
            komut.Parameters.AddWithValue("@p2", TextSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TextBakiye.Text));
            komut.Parameters.AddWithValue("@p5", TextId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Güncellendi.");
            Listele();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Musteri where musteriad=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", TextAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
