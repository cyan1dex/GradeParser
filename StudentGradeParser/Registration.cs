using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SchedulingFor8th;
using SchedulingFor8th.Classes;

namespace StudentGradeParser {
    class Registration {
        public static List<Student> GetRegistration()
        {
            List<Student> registration = new List<Student>();

            int unknown = 0;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.registration.csv"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine();

                        String[] vals = line.Split(',');
                        for (int i = 0; i < vals.Length; i++)
                            vals[i] = vals[i].Trim('\"'); //remove poor formatting delimeters

                        Student student = new Student();
                        String[] date = vals[14].Split('-');
                        int day = Int32.Parse(date[2].Split(' ')[0]);
                        int month = Int32.Parse(date[1]);

                        if (vals[1] == "") //entries without student IDs got registered into the database, keep track of unknowns
                            vals[1] = "" + unknown++;

                        student.ID = Int32.Parse(vals[1]);

                        //math
                        student.classes[0] = CourseHandler.RetrieveCourse(vals[4]);
                        //glang
                        student.classes[1] = CourseHandler.RetrieveCourse(vals[6]);
                        //science
                        student.classes[2] = CourseHandler.RetrieveCourse(vals[3]);
                        //english
                        student.classes[3] = CourseHandler.RetrieveCourse(vals[2]);
                        //history
                        student.classes[4] = CourseHandler.RetrieveCourse(vals[5]);
                        //elective
                        student.classes[5] = CourseHandler.RetrieveCourse(vals[7]);

                        if (vals[8] != null)
                            student.duplicate = vals[8];

                        if (Int32.Parse(vals[12]) == 1)
                            student.mathPlacement = true;
                        if (Int32.Parse(vals[13]) == 1)
                            student.langPlacement = true;
                        if (day > 21 || month > 4 ) //use registratio9ns after april 21st or May 
                            registration.Add(student);

                    }
                }
            }

            return registration;
        }


        public static Dictionary<int, Student> GetFinalRegistration(List<Student> students)
        {
            Dictionary<int, Student> unique = new Dictionary<int, Student>();

            for (int pos = students.Count - 1; pos >= 0; pos--)
            {
                if (!unique.ContainsKey(students[pos].ID))
                    unique[students[pos].ID] = students[pos];
            }
            return unique;
        }

        public static Dictionary<SchedulingFor8th.CourseHandler.COURSENAME, int> GetCourseNumbers(Dictionary<int, Student> students)
        {
            Dictionary<CourseHandler.COURSENAME, int> courseData = new Dictionary<CourseHandler.COURSENAME, int>();


            
            foreach (KeyValuePair<int, Student> entry in students)
            {
                foreach (SchedulingFor8th.Classes.Class_ c in entry.Value.classes)
                {
                    if (c == null || entry.Value.ID <= 60)
                        continue;

                    if (!courseData.ContainsKey(c.course))
                        courseData[c.course] = 0;

                    courseData[c.course]++;
                }

            }
            return courseData;
        }

        public static Dictionary<SchedulingFor8th.CourseHandler.COURSENAME, int> GetCourseNumbers(Dictionary<int, Student> students, Type type)
        {
            Dictionary<CourseHandler.COURSENAME, int> courseData = new Dictionary<CourseHandler.COURSENAME, int>();

            foreach (KeyValuePair<int, Student> entry in students)
            {
                foreach (SchedulingFor8th.Classes.Class_ c in entry.Value.classes)
                {
                    if (c == null || entry.Value.ID <= 60 || c.GetType() != type)
                        continue;

                    if (!courseData.ContainsKey(c.course))
                        courseData[c.course] = 0;

                    courseData[c.course]++;
                }

            }
            return courseData;
        }

        public static Dictionary<int, Student> GetStudentInfo()
        {
            Dictionary<int, Student> info = new Dictionary<int, Student>();
            int total = 0;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.MSUS_Students.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String[] vals = reader.ReadLine().Split(',');

                        if (!info.ContainsKey(Int32.Parse(vals[0])))
                        {
                            info[Int32.Parse(vals[0])] = new Student();

                        }
                        int grade = Int32.Parse(vals[5]);
                        info[Int32.Parse(vals[0])].Grade = grade;
                        info[Int32.Parse(vals[0])].FirstName = vals[1];
                        info[Int32.Parse(vals[0])].LastName = vals[3];
                        if (grade == 7)
                            total++;
                    }
                }
            }
            return info;
        }

        public static List<Student> UnregisteredStudents(Dictionary<int, Student> registration)
        {
            List<Student> unregistered = new List<Student>();

            Dictionary<int, Student> students = GetStudentInfo();

            foreach (var student in students)
            {
                if (!registration.ContainsKey(student.Key) && student.Value.Grade != 12)
                    unregistered.Add(student.Value);
            }
            return unregistered;
        }

        public static void WriteMissingStudentInfo(List<Student> students)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\unregistered.txt"))
            {
                int pos = 1;
                foreach (Student s in students)
                {
                    file.WriteLine(String.Format("{0}.) {1} {2}", pos++, s.FirstName, s.LastName));
                }
            }
        }

        public static void GetStudentMissingInfo(Dictionary<int, Student> students)
        {
            Dictionary<int, Student> info = GetStudentInfo();

            foreach (var student in students)
            {
                if (!info.ContainsKey(student.Key))
                    continue;
                student.Value.Grade = info[student.Key].Grade;
                student.Value.FirstName = info[student.Key].FirstName;
                student.Value.LastName = info[student.Key].LastName;
            }
        }

        public static void WriteRqPlacements(Dictionary<int, Student> students)
        {
            int pos = 1;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\palcements.txt"))
            {
                file.WriteLine("Requested Math Placements");
                foreach (var student in students)
                {
                    if (student.Key > 60 && student.Value.mathPlacement)
                        file.WriteLine(String.Format("{0}.) ID:{1} \t {2} {3}", pos++, student.Key, student.Value.FirstName, student.Value.LastName));
                }


                pos = 1;
                file.WriteLine("Requested Lang Placements");
                foreach (var student in students)
                {
                    if (student.Key > 60 && student.Value.langPlacement)
                        file.WriteLine(String.Format("{0}.) ID:{1} \t {2} {3}", pos++, student.Key, student.Value.FirstName, student.Value.LastName));
                }
            }
        }

        public static void WriteStudentsClasses(Dictionary<int, Student> students)
        {
            int pos = 1;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\classes.txt"))
            {
                foreach (var student in students)
                {
                    if (student.Key > 60)
                    {
                        file.WriteLine(String.Format("{0}.) {1} {2} {3} ", pos++, student.Value.FirstName, student.Value.LastName,student.Key ));
                        foreach (Class_ c in student.Value.classes)
                            if (c != null && c.course.ToString() != "None")
                                file.WriteLine(String.Format(" \t {0}", c.course.ToString()));
                        file.WriteLine();
                    }

                }
            }
        }

        public static void WriteIndvidualClasses(Dictionary<int, Student> students)
        {
            int pos = 1;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\individuals.txt"))
            {
                foreach (var student in students)
                {
                    Class_ c = student.Value.classes[3];

                    if(c == null)
                        c = new Science(CourseHandler.COURSENAME.None);

                        if ((student.Key > 70) && student.Value.Grade == 10)
                            file.WriteLine(String.Format("{0}.) {1} \t {2} {3} \t {4}", pos++, student.Key, student.Value.FirstName, student.Value.LastName, c.course.ToString()));
                }
            }
        }

        public static void WriteClass(Dictionary<int, Student> students, CourseHandler.COURSENAME course)
        {
            int pos = 1;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\religion.txt"))
            {
                foreach (var student in students)
                {
                    foreach (Class_ c in student.Value.classes)
                        if ((c != null && student.Key > 60) && (c.GetCourse() == course))
                            file.WriteLine(String.Format("{0}.) ID:{1} \t {2} {3} \t {4}", pos++, student.Key, student.Value.FirstName, student.Value.LastName, c.course.ToString()));
                }
            }
        }

        public static void WriteMissingSubjects(Dictionary<int, Student> students)
        {

            int science8th = 0;
            int science9th = 0;
            int science10th = 0;

            int englisth10th = 0;
            int english11th = 0;
            int history11th = 0;
            int history10th = 0;

            foreach (KeyValuePair<int, Student> entry in students)
            {
                if (entry.Value.classes[2].course.ToString() == "None")
                {
                    if (entry.Value.Grade == 8)
                        science8th++;
                    else if (entry.Value.Grade == 9)
                        science9th++;
                    else if (entry.Value.Grade == 10)
                        science10th++;
                }
                if (entry.Value.classes[3].course.ToString() == "None")
                {
                    if (entry.Value.Grade == 10)
                        englisth10th++;
                    else if (entry.Value.Grade == 11)
                        english11th++;
                }
                if (entry.Value.classes[4].course.ToString() == "None")
                {
                    if (entry.Value.Grade == 10)
                        history10th++;
                    else if (entry.Value.Grade == 11)
                        history11th++;
                }

            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\missing.txt"))
            {
                file.WriteLine("science 8th missing: " + science8th);
                file.WriteLine("science 9th missing: " + science9th);
                file.WriteLine("science 10th missing: " + science10th);

                file.WriteLine("english 10th missing: " + englisth10th);
                file.WriteLine("english 11th missing: " + english11th);

                file.WriteLine("history 10th missing: " + history10th);
                file.WriteLine("history 11th missing: " + history11th);
            }
        }

        public static void GetDuplicates(Dictionary<int, Student> students)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\dupes.txt"))
            {

                foreach (KeyValuePair<int, Student> entry in students)
                {
                    if (entry.Value.duplicate != null)
                        file.WriteLine(entry.Value.duplicate);
                }
            }
        }

        public static void WriteClassNumbers(Dictionary<SchedulingFor8th.CourseHandler.COURSENAME, int> courses)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\courses"))
            {
                foreach (var course in courses)
                {
                    file.WriteLine(course.Key + ": " + course.Value);
                }
            }
        }


        public static void WriteCurrentCourseAndPlacement(Dictionary<int, Student> studentPlacements)
        {
            Dictionary<int, Student> currentPlacements = StudentReader.GetStudentReportList();

            Dictionary<CourseHandler.COURSENAME, List<Student>> courses = new Dictionary<CourseHandler.COURSENAME, List<Student>>();
            List<int> notShceduled = new List<int>();

            foreach(KeyValuePair<int, Student> entry in currentPlacements)
            {
                foreach(Class_ c in entry.Value.classes)
                {
                    if(c != null && c.GetCourse() != CourseHandler.COURSENAME.None &&  c.GetType() == typeof(Science))
                    {
                        if (!courses.ContainsKey(c.course))
                        courses[c.course] = new List<Student>();

                        try
                        {
                            courses[c.course].Add(studentPlacements[entry.Key]);
                        }
                        catch(KeyNotFoundException exception)
                        {
                            notShceduled.Add(entry.Key);
                                
                        }
                        
                    }
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\courses.txt"))
            {
                foreach (var course in courses)
                {
                    file.WriteLine(course.Key.ToString());

                    foreach(Student s in course.Value)
                    {
                        foreach(Class_ c in s.classes)
                        {
                            if (c != null && c.GetCourse() != CourseHandler.COURSENAME.None &&  c.GetType() == typeof(Science))
                                file.WriteLine(String.Format("{0}, {1} {2} - {3}: {4}",s.LastName, s.FirstName,s.Grade,s.ID, c.GetCourse().ToString()));
                        }
                    }
                    file.WriteLine();
                }

                foreach (var i in notShceduled)
                {
                    if (currentPlacements[i].Grade < 12)
                    file.WriteLine(String.Format("{0} - {1}, {2}", currentPlacements[i].ID, currentPlacements[i].LastName, currentPlacements[i].FirstName));
                }
            }
        }
    }
}
