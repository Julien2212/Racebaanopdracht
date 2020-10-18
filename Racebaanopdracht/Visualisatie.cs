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
            //int i = 0;
            foreach (Section s in t.Sections)
            {
                if (s.SectionType == SectionTypes.Finish)
                {
                    foreach (string a in _finishHorizontal)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.Straight)
                {
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
                    foreach (string a in _curveRightUnder)
                    {
                        Console.WriteLine(a);
                    }
                }

                if (s.SectionType == SectionTypes.StartGrid)
                {
                    foreach (string a in _finishHorizontal)
                    {
                        Console.WriteLine(a);
                    }
                }
                /*Console.WriteLine($"hallo + {i}");
                i++;*/
            }
        }
    }
}
