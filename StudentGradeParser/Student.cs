using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulingFor8th;
using SchedulingFor8th.Classes;

namespace StudentGradeParser
{
    public class Student : IPlaceable
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int ID { get; set; }
        public int Grade { get; set; }
        public Class_[] classes = new Class_[7];
        public bool mathPlacement, langPlacement;
        public String duplicate;

        //Determeine which foreign lang student should take the following year based on their current grades
        public String GetForeignLangPlacement(int year)
        {
            if (classes[1] == null)
                return "No global language course taken";
            else
            {
                if (classes[1].gradeFall == String.Empty)
                    return "No grade received";
                else
                {
                    int gradeSubtractionFall = GradeConverter.GetInverseGrade(classes[1].gradeFall);
                    int gradeSubtractionSpring = GradeConverter.GetInverseGrade(classes[1].gradeSpring);
                    int gradeSubtraction;

                    if(year >= 9) //if student year is after 9th, than placement is dependant on spring and fall grades
                        gradeSubtraction = (gradeSubtractionFall + gradeSubtractionSpring) / 2;
                    else
                        gradeSubtraction =  gradeSubtractionSpring;
                    
                    CourseHandler.COURSENAME class_ = classes[1].course;

                    //todo: decouple this from the method
                    switch (class_)
                    {
                        #region french
                        case CourseHandler.COURSENAME.FrenchIntensive:
                            {
                                if (Grade >= 8)
                                {
                                    if (gradeSubtraction <= GradeConverter.GetInverseGrade("A"))
                                        return CourseHandler.COURSENAME.French2.ToString();
                                }
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French1b.ToString();

                                return CourseHandler.COURSENAME.FrenchIntensive.ToString();
                            }
                        case CourseHandler.COURSENAME.French1a:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French1b.ToString();

                                return CourseHandler.COURSENAME.French1a.ToString();
                            }
                        case CourseHandler.COURSENAME.French1b:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French2.ToString();

                                return CourseHandler.COURSENAME.French1b.ToString();
                            }
                        case CourseHandler.COURSENAME.French2:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A-"))
                                    return CourseHandler.COURSENAME.French3h.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French3.ToString();

                                return CourseHandler.COURSENAME.French2.ToString();
                            }

                        case CourseHandler.COURSENAME.French3:
                            {

                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French4.ToString();

                                return CourseHandler.COURSENAME.French3.ToString();
                            }
                        case CourseHandler.COURSENAME.French3h:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.FrenchAP.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French4.ToString();

                                return CourseHandler.COURSENAME.French3h.ToString();
                            }
                        case CourseHandler.COURSENAME.French4:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A-"))
                                    return CourseHandler.COURSENAME.French5H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French5.ToString();

