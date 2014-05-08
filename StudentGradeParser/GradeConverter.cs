using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGradeParser
{

    class GradeConverter
    {
        public static int GetInverseGrade(String grade)
        {
            if (grade == "A+")
                return 0;
            else if (grade == "A")
                return 1;
            else if (grade == "A-")
                return 2;
            else if (grade == "B+")
                return 3;
            else if (grade == "B")
                return 4;
            else if (grade == "B-")
                return 5;
            else if (grade == "C+")
                return 6;
            else if (grade == "C")
                return 7;
            else if (grade == "C-")
                return 8;
            else if (grade == "D+")
                return 9;
            else if (grade == "D")
                return 10;
            else if (grade == "D-")
                return 11;
            else if (grade == "F")
                return 12;
            else if (grade == "INC")
                return 12;
            else if (grade == "")
                return 12;
            else if (grade == "PASS")
                return 0;
            else
                throw new Exception("Grade representation not found");

        }
    }
}
