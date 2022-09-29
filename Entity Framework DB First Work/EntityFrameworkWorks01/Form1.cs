using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //entity de gerek yok ama sql komutuyla çekicez ders listesini entity ile farkı görmek için
namespace EntityFrameworkWorks01
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLessonList_Click(object sender, EventArgs e)
        {
            //ado.net disconnected mimari ile dersleri listelettik griedview e . entity framework kullanmadık
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IJNNT7V;Initial Catalog=DBStudentExam;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from TABLELESSON", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnStuList_Click(object sender, EventArgs e)
        {
            using (DBStudentExamEntities db = new DBStudentExamEntities()) //sadece bu alanda new lenir using blogunda sonra new leme olmaz dolayısıyla çok verili bir class ise diyelim tabloda birsürü veri var 
                                                                           //bu alandan sonra bellekte yer kaplamaz
            {
                //modelimize ulaşmak için açtıgımız enitty nesnesi
                dataGridView1.DataSource = db.TABLESTUDENT.ToList(); //direk entityden tabloyu çektik atadık. db. yazınca veritabanı
                                                                     //tablolarımızı görebiliyoruz. sonra ToList ile listelettik

                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false; //visible yerine btnExamListte yaptıgımız istedigimiz kolonları linq sorgusuyla getirebirilirz
            }
        }

        private void btnExamList_Click(object sender, EventArgs e)
        {// linq sorgusu 4 paremetresi var
         //1 from
         //2 foreacteki var item kısmı gibi düşün 2. kısmı item gibi diziyi dönen gibi 
         //3 database tablosu entity class nesnesinden erişiriz direk 
         //4 select new {} {} içindeki bulunan alanları sec
         //item. dendikten sonra item in bağlı oldugu tablodaki tüm propertyleri getirir
            DBStudentExamEntities db = new DBStudentExamEntities();
            var query = from item in db.TABLESCORE
                            //  select new { item.SCOREID, item.StudentId, item.LessonId, item.Exam1, item.Exam2, item.Exam3, item.Average, item.Situation };
                        select new { item.SCOREID, item.TABLESTUDENT.Name, item.TABLELESSON.LessonName, item.Exam1, item.Exam2, item.Exam3, item.Average, item.Situation };
            //join kullanmadan fk ları direk isimlerini çağırdık ilgili tablolardan
            //yani bu query şunla aynı -> SELECT ScoreId, StudentId, LessonId, Exam1 from TABLESCORE 
            dataGridView1.DataSource = query.ToList(); //toList metodu selectin karsılıgı olan listelemeyi gerçekleştiren metottur
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
            //validation, isim boş mu vs 
            TABLESTUDENT tableStudent = new TABLESTUDENT();
            tableStudent.Name = txtStuName.Text;
            tableStudent.Surname = txtStuSurname.Text;
            db.TABLESTUDENT.Add(tableStudent);//add metodunda parantez içine bak TABLESTUDENT entity si yani TABLESTUDENT nesnesi, tablosu bekler DbSet
            db.SaveChanges();//değişiklikleri kaydet ve veritabanına yansıt. ado.net teki ExecuteNonQuery anlamı gibi yada ExecuteReader gibi 
            MessageBox.Show("Öğrenci eklendi");
            */
            //diğer sytax
            using (DBStudentExamEntities db = new DBStudentExamEntities()) //using burada kullanıp listeleme butonunda kullanmazsa student tablosunun hata verri
            {
                db.TABLESTUDENT.Add(new TABLESTUDENT()
                {
                    Name = txtStuName.Text,
                    Surname = txtStuSurname.Text,
                });
                MessageBox.Show(db.SaveChanges() > 0 ? "veri eklendi" : "hata var");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtStuID.Text);
            using (DBStudentExamEntities db = new DBStudentExamEntities())
            {
                var x = db.TABLESTUDENT.Find(id);
                db.TABLESTUDENT.Remove(x);
                db.SaveChanges();
            }
            //ilişkili tablolarda ilişkili kolonda silme işlemi yapılamaz hata verir fk dır çünkü başka tablolarla ilişkilidir.
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (DBStudentExamEntities db = new DBStudentExamEntities())
            {
                int id = Convert.ToInt32(txtStuID.Text);
                var x = db.TABLESTUDENT.Find(id);
                x.Name = txtStuName.Text;
                x.Surname = txtStuSurname.Text;
                x.Photograph = txtStuPhotograph.Text;
                db.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            using (DBStudentExamEntities db = new DBStudentExamEntities())
            {
                dataGridView1.DataSource = db.SCORELIST();//uzun sorguyu burda yazmak yerine direk procedure olarak sqlde yazıp burada çağırdık 

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            /*
             lambda sorgular,
            sadeleştirilmiş anonim fonksiyonlardır.
            linq sorguların yerine kullanılabilir ama linq daha hızlıdır. linq kullanılması daha iyyidir.
            lambdada çok kullanılır.
            => sembolleri kullanılır.
            degisken01=>degisken01 degisken sol tarafına atanır aynı degisken sagada atanır 

             */
            using (DBStudentExamEntities db = new DBStudentExamEntities())
            {
                //    dataGridView1.DataSource = db.TABLESTUDENT.ToList();  ogrenci tablosunda arama yapıcaz, tolist hepsini listeler bunu istemiyoruz find çünkü
                //dataGridView1.DataSource = db.TABLESTUDENT.Where(x => x.Name == txtStuName.Text).ToList(); //TABLESTUDENT daki tüm property leri görürüz x. diyince, yani x e gönderilen ifade
                //ki o burada txtStuName.Text tir, bu Name e eşit olan dataları getir dedik listeleyip
                dataGridView1.DataSource = db.TABLESTUDENT.Where(x => x.Name == txtStuName.Text && x.Surname == txtStuSurname.Text).ToList(); //&& ve şartı, || yazsak 2 sinden biri eşleşirse listler
            }
        }

        private void txtStuName_TextChanged(object sender, EventArgs e)
        {
            DBStudentExamEntities db = new DBStudentExamEntities(); //using ile kullanınca hata verir arama algoritmasından
            string searchValue = txtStuName.Text;
            var values = from s in db.TABLESTUDENT
                         where s.Name.Contains(searchValue) //eğer TABLESTUDENT'un name propertysi içerirse searchValue yi onu getirttik ve atadık values e. yani o datayı getirdik en sonda select s ile sonra atadık
                         select s;
            dataGridView1.DataSource = values.ToList();


        }

        private void btnLinqEntity_Click(object sender, EventArgs e)
        {
            using (DBStudentExamEntities db = new DBStudentExamEntities())
            {
                if (radioButton1.Checked == true)
                {
                    List<TABLESTUDENT> sıralamaList = db.TABLESTUDENT.OrderBy(p => p.Name).ToList();
                    //ada göre sıralama. OrderBy metodunu kullandık, dbsetin metotları vardır birsürü
                    dataGridView1.DataSource = sıralamaList; //direk atayabiliriz çünkü toList atadık 
                }
                if (radioButton2.Checked == true)
                {
                    List<TABLESTUDENT> list2 = db.TABLESTUDENT.OrderByDescending(p => p.Name).ToList();
                    dataGridView1.DataSource = list2; //z den a ya sıralama 
                }
                if (radioButton3.Checked == true)
                {//sıralı ilk 3 eleman A-Z
                    List<TABLESTUDENT> list3 = db.TABLESTUDENT.OrderBy(p => p.Name).Take(3).ToList();
                    dataGridView1.DataSource = list3;
                }
                if (radioButton4.Checked == true)
                {
                    List<TABLESTUDENT> list4 = db.TABLESTUDENT.Where(p => p.Name.StartsWith("a")).ToList();
                    dataGridView1.DataSource = list4; //a ile biten için endwith
                }
                if (radioButton5.Checked == true)
                {
                    int toplam = db.TABLESTUDENT.Count();
                    MessageBox.Show(toplam.ToString());
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBStudentExamEntities db = new DBStudentExamEntities();
            var query = (from tablescore in db.TABLESCORE
                         join st in db.TABLESTUDENT on tablescore.StudentId equals st.ID
                         join lesson in db.TABLELESSON on tablescore.LessonId equals lesson.LessonId
                         select new
                         {
                             Student = st.Name,
                             Lesson = lesson.LessonName,
                             Exam1 = tablescore.Exam1,
                             Exam2 = tablescore.Exam2,
                             Exam3 = tablescore.Exam3,
                             Average = tablescore.Average,
                             Situation = tablescore.Situation
                         }).ToList();
            dataGridView1.DataSource = query;
        }
    }
}
/*
 Sınav Puanları Listesinde verilerde fk oldugundan ID ler geliyordu sayı olarak 
1, 2, 3 vs gibi 
bunu engelleyip mesela o id ye gidip öğrenci ismine bakmasın anlamak için bu bir ui çünkü user friendly olması için direkt o fkların değerlerini çeksin
diye
procedure yazdık

CREATE PROCEDURE SCORELIST
AS 
SELECT   SCOREID,[Name]+' '+Surname as [Ad Soyad], LessonName
Exam1,Exam2,Exam3,Average,Situation from TABLESCORE tsc JOIN TABLESTUDENT tst ON tsc.StudentId = tst.ID JOIN TABLELESSON tl on
tl.LessonId = tsc.LessonId
şeklinde
 */


/*
  
mesela shipper tableında insert yapmak istiyoruz, ya da join işlemleri yapcagımızı demek için


Context, Entities ->

.edmx -> 

t4 dili->
Model1.Constext.tt -> buraya müdahale edilebilir. buraya yapılan her müdahale wrapping olarak isimlenidirli
DbContext 

dpContext -> database alanının tamamı mesela NorthWindContext -> northiwnd db işlemlerinni hepsini yöntetttigimiz tanımladıgımız alanın tamamı
bütün tipler model1.tt içinde var category.cs product.cs vs

App.config dosyası içinde yazan kodları öğren 


raiseloading nedir iggerloading nedir? ödev ef için
bu kavram düzgün anlaşılmazsa performanstan bahsedemezsin projede.
ef kullanıyorsan bilmelisin, bunlara müdahale etmelisin.

nosql nedir ->
en bilindiği mongo db nosqlin

model1.edmx görünen navigation properties nedir
fk ilişkilerinin burdaki ismi navigation properties tir

NorthwindEntites mesela nesne açıcak using ile kullan çünkü mesela 300 tablosu olan db nin mesela 
birsürü 500 tane propertysi var
tablo kolon isimleri yani
bu classı new lersen heps iayağa kalkar o yüzden usingle new le ki sadece kullanınca newlensin
add metotları generic metotlardır
db.Categories.Add mesela bir class tipinde paremetre isteyen mettotdur

sorguyu exec ederdik adonette executereader, scalar, nonquery vs efcoreda tamamı bunların db.savechanges() iledir

Liste data çekerken yani List<Product> d = db.Products.ToList(); burda savechanges gerek yok ama bunun dısında hepsi
için lazım ekleme vs silme vs için

delete metodu çağırılcaksa ID üzerinden silinir

removeda paremetrenin statei olmak zorunda 
EntityState -> bildigin enumlardır ctrl+sol tık bak
mesela bir class açtın statei delete çekip removea gönderirsin, categoryID si varsa classı db den bulup silmeye çalısır

where db.Categories.Where where alg bak
db.Categories.Where.SingleOrDefault bak db.Categories.Where.take bak
vs metotlarına bak IQueryable veri tipine bak
db.Categories.Where üzerine gel veri tipine bak
state otomatik added durumunda olur eklenen property db den çekili

1 nolu catı çağırdın mesela fk ile baglıysa fk 
silinmez odata çünkü foreign key cascading tir. data ilişkilidir başka tablolardı normalizasyondan aklına gelsin

güncellemeden sonra db.savechanges çağırlır
data.Descfiptinn = "gag"; mesela datanın description kolonunu gag olarak güncelldik
sorna db.savechanges

data çekiliyosa aranıp modified dır statei
remove gönderileribir modified olan 
ternary if alış

pk üzerinden aratma yaptıgı içni single or default kullanıyor wherede
pk 1 tanedir çünkü .

firstordefault ise pk olmayan kolonlarda kullanılr farkını öğren sing ve first

contextmenustript - propertyste gösterilir nerde gösterilceği neye sağ tıklanınca çıksın contextmenustript özelliği


DTO -> data transfer objectler

dbden ihtiyacın olmayan kolonları arayüze kyoma asla webdede formdada messela ıd ile işi yok ui de bunu koyma


ürünRaporDtoda
ui de basılan kolonlar modellenir

linq query yazıyosa hoca lambdasını yaz lambda yazıyosa linq ini yazmaya çalıs
lamda linq farkı bak

Queryable değişken tipindekileri kullanamıyoruz o yüzden linqte tolist yaptı
tolist değilde pk oldugundan eminsen singleordefauld yaptı tolist yerine
kolon çekilmek isteniyorsa {} içine yazılır

anonymous type değişten tipine bak 'a olarka sembollenirler
newlenebilen tek şeyler referans typelardır

ef ile ilgili hep crud yapılır
crud çok çalış
web, core değiştirilir, 3-5 yeni metotlar var mesela ef core da ama kavram aynı
ne yapılırsa yapılsın db destekli yapılır 

linq yerrine lambdada yapılır ama linq daha hızlı çalısır


101 sample linq bak 


observer pattern foreach kullanamdan yapılan bir şeydir
 */
