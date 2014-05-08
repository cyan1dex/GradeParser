using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SchedulingFor8th;

namespace StudentGradeParser {
    class Program {
        static Dictionary<int, String> courses = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            // ExcelWriter.PrintScheduleToExcel();
            Dictionary<int, Student> students = Registration.GetFinalRegistration(Registration.GetRegistration());
            Registration.GetStudentMissingInfo(students);
           // Registration.WriteClassNumbers(Registration.GetCourseNumbers(students, typeof(SchedulingFor8th.Classes.History)));
            // Registration.WriteMissingSubjects(students);
             Registration.WriteCurrentCourseAndPlacement(students);
           //  Registration.WriteMissingStudentInfo(Registration.UnregisteredStudents(students));
            // Registration.WriteClass(students, CourseHandler.COURSENAME.Graphics);
           // Registration.WriteIndvidualClasses(students);
            //  SQLwriter.WriteSqlStatements();
            //  SQLwriter.WriteUpdateStatements();

            /* this reads previously written sql statements and writes them to text */
            // SQLwriter.WriteSQLstatements();
        }

        public static void ReadCourses()
        {

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.CourseIDs.txt"))
            {
                int test = 0;

                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String str = reader.ReadLine();
                    }
                }
            }
        }
    }
}
