using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using SchedulingFor8th;


namespace StudentGradeParser
{

    public class ExcelWriter
    {
        static Dictionary<String, int > courseCounts = new Dictionary<String, int>(); 

        public static void PrintScheduleToExcel()
        {
            Array.Sort(CourseHandler.ElectiveChoices);
            object misValue = System.Reflection.Missing.Value;

            // Specify a "currently active folder"
            string activeDir = @"c:\";

            //Create a newPath - the Path to Excel file

            string newFileName = "schedule.xlsx";
            string newPath = System.IO.Path.Combine(activeDir, newFileName);

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(newPath, 0, true, 5, "", "", true,
                                                                                      Microsoft.Office.Interop.Excel.
                                                                                          XlPlatform.xlWindows, "\t", false,
                                                                                      false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet =
                (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Dictionary<int, Student> report = StudentReader.GetStudentReportList();


            

            //WRITES ALL CLASSES AND STUDENTS FOR EACH PERIOD TO A SEPARATE SHEET
            for (int i = 1; i <= 6; i++)      
                WritePeriodGrades((Microsoft.Office.Interop.Excel.Worksheet) xlWorkBook.Worksheets.get_Item(i), i,
                                  report);
            

            //   xlWorkBook.Worksheets.Add();
            Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(7); //get the 7th sheet
            sheet.Name = "Tally";
            //print course counts
            int row = 1;
            foreach (KeyValuePair<String,int> c in courseCounts)
            {
                sheet.Cells[row, 1] = c.Key.ToString();
                sheet.Cells[row++, 2] = c.Value.ToString();
            }

           // if (File.Exists("c:\\schedule.xlsx")) File.Delete("c:\\schedule.xlsx");
           // xlWorkBook.SaveAs("c:\\schedule.xlsx", XlFileFormat.xlWorkbookDefault, misValue, misValue, true, false, XlSaveAsAccessMode.xlExclusive, XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Workbooks.Close(); 
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }

        #region DropDownList

        public static void CreateDropDownList(Worksheet sheet, int grade, int row)
        {
            int electiveCol = 26;// "Z";
            int scienceCol = 17;//"Q";
            int englishCol = 20;//"T";
            int historyCol = 23;//"W";
            int msonCol = 27;
            int fallCol = 31;
            int winterCol = 32;
            int springCol = 33;

            //Sports Choices
            CreateList(sheet,CourseHandler.FallSports,fallCol,row);
            CreateList(sheet, CourseHandler.WinterSports, winterCol, row);
            CreateList(sheet, CourseHandler.SpringSports, springCol, row);


            //Class Choices
           
            switch (grade)
            {
                case 7:
                    {
                        string[] musicItems = {"Chorus", "Orchestra","None"} ;
                        sheet.Cells[row, scienceCol] = CourseHandler.COURSENAME.PCB1.ToString();
                        sheet.Cells[row, historyCol] = CourseHandler.COURSENAME.History8th.ToString();
                        sheet.Cells[row, englishCol] = CourseHandler.COURSENAME.English8th.ToString();
                        CreateList(sheet, musicItems, electiveCol, row);
                        
                        break;
                    }
                case 8:
                    {
                        //science choices
                        string[] scienceItems = { "Pcb2", "Pcb2H" };
                        CreateList(sheet, scienceItems, scienceCol, row);

                        //elective choices
                        string[] ElectiveChoices = { "CeramicsFirstYear", "CompSciAP", "FundamentalsIT", "MusicalTheater", "PhotographyFirstYear", "StudioArtFirstYear", "Theater1", "None", };
                        CreateList(sheet, ElectiveChoices, electiveCol, row);

                        sheet.Cells[row, historyCol] = CourseHandler.COURSENAME.History9th.ToString();
                        sheet.Cells[row, englishCol] = CourseHandler.COURSENAME.English9th.ToString();
                        break;
                    }
                case 9:
                    {
                        //history choices
                        string[] historyItems = { "HistoryAfrican", "HistoryAsian", "HistoryMiddleEastern", };
                        CreateList(sheet, historyItems, historyCol, row);

                        //science choices
                        string[] scienceItems = { "Pcb3", "Pcb3H" };
                        CreateList(sheet, scienceItems, scienceCol, row);

                        //elective choices
                        string[] ElectiveChoices = CourseHandler.ElectiveChoices;
                        CreateList(sheet, ElectiveChoices, electiveCol, row);

                        sheet.Cells[row, englishCol] = CourseHandler.COURSENAME.English10th.ToString();
                        break;
                    }
                case 10:
                    {
                        //history choices
                        string[] historyItems = { "HistoryAmerican", "History11th", "History11AP" ,"None"};
                        CreateList(sheet, historyItems, historyCol, row);

                        //science choices
                        string[] scienceItems = { "BioAP", "BrainBehavior", "ChemAP", "EnvironAP", "Forensics", "MarineBio", "Physics", "PhysicsAP", "Robotics", "None" };
                        CreateList(sheet, scienceItems, scienceCol, row);

                        //elective choices
                        string[] ElectiveChoices = CourseHandler.ElectiveChoices;
                        CreateList(sheet, ElectiveChoices, electiveCol, row);

                        //english choices
                        string[] englishChoices = { "EnglishAmerican", "English11th",  "English11thAP",};
                        CreateList(sheet, englishChoices, englishCol, row);

                        //Mson choices
                        CreateList(sheet,CourseHandler.MSON,msonCol,row);
                        break;
          
                    }
                case 11:
                    {
                        //history choices
                        string[] historyItems = { "HistoryArtHist", "HistoryEcon", "HistoryGov", "None" };
                        CreateList(sheet, historyItems, historyCol, row);

                        //science choices
                        string[] scienceItems = { "BioAP", "BrainBehavior", "ChemAP", "EnvironAP", "Forensics", "MarineBio", "Physics", "PhysicsAP", "Robotics", "None" };
                        CreateList(sheet, scienceItems, scienceCol, row);

                        //elective choices
                        string[] ElectiveChoices = CourseHandler.ElectiveChoices;
                        CreateList(sheet, ElectiveChoices, electiveCol, row);

                        //english choices
                        string[] englishChoices = {"EnglishAngelino" , "EnglishSelf", "English12APSelf", "EnglishEthics", };
                        CreateList(sheet, englishChoices,englishCol, row);

                        //Mson choices
                        CreateList(sheet, CourseHandler.MSON, msonCol, row);

                        break;
                    }             
                case 12: //nothing to do here
                    {
                        break;
                    }
                default:
                    {
                        throw new Exception("not a valid grade");
                    }
            }

            //Add item into drop down list
        }
            #endregion

        public static void CreateList(Worksheet sheet, string[] items, int col,int row)
        {
            var flatList = string.Join(",", items);
            var cell = (Range)sheet.Cells[row, col];
            cell.Validation.Delete();
            cell.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlBetween, flatList, Type.Missing);

            cell.Validation.IgnoreBlank = true;
            cell.Validation.InCellDropdown = true;
        }


        public static void WritePeriodGrades(Worksheet xlWorkSheet, int grade, Dictionary<int, Student> report)
        {        
            int gradeLevel = grade + 6;

            xlWorkSheet.Name = gradeLevel + "th";
            xlWorkSheet.Activate();
            xlWorkSheet.Application.ActiveWindow.SplitColumn = 2;
            xlWorkSheet.Application.ActiveWindow.SplitRow = 2;
            xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

            List<Student> students = (from student in report where student.Value.Grade == gradeLevel select student.Value).ToList();

            #region headers
            xlWorkSheet.Cells[1, 1] = gradeLevel + "th Grade";
            xlWorkSheet.Cells[2, 1] = "First";
            xlWorkSheet.Cells[2, 2] = "Last";
            xlWorkSheet.Cells[2, 3] = "ID";
            xlWorkSheet.Cells[1, 4] = "Math";
            xlWorkSheet.Cells[2, 4] = "Class";
            xlWorkSheet.Cells[2, 5] = "Grade Fall";
            xlWorkSheet.Cells[2, 6] = "Grade Spring";
            xlWorkSheet.Cells[2, 7] = "Placement";

            xlWorkSheet.Cells[1, 9] = "Class";
            xlWorkSheet.Cells[2, 9] = "Foreign Language";
            xlWorkSheet.Cells[2, 10] = "Grade Fall";
            xlWorkSheet.Cells[2, 11] = "Grade Spring";
            xlWorkSheet.Cells[2, 12] = "Placement";

            xlWorkSheet.Cells[1, 15] = "Science";
            xlWorkSheet.Cells[2, 15] = "Class";
            xlWorkSheet.Cells[2, 16] = "Grade";
            xlWorkSheet.Cells[2, 17] = "Choice";
            xlWorkSheet.Cells[1, 18] = "English";
            xlWorkSheet.Cells[2, 18] = "Class";
            xlWorkSheet.Cells[2, 19] = "Grade";
            xlWorkSheet.Cells[2, 20] = "Choice";
            xlWorkSheet.Cells[1, 21] = "History";
            xlWorkSheet.Cells[2, 21] = "Class";
            xlWorkSheet.Cells[2, 22] = "Grade";
            xlWorkSheet.Cells[2, 23] = "Choice";
            xlWorkSheet.Cells[1, 24] = "Elective";
            xlWorkSheet.Cells[2, 24] = "Class";
            xlWorkSheet.Cells[2, 25] = "Grade";
            xlWorkSheet.Cells[2, 26] = "Choice";
            xlWorkSheet.Cells[2, 27] = "MSON";
            xlWorkSheet.Cells[1, 27+1] = "Duplicate Subject";
            xlWorkSheet.Cells[2, 27+1] = "Class";
            xlWorkSheet.Cells[2, 28+1] = "Grade";
            xlWorkSheet.Cells[2, 29+1] = "Choice";
            xlWorkSheet.Cells[1, 30+1] = "Sports";
            xlWorkSheet.Cells[2, 30+1] = "Fall";
            xlWorkSheet.Cells[2, 31+1] = "Winter";
            xlWorkSheet.Cells[2, 32+1] = "Spring";
#endregion

            #region color Headers
            for (int r = 1; r <= 2; r++)
            {
                for (int c = 1; c <= 33; c++)
                {
                    Range cell = (Range)xlWorkSheet.Cells[r, c];

                    if (c >= 1 && c <= 3)
                        cell.Interior.Color = Color.Yellow;
                    else if (c >= 4 && c <= 7)
                        cell.Interior.Color = Color.LimeGreen;
                    else if (c >= 9 && c <= 12)
                        cell.Interior.Color = Color.Purple;
                    else if (c >= 15 && c <= 17)
                        cell.Interior.Color = Color.Blue;
                    else if (c >= 18 && c <= 20)
                        cell.Interior.Color = Color.Orange;
                    else if (c >= 21 && c <= 23)
                        cell.Interior.Color = Color.Red;
                    else if (c >= 24 && c <= 27)
                        cell.Interior.Color = Color.Orchid;
                   else if (c >= 28 && c <= 30)
                        cell.Interior.Color = Color.SpringGreen;
                    else if (c >= 31 && c <= 33) //31-33
                        cell.Interior.Color = Color.DeepPink;
                }
#endregion
            }

            int row = 3;

            foreach (var student in students)
            {
                xlWorkSheet.Cells[row, 1] = student.FirstName;
                xlWorkSheet.Cells[row, 2] = student.LastName;
                xlWorkSheet.Cells[row, 3] = student.ID;

                CreateDropDownList(xlWorkSheet, gradeLevel, row);

                for (int c = 1; c <= 33; c++)
                {
                    Range cell = (Range)xlWorkSheet.Cells[row, c];

                    cell.Interior.Color = row % 2 == 0 ? Color.Gray : Color.LightGray;
                }

                if (student.classes[0] != null) //math
                {
                    xlWorkSheet.Cells[row, 4] = student.classes[0].course.ToString();
                    xlWorkSheet.Cells[row, 5] = student.classes[0].gradeFall;
                    xlWorkSheet.Cells[row, 6] = student.classes[0].gradeSpring;
                    
                    if (student.Grade != 12)
                    {
                        String mathPlacement = student.GetMathPlacement(student.Grade);
                        xlWorkSheet.Cells[row, 7] = mathPlacement;

                        if (!courseCounts.ContainsKey(mathPlacement))
                            courseCounts[mathPlacement] = 0;
                        courseCounts[mathPlacement]++;
                    }
                }
                if (student.classes[1] != null) //foreign lang
                {
                    xlWorkSheet.Cells[row, 9] = student.classes[1].course.ToString();
                    xlWorkSheet.Cells[row, 10] = student.classes[1].gradeFall;
                    xlWorkSheet.Cells[row, 11] = student.classes[1].gradeSpring;

                    if (student.Grade != 12)
                    {
                        String globalLangPlacement = student.GetForeignLangPlacement(student.Grade);
                        xlWorkSheet.Cells[row, 12] = globalLangPlacement;

                        if (!courseCounts.ContainsKey(globalLangPlacement))
                            courseCounts[globalLangPlacement] = 0;
                        courseCounts[globalLangPlacement]++;
                    }
                }
                if (student.classes[4] != null) //science
                {
                    xlWorkSheet.Cells[row, 15] = student.classes[4].course.ToString();
                    xlWorkSheet.Cells[row, 16] = student.classes[4].gradeFall;
                }
                if (student.classes[2] != null) //english --> 3
                {
                    xlWorkSheet.Cells[row, 18] = student.classes[2].course.ToString();
                    xlWorkSheet.Cells[row, 19] = student.classes[2].gradeFall;
                }
                if (student.classes[3] != null) //history
                {
                    xlWorkSheet.Cells[row, 21] = student.classes[3].course.ToString();
                    xlWorkSheet.Cells[row, 22] = student.classes[3].gradeFall;
                }
                if (student.classes[5] != null) //elective
                {
                    xlWorkSheet.Cells[row, 24] = student.classes[5].course.ToString();
                    xlWorkSheet.Cells[row, 25] = student.classes[5].gradeFall;
                }
                if (student.classes[6] != null) //duplicate
                {
                    xlWorkSheet.Cells[row, 28] = student.classes[6].course.ToString();
                    xlWorkSheet.Cells[row, 29] = student.classes[6].gradeFall;
                }

                row++;
            }
        }



        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}