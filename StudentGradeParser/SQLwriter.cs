using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentGradeParser {
    class SQLwriter 
    {
        //SQL statement to enter student information into the database
        public static void WriteSQLstatements()
        {
            List<String> lines = new List<string>();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.MSUS_Students.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine();
                        lines.Add(line);

                    }
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\sqlStatements.txt"))
            {
                file.WriteLine("INSERT INTO students (id, first_name, last_name, grade) VALUES");
                foreach (var line in lines)
                {
                    String[] vals = line.Split(',');

                    vals[1] = vals[1].Replace("\'", "");
                    vals[3] = vals[3].Replace("\'", "");
                    file.WriteLine(String.Format("('{0}',\'{1}\',\'{2}\',{3}),", vals[0], vals[1], vals[3], vals[5]));
                }
                file.Write(";");

            }
        }

        //upadte student placements 
        public static void WriteUpdateStatements(int year)
        {
            Dictionary<int, String[]> placements = Placements.GetPlacements();
            Dictionary<int, Student> report = StudentReader.GetStudentReportList();
            List<Student> students = (from student in report where student.Value.Grade == year select student.Value).ToList();

            String eng = "";
            String hist = "";
            String sci = "";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\sqlUpdate.txt"))
            {
                
                foreach (var student in students)
                {
                    if (placements.ContainsKey(student.ID))
                    {
                        hist = placements[student.ID][0];
                        sci = placements[student.ID][2];
                        eng = placements[student.ID][1];
                    }


                    file.WriteLine(String.Format("UPDATE registration SET english='{0}',science='{1}',history='{2}' WHERE id={3};",  eng, sci, hist, student.ID));
                  
                }
            }

        }
        public static void WriteSqlStatements() //create sql update statements for all placements
        {

            Dictionary<int, Student> report = StudentReader.GetStudentReportList();
            Dictionary<int, String[]> placements = Placements.GetPlacements();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\sqlStatements.txt"))
            {
                file.WriteLine("INSERT INTO registration (id,math,glang,history,science,english) VALUES");

                String math = "";
                String lang = "";
                String eng = "";
                String hist = "";
                String sci = "";

                for (int grade = 7; grade < 12; grade++)
                {
                    List<Student> students =
                        (from student in report where student.Value.Grade == grade select student.Value).ToList();
                    

                    foreach (var student in students)
                    {
                        
                        if (student.classes[0] != null) //math
                            math = student.GetMathPlacement(grade);

                        if (student.classes[1] != null) //foreign lang
                            lang = student.GetForeignLangPlacement(grade);

                        if(placements.ContainsKey(student.ID))
                        {
                            hist = placements[student.ID][0];
                            sci = placements[student.ID][2];
                            eng = placements[student.ID][1];
                        }
        


                        file.WriteLine(String.Format("({0},'{1}', '{2}','{3}','{4}','{5}'),",student.ID,math,lang,hist,sci,eng));
                     //   file.WriteLine(String.Format("({0}, {1} - {2}th math: {3} lang: {4}),", student.LastName,student.FirstName, student.Grade, math, lang));
                    }
                   
                }
                file.Write(";");
            }
        }
    }
}
