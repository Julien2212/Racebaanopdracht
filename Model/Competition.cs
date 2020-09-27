using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<iParticipant> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }

        public Competition()
        {
            Tracks = new Queue<Track>();
        }

        public Track NextTrack()
        {
            Track volgende = null;
            int Tel = Tracks.Count;
            if (Tel == 0)
            {
                return volgende;
            }
            else
            {
                volgende = Tracks.Dequeue();
                return volgende;
            }
        }
    }
}
