using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulingFor8th;
using SchedulingFor8th.Classes;

namespace StudentGradeParser
{
    interface IPlaceable
    {
        String GetForeignLangPlacement(int year);

        String GetMathPlacement(int year);
    }

    
}
