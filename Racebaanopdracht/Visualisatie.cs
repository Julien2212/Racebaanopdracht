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
        static int PlaceParticipantsCounter = 0;
        static int ReplaceStringCounter = 0;
        public static bool participantChanged;
        public static Dictionary<iParticipant, Tuple<int, int>> ParticipantsPosition { get; set; } = new Dictionary<iParticipant, Tuple<int, int>>();
        #region graphics

        private static string[] _startGridHorizontal = { "----", "  1 ", "  2 ", "----" };
        private static string[] _startGridVertical = { "|  |", "|12|", "|  |", "|  |" };
        private static string[] _finishHorizontal = { "----", "  1 ", "  2 ", "----" };
        private static string[] _finishVertical = { "|  |", "|12|", "|  |", "|  |" };
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

        public static string PlaceParticipants(string s, List<iParticipant> participants)
        {
            var regex = new Regex(Regex.Escape("#"));

            string result = s;

            if (result.Contains('#'))
            {
                if (PlaceParticipantsCounter < participants.Count)
                {
                    result = regex.Replace(result, participants[PlaceParticipantsCounter].Name.First().ToString(), 1);
                    PlaceParticipantsCounter++;
                    //break;
                }
            }
            return result;
        }

        public static string ReplaceString(string s, List<iParticipant> participants, int SectieTeller)
        {
            if (s.Contains('1') && ReplaceStringCounter < participants.Count //&& Race.PlaceParticipant2(SectieTeller)
                )
            {
                s = s.Replace('1', participants[ReplaceStringCounter].Name[0]);
                ParticipantsPosition.Add(participants[ReplaceStringCounter], new Tuple<int, int>(0, 0));
                ReplaceStringCounter++;
                participantChanged = true;
            }
            //else s = (s.Contains('1')) ? s.Replace('1', ' ') : s; // wanneer er een 1 staat maar er hoort niks te staan, weghalen
           
            if (s.Contains('2') && ReplaceStringCounter < participants.Count //&& Race.PlaceParticipant2(SectieTeller)
                )
            {
                s = s.Replace('2', participants[ReplaceStringCounter].Name[0]);
                ParticipantsPosition.Add(participants[ReplaceStringCounter], new Tuple<int, int>(0, 0));
                ReplaceStringCounter++;
                participantChanged = true;
            }
            //else s = (s.Contains('2')) ? s.Replace('2', ' ') : s; // wanneer er een 2 staat maar er hoort niks te staan, weghalen
            return s;
        }
        public static void print(string[] a, int x, int y, int SectieTeller)
        { // a = sectie
            foreach (string b in a) // voor elke string b in array a
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ReplaceString(b, Data.CurrentRace.Participants, SectieTeller));

                if (participantChanged)
                {
                    var last = ParticipantsPosition.Keys.Last();
                    if (b.Contains('1'))
                    {
                        var participantIndex = b.IndexOf('1') + 1;
                        var participantsX = x + participantIndex;
                        ParticipantsPosition[last] = new Tuple<int, int>(participantsX, y);
                    }
                    else if (b.Contains('2'))
                    {
                        var participantIndex = b.IndexOf('2') + 1;
                        var participantsX = x + participantIndex;
                        ParticipantsPosition[last] = new Tuple<int, int>(participantsX, y);
                    }
                    participantChanged = false;
                }
                y++;
            }
        }

        public static void DrawTrack(Track t)
        {
            int tellerSectie = 0; // Bijhouden welke sectie er wordt getekend
            int testX = 25;
            int testY = 5;
            string richting = "East";

            foreach (Section s in t.Sections)
            {
                tellerSectie++;
                if (s.SectionType == SectionTypes.Straight)
                {
                    if (richting == "East")
                    {
                        print(_trackHorizontal, testX, testY, tellerSectie);
                        testX += 4;
                    }

                    if (richting == "West")
                    {
                        print(_trackHorizontal, testX, testY, tellerSectie);
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        print(_trackVertical, testX, testY, tellerSectie);
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        print(_trackVertical, testX, testY, tellerSectie);
                        testY -= 4;
                    }
                }
                if (s.SectionType == SectionTypes.LeftCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastLeft, testX, testY, tellerSectie);
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "South")
                    {
                        print(_southLeft, testX, testY, tellerSectie);
                        richting = "East";
                        testX += 4;
                    }

                    else if (richting == "West")
                    {

                        print(_westLeft, testX, testY, tellerSectie);
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "North")
                    {
                        print(_northLeft, testX, testY, tellerSectie);
                        richting = "West";
                        testX -= 4;
                    }
                }

                if (s.SectionType == SectionTypes.RightCorner)
                {
                    if (richting == "East")
                    {
                        print(_eastRight, testX, testY, tellerSectie);
                        richting = "South";
                        testY += 4;
                    }

                    else if (richting == "South")
                    {
                        print(_southRight, testX, testY, tellerSectie);
                        richting = "West";
                        testX -= 4;
                    }

                    else if (richting == "West")
                    {
                        print(_westRight, testX, testY, tellerSectie);
                        richting = "North";
                        testY -= 4;
                    }

                    else if (richting == "North")
                    {
                        print(_northRight, testX, testY, tellerSectie);
                        richting = "East";
                        testX += 4;
                    }
                }
                if (s.SectionType == SectionTypes.StartGrid || s.SectionType == SectionTypes.Finish)
                {
                    if (richting == "East")
                    {
                        print(_finishHorizontal, testX, testY, tellerSectie);
                        testX += 4;
                    }


                    if (richting == "West")
                    {
                        print(_finishHorizontal, testX, testY, tellerSectie);
                        testX -= 4;
                    }

                    if (richting == "South")
                    {
                        print(_finishVertical, testX, testY, tellerSectie);
                        testY += 4;
                    }
                    if (richting == "North")
                    {
                        print(_finishVertical, testX, testY, tellerSectie);
                        testY -= 4;
                    }
                }
            }
        }
    }
}