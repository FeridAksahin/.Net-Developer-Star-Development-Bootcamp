using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperCrud.ConsoleUI.Dtos
{
    internal record BaseDto
    {
        public int ShipperId { get; set; }
    }
}
