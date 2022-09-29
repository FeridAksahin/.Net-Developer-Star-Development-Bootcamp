using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro.Hastane.MyModels
{
    public class Hasta
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Doktor Doktor { get; set; }
        public string TC { get; set; }
        public string HastaSikayet { get; set; }
        public string DoktorTeshis { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
