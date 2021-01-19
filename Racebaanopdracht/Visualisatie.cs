using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Controller;
using Model;

namespace Racebaanopdracht
{
    public static class Visualisatie
    {
        #region graphics

        private static string[] _startGridHorizontal = { "----", "  1 ", "  2 ", "----" };
        private static string[] _startGridVertical = { "|  |", "|12|", "|  |", "|  |" };
        private static string[] _finishHorizontal = { "----", " #1 ", " #2 ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|  |", "|  |" };
        private static string[] _trackHorizontal = { "----", " 1  ", " 2  ", "----" };
        private static string[] _trackVertical = { @"|  |", @"|1 |", @"| 2|", @"|  |" };

        private static string[] _eastRight = { @"--\ ", @" 1 \", @" 2 |", @"\  |" };
        private static string[] _southRight = { "|  |", "1  /", " 2 /", "--- " };
        private static string[] _northRight = { " ---", "/1  ", "|2 /", "|  |" };
        private static string[] _westRight = { "|  |", @"|1 \", @"\ 2 ", " ---" };

        private static string[] _eastLeft = { "|  |", "/1 /", " 2 /", "--- " };
        private static string[] _southLeft = { "|  |", @"|1  ", @"\2  ", " ---" };
        private static string[] _westLeft = { " ---", "/ 1 ", "|2  ", "|  |" };
        private static string[] _northLeft = { @"--\ ", @"1  \", @"\2 |", "|  |" };
        #endregion

        public static void Initialize()
        {

        }

        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            DrawTrack(e.track);
        }

        public static string ReplaceString(string s, iParticipant left, iParticipant right)
        {
            if (left != null && left.Name != null)
            {
                s = s.Replace('1', left.Name[0]);
            }
            else s = s.Replace('1', ' '); // wanneer er een 1 staat maar er hoort niks te staan, weghalen

            if (right != null && right.Name != null)
            {
                s = s.Replace('2', right.Name[0]);
            }
            else s = s.Replace('2', ' '); // wanneer er een 2 staat maar er hoort niks te staan, weghalen
          
            return s;
        }
        public static void print(string[] a, int x, int y, SectionData data)
        { // a = sectie
            foreach (string b in a) // voor elke string b in array a
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ReplaceString(b, data.Left, data.Right));
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
                var data = Data.CurrentRace.GetSectionData(s);
                //tellerSectie++;
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        print(_trackHorizontal, testX, testY, data);
                        testX += 4;
                    }

                    if (richting == "West")
                    {
                        print(_trackHorizontal, testX, testY, data);
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        print(_trackVertical, testX, testY, data);
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        print(_trackVertical, testX, testY, data);
                        testY -= 4;
                    }
                }
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastLeft, testX, testY, data);
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "South")
                    {
                        print(_southLeft, testX, testY, data);
                        richting = "East";
                        testX += 4;
                    }

                    else if (richting == "West")
                    {

                        print(_westLeft, testX, testY, data);
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "North")
                    {
                        print(_northLeft, testX, testY, data);
                        richting = "West";
                        testX -= 4;
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastRight, testX, testY, data);
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "South")
                    {
                        print(_southRight, testX, testY, data);
                        richting = "West";
                        testX -= 4;
                    }

                    else if (richting == "West")
                    {
                        print(_westRight, testX, testY, data);
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "North")
                    {
                        print(_northRight, testX, testY, data);
                        richting = "East";
                        testX += 4;
                    }
                }
                if (s.SectionType == SectionTypes.StartGrid)
                {
                    if (richting == "East")
                    {
                        print(_finishHorizontal, testX, testY, data);
                        testX += 4;
                    }


                    if (richting == "West")
                    {
                        print(_finishHorizontal, testX, testY, data);
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        print(_finishVertical, testX, testY, data);
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        print(_finishVertical, testX, testY, data);
                        testY -= 4;
                    }
                }
                if (s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                        print(_finishHorizontal, testX, testY, data);
                        testX += 4;
                    }


                    if (richting == "West")
                    {
                        print(_finishHorizontal, testX, testY, data);
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        print(_finishVertical, testX, testY, data);
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        print(_finishVertical, testX, testY, data);
                        testY -= 4;
                    }
                }
            }
        }
    }
}