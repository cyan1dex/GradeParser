using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
    public abstract class Class_ : IEquatable<Class_>
    {
        public CourseHandler.COURSENAME course;
        public String gradeFall;
        public String gradeSpring;

        public CourseHandler.COURSENAME GetCourse()
        {
            return course;
        }

        public Class_(CourseHandler.COURSENAME c)
        {
            course = c;
        }

        public bool Equals(Class_ obj)
        {
            return this.course == obj.course;
        }

        public abstract Class_ Clone();

    }
}
