using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Model;

namespace Racebaanopdracht
{
    public static class Visualisatie
    {
        #region graphics
        private static string[] _finishHorizontal = { "----", "  # ", "  # ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|  |", "|  |" };
        private static string[] _trackHorizontal = { "----", "    ", "    ", "----" };
        private static string[] _trackVertical = { "|  |", "|  |", "|  |", "|  |" };

        private static string[] _eastRight = { @"--\ ", @"   \", @"\  |", "|  |" };
        private static string[] _southRight = { "|  |", "/  /", "   /", "--- " };
        private static string[] _northRight = { " ---", "/   ", "|  /", "|  |" };
        private static string[] _westRight = { "|  |", @"|  \", @"\   ", " ---" };

        private static string[] _eastLeft = { "|  |", "/  /", "   /", "--- " };
        private static string[] _southLeft = { "|  |", @"|  \", @"\   ", " ---" };
        private static string[] _westLeft = { " ---", "/   ", "|  /", "|  |" };
        private static string[] _northLeft = { @"--\ ", @"   \", @"\  |", "|  |" };
        #endregion
        public static void Initialize()
        {

        }
        public static void DrawTrack(Track t)
        {
            int CursorX = 1;
            int CursorY = 0;
            string richting = "East";
           
            foreach (Section s in t.Sections)
            {
                Console.SetCursorPosition(CursorY, CursorX);
                if (s.SectionType == SectionTypes.StartGrid) // Als de section type gelijk is aan StartGrid
                {
                    if (richting == "East" || richting == "West") 
                    {
                        foreach (string a in _finishHorizontal)
                        {
                            Console.WriteLine(a);
                        }
                    }
                }

                Console.SetCursorPosition(CursorY, CursorX);
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        //Console.SetCursorPosition(CursorY += 5, CursorX);
                        CursorY += 5;
                        foreach (string a in _trackHorizontal)
                        {
                            Console.WriteLine(a);
                            Console.SetCursorPosition(CursorY, CursorX);
                        }
                    }

                    if (richting == "West")
                    {
                        //Console.SetCursorPosition(CursorY-=5, CursorX);
                        CursorY -= 5;
                        foreach (string a in _trackHorizontal)
                        {
                            Console.WriteLine(a);

                        }
                    }

                    if (richting == "South")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX+=5);
                        CursorX += 5;
                        foreach (string a in _trackVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    if (richting == "North")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX-=5);
                        CursorX -= 5;
                        foreach (string a in _trackVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                }

                Console.SetCursorPosition(CursorY, CursorX);
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                        foreach (string a in _eastLeft)
                        {
                            Console.WriteLine(a);
                        }

                        richting = "South";
                    }

                    else if (richting == "South")
                    {
                        foreach (string a in _southLeft)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "West";
                    }

                    else if (richting == "West")
                    {
                        foreach (string a in _westLeft)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "North";
                    }

                    else if (richting == "North")
                    {
                        foreach (string a in _northLeft)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "East";
                    }
                }

                Console.SetCursorPosition(CursorY, CursorX);
                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        foreach (string a in _eastRight)
                        {
                            Console.WriteLine(a);
                        }

                        richting = "South";
                    }

                   else if (richting == "South")
                    {
                        foreach (string a in _southRight)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "West";
                    }

                    else if (richting == "West")
                    {
                        foreach (string a in _westRight)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "North";
                    }

                    else if (richting == "North")
                    {
                        foreach (string a in _northRight)
                        {
                            Console.WriteLine(a);
                        }
                        richting = "East";
                    }
                }

                Console.SetCursorPosition(CursorY, CursorX);
                if (s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East" || richting == "West")
                    {
                        foreach (string a in _finishHorizontal)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    else
                    {
                        foreach (string a in _finishVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                }
            }
        }
    }
}