using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.Converter
{
    internal class Ascii : IConverter
    {
        public void ConvertGo(string s) //text to ascii
        {
            foreach (char c in s)
            {
                Console.Write(System.Convert.ToInt32(c));
            }
        }
        public void Deconvert(string str)
        {
        //codes
        }
    }
}
