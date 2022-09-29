using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.Converter
{
    internal interface IConverter
    {
        void ConvertGo(string convert);
        void Deconvert(string convert);
    }
}
