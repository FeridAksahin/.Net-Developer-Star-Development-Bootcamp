using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    public class Film
    {
        public string Name { get; set; }
        public string Seans01 { get; set; }
        public string Seans02 { get; set; }
        public string Seans03 { get; set; }
        public decimal Price { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
