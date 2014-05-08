using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes
{
   public  class ForeignLang : Class_
   {
       public String type;
       public ForeignLang(CourseHandler.COURSENAME c) : base(c)
       {
       }

       public ForeignLang(CourseHandler.COURSENAME c, String type)
           : base(c)
       {
           this.type = type;
       }

       public override Class_ Clone()
       {
           return new ForeignLang(course, type);
       }
    }
}
