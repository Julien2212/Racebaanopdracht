using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Model;

namespace Racebaanopdracht
{
    public static class Visualisatie
    {
        static int Counter;
        #region graphics

        private static string[] _startGridHorizontal = { "----", "  # ", "  # ", "----" };
        private static string[] _startGridVertical = { "|  |", "|##|", "|  |", "|  |" };
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            DrawTrack(e.track); 
            Counter = 0;
        }

        public static string PlaceParticipants(string s, List<iParticipant> participants)
        {
            var regex = new Regex(Regex.Escape("#"));

            string result = s;

            if (result.Contains('#'))
            {
                if (Counter < participants.Count)
                {
                    result = regex.Replace(result, participants[Counter].Name.First().ToString(), 1);
                    Counter++;
                    //break;
                }
            }
            return result;
        }

        public static void print(string[] a, int x, int y)
        {
            foreach (string b in a)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(PlaceParticipants(b, Controller.Data.CurrentRace.Participants));
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
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        print(_trackHorizontal, testX, testY);
                        testX += 5;
                    }


                    if (richting == "West")
                    {
                        print(_trackHorizontal, testX, testY);
                        testX -= 5;
                    }

                    if (richting == "South")
                    {
                        print(_trackVertical, testX, testY);
                        testY += 5;
                    }
                    if (richting == "North")
                    {
                        print(_trackVertical, testX, testY);
                        testY -= 5;
                    }
                }
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
                if (s.SectionType == SectionTypes.StartGrid || s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                        print(_finishHorizontal, testX, testY);
                        testX += 5;
                    }


                    if (richting == "West")
                    {
                        print(_finishHorizontal, testX, testY);
                        testX -= 5;
                    }

                    if (richting == "South")
                    {
                        print(_finishVertical, testX, testY);
                        testY += 5;
                    }
                    if (richting == "North")
                    {
                        print(_finishVertical, testX, testY);
                        testY -= 5;
                    }
                }
            }
        }
    }
}