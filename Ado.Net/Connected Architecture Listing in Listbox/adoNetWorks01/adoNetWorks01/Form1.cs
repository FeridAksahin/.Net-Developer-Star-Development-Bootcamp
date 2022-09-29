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

namespace adoNetWorks01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //veritabanı bağlantısı olmalı c#ta sqlconnection sınıfını kullanarak bağlanırız
            SqlConnection conn = new SqlConnection(); //tipi sqlConnection olan bir nesne açtık 
            //bu veritabanı ile bağlantı kurmamızı sağlicak nesne
            conn.ConnectionString = "Server=.;Database=Northwind;Integrated Security = true;"; //integrated security windows authenticaion bağlan demek
                /*ConnectionString bağlantı cümlesidir, app ile db arasındaki bağlantıyı sağlicak cümle string tipinde değer ister
                strng propertydr
            conn.ConnectionString = "Server=localhost;Database=Northwind;User=sa;Pwd=123"; sql authentication ile bağlanma
                 sql server authentication lada bağlanılabilir kullanıcı adı ve pass lazım
                ama biz windows authentication ile bağlanıcaz user parola gerekmez

            uzaktaki bir server bağlanılcaksa o server windows atuhenticaton kabul etmez  dolayısıyla user ve pass verilmeli
                 */

            //c# ta sql query leri yazmak için SqlCommand kullanılır
            SqlCommand cmd = new SqlCommand(); //dbde çalısılcak komutu yazarız select * from Employees gibi 2. olarak hangi servera gidilcek onun bilgisi verilir
            //yani bu komutu hangi db de çalısıtırılcak
            cmd.CommandText = "select * from Employees Where FirstName is not null";//komut metnidir, 
            cmd.Connection = conn; //Connection üzerine gelindiğinde SqlConnection tipinde nesne ister, conn zaten SqlConnection tipinde burada
            //conn cümlesindeki db ye git yani ConnectionStringteki Northwindde cmd.CommandText te bulunan sorguyu çalıstır demiş olduk
            //ama henüz çalıstırtmadık sadece ne yapcagını söyledik
            //komutları çalıstırmak için sqlde exec yaprdık ctrl+e ile buradada exec etmeliyiz, execute etmenin çeşitleri var. cmd.E yazdıgında görünüyor
            //bu execlerin hepsi farklı işlere yarıyor
            //cmd.ExecuteReader();//şuan reader ı kullandık çalıstır ve oku yani bu metot SqlDataReader tipinde üzerine geldiignde gözüküyor 
            // o zaman şöyle yapabiliriz
            conn.Open();    
            SqlDataReader sqlDataReader = cmd.ExecuteReader(); //ExecuteReader metodu zaten SqlDataReader dönüyor dolayısıyla gelen değeri SqlDataReader nesnesine atabiliriz
            //cmd yi ExecuteReader ile çalıstır dönen değeri sqlDataReader a eşitle dedik yani. yani bütün tablo bi veridir aslında bu verileri sqlDataReader a atadık
            //şimdi bu komutu çalıstırmak için sql bağlantısını açmalıyız, 
            /*
             cmd yi çalıs demeden önce bağlantıyı açmalıyız
            komut ne Select * from Employees
            sqle gider connection nesne ister, connection dogruysa bağlantıyı açmalıyız sonra sorgu çalısır, select * from Employees çalısır geriye dönen
            değerleri alır dataları sonra tekrar çıkılır yani bağlantı kapanır
            yani komutu çalıstırmadan önce bağlantı açılır, çıktıktan sorna bağlantı kapanır o yüzden 
            SqlDataReader sqlDataReader = cmd.ExecuteReader();  den ön ce bağlantıyı açmalıyız open ile
            bağlantıyı açtıktan sonra ExecuteReader ile komutu çalıstırıp geriye dnen değerleri sqlDataReader nesnesine attık
            şimdi Employeeste birsürü satır var tabloda bu tüm satırları her employeeyi listboxa atamak istiyoruz
            yani her veride dönmeliyiz, foreach gibi düşün
            while döngüsü kullanabiliriz
             *///Read() metodu üzerine geldiğinde bool döndürür odlugu görünür. yani bir sonraki sırada eleman varsa true döner while içine girer yoksa false döner whilea girmez
   
            while (sqlDataReader.Read()) //burda sunu demiş olduk sqlDataReader içerisindeki verileri okumaya başla dedik. datareaderımızın içinde tablodaki tüm datalar mevcut tüm satırlar
                //yani tablodaki tüm satırları tek tek okuycak, mesela ilk satırı okduu sonra while bida döner 2. satırı okur ta ki tüm satırlar bitene kadar tablodaki
                //tablo içinde kaç satır varsa o kadar döner while, sqle gitsek sağ altta row sayısı gözüküyor, satırları tablodaki sıraya göre okur
            {
                string FirstName = sqlDataReader["FirstName"].ToString();/*[] açtıgımız anda 2 kullanım şekli oldugu görünür, int i demis i nin açıklamasında zero based column ordinal yazar
                                                   yani çekmek istedigin kolonun index numarasını ver ilk kolon indexi 0 sayılır 2. si 1 diziler index mantıgı
                    diğer kullanım şekli için sol tık yap açılan o info kutusunda string name diyor ya da, açıklamasında column name diyor
                    yani sütünun ismini gireriz çekmek istiegimiz*/
                string LastName = sqlDataReader["LastName"].ToString();// sqlde sütunların veri tipleri neyse ona göre değişkenleri açıyoruz. object türünde data bun stringe çevirmeliyiz
                int EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]); //int oldugundan int e çevirirz. 
               /* listBox1.Items.Add(FirstName);
                listBox1.Items.Add(LastName);
                listBox1.Items.Add(EmployeeID);*/
              listBox1.Items.Add(string.Format("{0}-{1}-{2}", FirstName, LastName, EmployeeID)); //yada direk böylede atayabiliriz
               /*
                while döngüsünde okuma işlemi devam eder o yüzden whiledan önce bağlantı kapatırsak, hata verir bağlantı açık olmalı hala yani
                */
            }
            //whiledan sorna bğlantıyı kapatmalıyız
            /*
             bağlantıyı kapatmasak olur, başka bir iş yaparsak bide connectio naçıp open dersen app hata verir bağlantı zaten açık diye ve kapatılmazsa bağlantı
            sızıntı olabilir güvensizdir, açılan bağlantı hep kapatılmalı yani
             */
            conn.Close();

            /*
             adonet te veri listelemek için 2 yöntem vardır 
            birisi connected mimari -> veri listelemek için bir tane connectionstring tanımlanır ve bağlantı açılrı open ile bağltıyı açıp sorguyu 
            çalısıtrıp kapattıgımız yöntem connected mimaridir
            diğeri disconnected mimari -> bunda ise bağlantıyı açıp kapatmak gerekmez  ama bu sadece listeleme işleminde geçerli komutu çalıstır dedigimizde
            arka plandan bağlantıyı açar komutu çalıstırır verileri getirir bağlantıyı kendisi kapatıcak otomatik
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryForm c = new CategoryForm();
            c.Show();
        }
    }
}

//-----------------DERS NOTLARI

/*
           Activities data object - ADO.NET
          UI tarafı dallandırırız, db dedigimzi tarafı dallandırırız
          mesela db tarafında mssql ya da oracle mysql ne varsa bunlar markalardır birde bunların dilleri vardır
          msssql, tsql vs
          biz msssqlde transact sql tsql kullanıyoruz
          UI tarafında winform, console app, web web içinde asp.net tut normal mvc ya da core mvc kadar bir sürü teknoloji var
          UI nda ne oldugu önemli degil bizim datalarımız ado nette tutuluyor burada kullanıyoruz uı da.

          biz mssql kullanıyoruz dolayısıyla tsql kullanıyıoruz, adonet c# la dataları tutar
          tsql anlamaz dolayısıyla çevirici olarak ORM kullanır yani object relitoanal mapping
          yani bir objeyi ilişkisel olarak mapleme
          c#ta tsql i convert eder birbirine uygular
          yani karışına cıkıcak bu aşamada c#microsoft için söylüyoruz
          Entity framework, Nhibernate bu ikisi orm toolstur.
          entity framework ve nhibernate bizim için orm demektri
          db tarafındaki datayı uı tarafıdna ihtiyaç duyuldugunda datayı yollamaktır sqle başvurup
          bunu ise ado.net ile sağlanır
          adonet entity framework arkasında kullanılır. ef nin adonet destekli bir frameworktür.
          sektör microsoft ise ef kullanır
          yani nhibernate bakmana gerek yok
          bizim prjenin tamamı ef hatta codeefirst
          adonet çok az kullanılır ama adonet bilmeyen efde yapamaz

          adonet -> 2 komut iblinmeli, sqlconnection sqlcommand
          adonet kendi içinde 2 ye ayrılır -> connected architecture, disconnected architecture
          disconnected anında iletişim sağlayamayacaıgımız yöntemdir
          adaptör vs kullanılırsa disconected
          sqlconnection ya da command ise connecteed mimari
          datayı anında saklamak isteriz genel anlamda dolayısıyla projeelr conencted çalısır genlde

          sql connection ya da sql command mirariları connected teknoloji çalısıtıgımız ıbelirtir gibi
          sql connection tüm adres bilgileridir data nerede ev adresi gibi
          sql connectionda bir adres tutulmalı bu datanın nerede tutulcagını belirten adrestir
          sqlde ilk açıldıgında gelen ekran o kutu tamamı sql connection nesnesidir sql conectiondır

          mesela windows auete seçerseç login pass girmez
          ama sql server auth dersek login pass gireriz
          iki türlüde bağlanabiliriz
          mesela sql server auth seçtik login pass gireriz yetkimiz varsa dolayısıyla sql connection da değişir
          mesela girdik
          sorgu ekranı açma vs connectino stringtir
          ama en zaman ki sorgu yazdık selct insert vs o zaman bunlar sql command tır
          SqlConnection nesnesi system.data sql in altında mssql kullanıdgımıza işaret
          oracle kullansal sqlconnection kullanılmaz oracle nesnesi yüklenmeli
           */



