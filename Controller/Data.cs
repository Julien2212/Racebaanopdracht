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
        public static Competition competition { get; set; }
        public static List<Track> Tracks { get; set; }
        public static List<iParticipant> Participants { get; private set; }

        public static Race CurrentRace { get; set; }

        public static void Initialize()
        {
            competition = new Competition();
            addParticipants();
            addTracks();
        }

        static void addParticipants()
        {
            Participants = new List<iParticipant>()
            {
                new Astronaut("Gerard"),
                new Astronaut("Kerym"),
                new Astronaut("Coolio")
            };
            competition.Participants = Participants;
        }

        static void addTracks()
        {
            SectionTypes[] elburg = new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight,
                SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.StartGrid, SectionTypes.StartGrid
            };
            competition.Tracks = new Queue<Track>();
            competition.Tracks.Enqueue(new Track("Track1", elburg));
            competition.Tracks.Enqueue(new Track("Track2", elburg));
        }

        public static void NextRace()
        {
            var volgende = competition.NextTrack();
            // als NextTrack() niet null returnt:
            if (volgende != null)
            {
                CurrentRace = new Race(volgende, Participants); // CurrentRace initialiseren
            }
        }
    }

}