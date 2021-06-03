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
                new Astronaut("Yuri Gagarin", new Raket(), iParticipant.TeamColors.Blue,0),
                new Astronaut("Neil Armstrong", new Raket(), iParticipant.TeamColors.Red,0),
                new Astronaut("Andre Kuipers", new Raket(), iParticipant.TeamColors.Yellow,0),
                new Astronaut("Julian van Rijckevorsel", new Raket(), iParticipant.TeamColors.Green,0)

            };
            competition.Participants = Participants;
        }

        static void addTracks()
        {
            SectionTypes[] middel = new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.StartGrid,SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight,
                SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner,
                SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,

            };
            SectionTypes[] klein = new SectionTypes[]
            {
              
                SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner
            };
            
            SectionTypes[] groot = new SectionTypes[]
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
            };
            competition.Tracks = new Queue<Track>();
            competition.Tracks.Enqueue(new Track("Track1", klein));
            competition.Tracks.Enqueue(new Track("Track2", middel));
            competition.Tracks.Enqueue(new Track("Track3", groot));

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