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
        private static string[] _trackVertical = { @"|  |", @"|  |", @"|  |", @"|  |" };

        private static string[] _eastRight = { @"--\ ", @"   \", @"   |", @"\  |" };
        private static string[] _southRight = { "|  |", "   /", "   /", "--- " };
        private static string[] _northRight = { " ---", "/   ", "|  /", "|  |" };
        private static string[] _westRight = { "|  |", @"|  \", @"\   ", " ---" };

        private static string[] _eastLeft = { "|  |", "/  /", "   /", "--- " };
        private static string[] _southLeft = { "|  |", @"|   ", @"\   ", " ---" };
        private static string[] _westLeft = { " ---", "/   ", "|   ", "|  |" };
        private static string[] _northLeft = { @"--\ ", @"   \", @"\  |", "|  |" };
        #endregion
        public static void Initialize()
        {

        }

        public static string PlaatsenDeelnemers(string s, iParticipant p)
        {
            s.Replace(s, $"|{p.Name}|");
            return s;
        }
        public static void print(string[] a, int x, int y)
        {
            foreach (string b in a)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(b);
                y++;
            }

        }
        public static void DrawTrack(Track t)
        {
            int testX = 25;
            int testY = 5;
            string richting = "East";
           
            foreach (Section s in t.Sections)
            {
                
                //Console.SetCursorPosition(testX, testY);
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        //Console.SetCursorPosition(CursorY += 5, CursorX);
                        
                        print(_trackHorizontal, testX, testY);
                        testX += 5;
                    }


                    if (richting == "West")
                    {
                        //Console.SetCursorPosition(CursorY-=5, CursorX);
                        
                        print(_trackHorizontal, testX, testY);
                        testX -= 5;
                    }

                    if (richting == "South")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX+=5);
                        
                        print(_trackVertical, testX, testY);
                        testY += 5;
                    }
                    if (richting == "North")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX-=5);
                        
                        print(_trackVertical, testX, testY);
                        testY -= 5;
                    }
                }

                //Console.SetCursorPosition(testX, testY);
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastLeft, testX, testY);
                        richting = "North";
                        testY -= 5;
                    }

                    else if (richting == "South")
                    {
                        print(_southLeft, testX, testY);
                        richting = "East";
                        testX += 5;
                    }

                    else if (richting == "West")
                    {
                        
                        print(_westLeft, testX, testY);
                        richting = "South";
                        testY += 5;
                    }

                    else if (richting == "North")
                    {
                        print(_northLeft, testX, testY);
                        richting = "West";
                        testX -= 5;
                    }
                }

                //Console.SetCursorPosition(testX, testY);
                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastRight, testX, testY);
                        richting = "South";
                        testY += 5;
                    }

                   else if (richting == "South")
                    {
                        print(_southRight, testX, testY);
                        richting = "West";
                        testX -= 5;
                    }

                    else if (richting == "West")
                    {
                        print(_westRight, testX, testY);
                        richting = "North";
                        testY -= 5;
                    }

                    else if (richting == "North")
                    {
                        print(_northRight, testX, testY);
                        richting = "East";
                        testX += 5;
                    }
                }

                //Console.SetCursorPosition(testX, testY);
                if (s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East" || richting == "West")
                    {
                        print(_finishHorizontal, testX, testY);
                        //testX += 5;
                    }
                    else
                    {
                        print(_finishVertical, testX, testY);
                        //testY += 5;
                    }
                }
                //Console.SetCursorPosition(testX, testY);
                if (s.SectionType == SectionTypes.StartGrid) // Als de section type gelijk is aan StartGrid
                {
                    if (richting == "East" || richting == "West")
                    {
                        print(_finishHorizontal, testX, testY);
                        //testX += 5;
                    }
                }

                if (s.SectionType == SectionTypes.StartGrid || s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                        //Console.SetCursorPosition(CursorY += 5, CursorX);

                        print(_finishHorizontal, testX, testY);
                        testX += 5;
                    }


                    if (richting == "West")
                    {
                        //Console.SetCursorPosition(CursorY-=5, CursorX);

                        print(_finishHorizontal, testX, testY);
                        testX -= 5;
                    }

                    if (richting == "South")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX+=5);

                        print(_finishVertical, testX, testY);
                        testY += 5;
                    }
                    if (richting == "North")
                    {
                        //Console.SetCursorPosition(CursorY, CursorX-=5);

                        print(_finishVertical, testX, testY);
                        testY -= 5;
                    }
                }
            }
        }
    }
}