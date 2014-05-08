using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentGradeParser {
    class Placements {

        public static Dictionary<int, String[]> GetPlacements()
        {
            Dictionary<int, String[]> placements = new Dictionary<int, string[]>();

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.otherRecs.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String[] vals = reader.ReadLine().Split(',');
                        int id = Int32.Parse(vals[3]);
                        if(id == 17522)
                        {
                            string x = "";
                        }
                        if(!placements.ContainsKey(id))
                        {
                            placements[id] = new string[3];
                        }

                        SetCourse(id, placements, vals[5]);
                    }
                }
            }

            return placements;
        }

        public static void SetCourse(int id, Dictionary<int, String[]> placements, String val)
        {
            switch(val)
            {
                    //2 is science
                case "SCIAP":
                    {
                        placements[id][2] = "AP";
                        break;
                    }
                case "SCIREG":
                    {
                        placements[id][2] = "Regular";
                        break;
                    }
                case "SCIH":
                    {
                        placements[id][2] = "Honors";
                        break;
                    }
                case "APENGL":
                    {
                        placements[id][1] = "AP";
                        break;
                    }
                case "ENGLREG":
                    {
                        placements[id][1] = "Regular";
                        break;
                    }
                case "HISTREG":
                    {
                        placements[id][0] = "Regular";
                        break;
                    }
                case "HISTAP":
                    {
                        placements[id][0] = "AP";
                        break;
                    }
         
            }
        }
    }
}
