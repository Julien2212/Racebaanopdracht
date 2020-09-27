using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition competition{ get; set; }
        public static List<Track> Tracks { get; set; }
        public static List<iParticipant> Participants { get; private set; }

        public static Race CurrentRace { get; set; }

        public static void Initialize(string Competition)
        {
            competition = new Competition();
            addParticipants();
            addTracks();
        }

        static void addParticipants()
        {
            competition.Participants = new List<iParticipant>()
            {
                new Astronaut(),
                new Astronaut(),
                new Astronaut()
            };
        }

        static void addTracks()
        {
            competition.Tracks = new Queue<Track>();
            competition.Tracks.Enqueue(new Track("Track1", null));
            competition.Tracks.Enqueue(new Track("Track2", null));
        }

        public static Track NextRace()
        {
            var volgende = competition.NextTrack();
            // als NextTrack() niet null returnt:
            if (volgende != null)
            {
                CurrentRace = new Race(volgende, Participants); // CurrentRace initialiseren
            }
            else
            {
                return null;
            }
            return null;
        }
    }

}
