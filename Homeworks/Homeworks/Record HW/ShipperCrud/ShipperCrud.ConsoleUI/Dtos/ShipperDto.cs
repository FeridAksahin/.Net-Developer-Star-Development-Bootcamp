using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperCrud.ConsoleUI.Dtos
{
    internal record ShipperDto : BaseDto
    {
    
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

    }
}
