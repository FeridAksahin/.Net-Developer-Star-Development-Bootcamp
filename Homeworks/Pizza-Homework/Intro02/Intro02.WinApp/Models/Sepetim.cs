using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro02.WinApp.Models
{
  public  class Sepetim
    {
        public Pizza Pizza { get; set; }
        public decimal AraTutar { get; set; }
        public decimal Adet { get; set; }

        public override string ToString()
        {
            return $"{Pizza.Adi} pizzası: {Adet} adet olup  {AraTutar} TL";
        }
    }
}
