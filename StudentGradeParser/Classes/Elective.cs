using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public class Elective : Class_
    {
        public String type;
        public Elective(CourseHandler.COURSENAME c) : base(c)
        {
        }

        public Elective(CourseHandler.COURSENAME c, String Type)
            : base(c)
        {
            type = Type;
        }

        public override Class_ Clone()
        {
            return new Elective(course, type);
        }
    }
}
