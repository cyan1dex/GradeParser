using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SchedulingFor8th.Classes;
using Math = SchedulingFor8th.Classes.Mathamatics;


namespace SchedulingFor8th {

    public class CourseHandler {

        /*
         * Populate the dictionary of courses to their section IDS
         */
        public static Dictionary<String, String> GetCourseList()
        {
           Dictionary<String,String> courseList = new Dictionary<String,String>();

            using (  Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StudentGradeParser.CourseIDs.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        String[] line = reader.ReadLine().Split(',');
                        String courseId = line[1];
                        String course = line[0];
                        
                        
                        courseList.Add(courseId, course);
                    }
                }
            }
            return courseList;
        }

        #region all course arrays
        public  static  string[] EnglishCourses = { "English7th", "English8th", "English9th", "English10th", "EnglishAmerican", "English11th", 
                                                    "English11thAP", "EnglishSelf", "English12APSelf", "EnglishEthics", "EnglishAngelino" };

        public static string[] MathCourses = {"PreAlgA", "PreAlgB", "Trig", "Finite", "Geometry", "GeometryH", "Algebra1", "Algebra1A", "Algebra1b",
                                                 "Alg1H", "Algebra2A", "Algebra2B", "Algebra2H", "Precalc", "PrecalcH", "CalcAB", "CalcBC", "CalcFund",  };


        public static string[] ScienceCourses = {"LifeSci", "PCB1", "Pcb2", "Pcb2H", "Pcb3", "Pcb3H", "ChemAP", "BioAP", "Forensics",
                                                 "BrainBehavior", "EnvironAP", "MarineBio", "PhysicsAP", "Physics", "Robotics",   };

        public static string[] HistoryCourses = {"History7th", "History8th", "History9th", "History10th","HistoryMiddleEastern", "HistoryAfrican", "HistoryAsian", "HistoryAmerican", "History11th", "History11AP",
                                                 "HistoryEcon", "HistoryGov", "HistoryArtHist", "WorldReligions"  };

        public static string[] GlobalLanguageCourses = {"FrenchIntensive", "French1a", "French1b", "French2", "French3", "French4", "French5", "French5H", "FrenchAP",
                                                        "SpanishIntensive", "Spanish1a", "Spanish1b", "Spanish3", "Spanish3H", "Spanish4", "Spanish5", "Spanish5H", "Spanish5Ap","Spanish6" ,"Spanish6H","SpanishLit","SpanishLang",
                                                       "ChineseIntensive", "Chinese1A", "Chinese1B", "Chinese2", "Chinese3", "Chinese3H", "Chinese4", "Chinese4H", "Chinese5","Chinese5H" ,"ChineseAP","ChineseVorVH",};

        public static string[] ElectiveChoices = {
                                                     "StudioArtFirstYear", "StudioArtAdvanced", "CeramicsFirstYear",
                                                     "CeramicsAdvanced", "PhotographyFirstYear", "PhotographyAdvanced",
                                                     "Theater1", "AdvancedActing", "MusicFull", "MusicAP",
                                                     "MusicalTheater", "CompSciAP","FundamentalsIT","Graphics","Statistics","JuniorCapstone","SeniorCapstone","MSON","None"
                                                 };

        public static string[] FallSports = {"Cheerleading","CrossCountry","Equestrian","Football","Golf_girls","Tennis_girls","Volleyball_girls","WaterPolo_boys","PE"
                                                ,"Dance","DanceCompany","None"};

        public static string[] WinterSports = {"Basketball_boys","Basketball_girls","Equestrian","Soccer_boys","Soccer_girls","WaterPolo_girls","PE","Dance","DanceCompany"
                                                ,"None"};

        public static string[] SpringSports = {"Baseball","Lacrosse_girls","Lacrosse_boys","Softball","Swimming","Tennis_boys","TrackField","Volleyball_boys","PE"
                                                ,"Dance","DanceCompany","None"};

        public static string[] MSON = {"Democracy","MobyDick","OttomanHistory","AdvancedCompSci","AbstractMath","AdvancedChem","OrganicChem","Meteorlogy","MultiVarCalc"};

