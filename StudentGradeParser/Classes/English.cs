using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public class English : Class_
    {
        public English(CourseHandler.COURSENAME c) : base(c)
        {
        }
        public override Class_ Clone()
        {
            return new English(course);
        }
    }
}
