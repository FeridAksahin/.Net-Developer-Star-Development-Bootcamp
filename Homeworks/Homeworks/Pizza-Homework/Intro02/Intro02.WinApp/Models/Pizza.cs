using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro02.WinApp.Models
{
  public  class Pizza
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