#endregion

        #region course enums
        public enum COURSENAME {
            //English Courses
            English7th, English8th, English9th, English10th, EnglishAmerican, English11th, English11thAP, EnglishSelf, English12APSelf, EnglishEthics, EnglishAngelino, 
            //History Courses
            History7th, History8th, History9th, HistoryMiddleEastern, HistoryAfrican, HistoryAsian, WorldReligions, HistoryAmerican,History10th, History11th, History11AP, HistoryEcon, HistoryGov, HistoryArtHist,
            //Scienec Courses
            LifeSci, PCB1, Pcb2, Pcb2H, Pcb3, Pcb3H, ChemAP, BioAP, Forensics, BrainBehavior, EnvironAP, MarineBio, PhysicsAP, Physics, Robotics,
            //Foreign Language Courses
            FrenchIntensive, French1a, French1b, French2, French3, French3h, French4, French4H, French5, French5H, FrenchAP,
            SpanishIntensive, Spanish1a, Spanish1b, Spanish2, Spanish3, Spanish3H, Spanish4, Spanish4h, Spanish5, Spanish5H, Spanish5Ap, Spanish6, Spanish6H, SpanishLit, SpanishLang,
            ChineseIntensive, Chinese1A, Chinese1B, Chinese2, Chinese3, Chinese3H, Chinese4, Chinese4H, Chinese5, Chinese5H, ChineseAP,ChineseVorVH,
            //Math Courses
            PreAlgA, PreAlgB, Trig, Finite, Geometry, GeometryH, Algebra1, Algebra1A, Algebra1b, Alg1H, Algebra2A, Algebra2B, Algebra2H, Precalc, PrecalcH, CalcAB, CalcBC, CalcFund,  
            //Elective Coureses
            //Visual Arts
            StudioArtFirstYear, StudioArtAdvanced, CeramicsFirstYear, CeramicsAdvanced,Ceramics3aHonors, PhotographyFirstYear, PhotographyAdvanced,
            //Performing Arts
            Theater1, AdvancedActing, MusicFull, MusicAP, StageCraft, MusicalTheater,ConcertChoir1,
            //7th and 8th performing art
            Orchestra, Chorus,
            CompSciAP, FundamentalsIT, Graphics, Statistics, Capstone, MSON, None, StanfordLinearAlg,SciResearch,
            //MSON
            Democracy, MobyDick,OttomanHistory,AdvancedCompSci,AbstractMath,AdvancedChem,OrganicChem,Meteorlogy,MultiVarCalc,
            //Erroneous
            KindnessClub,HeadStart,
            //Sports Fall
            Cheerleading,CrossCountry,Equestrian,Football,Golf_girls,Tennis_girls,Volleyball_girls,WaterPolo_boys,PE,Dance,DanceCompany,
            //Sports Winter
            Basketball_boys,Basketball_girls,Soccer_boys,Soccer_girls,WaterPolo_girls,
            //sports spring
            Baseball,Golf,Lacrosse_girls,Lacrosse_boys,Softball,Swimming,Tennis_boys,TrackField,Volleyball_boys
        };