/*
         SqlConnection conn = new SqlConnection("");
            conn.ConnectionString = ""; //bağlantı cümlecigidir burası ezberlemene greek yok "" içini internetten bak
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = "";
            sb.InitialCatalog = "Northwind";
            sb.UserID = "sa";
            sb.Password = "123";
            // conn.ConnectionString = sb.ToString(); connection stringi builderla alıp böylede bağlanabiliriz
            //SqlCommand sqlCommand = new SqlCommand("select * from Employees",conn); böylede komut kullanılabilir
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Employees";
            cmd.CommandType = CommandType.Text; //defaultu texttir, text seçilirse insert update delete select vs çalıştırılır
            //
          //  conn.Open(); //connectionu açtık sonra exec edilmeli ama birden fazla open edilirse hata olur zaten açık o yüzden if
           if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

           //select çekip tablo geliyorsa farklı exec olur insertte mesela farklı exec olur
            cmd.ExecuteNonQuery();// exec etmeliyiz commandı çalısması için. // metot üzerine geldiginde acıklaması var effected olan row sayısını verir
            //hata verir
            //eğer sorgunun cevabı mssqlde bir tablo döndürürse exec türü executeReader olmak zorunda
           
            cmd.ExecuteReader();
            try
            {
                int etkilenenSatirSayisi = cmd.ExecuteNonQuery(); 
                object tekSutunTekKolon = cmd.ExecuteScalar(); //scalar obje döner
                SqlDataReader rdr = cmd.ExecuteReader();     //gelen datayı şöyle alaiblirz
                if (rdr.HasRows) //rdr satırları varmı 
                {
                    while (rdr.Read())
                    {
                        rdr.GetString(0); //burada kolon söylüyoruz mesela shipper tablosu ilk kolonu olan ıd yi verir ve string olarak 
                        rdr.GetInt64(1); //shipper tablosunda mesela 1. kolondakikni int olur ama kargo adı mesela geliyor string to int olmaz hata verir satır
                        //hepsini böyle getstring, getint vs kullanılabilri ama rdr nin kendi içerisinde 
                        string s = rdr["CompanyName"].ToString(); //böylede kullanılabilir
                        //bırada rdr[0] gibide belirtebilirsin 0. indexi companyname denk gelir gibi ama ismen görmek en mantıklısı

                    }
                }
                else
                {
                    MessageBox.Show("data gelmedi");
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show("hata var");
            }
            finally //tryda olsa catchte olsa finally her türlü düşer
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }//db komutları adonette try catc ile genelde ele alınır
            }
            //query ifadeisne göre commend type bleirlenlir querye ifadesine göre execute tipi belirlenir
            //kafana göre open kafana göre close olmaz
            //rdr yi datay ıbir yerde kullanmadıkca connection close edilmeyecek.
            //rdr nin data görünmesi için rdr.Read() olması yeterli ama tablonun sütü nsatırları olmalı
           
           
            /*
             adonet her zaman ormlerdende hızlıdır
            en hızlı çalısan aradaki bağlantıyı convert işlemlerini sağlayan en hızlı teknolojidir
             */
//ado oop kullanılmadıgı sürece çok fazla gereksiz kod yazılır
