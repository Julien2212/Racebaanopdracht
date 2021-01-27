
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public static class Visualisatie
    {
        
        #region graphics
        private const string _finishHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/finishHorizontal.png";
        private const string _finishVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/finishVertical.png";
        private const string _startGridHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/startGridHorizontal.png";
        private const string _startGridVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/startGridVertical.png";

        private const string _trackHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/trackHorizontal.png";
        private const string _trackVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/trackVertical.png";

        private const string _northRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/northRight.png";
        private const string _eastRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/eastRight.png";
        private const string _southRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/southRight.png";
        private const string _westRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/westRight.png";

        private const string _northLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/northLeft.png";
        private const string _eastLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/eastLeft.png";
        private const string _southLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/southLeft.png";
        private const string _westLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/westLeft.png";

        private const string _blueNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueNorth.png";
        private const string _blueEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueEast.png";
        private const string _blueSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueSouth.png";
        private const string _blueWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueWest.png";
        private const string _blueKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueKapot.png";

        private const string _redNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redNorth.png";
        private const string _redEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redEast.png";
        private const string _redSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redSouth.png";
        private const string _redWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redWest.png";
        private const string _redKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redKapot.png";

        private const string _yellowNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowNorth.png";
        private const string _yellowEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowEast.png";
        private const string _yellowSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowSouth.png";
        private const string _yellowWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowWest.png";
        private const string _yellowKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowKapot.png";

        private const string _greenNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenNorth.png";
        private const string _greenEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenEast.png";
        private const string _greenSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenSouth.png";
        private const string _greenWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenWest.png";
        private const string _greenKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenKapot.png";

        private const string _greyNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyNorth.png";
        private const string _greyEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyEast.png";
        private const string _greySouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greySouth.png";
        private const string _greyWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyWest.png";
        private const string _greyKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyKapot.png";
        #endregion
        private static int X = 0;
        private static int Y = 0;
        private static Bitmap bitmap;
        private static Graphics g;
        public static BitmapSource DrawTrack(Track t)
        {
            string richting = "East";
            X = 1024;
            Y = 0;
            bitmap = new Bitmap(16 * 256, 9 * 256);
            g = Graphics.FromImage(bitmap);
            foreach (Section s in t.Sections)
            {
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_trackHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X += 256;
                    }

                    if (richting == "West")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_trackHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X -= 256;
                       
                    }

                    if (richting == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_trackVertical), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y += 256;
                    }
                    if (richting == "North")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_trackVertical), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y -= 256;
                    }
                }
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                      
                        g.DrawImage(MakeAfbeelding.GetDict(_eastLeft), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "North";
                        Y -= 256;
                    }

                    else if (richting == "South")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_southLeft), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "East";
                        X += 256;
                    }

                    else if (richting == "West")
                    {
                     
                        g.DrawImage(MakeAfbeelding.GetDict(_westLeft), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "South";
                        Y += 256;
                    }

                    else if (richting == "North")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_northLeft), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "West";
                        X -= 256;
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_eastRight), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "South";
                        Y += 256;
                    }

                    else if (richting == "South")
                    {
                      
                        g.DrawImage(MakeAfbeelding.GetDict(_southRight), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "West";
                        X -= 256;
                    }

                    else if (richting == "West")
                    {
                      
                        g.DrawImage(MakeAfbeelding.GetDict(_westRight), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "North";
                        Y -= 256;
                    }

                    else if (richting == "North")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_northRight), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        richting = "East";
                        X += 256;
                    }
                }
                if (s.SectionType == SectionTypes.StartGrid)
                {
                    if (richting == "East")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_startGridHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X += 256;
                    }


                    if (richting == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_startGridHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X -= 256;
                    }

                    if (richting == "South")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_startGridHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y += 256;
                    }
                    if (richting == "North")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_startGridVertical), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y -= 256;
                    }
                }
                if (s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_finishHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X += 256;
                    }

                    if (richting == "West")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_finishHorizontal), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        X -= 256;
                    }

                    if (richting == "South")
                    {
                       
                        g.DrawImage(MakeAfbeelding.GetDict(_finishVertical), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y += 256;
                    }
                    if (richting == "North")
                    {
                        
                        g.DrawImage(MakeAfbeelding.GetDict(_finishVertical), X, Y);
                        DrawPeople(g, Controller.Data.CurrentRace.GetSectionData(s).Left, Controller.Data.CurrentRace.GetSectionData(s).Right, X, Y, richting);
                        Y -= 256;
                    }
                }
            }
            return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(bitmap);
            
        }

        public static void DrawPeople(Graphics g, iParticipant left, iParticipant right, int x, int y, string r)
        {
            
            if (left != null && left.Name != null)
            {
                if (left.TeamColor == iParticipant.TeamColors.Blue)
                {
                    if (left.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_blueKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueNorth), x, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueEast), x, y);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueSouth), x, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueWest), x, y);
                    }
                }
                if (left.TeamColor == iParticipant.TeamColors.Red)
                {
                    if (left.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_redKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redNorth), x, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redEast), x, y);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redSouth), x, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redWest), x, y);
                    }
                }
                if (left.TeamColor == iParticipant.TeamColors.Yellow)
                {
                    if (left.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_yellowKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowNorth), x, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowEast), x, y);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowSouth), x, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowWest), x, y);
                    }
                }
                if (left.TeamColor == iParticipant.TeamColors.Green)
                {
                    if (left.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_greenKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenNorth), x, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenEast), x, y);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenSouth), x, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenWest), x, y);
                    }
                }
                if (left.TeamColor == iParticipant.TeamColors.Grey)
                {
                    if (left.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_greenKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenNorth), x, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greyEast), x, y);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greySouth), x, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greyWest), x, y);
                    }
                }
            }

            if (right != null && right.Name != null)
            {
                if (right.TeamColor == iParticipant.TeamColors.Blue)
                {
                    if (right.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_blueKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueNorth), x + 100, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueEast), x, y + 100);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueSouth), x + 100, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_blueWest), x, y + 100);
                    }
                }
                if (right.TeamColor == iParticipant.TeamColors.Red)
                {
                    if (right.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_redKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redNorth), x + 100, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redEast), x, y + 100);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redSouth), x + 100, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_redWest), x, y + 100);
                    }
                }
                if (right.TeamColor == iParticipant.TeamColors.Green)
                {
                    if (right.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_greenKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenNorth), x + 100, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenEast), x, y + 100);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenSouth), x + 100, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greenWest), x, y + 100);
                    }
                }
                if (right.TeamColor == iParticipant.TeamColors.Yellow)
                {
                    if (right.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_yellowKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowNorth), x + 100, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowEast), x, y + 100);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowSouth), x + 100, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_yellowWest), x, y + 100);
                    }
                }
                if (right.TeamColor == iParticipant.TeamColors.Grey)
                {
                    if (right.Equipment.IsBroken)
                    {
                        g.DrawImage(new Bitmap(MakeAfbeelding.GetDict(_greyKapot), 128, 128), x, y);
                    }
                    else if (r == "North")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greyNorth), x + 100, y);
                    }
                    else if (r == "East")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greyEast), x, y + 100);
                    }
                    else if (r == "South")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greySouth), x + 100, y);
                    }
                    else if (r == "West")
                    {
                        g.DrawImage(MakeAfbeelding.GetDict(_greyWest), x, y + 100);
                    }
                }
            }
        }
    }
}
