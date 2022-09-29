using Solid_Works.ScholarshipExample;
using Solid_Works.Converter;
using System;

namespace Solid_Works
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            /*
            HighSchoolScholarship m = new HighSchoolScholarship();
            m.CalculateScholarship(55); 
            UniversityScholarship university = new UniversityScholarship();
            university.CalculateScholarship(55);
            */
            MainScholarship ms = new MainScholarship(new HighSchoolScholarship());
            ms.CalculateScholarship(55);
            MainScholarship ms2 = new MainScholarship(new UniversityScholarship());
            ms2.CalculateScholarship(55);
       

            SetConverter sc = new SetConverter(new Ascii());
            sc.ConvertGo("bb");

            SetConverter sc2 = new SetConverter(new Binary());
            sc2.ConvertGo("53");
            sc2.Deconvert("110101");
        }
    }
}

 