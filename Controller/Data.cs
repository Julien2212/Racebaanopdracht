using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        static Competition competition { get; set; }
        public static List<Track> Tracks { get; set; }
        public static List<iParticipant> Participants { get; private set; }

        public static Race CurrentRace { get; set; }

        public static void Initialize(string Competition)
        {
            Competition competition = new Competition();
            addParticipants();
            addTracks();
        }

        static void addParticipants()
        {
            Participants = new List<iParticipant>()
            {
                new Astronaut(),
                new Astronaut(),
                new Astronaut()
            };
        }

        static void addTracks()
        {
            Tracks = new List<Track>()
             {
                 new Track(),
                 new Track(),
                 new Track()
             };
        }

        public static void NextRace()
        {
            if (Competition.NextTrack() != "null")
            {
                CurrentRace = t;
            }
        }
    }

}
