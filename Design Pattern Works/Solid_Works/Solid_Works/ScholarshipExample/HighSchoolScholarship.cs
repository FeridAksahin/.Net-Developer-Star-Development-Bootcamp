using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.ScholarshipExample
{
    internal class HighSchoolScholarship : Scholarship
    {
        public override void CalculateScholarship(byte ExamScore)
        {

            base.ExamScore = ExamScore;
            if (ExamScore >= 50 && ExamScore <= 70)
            {
                ScholarshipAmount = 60.000M;
            }
            else if (ExamScore >= 70 && ExamScore <= 85)
            {
                ScholarshipAmount = 80.000M;
            }
            else if (ExamScore >= 85 && ExamScore <= 100)
            {
                ScholarshipAmount = 300.000M;
            }
            else if (ExamScore >= 40 && ExamScore <= 50)
            {
                ScholarshipAmount = 40.000M;
            }
            else
            {
                Console.WriteLine("Belirtilen sınav puanları dışındasınız.");
            }
            Console.WriteLine("Burs miktarı : " + ScholarshipAmount);
        }
    }
}
