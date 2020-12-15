using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

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

        private Timer timer = new Timer(500);
        public event EventHandler<DriversChangedEventArgs> DriversChanged;

        public void OnTimedEvent(object sender, EventArgs e)
        {
            Console.Clear();
            DriversChanged?.Invoke(this, new DriversChangedEventArgs() {track = Track });
            // Bewegen
        }
        public SectionData GetSectionData(Section section)
        {
            SectionData value = null;

            if (_positions.ContainsKey(section))
            {
                value = _positions[section];
            }
            else
            {
                _positions.Add(section, new SectionData(null, null));
            }
            return _positions[section];
        }

        public Race(Track t, List<iParticipant> participants)
        {
            Track = t;
            Participants = participants;
            StartTime = new DateTime();
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
            SetStartPosition(Track, Participants);
            //timer = new Timer(500);
            Start();
            timer.Elapsed += OnTimedEvent;
            
        }

        public void Start()
        {
            timer.Start();
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

        public void SetStartPosition(Track t, List<iParticipant> p)
        { // Deelnemers op startgrid zetten
            Track = t;
            Participants = p;
            Queue<Section> starts = new Queue<Section>();
            foreach (Section s in t.Sections)
            {
                if (s.SectionType == SectionTypes.StartGrid)
                { // Als SectionType een start is, enqueue deze
                    starts.Enqueue(s);
                }

                if (s.SectionType == SectionTypes.Finish)
                {// Als SectionType een finish is, stop. Anders gaat hij lang door blijven gaan
                    break; 
                }
            }
            int tel = 0; // Teller
            if ((p.Count % 2) == 0)
            {
                while (tel < p.Count) // Terwijl teller kleiner is dan participants.Count
                { // Voeg deze toe aan _positions
                    _positions.Add(starts.Dequeue(), new SectionData(p[tel], p[tel+1])); // Weet niet of dit goed is. GetSectionData(starts.Dequeue())
                    tel+=2;
                }
            }
            else
            {
                while (tel < p.Count-1) // Terwijl teller kleiner is dan participants.Count
                { // Voeg deze toe aan _positions
                    _positions.Add(starts.Dequeue(), new SectionData(p[tel], p[tel + 1])); // Weet niet of dit goed is. GetSectionData(starts.Dequeue())
                    tel+=2;
                }
                //_positions.Add(starts.Dequeue(), new SectionData(p[tel]));
            }
           
        }
    }
}
