using System;
using System.Collections;

namespace LessonOneQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz : ");
            int num = Convert.ToInt32(Console.ReadLine());
            Questions q = new Questions();
            string a = q.MukemmelSayi(num);
            Console.WriteLine(a);
         

        }
    }

    class Questions
    {
        public string MukemmelSayi(int num)
        {
            ArrayList ar = new ArrayList(); //Boyutu bilmediğimden normal array yazmak yerine ArrayList yapısı kullandım. Bu diziyi girilen saıynın pozitif tam bölenlerini tutmak için açtım.
                                            //"List" yapısıda kullanabilirdim fakat ArrayList kullandım. 
            int sum = 0; //Sayının pozitif tam bölenlerinin toplamını tutacağım bir değişken. 
            string ans = "";//return olarak string döndürüyorum metotta, bu değişkenle mükemmel sayı olup olmadığını belirtip döndürcem.
            for (int i = 1; i < num; i++) // girilen sayıya kadar 1 den başlayıp devam etmesini istediğim for döngüsü.
            {
                if (num <= 0) //Girilen sayı eğer 0 ve ya küçükse direk döngüden çıksın, çünkü mükemmel sayı olamayacaktır.
                {
                    break;
                }
                else if (num % i == 0)// sayı eğer büyükse 0'dan, sayıya kadar for'da döndüm ve her for döngüsünde sayıyı, fordaki değişkende kalanı 0 sa dedim. Yani tam bölünüyodur.
                {
                    ar.Add(i); //eğer tam bölünüyorsa onu ArrayList'im olan ar'a ekledim.
                }
            }

            foreach (int i in ar) //Sayının pozitif bölenlerini topladığım ar dizisinde foreach ile dolaştım.
            {
                sum += i; //her ar elemanını sum değişkenime ekledim.
            }
            if (sum == num) //eğer sum değişkeni sayıya eşitse mükemmel sayıdır.
            {
                ans = "Girilen sayı mükemmel sayıdır.";
            }
            else //sum değişkeni sayıya eşit değilse mükemmel sayı değildir.
            {
                ans = "Girilen sayı mükemmel sayı değildir.";
            }
            return ans; //string değişkenim olan mükemmel sayı durumu olup olmadığını belirttiğim değişkeni geri dönüş tipi string olan metodun sonunda return olarak döndürdüm.

        }

    }
}

/*
 1)	Girilen bir sayının mükemmel sayı olup olmadığını ispatlayan programı ve akış şemasını hazırlayınız.. (Akış şeması için özel bir tool a gerek yok . 
Program dosyaları içine karalama yaptığınız kağıdın resmini atmanız yeterli olacaktır. )

Mükemmel Sayı: Kendisi tüm pozitif bölenlerinin toplamı kendisine eşit olan sayıları mükemmel sayı denir. 6 bir mükemmel sayıdır. 
Çünkü 6'nın pozitif bölenleri 1,2,3 ve 6'dır. Kendisi hariç diğer bölenlerini toplarsak 1 + 2 + 3 = 6 eder.

-------------------

2) Oyuncu oyuna başladığında random daha önce tanımlanmış bir kelime belirlenir? Kullanıcının tıkladığı her harf kelime içinde taranır ve o harf var ise kullanıcıya gösterilir, 
yok ise adamı adım adım asmaya başlarız toplam 6 kere harf bulamadığında ise oyun biter adam asılmış olur 😊 Aşağıdaki gibi.  Eğer adamı asmadan kelimenin harflerini bulursa   
bir mesajla oyuncuyu tebrik eder ve oyunu bitirmesini sağlarız. Oyundan atmadan tekarar da başlayabilir kullanıcı bu detayı unutmayınız ?

Windows form uygulamaları yapmayı unuttuğumdan, hemen öğrenip görsel olarak yapmaya vaktimin az olması sebebiyle 2. soruyu konsol üzerinden yaptım. 

 */


/*
 •	.Net Framework ve  .Net Core sizin için (kodda) ne anlam ifade eder ? .Net dünyasının trend frameworkü hangisidir ?

.Net Framework ve  .Net Core çeşitli ihtiyaçlara, problemlere karşı sunulan yeni alternatiflerle ve güncel teknolojilerle projeyi daha hızlı ve daha uluşılabilir olduğu ifade eder. 

-------------------

•	Bir database yönetim sisteminde  verilerin sıralanması veya veriler içinde arama yapmamız bizden istenmişse  database in normalizasyonu sırasında sizce nelere dikkat etmek gereklidir ?

Tablodaki verilerin eklenirken ID'lerin tek tek artmasına dikkat edilmelidir. (Indentity özelliği) 

-------------------

•	Müşteri online anket sistemi yazdırmak istiyor. Amaç  kullanıcılardan veri toplamak herhangi bir konuda ? 

Bu verileri sonraki aşamalarda analiz veya raporlama toollarını kullanarak veri analizi yapacaklar ? Ama bu bizim görevimiz değil biz sadece max 10 soruluk 1 anketi dolduran kullanıcıların 
anket sorularına verdiği cevapları saklayacağız? 
Bu durumda kullanacağız web programlama, database yada script dil(ler)i nelerdir ve neden ?

MVC projesi yaparak, backend tarafında .NET core, frontend tarafında html, css ve bootstrap kullanılabilir. Verileri tutmak için Microsoft Sql Management Studio kullanılabilir.
Veya başka teknolojiler olarak Php projesi çıkartılabilir. Frontend tarafında html, css ve bootstrap kullanılabilir, backend tarafında crud işlemleri için php kullanılıp, phpMyAdmin ile veriler saklanıp tutulabilir.

-------------------

•	Bir kod blogu ya da yeni bir Teknoloji öğrenmek istediğinizde hangi platformlardan yararlanırsınız ? (Link ya da isim olarak yazabilirsiniz ?) Takip ettiğiniz kişiler ya da bloglar var mı ?

Programlama dili öğrenmek ya da öğrendiklerimi pratik yapmak istiyorsam (ayrıca hobimdir) -> https://www.hackerrank.com/
PatikaDev -> https://www.patika.dev/tr
FreeCodeCamp ->  https://www.freecodecamp.org/learn
Udemy -> Öğretmen olarak -> Angela Yu, Murat Yücedağ , fakat özellikle dikkat ettiğim öğretmen mevcut değil ama en çok eğitimine baktıklarım yazdığım 2 öğretmendir.

-------------------

•	Hangi oyunları oynuyorsunuz ? 😊 Birbirimizi iyice tanıyalım.

En çok oynadığım bir moba oyunu
 

 */

