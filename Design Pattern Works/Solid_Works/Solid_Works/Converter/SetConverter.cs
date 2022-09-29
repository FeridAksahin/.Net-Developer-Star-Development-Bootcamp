using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.Converter
{
    internal class SetConverter
    {
        IConverter converter;
        public SetConverter(IConverter converter)
        {
            this.converter = converter;
        }
        public void ConvertGo(string str)
        {
            converter.ConvertGo(str);
        }
        public void Deconvert(string str)
        {
            converter.Deconvert(str);
        }
    }
}
