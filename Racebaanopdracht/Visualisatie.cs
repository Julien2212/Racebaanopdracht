using System;
using System.Collections.Generic;
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
            t = new Track("bruh", null);
            if (t.Sections == null)
            {
                foreach (string s in _curveLeftUnder)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                foreach (string s in _finishHorizontal)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
