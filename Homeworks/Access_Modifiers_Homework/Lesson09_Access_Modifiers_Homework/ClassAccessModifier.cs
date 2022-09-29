using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09_Access_Modifiers_Homework
{
    internal class ClassAccessModifier
    {
        private string CMember; //default olarak privatetir, eğer hiç birşey tanımlanmazsa sınıf üyeleri.
        string CMember2;
        protected internal int protectedInternalValue = 0;

        void privateMethod() //private tir. default olarak.
        {
            //private sadece bu sınıf erişebilir.
        }
        internal void internalMethod()
        {
            //erişmek isteyen, internal tanımlıyla aynı derleyecide oldugu sürece erişilebilir.
        }
        protected internal void protectedInternalMethod() //İç içe sınıflar ve yapılar da dahil olmak üzere sınıf üyeleri 
                                      //protected internal, protected, internal, private protected veya private olabilir 
        {
            //protected internal, yani ya kalıtım alınarak erişilebilir, ya da aynı derlemede olunarak erişilebilir yani internal, yani 
            //ya protected şartı sağlanılırsa erişilir ya da internal şartı sağlanırsa aralarında veya vardır yani
        }
        protected void protectedMethod()
        {
            //protected yani bu sınıfı kalıtım alan sınıf erişebilir. ve farklı derleme olsa dahi kalıtım alındıgı sürece erişilebilir.
        }
        private protected void privateProtectedMethod()
        {
            //kalıtım alınma şartı ve aynı derleme oldugu sürece erişilebilir.
        }
 
        private class A //iç içe sınıf yapısındaki iç sınıflara private olabilir
        {
            ClassAccessModifier e = new ClassAccessModifier();
            public void Access()
            {//iç içe class oldugundan protected olanlara tanımlandıgı sınıfın nesnesiylede direk erişebiliyoruz.
                e.privateMethod();
                e.protectedMethod();
                e.internalMethod();
                e.privateProtectedMethod();
                e.protectedInternalMethod();

                // her metoduna erişebildik çünkü iç içe class yapısında A sınıfı içindedir zaten ClassAccessModifier sınıfının yani sanki ClassAccessModifier
                //sınıfında gibi ClassAccessModifier ın her üyelerine erişilebilir herhangi bir kalıtı mvs yapmadan.

            }

        }
        internal class B //iç içe sınıf yapısındaki iç sınıflara private olabilir
        {
            ClassAccessModifier e = new ClassAccessModifier();
            public void Access()
            {
                e.privateMethod();
            }
        }
        internal class C //iç içe sınıf yapısındaki iç sınıflara private olabilir
        {

        }
    }
    class Example : ClassAccessModifier
    {
        ClassAccessModifier e = new ClassAccessModifier();
        Example accessProtected = new Example();
        public Example()
        {
            base.protectedMethod(); 
        }
        public void Access()
        {
            // e. yazıldıgında privateMethoda erişelemez çünkü o classtan erişilir sadece privatettir.
            base.protectedMethod(); //protected methoda base. ile erişilir ve protected tanımlanan classın nesnesiyle erisilemez, ancak kalıtım alan sınıfın nesnesiyle
                                    //erişilir eğer nesneyle erişilmek isteniyorsa. Kalıtım alınmazsa erişilmez. 
            //iç içe class ise kalıtım almadanda protected access modifier olanlara direk nesne aracılıgıyla erişilebilir.
            e.protectedInternalValue = 3;//protected internal access modifier ile tanımlanmıs fielde  nesne ile erişebiliyoruz.
            e.protectedInternalMethod(); //protected internal access modifier ile tanımlanmıs metoda nesne ile erişebiliyoruz. 
            e.internalMethod(); //aynı derlemede erişilebilir.
            accessProtected.protectedMethod();
            accessProtected.protectedInternalMethod();
            accessProtected.protectedInternalValue = 5;
            accessProtected.privateProtectedMethod();  //aynı derleme ve kalıtım alma şartı var.



        }
        
    }

    class Example2
    {
        ClassAccessModifier e = new ClassAccessModifier();
        public void z()
        {
            e.protectedInternalMethod();
            e.protectedInternalValue = 35;// kalıtım almadık fakat erişebiliyoruz çünkü internal şartı sağlanıyor. aynı derlemede her iki classta.
        }
    }
}

/*
 classların access modifier ları (iç içe olamayan)-> internal , public. eğer hiç bir erişim belirleyici belirtilmezse internaldır classlar. 

 */

/*
 //ödev - publici metotta kullanırsak ne demek classta kullanırsak ne demek gibi access modifierlar için bir tablo dökümanı.

//access modifier classa, metoda, değişkene, fielde, constructora v verilebilir.



    
 */
