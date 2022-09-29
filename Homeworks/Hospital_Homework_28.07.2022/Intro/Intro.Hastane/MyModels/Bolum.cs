using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro.Hastane.MyModels
{
  public class Bolum :Object, IDisposable
    {
        public override string ToString()
        {
            return BolumAdi.ToUpper(); 
        }

        //SOLID
        //
        public Bolum(/*Doktor dt*/)/*:this(58)*/
        {
            //Doktor d = new Doktor();
            //Doktor = d;

        }
        public Bolum(int i)
        {


        }
        //field
        int i = 0;
        public string bolumadi;
        public string aciklama;

        // object   class  Type  int 
        //prop 
        public string BolumAdi { get; set; }
        public string Aciklama { get; set; }
        // public bool AktifMi  { get; init; }
        // public Doktor Doktor { get; set; }


        public void BolumAra(string aranacakKelime = "ara")
        {
            //listten aramanın kodları 
        }

        public bool BolumAra(string aranacakKelime, string aranacakKelime2 = null)
        {
            //listten aramanın kodları 
            return true;
        }
        public void Dispose()
        {

        }


        ~Bolum()
        {
            //

        }
    }

    //public record Hede
    //{ 

    //}

}
