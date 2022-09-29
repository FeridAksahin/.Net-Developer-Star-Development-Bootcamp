using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Works.ScholarshipExample
{
    internal abstract class Scholarship
    {
        decimal amount;
        byte exam_score;
        public decimal ScholarshipAmount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                if (!(value >= 40.000M && value <= 500.000M))
                {
                    throw new Exception("Burs miktarı 40 bin ile 500 bin arasında olmalı");
                }
            }
        }


        public byte ExamScore
        {
            get
            {
                return exam_score;
            }
            set
            {
                exam_score = value;
                if (!(value <= 100 && value >= 0))
                {
                    throw new Exception("Sınav puanı 0 ile 100 arasında olmalı");
                }
            }
        }

        public abstract void CalculateScholarship(byte ExamScore);
    }
}
