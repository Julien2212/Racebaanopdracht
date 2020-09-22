using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<iParticipant> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }

        public Track NextTrack()
        {
            if (Tracks.Count == 0)
            {
                return null;
            }
            else
            {
                return Tracks.Dequeue();
            }
        }

    }
}
