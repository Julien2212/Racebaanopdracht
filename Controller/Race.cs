using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<iParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }

        private Random _random = new Random(DateTime.Now.Millisecond);

        private Dictionary<Section, SectionData> _positions = new Dictionary<Section, SectionData>();


        public Section GetSectionData(Section s)
        {
            SectionData x = null;

            if (_positions.ContainsKey(s))
            {
                x = _positions[s];
            }
            else
            {
                _positions.Add(s, x);
            }
            return x;
        }

        public Race(Track track, List<iParticipant> iParticipants)
        {
            Track Track = new Track();
            Participants = new List<iParticipant>();
        }

        public void RandomizeEquipment()
        {
            foreach (iEquipment equipment in Participants)
            {
                int random = _random.Next();
                equipment.Quality = random;
                equipment.Performance = random;
            }
        }
    }
}
