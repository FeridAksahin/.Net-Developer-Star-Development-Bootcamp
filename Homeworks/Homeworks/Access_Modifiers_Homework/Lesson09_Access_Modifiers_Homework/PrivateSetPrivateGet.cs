using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09_Access_Modifiers_Homework
{//soru -> // bir propertyinin set metodunu private yaparsak neden cons kullanmayız? 
    //çünkü constructor aracılıgıyla değer değiştirilebiliyor. çünkü dışarıdan private ayarlı tanımlandıgı classta değil.
    internal class PrivateSetPrivateGet
    {
        public PrivateSetPrivateGet(int no)
        {
            No = no;
            number++; //yine bu classtan nesne alırsak number 1 artar hata vermez.
            surname = "g";
            
        }
        public PrivateSetPrivateGet(string name)
        {
            Console.WriteLine(name);
        }
        public PrivateSetPrivateGet()
        {

        }

        public int No { get; private set; } //dışarıdan değişime kapalı
        public int number { get; private set; } //salt yazma yani private set nadir kullanılır hassas verileri korumak için önlemdir.
        public string name { private get; set; } //dışarıdan returne kapalı 

        public string surname { get; protected set; }

    }
}
