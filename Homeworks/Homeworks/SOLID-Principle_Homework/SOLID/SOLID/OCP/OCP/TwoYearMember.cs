using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.OCP
{
    internal class TwoYearMember : Member
    {
        private double _Discount { get; set; } = 0;
        public override double Discount(double amount)
        {
            _Discount = ((amount * 10) / 100);
            return _Discount;
        }
    }
}
