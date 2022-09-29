using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armator.Models
{
    internal class Ship
    {
        string name;
        int capacity;
        string port01;
        string port02;
        string port03;
        public DateTime route01Enter;
        public DateTime route01Exit;
        public DateTime route02Enter;
        public DateTime route02Exit;
        public DateTime route03Enter;
        public DateTime route03Exit;
        public int amountOfReceivedProduct;
        public string nameOfReceivedProduct;
        public int amountOfDeliveredProduct;
        public string nameOfDeliveredProduct;
        public string productName;
  
        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string Port01 { get => port01; set => port01 = value; }
        public string Port02 { get => port02; set => port02 = value; }
        public string Port03 { get => port03; set => port03 = value; }

    }
}
