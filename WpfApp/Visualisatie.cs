using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public static class Visualisatie
    {
        public static int testX = 25;
        public static int testY = 5;
        public static string richting ="East";
        #region graphics
        private static string _finishHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/finishHorizontal.png";
        private static string _finishVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/finishVertical.png";
        private static string _startGridHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/startGridHorizontal.png";
        private static string _startGridVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/startGridVertical.png";

        private static string _trackHorizontal = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/trackHorizontal.png";
        private static string _trackVertical = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/trackVertical.png";

        private static string _northRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/northRight.png";
        private static string _eastRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/eastRight.png";
        private static string _southRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/southRight.png";
        private static string _westRight = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/westRight.png";

        private static string _northLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/northLeft.png";
        private static string _eastLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/eastLeft.png";
        private static string _southLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/southLeft.png";
        private static string _westLeft = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/westLeft.png";

        private static string _blueNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueNorth.png";
        private static string _blueEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueEast.png";
        private static string _blueSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueSouth.png";
        private static string _blueWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueWest.png";
        private static string _blueKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/blueKapot.png";

        private static string _redNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redNorth.png";
        private static string _redEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redEast.png";
        private static string _redSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redSouth.png";
        private static string _redWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redWest.png";
        private static string _redKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/redKapot.png";

        private static string _yellowNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowNorth.png";
        private static string _yellowEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowEast.png";
        private static string _yellowSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowSouth.png";
        private static string _yellowWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowWest.png";
        private static string _yellowKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/yellowKapot.png";

        private static string _greenNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenNorth.png";
        private static string _greenEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenEast.png";
        private static string _greenSouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenSouth.png";
        private static string _greenWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenWest.png";
        private static string _greenKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greenKapot.png";

        private static string _greyNorth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyNorth.png";
        private static string _greyEast = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyEast.png";
        private static string _greySouth = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greySouth.png";
        private static string _greyWest = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyWest.png";
        private static string _greyKapot = "C:/Users/julia/source/repos/Racebaanopdracht/WpfApp/Afbeeldingen/greyKapot.png";
        #endregion
        public static BitmapSource DrawTrack(Track t)
        {

            foreach (Section s in t.Sections)
            {
                //tellerSectie++;
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_trackHorizontal));
                        testX += 4;
                    }

                    if (richting == "West")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_trackHorizontal));
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_trackVertical));
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_trackVertical));
                        testY -= 4;
                    }
                }
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_eastLeft));
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "South")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_southLeft));
                        richting = "East";
                        testX += 4;
                    }

                    else if (richting == "West")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_westLeft));
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "North")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_northLeft));
                        richting = "West";
                        testX -= 4;
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_eastRight));
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "South")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_southRight));
                        richting = "West";
                        testX -= 4;
                    }

                    else if (richting == "West")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_westRight));
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "North")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_northRight));
                        richting = "East";
                        testX += 4;
                    }
                }
                if (s.SectionType == SectionTypes.StartGrid)
                {
                    if (richting == "East")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_startGridHorizontal));
                        testX += 4;
                    }


                    if (richting == "West")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_startGridHorizontal));
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_startGridVertical));
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_startGridVertical));
                        testY -= 4;
                    }
                }
                if (s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_finishHorizontal));
                        testX += 4;
                    }


                    if (richting == "West")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_finishHorizontal));
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_finishVertical));
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        Console.SetCursorPosition(testX, testY);
                        return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.AddDict(_finishVertical));
                        testY -= 4;
                    }
                }
                else
                {
                    return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.Leeg(256, 256));
                }
            }
            return MakeAfbeelding.CreateBitmapSourceFromGdiBitmap(MakeAfbeelding.Leeg(256, 256));
        }
    }
}
