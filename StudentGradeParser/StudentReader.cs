using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentGradeParser
{
    class StudentReader
    {
        private int midFall = 8;
        private int fall = 11;
        
        public static Dictionary<int, Student> GetStudentReportList()
        {
            Dictionary<int,Student> students = new Dictionary<int, Student>();
            Dictionary<String, String> courseList = SchedulingFor8th.CourseHandler.GetCourseList();
            
            //read in the student grades
            using (  Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.spring.csv"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        //parse relevant student data
                        String str = reader.ReadLine();
                        String[] line = str.Split(',');

                        int ID = Int32.Parse(line[0]);
                        String LastName = line[1];
                        String FirstName = line[2];

                        int Grade = Int32.Parse(line[3]);
                        String SectionID = line[4].Split('-')[0];

                        //TODO: ensure there are no commas in teachers names before parse
                        //List of non academic classes that should not be included
                        if (SectionID == "10007" || SectionID == "00956" || SectionID == "09215" || SectionID == "00011" || SectionID == "00403" || SectionID == "00184")
                            continue;
                        else if (SectionID == "00457") // change improper section IDs to existing ones
                            SectionID = "00170";
                        else if (SectionID == "00458")
                            SectionID = "00455";
                        else if (SectionID == "99930")
                            SectionID = "00021";

                        SchedulingFor8th.Classes.Class_ class_ = SchedulingFor8th.CourseHandler.RetrieveCourse(  courseList[SectionID ]);
                        class_.gradeFall = line[11];
                        class_.gradeSpring = line[13];
                        
                        int arrayPosition = GetArrayPosition(class_);

                        if(!students.ContainsKey(ID)) //add student to dictionary, student ID is the key
                        {
                            Student student = new Student();
                            student.ID = ID;
                            student.FirstName = FirstName;
                            student.LastName = LastName;
                            student.Grade = Grade;
                            students[ID] = student;
                        }

                        if(students[ID].classes[arrayPosition] == null)
                            students[ID].classes[arrayPosition] = class_;
                        else //There is already a class at the position, therefore student is takign two of one subject
                        {
                            if (students[ID].classes[5] == null) 
                                students[ID].classes[arrayPosition] = class_;
                            else //Duplicates at the elective position, put in the erroneous spot
                            {
                                students[ID].classes[6] = class_;
                            }
                        }
                    }
                }
            }
            return students;
        }

        /*
         * Use reflection to determine which position of the array holding students classes should be placed
         */
        public static int GetArrayPosition(SchedulingFor8th.Classes.Class_ class_)
        {
            if (class_.GetType() == typeof(SchedulingFor8th.Classes.Elective))
                return 5;
            else if (class_.GetType() == typeof(SchedulingFor8th.Classes.Science))
                return 4;
            else if (class_.GetType() == typeof(SchedulingFor8th.Classes.History))
                return 3;
            else if (class_.GetType() == typeof(SchedulingFor8th.Classes.English))
                return 2;
            else if (class_.GetType() == typeof(SchedulingFor8th.Classes.ForeignLang))
                return 1;
            else if (class_.GetType() == typeof(SchedulingFor8th.Classes.Mathamatics))
                return 0;
            else
                throw new Exception("invalid class");
        }


    }
}
