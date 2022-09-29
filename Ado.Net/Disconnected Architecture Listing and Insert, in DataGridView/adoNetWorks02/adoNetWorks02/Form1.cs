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

namespace adoNetWorks02
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server=.;Database=Northwind;Integrated Security = true;");
        public Form1()
        {
            InitializeComponent();
        }//disconnected mimari ile connection
        //disconnected arka planda bağlantıyı açıp komutu çalışıp geriye değer dönünce bağlantıyı kapatır. Disconnectedda bağlantıyı biz kapatmayız

        private void Form1_Load(object sender, EventArgs e)
        {
            getProductList();
        }
        private void getProductList()
        {
            /*
            DataGridView kontrolü, bir data source ister o şekilde çalışır. 
            */


            // SqlDataAdapter adapter = new SqlDataAdapter();
            /*
             parantez açılınca ya da direk ctrl+sol tık
            SqlDataAdapter()
            SqlDataAdapter(SqlCommand selectCommand)
            SqlDataAdapter(string selectCommandText, string selectConnectionString)
             SqlDataAdapter(string selectCommandText, SqlConnection selectConnection)
            şeklinde overloadlarını görürüz
            SqlDataAdapter
            SqlCommand diyip parantez açıldıgıdna string olarak cmd text vardı ve bağlantı  yani overloadlarında nbiri şöyleydi
             SqlCommand sqlCommand = new SqlCommand("Select * from Categories",conn);
            SqlCommand da SqlCommand(string cmdText, SqlConnection connection) şeklinde overloadı var mesela cmdText
            oysa burada selectCommandText diyor yani insert update delete olmuyor select veriliyor adapterde.
            sql dataadapter nesnesiyle insert update delete yapılamazmı yapılır ama sqlDataAdapter de olsa sqlCommand da kullansak
            insert update ve delete işlemlerinde her seferinde elle bağlantı açılıp kapatılması lazım yani insert update delete te 
            disconnected bağlantı yok yani arka planda bağlantıyı açıp, kapatıcak yöntem yok sadece select te otomati kaçılıp kapanır
            oda sqldataadapter kullanılırsa öyle olur.
             */
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products", conn); //bı adaptör kendsi bağlantının oldugu yerde
            //arkaplanda bağlantıyı açıp kaaptrı , vermis oldugumuz selecti çalıstırır tablo çıktısı elde eder ve kapatır baglantıyı
            //
            DataTable dataTable = new DataTable(); //içerisinde tablo tutmayı sağlayan bir yapıdır
            adapter.Fill(dataTable); //fill metoduyla datatable içini doldurduk adaptör sorguyu exec edip bir tablo çıktısı elde etti
            //bu çıktıyı datatable a doldurduk
            dataGridView1.DataSource = dataTable;//datasource veri kaynagı verilemeliki içerisine elemanları listelesin
            //aynı sqldeki gibi tablo geldi, oto generate columns özelliği var datagridview in onu kapatsaydık kolonları açmicaktı
            //bu SqlDataAdapter ve buraya kadarı disconnnected mimari ile veri listelemedir.
            /*
             CategoryID vs kolonuda geldi bunları istemiyoruz, oto generate özelligi kapatıp kolonları kendimiz girebiliriz ama uzun sürer
            direk kolon gizleme özelligini kullanalım datagridview in 
             */
            dataGridView1.Columns["CategoryID"].Visible = false; //kolleksiyondur columns yani birden fazla elemean bulundurabilir içerisinde, istersek kolonun indexini istersek ismiyle verebilriiz
            //CategoryID indexine ulasıp visiple false yaptık
            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["SupplierID"].Visible = false;
            //aslında direk sorguda bunları istemeden listeledebilirdik ama güncelleme işleminde ID leri kullanmak istiyoruz
            //ID kolonlarıda olmalı yani silmedik sadece gizledik
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = prNameTextBox.Text;
            decimal price = unitPriceNumericUpDown.Value;
            int stock = Convert.ToInt32(stockNumericUpDown.Value);
            if(productName=="" || price ==null || stock == null)
            {
                MessageBox.Show("Doldurulmayan alan var");
                Application.Restart();
            }
            SqlCommand command = new SqlCommand();
            command.CommandText = string.Format("INSERT Products (ProductName, UnitPrice, UnitsInStock) Values('{0}',{1},{2})", productName
                , price, stock); //string formatla yazdık yani {} şeklinde kullanmalar yaptık
            //ekleme silme güncelleme işlemi ypaıaz her biri ayrı ayrı sql connection nesnesi tanımlamaya gerek yok global düzeye alırız connection
            //yani class düzeyine aldık bu classtaki metotlardan erişebiliriz artık
            command.Connection = conn;

            //select işleminde ExecuteReader kullanılır, insertte update ve delette ExecuteNonQuery kullanılabilir
            conn.Open(); //bağlantı açılmalı ekleme işlemi için 
            int etkilenenSatırSayısı = command.ExecuteNonQuery();
            /*
             System.Data.SqlClient.SqlException: 'Invalid column name 'garg'.'
                mesela ürün ismine garg girdim hatası verdi.
            sebebi şu textboxta direk yazıyor garg ı mesela hata geldiginde sorguyu breakpointle alalım 75. satırı
            command.CommandText = "INSERT Products (ProductName, UnitPrice, UnitsInStock) Values(garg,0,0)" şeklinde 
            "INSERT Products (ProductName, UnitPrice, UnitsInStock) Values(garg,0,0)" sql de yaz sorguyu çalısmaz çünkü ProductName nvarchar tipinde yani değeri ' ' içinde 
            olamlı
            o yüzden
                  command.CommandText = string.Format("INSERT Products (ProductName, UnitPrice, UnitsInStock) Values({0},{1},{2})",productName
                ,price,stock);  kısmında 
            ({0} kısmını ' ' arasına aldık 
             */
            //ExecuteNonQuery metodu int döner geriye kaç satır etkilendiği yani row effected 
            //yani biz bi insert yaptıgımzıda 1 row effecteddan 1 döner hata verirse 0 döner 
            if (etkilenenSatırSayısı > 0) //etkilnen 0  dan büyükse insert olmustur kayıt başarılı ynai
            {
                MessageBox.Show("Kayıt başarıyla eklenmiştir.");
                //kayıt başırıyla eklenirse db table güncelleniyor ama datagridview table güncel hali yok çünk ükayıttan önceki halini listelidk. o yüzden tabloyu bidaha listelemeliyiz
                getProductList();
            }
            else
            {
                MessageBox.Show("Kayıt ekleme başarısız olmuştur.");
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.Show();
        }
    }
}
