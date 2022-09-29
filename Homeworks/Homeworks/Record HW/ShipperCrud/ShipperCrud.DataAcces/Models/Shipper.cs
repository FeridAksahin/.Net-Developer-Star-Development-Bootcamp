using System;
using System.Collections.Generic;

namespace ShipperCrud.DataAcces.Models
{
    public partial class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
