using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro.Hastane.MyModels
{
    public class Doktor
    {
        private string _DoktorAdSoyad;
        public string DoktorAdSoyad
        {
            get
            {
                ////ilk harf buyuk
                //string harf = _DoktorAdSoyad.Substring(0, 1);
                //_DoktorAdSoyad = harf.ToUpper() + _DoktorAdSoyad.Substring(1, _DoktorAdSoyad.Length - 1);
                ////boşlukların tamamı _ işareti olsun..
                //string yeniHali = _DoktorAdSoyad.Replace(' ', '_');
                //return yeniHali;


               // return (_DoktorAdSoyad.Substring(0, 1).ToUpper() + _DoktorAdSoyad.Substring(1, _DoktorAdSoyad.Length - 1)).Replace(' ', '_');

                return ( _DoktorAdSoyad[0].ToString().ToUpper() + _DoktorAdSoyad.Substring(1, _DoktorAdSoyad.Length - 1)).Replace(' ', '_');
            }

            set
            {
                _DoktorAdSoyad = value;
            }

        }
        public string Adres { get; set; }
        public string Tel { get; set; }
        public Bolum Bolum { get; set; }

        public override string ToString()
        {
            return DoktorAdSoyad;
        }
    }
}
