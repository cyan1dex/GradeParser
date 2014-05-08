using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public class Science : Class_
    {
        public Science(CourseHandler.COURSENAME c) : base(c)
        {
        }

        public override Class_ Clone()
        {
            return new Science(course);
        }
    }
}
