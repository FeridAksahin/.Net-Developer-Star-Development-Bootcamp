using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.Converter
{
    internal class Binary : IConverter //num to binary
    {
        public void ConvertGo(string convert)
        {
            Console.WriteLine();
            int num = int.Parse(convert);
            string binary = Convert.ToString(num, 2);
            Console.WriteLine("Convert num (For Binary)= " + binary);
        }
        public void Deconvert(string convert)
        {
            int value02 = Convert.ToInt32(convert, 2);
            Console.WriteLine("Deconvert num (For Binary)= " + value02);
        }
    }
}
