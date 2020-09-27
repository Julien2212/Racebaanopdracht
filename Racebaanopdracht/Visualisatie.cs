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

        }
    }
}
