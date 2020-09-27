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

        private Random _random { get; set; }

        private Dictionary<Section, SectionData> _positions;
        private List<Track> tracks;

        public SectionData GetSectionData(Section section)
        {
            SectionData value = null;

            if (_positions.ContainsKey(section))
            {
                value = _positions[section];
            }
            else
            {
                _positions.Add(section, value);
            }
            return value;
        }

        public Race(Track t, List<iParticipant> participants)
        {
            Track = t;
            Participants = participants;
            StartTime = new DateTime();
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
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
