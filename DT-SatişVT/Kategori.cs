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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-USHOI74\INSTALL;Initial Catalog=SatisVT;Integrated Security=True");
        private void btn_listele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Kategori", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Kategori (KategoriAd) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Eklendi.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
           
            {
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("delete from Kategori where KategoriId=@p1", baglanti);
                komut3.Parameters.AddWithValue("@p1", textBox2.Text);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori Silindi.");
            }
           

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update  Kategori set KategoriAd=@p1 where KategoriId=@p2", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox1.Text);
            komut3.Parameters.AddWithValue("@p2", textBox2.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori Güncellendi.");

        }
    }
}
//Data Source=DESKTOP-USHOI74\INSTALL;Initial Catalog=SatisVT;Integrated Security=True