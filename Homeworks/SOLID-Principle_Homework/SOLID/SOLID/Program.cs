using SOLID.OCP.OCP;
using System;

namespace SOLID // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TwoYearMember m2 = new TwoYearMember();
            OneYearMember m1 = new OneYearMember();
            Console.WriteLine("One Year Member Discount = " + m1.Discount(10));
            Console.WriteLine("Two Year Member Discount = " + m2.Discount(20));
            
        }
    }
}