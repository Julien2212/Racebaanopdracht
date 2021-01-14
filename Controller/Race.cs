using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private Timer timer = new Timer(1000);
        public event EventHandler<DriversChangedEventArgs> DriversChanged;
        public static int x = 0;
        //public static int SectionNext = 0;

        public Race(Track t, List<iParticipant> participants)
        {
            Track = t;
            Participants = participants;
            StartTime = new DateTime();
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>(); // Sectie als key met informatie als value
            SetStartPosition(Track, Participants);
            Start();
            timer.Elapsed += OnTimedEvent;
        }
        public void OnTimedEvent(object sender, EventArgs e)
        {
            MoveAstronauts();
        }

        public void MoveAstronauts()
        {
            timer.Enabled = false;
            int i = 0; // bij een for de counter
            foreach (var section in Track.Sections) // voor elke section in Track.Sections
            {
                var data = GetSectionData(section);
                while (i < _positions.Count - 1)
                {
                    if (_positions.ElementAt(i).Value.Left == data.Left) // links
                    {
                        var LeftAstronaut = _positions.ElementAt(i).Value.Left;
                        if (LeftAstronaut != null)
                        {
                            if (_positions.ElementAt(i + 1).Value.Left == null) // Als er geen "astronaut" in de volgende sectie op links staat
                            {
                                _positions.ElementAt(i + 1).Value.Left = LeftAstronaut; // De volgende plek waar iemand kan staan wordt de plek van de astronaut
                                data.Left = null;
                                DriversChanged?.Invoke(this, new DriversChangedEventArgs() { track = Track });
                                i++;
                            }
                        }
                    }
                    
                    if (_positions.ElementAt(i).Value.Right == data.Right) // rechts
                    {
                        var RightAstronaut = _positions.ElementAt(i).Value.Right;
                        if (RightAstronaut != null)
                        {
                            if (_positions.ElementAt(i + 1).Value.Right == null) // Als er geen "astronaut" in de volgende sectie op rechts staat
                            {
                                _positions.ElementAt(i + 1).Value.Right = RightAstronaut; // De volgende plek waar iemand kan staan wordt de plek van de astronaut
                                data.Right = null;
                                DriversChanged?.Invoke(this, new DriversChangedEventArgs() { track = Track });
                                i++;
                            }
                        }
                    }
                }
            }
            timer.Enabled = true;
        }

        /*public static bool PlaceParticipant2(int SectieTeller)
        {
            if (SectionNext == SectieTeller)
            {
                return true;
            }
            else
            {
                return false;
                SectionNext++;
            }
            
        }*/

        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
                _positions.Add(section, new SectionData(null, null));
            return _positions[section];
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
            Queue<Section> normalSections = new Queue<Section>();
            foreach (Section s in t.Sections)
            {
                if (s.SectionType == SectionTypes.StartGrid)
                { // Als SectionType een start is, enqueue deze
                    starts.Enqueue(s);
                }
                else normalSections.Enqueue(s);
            }
            int participantCount = 0; // Teller voor participants
            int sectionsCount = 0; // Teller voor sections
            if ((p.Count % 2) == 0)
            {
                while (sectionsCount < t.Sections.Count) // Terwijl teller kleiner is dan participants.Count
                { // Voeg deze toe aan _positions
                    if (t.Sections.ElementAt(sectionsCount).SectionType == SectionTypes.StartGrid && participantCount < p.Count)
                    {
                        _positions.Add(starts.Dequeue(), new SectionData(p[participantCount], p[participantCount + 1])); // Weet niet of dit goed is. GetSectionData(starts.Dequeue())
                        participantCount += 2;
                        sectionsCount++;
                    }
                    else if (t.Sections.ElementAt(sectionsCount).SectionType == SectionTypes.StartGrid)
                    {
                        _positions.Add(starts.Dequeue(), new SectionData(null, null)); // Positie toevoegen aan _positions, niks in zetten
                        sectionsCount++;

                    }
                    else
                    {
                        _positions.Add(normalSections.Dequeue(), new SectionData(null, null)); // Positie toevoegen aan _positions, niks in zetten
                        sectionsCount++;
                    }
                }
            }
            else
            {
                while (sectionsCount < t.Sections.Count - 1) // Terwijl teller kleiner is dan participants.Count
                { // Voeg deze toe aan _positions
                    if (t.Sections.ElementAt(sectionsCount).SectionType == SectionTypes.StartGrid && participantCount < p.Count - 1)
                    {
                        _positions.Add(starts.Dequeue(), new SectionData(p[participantCount], null)); // Weet niet of dit goed is. GetSectionData(starts.Dequeue())
                        participantCount += 2;
                        sectionsCount++;
                    }
                    else if (t.Sections.ElementAt(sectionsCount).SectionType == SectionTypes.StartGrid)
                    {
                        _positions.Add(starts.Dequeue(), new SectionData(null, null)); // Positie toevoegen aan _positions, niks in zetten
                        sectionsCount++;

                    }
                    else
                    {
                        _positions.Add(normalSections.Dequeue(), new SectionData(null, null)); // Positie toevoegen aan _positions, niks in zetten
                        sectionsCount++;
                    }
                }
            }
        }
    }
}
