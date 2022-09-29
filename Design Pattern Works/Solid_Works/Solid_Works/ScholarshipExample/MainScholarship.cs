using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.ScholarshipExample
{
    internal class MainScholarship
    {
        Scholarship scholarship;
        public MainScholarship(Scholarship scholarship)
        {
            this.scholarship = scholarship;
        }
        public void CalculateScholarship(byte ExamScore)
        {
            scholarship.CalculateScholarship(ExamScore);
        }
    }
}
