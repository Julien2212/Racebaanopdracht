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
        private static string[] _curveRightUnder = { @"--\ ", @"   \", @"\  |", "|  |" };
        private static string[] _curveRightUp = { "|  |", "/  /", "   /", "--- " };
        private static string[] _curveLeftUnder = { " ---", "/   ", "|  /", "|  |" };
        private static string[] _curveleftLeftUp = { "|  |", @"|  \", @"\   ", " ---" };
        #endregion
        public static void Initialize()
        {

        }

        public static void DrawTrack(Track t)
        {
            int CursorX = 1;
            int CursorY = 0;
            foreach (Section s in t.Sections)
            {

                if (s.SectionType == SectionTypes.StartGrid) // Als de section type gelijk is aan StartGrid
                {
                    //Console.SetCursorPosition(CursorY,CursorX); // Cursor op 0,1
                    CursorY += 5;
                    foreach (string a in _finishHorizontal)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.Straight)
                {
                    //Console.SetCursorPosition(CursorY,CursorX); // Zet de cursor op de goede positie
                    foreach (string a in _trackHorizontal)
                    {
                        Console.WriteLine(a);
                    }

                }

                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    foreach (string a in _curveLeftUnder)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    Console.SetCursorPosition(6, 1);
                    foreach (string a in _curveRightUp)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.Finish)
                {
                    foreach (string a in _finishHorizontal)
                    {
                        Console.WriteLine(a);
                    }
                }
            }
        }

        /*public static void DrawTrack(Track t)
        {
            int hulp = 0;
            int cursorY = 0;
            int cursorX = 1;
            foreach (Section s in t.Sections)
            {
                if (s.SectionType == SectionTypes.Finish)
                {
                    Console.SetCursorPosition(cursorY, cursorX);
                    if (hulp == 1)
                    {
                        foreach (string a in _finishVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    else
                    {
                        foreach (string a in _finishHorizontal)
                        {
                            Console.WriteLine(a);
                        }
                    }
                }

                if (s.SectionType == SectionTypes.Straight)
                {
                    Console.SetCursorPosition(cursorY, cursorX);
                    if (hulp == 1)
                    {
                        foreach (string a in _trackVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    else
                    {
                        foreach (string a in _trackHorizontal)
                        {
                            Console.WriteLine(a);
                        }
                    }
                }

                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    Console.SetCursorPosition(cursorY, cursorX);
                    foreach (string a in _curveLeftUnder)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    Console.SetCursorPosition(cursorY, cursorX);
                    hulp = 1;
                    foreach (string a in _curveRightUnder)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.StartGrid)
                {
                    Console.SetCursorPosition(cursorY, cursorX);
                    if (hulp == 1)
                    {
                        foreach (string a in _finishVertical)
                        {
                            Console.WriteLine(a);
                        }
                    }
                    else
                    {
                        foreach (string a in _finishHorizontal)
                        {
                            Console.WriteLine(a);
                        }
                    } 
                }
                cursorY += 5;
                cursorX += 5;
            }
        }*/
    }
}