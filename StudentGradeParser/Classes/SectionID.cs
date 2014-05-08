using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulingFor8th.Classes {

    public class SectionID {

        public static string CourseID(Class_ class_)
        {
            if (class_.GetType() == typeof(ForeignLang) || class_.GetType() == typeof(Elective))
            {
                if (class_.GetType() == typeof(ForeignLang))
                {
                    switch (class_.GetCourse())
                    {
                        case CourseHandler.COURSENAME.French1a:
                            return "00501";
                        case CourseHandler.COURSENAME.French1b:
                            return "00503";
                        case CourseHandler.COURSENAME.French2:
                            return "00504";
                        case CourseHandler.COURSENAME.French3:
                            return "00506";
                        case CourseHandler.COURSENAME.French3h:
                            return "00517";
                        case CourseHandler.COURSENAME.French4:
                            return "00529";
                        case CourseHandler.COURSENAME.French5:
                            {
                                if (((ForeignLang)class_).type == "Honors")
                                    return "00518";
                                else
                                    return "00519";
                            }
                        case CourseHandler.COURSENAME.FrenchAP:
                            return "00530";
                        case CourseHandler.COURSENAME.FrenchIntensive:
                            return "00521";
                        case CourseHandler.COURSENAME.Spanish1a:
                            return "00086";
                         case CourseHandler.COURSENAME.Spanish1b:
                            return "Spanish 1b, UKNWN";
                        case CourseHandler.COURSENAME.Spanish3:
                            return "00510";
                        case CourseHandler.COURSENAME.Spanish3H:
                            return "spanish 3H uknwn";
                        case CourseHandler.COURSENAME.Spanish4:
                            return "00511";
                        case CourseHandler.COURSENAME.Spanish4h:
                            return "00512";
                        case CourseHandler.COURSENAME.Spanish5:
                            return "00513";
                        case CourseHandler.COURSENAME.Spanish5H:
                            return "00523";
                        case CourseHandler.COURSENAME.Spanish6:
                            {
                                if (((ForeignLang)class_).type == "Honors")
                                    return "00620";
                                else
                                    return "00524";
                            }
                        case CourseHandler.COURSENAME.SpanishLang:
                            return "00514";
                        case CourseHandler.COURSENAME.SpanishLit:
                            return "00515";
                        case CourseHandler.COURSENAME.SpanishIntensive:
                            return "00508";
                            case CourseHandler.COURSENAME.ChineseIntensive:
                            return "00528";
                        case CourseHandler.COURSENAME.Chinese1A:
                            return "00527";
                        case CourseHandler.COURSENAME.Chinese1B:
                            return "00161";
                        case CourseHandler.COURSENAME.Chinese2:
                            return "00165";
                        case CourseHandler.COURSENAME.Chinese3:
                            {
                                if (((ForeignLang)class_).type == "Honors")
                                    return "00173";
                                else
                                    return "00160";
                            }
                        case CourseHandler.COURSENAME.Chinese4:
                            {
                                if (((ForeignLang)class_).type == "AP")
                                    return "00059";
                                else
                                    return "00133";
                            }

                        case CourseHandler.COURSENAME.Chinese5:
                            {
                                if (((ForeignLang)class_).type == "Honors")
                                    return "00134";
                                else
                                    return "00160";
                            }
                            case CourseHandler.COURSENAME.None:
                            return "FREE";
                    }
                }
                else //Elective
                {
                    switch (class_.GetCourse())
                    {
                        case CourseHandler.COURSENAME.CompSciAP:
                            return "00206";
                        case CourseHandler.COURSENAME.Graphics:
                            return "00080";

                            case CourseHandler.COURSENAME.MSON:
                            return ((Elective) class_).type;
                        case CourseHandler.COURSENAME.Theater1: //Theater 1
                            return "00177";
                        case CourseHandler.COURSENAME.AdvancedActing:
                            return "00115";
                        case CourseHandler.COURSENAME.Orchestra:
                            return "00119";
                        case CourseHandler.COURSENAME.StageCraft:
                            return "00082";

                        case CourseHandler.COURSENAME.StudioArtFirstYear:
                            return "00164";
                        case CourseHandler.COURSENAME.StudioArtAdvanced:
                            {
                                {
                                    if (((Elective)class_).type == "2")
                                        return "00168";
                                    if (((Elective)class_).type == "3")
                                        return "00170";
                                    if (((Elective)class_).type == "4")
                                        return "00171";
                                    if (((Elective)class_).type == "5")
                                        return "00172";
                                    if (((Elective)class_).type == "6")
                                        return "00173";
                                    throw new Exception("Studio are level not found");
                                }
                            }
                        case CourseHandler.COURSENAME.CeramicsFirstYear:
                            return "00108";
                        case CourseHandler.COURSENAME.CeramicsAdvanced:
                            {
                                {
                                    if (((Elective)class_).type == "2")
                                        return "00106";
                                    if (((Elective)class_).type == "3")
                                        return "00107";
                                    if (((Elective)class_).type == "4")
                                        return "00105";
                                    if (((Elective)class_).type == "5")
                                        return "00110";
                                    if (((Elective)class_).type == "6")
                                        return "00085";
                                    throw new Exception("Studio are level not found");
                                }
                            }
                        case CourseHandler.COURSENAME.PhotographyFirstYear: //Digital Media
                            return "00013";
                        case CourseHandler.COURSENAME.PhotographyAdvanced:
                            {
                                if (((Elective)class_).type == "2")
                                    return "00018";
                                if (((Elective)class_).type == "3")
                                    return "00021";
                                throw new Exception("Photo level not found");
                            }

                        case CourseHandler.COURSENAME.MusicFull:
                            return "00116";
                        case CourseHandler.COURSENAME.MusicAP:
                            return "00938";
                            case CourseHandler.COURSENAME.Chorus:
                            return "00155";
                            case CourseHandler.COURSENAME.None:
                            return "FREE";
                    }
                }
            }
            else //science, math, english, history
            {
                switch (class_.GetCourse())
                {
                    case CourseHandler.COURSENAME.MarineBio:
                        return "00705";
                    case CourseHandler.COURSENAME.Trig:
                        return "00633";
                    case CourseHandler.COURSENAME.Statistics:
                        return "00058";
                    case CourseHandler.COURSENAME.English9th:
                        return "00305";
                    case CourseHandler.COURSENAME.English10th:
                        return "00302";
                    case CourseHandler.COURSENAME.English11th:
                        return "00332";
                     case CourseHandler.COURSENAME.English11thAP:
                        return "english 11AP uknwn";
                    case CourseHandler.COURSENAME.EnglishSelf:
                        return "00181";
                        case CourseHandler.COURSENAME.English12APSelf:
                        return "AP Self unkwn";
                    case CourseHandler.COURSENAME.EnglishEthics:
                        return "ethics unknwon";
                   case CourseHandler.COURSENAME.EnglishAngelino:
                        return "angelino unkwn";
                        case CourseHandler.COURSENAME.Algebra2B:
                        return "algebra 2b uknwn";

                        case CourseHandler.COURSENAME.Pcb2H:
                        return "pcb2H unkwn";

                    case CourseHandler.COURSENAME.English7th:
                        return "00303";
                    case CourseHandler.COURSENAME.English8th:
                        return "00304";
                    case CourseHandler.COURSENAME.Forensics:
                        return "00127";
                    case CourseHandler.COURSENAME.EnvironAP:
                        return "00057";

                    case CourseHandler.COURSENAME.History7th:
                        return "00405";
                    case CourseHandler.COURSENAME.History8th:
                        return "00406";
                    case CourseHandler.COURSENAME.History9th:
                        return "00407";
                    case CourseHandler.COURSENAME.HistoryMiddleEastern:
                        return "00422";
                    case CourseHandler.COURSENAME.HistoryAfrican:
                        return "00417";
                    case CourseHandler.COURSENAME.HistoryAsian:
                        return "00423";
                    case CourseHandler.COURSENAME.EnglishAmerican:
                        return "00131";
                    case CourseHandler.COURSENAME.HistoryAmerican:
                        return "00130";

                    case CourseHandler.COURSENAME.LifeSci:
                        return "00710";

                    case CourseHandler.COURSENAME.History11th:
                        return "00410";
                    case CourseHandler.COURSENAME.History11AP:
                        return "00411";
                    case CourseHandler.COURSENAME.HistoryArtHist:
                        return "00408";
                    case CourseHandler.COURSENAME.HistoryGov:
                        return "00084";
                    case CourseHandler.COURSENAME.HistoryEcon:
                        return "00126";

                    case CourseHandler.COURSENAME.PCB1:
                        return "00068";
                    case CourseHandler.COURSENAME.Pcb2:
                        return "00050";
                    case CourseHandler.COURSENAME.Pcb3:
                        return "00052";
                    case CourseHandler.COURSENAME.Pcb3H:
                        return "00053";
                    case CourseHandler.COURSENAME.PhysicsAP:
                        return "00703";
                    case CourseHandler.COURSENAME.PreAlgA:
                        return "00610";
                    case CourseHandler.COURSENAME.PreAlgB:
                        return "00612";
                    case CourseHandler.COURSENAME.Precalc:
                        return "00605";
                    case CourseHandler.COURSENAME.PrecalcH:
                        return "00614";
                    //TODO: capstone for mark 12th
                      //  case CourseHandler.COURSENAME.SeniorCapstone:
                    case CourseHandler.COURSENAME.Geometry:
                        return "00609";
                    case CourseHandler.COURSENAME.GeometryH:
                        return "00619";
                    case CourseHandler.COURSENAME.Alg1H:
                        return "00632";
                    case CourseHandler.COURSENAME.Algebra1:
                        return "00602";
                    case CourseHandler.COURSENAME.Algebra1A:
                        return "00623";
                    case CourseHandler.COURSENAME.Algebra1b:
                        return "00608";
                    case CourseHandler.COURSENAME.Algebra2A:
                        return "00618";
                    //TODO: algebra IIB
                    //  case CourseHandler.COURSENAME.Algebra2B:
                    case CourseHandler.COURSENAME.Algebra2H:
                        return "00604";
                    case CourseHandler.COURSENAME.BioAP:
                        return "00701";
                    case CourseHandler.COURSENAME.BrainBehavior:
                        return "00132";
                    case CourseHandler.COURSENAME.CalcAB:
                        return "00606";
                    case CourseHandler.COURSENAME.CalcBC:
                        return "00607";
                    case CourseHandler.COURSENAME.CalcFund:
                        return "00613";
                    case CourseHandler.COURSENAME.ChemAP:
                        return "00707";

                    case CourseHandler.COURSENAME.None:
                        return "FREE";
                    default:
                        throw new Exception("Section ID not found for the course");
                }
            }
            throw new Exception("Section ID not found for the course");
        }
    }
}
