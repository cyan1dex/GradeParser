using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public class History : Class_
    {
        public History(CourseHandler.COURSENAME c) : base(c)
        {
        }

        public override Class_ Clone()
        {
            return new History(course);
        }
    }
}
