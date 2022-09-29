using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoreticalStudy.DIP.DIPOrnek04True
{
    internal class IndividualDonate : DonateAccount
    {
        protected override bool Exam { get; set; } = true;
        protected override decimal Salary { get; set; } = 0;
        protected override decimal Donation { get; set; } = 0;


        public override void CalculatorDonation(decimal salary, bool exam)
        {
            this.Exam = exam;
            this.Salary = salary;

            if (Exam == true)
            {
                if (Salary <= 1000 && Salary >= 0)
                {
                    Donation = 100.000m;
                }
                else if (Salary >= 1000 && Salary <= 10000)
                {
                    Donation = 10.000m;
                }

                //vsvs
            }
            else
            {
                Console.WriteLine("Tekrar sınava giriniz");
            }

            Console.WriteLine(Donation);
        }
    }
}
