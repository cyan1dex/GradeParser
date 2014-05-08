using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public class Mathamatics : Class_
    {
        public Mathamatics(CourseHandler.COURSENAME c) : base(c)
        {
        }

        public override Class_ Clone()
        {
            return new Mathamatics(course);
        }
    }
}
