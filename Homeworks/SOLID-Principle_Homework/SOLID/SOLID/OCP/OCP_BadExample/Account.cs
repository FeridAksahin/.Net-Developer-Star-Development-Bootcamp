using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.OCP_BadExample
{//Open Closed Principle
    internal class Account
    {
        public double Discount { get; set; } = 0;

        public double getType(Type type,double amount)
        {
            if(type == Type.OneYear)
            {
                Discount = ((amount*5)/ 100);
            }
            if (type == Type.TwoYear)
            {
                Discount = ((amount * 10) / 100);
                
            }
            return Discount;
        }
    }
    public enum Type
    {
        OneYear,
        TwoYear 
    };
}