                                return CourseHandler.COURSENAME.French4.ToString();
                            }
                        case CourseHandler.COURSENAME.FrenchAP:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.French5H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.French5H.ToString();

                                return CourseHandler.COURSENAME.FrenchAP.ToString();
                            }
                        #endregion
                        #region chinese
                        case CourseHandler.COURSENAME.ChineseIntensive:
                            {
                                if (Grade >= 8) //student placement
                                {
                                    if (gradeSubtraction <= GradeConverter.GetInverseGrade("A"))
                                        return CourseHandler.COURSENAME.Chinese2.ToString();
                                }
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese1B.ToString();

                                return CourseHandler.COURSENAME.ChineseIntensive.ToString();
                            }
                        case CourseHandler.COURSENAME.Chinese1A:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese1B.ToString();

                                return CourseHandler.COURSENAME.Chinese1A.ToString();
                            }
                        case CourseHandler.COURSENAME.Chinese1B:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese2.ToString();

                                return CourseHandler.COURSENAME.Chinese1B.ToString();
                            }
                        case CourseHandler.COURSENAME.Chinese2:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A-"))
                                    return CourseHandler.COURSENAME.Chinese3H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese3.ToString();

                                return CourseHandler.COURSENAME.Chinese2.ToString();
                            }

                        case CourseHandler.COURSENAME.Chinese3:
                            {

                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese4.ToString();

                                return CourseHandler.COURSENAME.Chinese3.ToString();
                            }
                        case CourseHandler.COURSENAME.Chinese3H:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.ChineseAP.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese4.ToString();

                                return CourseHandler.COURSENAME.Chinese3H.ToString();
                            }
                        case CourseHandler.COURSENAME.Chinese4:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.Chinese5.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese4.ToString();

                                return CourseHandler.COURSENAME.Chinese4.ToString();
                            }
                        case CourseHandler.COURSENAME.ChineseAP:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.Chinese5H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Chinese5.ToString();

                                return CourseHandler.COURSENAME.ChineseAP.ToString();
                            }
                        case CourseHandler.COURSENAME.ChineseVorVH:
                            {

                                return CourseHandler.COURSENAME.None.ToString();
                            }
                        #endregion
                        #region spanish
                        case CourseHandler.COURSENAME.SpanishIntensive:
                            {
                                if(Grade >=8)
                                {
                                    if (gradeSubtraction <= GradeConverter.GetInverseGrade("A"))
                                        return CourseHandler.COURSENAME.Spanish1b.ToString();
                                }
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish1b.ToString();

                                return CourseHandler.COURSENAME.Spanish1a.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish1a:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish1b.ToString();

                                return CourseHandler.COURSENAME.Spanish1a.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish1b:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish2.ToString();

                                return CourseHandler.COURSENAME.Spanish1b.ToString();
                            }

                        case CourseHandler.COURSENAME.Spanish3:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A-"))
                                    return CourseHandler.COURSENAME.Spanish4h.ToString();

                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish4.ToString();

                                return CourseHandler.COURSENAME.Spanish2.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish4:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A-"))
                                    return CourseHandler.COURSENAME.Spanish5H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish5.ToString();

                                return CourseHandler.COURSENAME.Spanish4.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish4h:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.Spanish5H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish5.ToString();

                                return CourseHandler.COURSENAME.Spanish4h.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish5:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.Spanish6H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish6.ToString();

                                return CourseHandler.COURSENAME.Spanish5.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish5H:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.Spanish6H.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Spanish6.ToString();

                                return CourseHandler.COURSENAME.Spanish5H.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish6:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.SpanishLit.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.SpanishLit.ToString();

                                return CourseHandler.COURSENAME.Spanish6.ToString();
                            }
                        case CourseHandler.COURSENAME.Spanish6H:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.SpanishLit.ToString();
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.SpanishLit.ToString();

                                return CourseHandler.COURSENAME.Spanish6H.ToString();
                            }
                        case CourseHandler.COURSENAME.SpanishLang:
                            {

                                return CourseHandler.COURSENAME.SpanishLit.ToString();
                            }
                        #endregion
                    }
                }
            }
            throw new Exception("Course not found");
        }


        //Determeine which math student should take the following year based on their current grades
        public String GetMathPlacement(int year)
        {

            if (classes[0] == null)
                return "No math course taken";
            else
            {
                if (classes[0].gradeFall == String.Empty)
                    return "No grade received";
                else
                { 
                    //Handling of the inverse grade done here, SIMPLE
                    int gradeSubtractionFall = GradeConverter.GetInverseGrade(classes[0].gradeFall);
                    int gradeSubtractionSpring = GradeConverter.GetInverseGrade(classes[0].gradeSpring);
                    int gradeSubtraction;

                    if (year >= 9)
                        gradeSubtraction = (gradeSubtractionFall + gradeSubtractionSpring) / 2;
                    else
                        gradeSubtraction = gradeSubtractionSpring;
                    CourseHandler.COURSENAME class_ = classes[0].course;

                    #region placements
                    switch (class_)
                    {
                        case CourseHandler.COURSENAME.PreAlgA:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B+"))
                                    return CourseHandler.COURSENAME.Algebra1.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Algebra1A.ToString();
                                else
                                    return CourseHandler.COURSENAME.PreAlgB.ToString();
                            }
                        case CourseHandler.COURSENAME.PreAlgB: //
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B+"))
                                    return CourseHandler.COURSENAME.Alg1H.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Algebra1.ToString();
                                else
                                    return CourseHandler.COURSENAME.Algebra1A.ToString();
                            }
                        case CourseHandler.COURSENAME.Algebra1:
                            {
                                if (Grade == 8)
                                {
                                    if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                        return CourseHandler.COURSENAME.Geometry.ToString();
                                    else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                        return CourseHandler.COURSENAME.Algebra1b.ToString();
                                }
                                else
                                {
                                    if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                        return CourseHandler.COURSENAME.Algebra1A.ToString();
                                }
                                return CourseHandler.COURSENAME.Algebra1.ToString();

                            }
                        case CourseHandler.COURSENAME.Algebra1A:
                            {
                                if (gradeSubtraction <= 8) //C-
                                    return CourseHandler.COURSENAME.Algebra1b.ToString();
                                else
                                    return CourseHandler.COURSENAME.Algebra1A.ToString();
                            }
                        case CourseHandler.COURSENAME.Algebra1b:
                            {
                                if (gradeSubtraction > 7)
                                    return CourseHandler.COURSENAME.Algebra1b.ToString();
                                else
                                    return CourseHandler.COURSENAME.Geometry.ToString();
                            }
                        case CourseHandler.COURSENAME.Alg1H:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B-"))
                                    return CourseHandler.COURSENAME.GeometryH.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Geometry.ToString();
                                else
                                    return CourseHandler.COURSENAME.Alg1H.ToString();

                            }
                        case CourseHandler.COURSENAME.Geometry:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A"))
                                    return CourseHandler.COURSENAME.Algebra2H.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.Algebra2B.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Algebra2A.ToString();
                                else
                                    return CourseHandler.COURSENAME.Geometry.ToString();
                            }
                        case CourseHandler.COURSENAME.GeometryH:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.Algebra2H.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Algebra2B.ToString();
                                else
                                    return CourseHandler.COURSENAME.GeometryH.ToString();
                            }
                        case CourseHandler.COURSENAME.Algebra2A:
                            {
                                if (gradeSubtraction >= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Algebra2A.ToString();
                                else
                                    return CourseHandler.COURSENAME.Trig.ToString();
                            }
                        case CourseHandler.COURSENAME.Algebra2B:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("A"))
                                    return CourseHandler.COURSENAME.PrecalcH.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.Precalc.ToString();
                                else
                                    return CourseHandler.COURSENAME.Trig.ToString();
                            }
                        case CourseHandler.COURSENAME.Algebra2H:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.PrecalcH.ToString();
                                else
                                    return CourseHandler.COURSENAME.Precalc.ToString();
                            }
                        case CourseHandler.COURSENAME.Trig:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B+"))
                                    return CourseHandler.COURSENAME.Precalc.ToString();
                                else if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.Finite.ToString();
                                else
                                    return CourseHandler.COURSENAME.Trig.ToString();
                            }

                        case CourseHandler.COURSENAME.Precalc:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.CalcFund.ToString();

                                return CourseHandler.COURSENAME.Finite.ToString();
                            }
                        case CourseHandler.COURSENAME.PrecalcH:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.CalcAB.ToString();

                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.CalcFund.ToString();

                                return CourseHandler.COURSENAME.Precalc.ToString();
                            }
                        case CourseHandler.COURSENAME.CalcFund:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("B"))
                                    return CourseHandler.COURSENAME.CalcAB.ToString();
                                else
                                    return CourseHandler.COURSENAME.CalcFund.ToString();
                            }
                        case CourseHandler.COURSENAME.CalcAB:
                            {
                                if (gradeSubtraction <= GradeConverter.GetInverseGrade("C-"))
                                    return CourseHandler.COURSENAME.CalcBC.ToString();
                                else
                                    return CourseHandler.COURSENAME.CalcAB.ToString();
                            }
                        case CourseHandler.COURSENAME.CalcBC:
                            {
                                if (gradeSubtraction <= 7)
                                    return CourseHandler.COURSENAME.StanfordLinearAlg.ToString();
                                else
                                    return CourseHandler.COURSENAME.CalcBC.ToString();
                            }
                        case CourseHandler.COURSENAME.Statistics:
                            {
                                if (gradeSubtraction > 7)
                                    return CourseHandler.COURSENAME.None.ToString();
                                else
                                    return CourseHandler.COURSENAME.None.ToString();
                            }
                        default:
                            throw new Exception("Course not found");


                    }
#endregion

                }
            }

        }
    }
}
