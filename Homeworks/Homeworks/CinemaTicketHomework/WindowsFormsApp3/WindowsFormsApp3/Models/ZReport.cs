using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    public class ZReport
    {
        public string Cinsiyet { get; set; }
        public string OdemeTuru { get; set; }
        public string Koltuk { get; set; }
        public string SecilenFilm { get; set; }
        public string secilenSeans { get; set; }
        public decimal tutar { get; set; }
        public override string ToString()
        {
            return $"{Cinsiyet} cinsiyet türünde, {OdemeTuru} ödeme türü ile {SecilenFilm} filmine {secilenSeans} seansına tutarı {tutar} lira ödeyerek bilet aldı.";
        }

    }
}