#endregion


        /*
         * Retrieve subject and course from input given as a str
         */
        public static Class_ RetrieveCourse(String str)
        {
            switch (str)
            {
                case "Chorus":
                    {
                        return new Elective(COURSENAME.Chorus);
                    }
                case "Orchestra":
                    {
                        return new Elective(COURSENAME.Orchestra);
                    }
                case "English7th":
                    {
                        return new English(COURSENAME.English7th);
                    }
                case "English8th":
                    {
                        return new English(COURSENAME.English8th);
                    }
                case "English9th":
                    {
                        return new English(COURSENAME.English9th);
                    }
                case "English10th":
                    {
                        return new English(COURSENAME.English10th);
                    }
                case "English11thAP":
                    {
                        return new English(COURSENAME.English11thAP);
                    }
                case "English11th":
                    {
                        return new English(COURSENAME.English11th);
                    }
                case "Angelino":
                    {
                        return new English(COURSENAME.EnglishAngelino);
                    }
                case "EnglishSelf":
                    {
                        return new English(COURSENAME.EnglishSelf);
                    }
                case "English12APSelf":
                    {
                        return new English(COURSENAME.English12APSelf);
                    }
                case "EnglishEthics":
                    {
                        return new English(COURSENAME.EnglishEthics);
                    }
                case "EnglishAmerican":
                    {
                        return new English(COURSENAME.EnglishAmerican);
                    }
                case "Theater1":
                    {
                        return new Elective(COURSENAME.Theater1);
                    }
                case "Statistics":
                    {
                        return new Math(COURSENAME.Statistics);
                    }
                case "ChemAP":
                    {
                        return new Science(COURSENAME.ChemAP);
                    }
                case "EnvironAP":
                    {
                        return new Science(COURSENAME.EnvironAP);
                    }
                case "Forensics":
                    {
                        return new Science(COURSENAME.Forensics);
                    }
                case "AdvancedActing":
                    {
                        return new Elective(COURSENAME.AdvancedActing);
                    }
                case "StudioArtFirstYear":
                    {
                        return new Elective(COURSENAME.StudioArtFirstYear);
                    }

                case "StudioArtAdvanced 2":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "2");
                    }
                case "StudioArtAdvanced 3":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "3");
                    }
                case "StudioArtAdvanced4":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "4");
                    }
                case "PhotographyFirstYear":
                    {
                        return new Elective(COURSENAME.PhotographyFirstYear);
                    }
                case "PhotographyAdvanced2":
                    {
                        return new Elective(COURSENAME.PhotographyAdvanced, "2");
                    }
                case "PhotographyAdvanced 2":
                    {
                        return new Elective(COURSENAME.PhotographyAdvanced, "2");
                    }
                case "PhotographyAdvanced 3":
                    {
                        return new Elective(COURSENAME.PhotographyAdvanced, "3");
                    }
                case "PhotographyAdvanced3":
                    {
                        return new Elective(COURSENAME.PhotographyAdvanced, "3");
                    }
                case "CeramicsFirstYear":
                    {
                        return new Elective(COURSENAME.CeramicsFirstYear);
                    }
                case "CeramicsAdvanced2":
                    {
                        return new Elective(COURSENAME.CeramicsAdvanced, "2");
                    }
                case "CeramicsAdvanced 2":
                    {
                        return new Elective(COURSENAME.CeramicsAdvanced, "2");
                    }
                case "CeramicsAdvanced 3":
                    {
                        return new Elective(COURSENAME.CeramicsAdvanced, "3");
                    }
                case "CeramicsAdvanced 4":
                    {
                        return new Elective(COURSENAME.CeramicsAdvanced, "4");
                    }
                case "MusicFull":
                    {
                        return new Elective(COURSENAME.MusicFull);
                    }
                case "MusicAP":
                    {
                        return new Elective(COURSENAME.MusicAP);
                    }
                case "CompSciAP":
                    {
                        return new Elective(COURSENAME.CompSciAP);
                    }
                case "Graphics":
                    {
                        return new Elective(COURSENAME.Graphics);
                    }
                case "StageCraft":
                    {
                        return new Elective(COURSENAME.StageCraft);
                    }
                case "MusicalTheater":
                    {
                        return new Elective(COURSENAME.MusicalTheater);
                    }

                case "MSON Advanced Computer Programming":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Advanced Computer Programming");
                    }
                case "Malone Stanford Online Network (MSON) Arabic 1":
                    {
                        return new Elective(COURSENAME.MSON, "(MSON) Arabic 1");
                    }
                case "MSON Introduction to Organic Chemistry (sem 1)":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Introduction to Organic Chemistry (sem 1)");
                    }
                case "MSON Advanced Topics in Chemistry (sem 2)":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Advanced Topics in Chemistry (sem 2)");
                    }
                case "MSON Ottoman":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Ottoman");
                    }
                case "MSON Meteorol":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Meteorol");
                    }
                case "MSON meteorol":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Meteorol");
                    }
                case "MSON democracy":
                    {
                        return new Elective(COURSENAME.MSON, "MSON democracy");
                    }
                case "MSON Arabic":
                    {
                        return new Elective(COURSENAME.MSON, "MSON Arabic");
                    }
                case "MSON comp":
                    {
                        return new Elective(COURSENAME.MSON, "MSON comp");
                    }
                case "MSON chem sem1":
                    {
                        return new Elective(COURSENAME.MSON, "MSON chem sem1");
                    }
                case "MSON chem sem2":
                    {
                        return new Elective(COURSENAME.MSON, "MSON chem sem2");
                    }
                case "MSON advancedmath":
                    {
                        return new Elective(COURSENAME.MSON, "MSON advancedmath");
                    }
                case "MSON multivar":
                    {
                        return new Elective(COURSENAME.MSON, "MSON multivar");
                    }
                case "CalcAB":
                    {
                        return new Math(COURSENAME.CalcAB);
                    }
                case "HistoryArtHist":
                    {
                        return new History(COURSENAME.HistoryArtHist);
                    }
                case "CalcFund":
                    {
                        return new Math(COURSENAME.CalcFund);
                    }
                case "HistoryEcon":
                    {
                        return new History(COURSENAME.HistoryEcon);
                    }
                case "BioAP":
                    {
                        return new Science(COURSENAME.BioAP);
                    }
                case "PhysicsAP":
                    {
                        return new Science(COURSENAME.PhysicsAP);
                    }

                case "HistoryGov":
                    {
                        return new History(COURSENAME.HistoryGov);
                    }
                    
                case "MarineBio":
                    {
                        return new Science(COURSENAME.MarineBio);
                    }

                case "SpanishIntensive":
                    {
                        return new ForeignLang(COURSENAME.SpanishIntensive);
                    }
                case "Spanish1a":
                    {
                        return new ForeignLang(COURSENAME.Spanish1a);
                    }
                case "Spanish1b":
                    {
                        return new ForeignLang(COURSENAME.Spanish1b);
                    }
                case "Spanish3":
                    {
                        return new ForeignLang(COURSENAME.Spanish3);
                    }

                case "Spanish3H":
                    {
                        return new ForeignLang(COURSENAME.Spanish3);
                    }
                case "Spanish4":
                    {
                        return new ForeignLang(COURSENAME.Spanish4);
                    }
                case "Spanish4h":
                    {
                        return new ForeignLang(COURSENAME.Spanish4h);
                    }
                case "Spanish5":
                    {
                        return new ForeignLang(COURSENAME.Spanish5);
                    }
                case "Spanish5H":
                    {
                        return new ForeignLang(COURSENAME.Spanish5H);
                    }
                case "Spanish6":
                    {
                        return new ForeignLang(COURSENAME.Spanish6);
                    }
                case "Spanish6Honors":
                    {
                        return new ForeignLang(COURSENAME.Spanish6, "Honors");
                    }
                case "SpanishLang":
                    {
                        return new ForeignLang(COURSENAME.SpanishLang);
                    }
                case "SpanishLit":
                    {
                        return new ForeignLang(COURSENAME.SpanishLit);
                    }

                case "FrenchIntensive":
                    {
                        return new ForeignLang(COURSENAME.FrenchIntensive);
                    }
                case "French1a":
                    {
                        return new ForeignLang(COURSENAME.French1a);
                    }
                case "French1b":
                    {
                        return new ForeignLang(COURSENAME.French1b);
                    }
                case "French2":
                    {
                        return new ForeignLang(COURSENAME.French2);
                    }
                case "French3":
                    {
                        return new ForeignLang(COURSENAME.French3);
                    }
                case "French3h":
                    {
                        return new ForeignLang(COURSENAME.French3h);
                    }
                case "French4":
                    {
                        return new ForeignLang(COURSENAME.French4);
                    }
                case "French5":
                    {
                        return new ForeignLang(COURSENAME.French5);
                    }
                case "French4Honors":
                    {
                        return new ForeignLang(COURSENAME.French4, "Honors");
                    }
                case "French5Honors":
                    {
                        return new ForeignLang(COURSENAME.French5, "Honors");
                    }
                case "FrenchAP":
                    {
                        return new ForeignLang(COURSENAME.FrenchAP);
                    }
                case "ChineseIntensive":
                    {
                        return new ForeignLang(COURSENAME.ChineseIntensive);
                    }
                case "Chinese1A":
                    {
                        return new ForeignLang(COURSENAME.Chinese1A);
                    }
                case "Chinese1B":
                    {
                        return new ForeignLang(COURSENAME.Chinese1B);
                    }
                case "Chinese2":
                    {
                        return new ForeignLang(COURSENAME.Chinese2);
                    }

                case "Chinese3":
                    {
                        return new ForeignLang(COURSENAME.Chinese3);
                    }
                case "Chinese4":
                    {
                        return new ForeignLang(COURSENAME.Chinese4);
                    }
                case "Chinese3Honors":
                    {
                        return new ForeignLang(COURSENAME.Chinese3, "Honors");
                    }
                case "Chinese4Honors":
                    {
                        return new ForeignLang(COURSENAME.Chinese4, "Honors");
                    }
                case "Chinese 5 Honors":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "Chinese4AP":
                    {
                        return new ForeignLang(COURSENAME.Chinese4, "AP");
                    }
                case "HistoryAmerican":
                    {
                        return new History(COURSENAME.HistoryAmerican);
                    }
                case "History11AP":
                    {
                        return new History(COURSENAME.History11AP);
                    }

                case "History_11th":
                    {
                        return new History(COURSENAME.History11th);
                    }
                case "History_10th":
                    {
                        return new History(COURSENAME.History10th);
                    }


                case "HistoryMiddleEastern":
                    {
                        return new History(COURSENAME.HistoryMiddleEastern);
                    }
                case "HistoryAsian":
                    {
                        return new History(COURSENAME.HistoryAsian);
                    }
                case "HistoryAfrican":
                    {
                        return new History(COURSENAME.HistoryAfrican);
                    }
                case "History7th":
                    {
                        return new History(COURSENAME.History7th);
                    }
                case "History8th":
                    {
                        return new History(COURSENAME.History8th);
                    }
                case "History9th":
                    {
                        return new History(COURSENAME.History9th);
                    }
                case "History10th":
                    {
                        return new History(COURSENAME.History10th);
                    }
                case "PreAlgA":
                    {
                        return new Math(COURSENAME.PreAlgA);
                    }
                case "PreAlgB":
                    {
                        return new Math(COURSENAME.PreAlgB);
                    }
                case "GeometryH":
                    {
                        return new Math(COURSENAME.GeometryH);
                    }
                case "Geometry":
                    {
                        return new Math(COURSENAME.Geometry);
                    }
                case "Algebra1":
                    {
                        return new Math(COURSENAME.Algebra1);
                    }
                case "Alg1H":
                    {
                        return new Math(COURSENAME.Alg1H);
                    }
                case "Algebra1A":
                    {
                        return new Math(COURSENAME.Algebra1A);
                    }
                case "Algebra1b":
                    {
                        return new Math(COURSENAME.Algebra1b);
                    }
                case "Algebra2A":
                    {
                        return new Math(COURSENAME.Algebra2A);
                    }
                case "Algebra2B":
                    {
                        return new Math(COURSENAME.Algebra2B);
                    }
                case "Algebra2H":
                    {
                        return new Math(COURSENAME.Algebra2H);
                    }
                case "Precalc":
                    {
                        return new Math(COURSENAME.Precalc);
                    }
                case "PrecalcH":
                    {
                        return new Math(COURSENAME.PrecalcH);
                    }

                case "CalcBC":
                    {
                        return new Math(COURSENAME.CalcBC);
                    }
                case "Trig":
                    {
                        return new Math(COURSENAME.Trig);
                    }
                case "Pcb2Honors":
                    {
                        return new Science(COURSENAME.Pcb2H);
                    }
                case "LifeSci":
                    {
                        return new Science(COURSENAME.LifeSci);
                    }
                case "PCB1":
                    {
                        return new Science(COURSENAME.PCB1);
                    }
                case "Pcb2":
                    {
                        return new Science(COURSENAME.Pcb2);
                    }
                case "Pcb3H":
                    {
                        return new Science(COURSENAME.Pcb3H);
                    }
                case "Pcb3":
                    {
                        return new Science(COURSENAME.Pcb3);
                    }

                case "BrainBehavior":
                    {
                        return new Science(COURSENAME.BrainBehavior);
                    }
                case "Chinese5":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "StudioArtAdvanced":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced);
                    }
                case "StudioArtAdvanced 6":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "6");
                    }
                case "StudioArtAdvanced 4":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "4");
                    }
                case "StudioArtAdvanced2":
                    {
                        return new Elective(COURSENAME.StudioArtAdvanced, "2");
                    }
                case "Post-AP math":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "Organic Chemistry (sem 1)":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "democracy":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "adv comp sci":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "multivar calc":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "Chinese":
                    {
                        return new Elective(COURSENAME.MSON, str);
                    }
                case "EnglishAngelino":
                    {
                        return new English(COURSENAME.EnglishAngelino);
                    }
                case "CeramicsAdvanced":
                    {
                        return new Elective(COURSENAME.CeramicsAdvanced);
                    } 
                case"Ceramics 3A (H)":
                    {
                        return new Elective(COURSENAME.Ceramics3aHonors);
                    }
                case "Kindness Club":
                    {
                        return new Elective(COURSENAME.KindnessClub);
                    }
                case "Head Start-Los Colores":
                    {
                        return new Elective(COURSENAME.HeadStart);
                    }
                case "PhotographyAdvanced":
                    {
                        return new Elective(COURSENAME.PhotographyAdvanced);
                    }
                case "Chinese V/VH":
                    {
                        return new ForeignLang(COURSENAME.ChineseVorVH);
                    }
                case "Stanford Online HS: Linear Alg":
                    {
                        return new Math(COURSENAME.StanfordLinearAlg);
                    }

                case "":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "NULL":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "PCB2H":
                    {
                        return new Science(COURSENAME.Pcb2H);
                    }
                case "Alg1A":
                    {
                        return new Math(COURSENAME.Algebra1A);
                    }
                case "Chinese3H":
                    {
                        return new ForeignLang(COURSENAME.Chinese3H);
                    }
                case "Chinese4H":
                    {
                        return new ForeignLang(COURSENAME.Chinese4H);
                    }
                case "Spanish2":
                    {
                        return new ForeignLang(COURSENAME.Spanish2);
                    }
                case "Regular":
                    {
                        return new Science(COURSENAME.None);
                    }
                case "Honors":
                    {
                        return new Science(COURSENAME.None);
                    }
                case "PCB 3H":
                    {
                        return new Science(COURSENAME.Pcb3H);
                    }
                case "AP":
                    {
                        return new Science(COURSENAME.None);
                    }
                case "No grade received":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "French4h":
                    {
                        return new ForeignLang(COURSENAME.French4H);
                    }
                case "Spanish6H":
                    {
                        return new ForeignLang(COURSENAME.French4H);
                    }
                case "French5H":
                    {
                        return new ForeignLang(COURSENAME.French5H);
                    }
                case "Chinese 4 AP":
                    {
                        return new ForeignLang(COURSENAME.ChineseAP);
                    }
                case "Finite":
                    {
                        return new Math(COURSENAME.Finite);
                    }
                case "StanfordLinearAlg":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "None":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "unselected":
                    {
                        return new Math(COURSENAME.None);
                    }
                case "History11th":
                    {
                        return new History(COURSENAME.History11th);
                    }
                case "Pcb2H":
                    {
                        return new Science(COURSENAME.Pcb2H);
                    }
                case "WorldReligions":
                    {
                        return new History(COURSENAME.WorldReligions);
                    }
                case "Capstone":
                    {
                        return new History(COURSENAME.Capstone);
                    }
                case "History11thAP":
                    {
                        return new History(COURSENAME.History11AP);
                    }
                case "Stagecraft":
                    {
                        return new Elective(COURSENAME.StageCraft);
                    }
                case "SciResearch":
                    {
                        return new Elective(COURSENAME.SciResearch);
                    }
                case "APmusic":
                    {
                        return new Elective(COURSENAME.MusicAP);
                    }
                case "Robotics":
                    {
                        return new Elective(COURSENAME.Robotics);
                    }
                case "ConcertChoir1":
                    {
                        return new Elective(COURSENAME.ConcertChoir1);
                    }
                case "Calc AB":
                    {
                        return new Math(COURSENAME.CalcAB);
                    }
                case "PCB2":
                    {
                        return new Science(COURSENAME.Pcb2);
                    }
                case "MSON":
                    {
                        return new Elective(COURSENAME.MSON);
                    }
                case "PreCalc":
                    {
                        return new Math(COURSENAME.Precalc);
                    }
                case "GeoH":
                    {
                        return new Math(COURSENAME.GeometryH);
                    }
                case "Theatre1":
                    {
                        return new Elective(COURSENAME.Theater1);
                    }
                case "JuniorCapstone":
                    {
                        return new Elective(COURSENAME.None);
                    }
                case "SeniorCapstone":
                    {
                        return new Elective(COURSENAME.None);
                    }
                default:
                    throw new Exception("No course match");
            }
        

        }
    }

}
