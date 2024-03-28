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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btn_kategoriler_Click(object sender, EventArgs e)
        {
            Kategori fr = new Kategori();
            fr.Show();
        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            Musteri fr2 = new Musteri();
            fr2.Show();
        }

    

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-USHOI74\INSTALL;Initial Catalog=SatisVT;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // ürün seviyesi
            SqlCommand komut = new SqlCommand("Execute Test4",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //grafiğe veri çekme

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select KategoriAd, count(*) from Kategori inner join Urunler on Kategori.KategoriId=Urunler.Kategori group by KategoriAd ", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
               
            }
            baglanti.Close();
        }
    }
}
