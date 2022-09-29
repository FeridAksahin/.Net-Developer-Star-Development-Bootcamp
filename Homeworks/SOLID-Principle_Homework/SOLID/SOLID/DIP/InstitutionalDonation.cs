using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoreticalStudy.DIP.DIPOrnek04True
{
    internal class InstitutionalDonation : DonateAccount
    {
        protected override bool Exam { get; set; } = true;
        protected override decimal Salary { get; set; } = 0;
        protected override decimal Donation { get; set; } = 0;
        protected override int Member { get; set; }



        public override void CalculatorDonation(decimal salary, bool exam, int member)
        {
            this.Exam = exam;
            this.Salary = salary;
            this.Member = member;

            if (Exam == true)
            {
                if (Salary <= 100000 && Salary >= 50000 && Member > 2 || Member < 50)
                {
                    Donation = 999.999m;
                }
                else if (Salary >= 50000 && Salary <= 100000 && Member > 50 || Member < 60)
                {
                    Donation = 500.000m;
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
