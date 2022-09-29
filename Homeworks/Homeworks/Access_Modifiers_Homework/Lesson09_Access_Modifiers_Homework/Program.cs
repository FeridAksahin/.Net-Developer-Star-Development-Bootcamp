using Lesson09_Access_Modifiers_Homework;
using System;

namespace Lesson09_Access_Modifiers_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            #region PrivateGetPrivateSet
            PrivateSetPrivateGet q1 = new PrivateSetPrivateGet(4);
            Console.WriteLine(q1.No);// propertynin private set olarak ayarlı fakat constructor aracılgııyla degistirdik. number + landı. output -> 4
            Console.WriteLine(q1.number); //number default değeri 0 dı int çünkü 1 oldu çünkü class newlendi
                                          //q1.No = 44;hata verir çünkü private set, başka classtan değiştirilemez.
                                          //Console.WriteLine(q1.name); hata verir çünkü private get şeklinde property. Fakat constructor aracılıgıyla erişilebilir.
            PrivateSetPrivateGet q2 = new PrivateSetPrivateGet("fa"); //private get propertye overload edilen constructor aracılıgıyla erişildi
           // q2.surname = "protected sette değiştirilemez 
      
            #endregion


        }
    }

    class Orn : PrivateSetPrivateGet
    {
        PrivateSetPrivateGet q1 = new PrivateSetPrivateGet();
        Orn o = new Orn();
        public void protectedProperty()
        {
            //q1.surname = "g"; hata verir kalıtım alınsa dahi çünkü o sınıf nesnesiyle değiştirilmelidir çünkü protected set tedir property, yani
            //kalıtım alan sınıf sadece değiştirebilir. ya da constructorlada değiştirilebilir tanılandıgı sınıfın constructorı
            o.surname = "g"; //degisitirebirlir cünkü Orn sınıfı kalıtım almıstır PrivateSetPrivateGet sınıfından.


        }
    }
 
}

