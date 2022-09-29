using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoreticalStudy.DIP.DIPOrnek04True
{
    internal abstract class DonateAccount
    {
        protected abstract decimal Salary { get; set; }
        protected abstract decimal Donation { get; set; }
        protected abstract bool Exam { get; set; }
        protected virtual int Member { get; set; }
        public virtual void CalculatorDonation(decimal salary, bool exam)
        {

        }
        public virtual void CalculatorDonation(decimal salary, bool exam, int member)
        {

        }
    }
}
