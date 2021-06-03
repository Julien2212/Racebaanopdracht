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

        private Timer timer = new Timer(250); // 0,5 sec
        public event EventHandler<DriversChangedEventArgs> DriversChanged;
        private int _roundsteller = 0;
        private Dictionary<iParticipant, int> _rounds;

        ///
        public event EventHandler<DriversChangedEventArgs> OnRaceFinishedHandler;

        public Queue<iParticipant> EindstandQueue = new Queue<iParticipant>();

        Dictionary<iParticipant, DateTime> TijdDict = new Dictionary<iParticipant, DateTime>();
        public DateTime startTijd;
        public GenericGegevens<Tijd> opslaanGegevensTijd = new GenericGegevens<Tijd>();
        public GenericGegevens<Kapot> opslaanGegevensKapot = new GenericGegevens<Kapot>();
        public GenericGegevens<Speed> opslaanGegevensSpeed = new GenericGegevens<Speed>();
        public GenericGegevens<Punten> opslaanGegevensPunten = new GenericGegevens<Punten>();

        public Race(Track t, List<iParticipant> participants)
        {
            Track = t;
            Participants = participants;
            StartTime = new DateTime();
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>(); // Sectie als key met informatie als value
            _rounds = new Dictionary<iParticipant, int>();
            SetStartPosition(Track, Participants);
            Start();
            startTijd = DateTime.Now;
            timer.Elapsed += OnTimedEvent;
        }

        public void OnTimedEvent(object sender, EventArgs e)
        {
            if (_roundsteller == Participants.Count)
            {
                DriversChanged?.Invoke(this, new DriversChangedEventArgs() { track = Track });
                RaceFinished();
                
            }
            else
            {
                DriversChanged?.Invoke(this, new DriversChangedEventArgs() { track = Track });
                MoveAstronauts();
            }
        }

        public void CleanUp()
        {
            DriversChanged = null;
            timer.Enabled = false;
            OnRaceFinishedHandler = null;
        }

        public SectionData getNext(LinkedListNode<Section> s)
        {
            if (s.Next == null) // als de volgende null is, einde van de track
            {
                return GetSectionData(Track.Sections.First.Value); // zet hem naar de eerste van de track
            }
            return GetSectionData(s.Next.Value); // anders volgende
        }

        public void MoveAstronauts()
        {
            LinkedListNode<Section> iterator = Track.Sections.Last; // Pakt laatste section
            while (iterator != null) // als hij niet null is, dus als er een section is
            {
                SectionData SectData = GetSectionData(iterator.Value); // getsectiondata van die iterator

                if (SectData.Left != null && !SectData.Left.Equipment.IsBroken) // als er iemand  op links staat
                {
                    BreakTheRocket(SectData.Left, iterator.Value);
                    OpslaanKapot(SectData.Left, iterator.Value);
                    OpslaanSnelheid(SectData.Left, iterator.Value);
                    int leftperformance = SectData.Left.Equipment.Performance * SectData.Left.Equipment.Speed; // bepaal de performance voor diegene
                    SectData.DistanceLeft += leftperformance; // tel deze bij distanceleft op
                    if (SectData.DistanceLeft > 100) // als deze groter dan 100 is
                    {
                        if (iterator.Value.SectionType == SectionTypes.Finish)
                        {
                            if (_rounds[SectData.Left] > 1) // 2 rondes
                            {
                                EindstandQueue.Enqueue(SectData.Left);
                                SectData.Left = null; // haal weg
                                SectData.DistanceLeft = 0;
                                _roundsteller++;
                            }
                            else
                            {
                                _rounds[SectData.Left] += 1;
                                var volgende = getNext(iterator);  // ga naar de volgende section
                                if (volgende.Left != null)
                                {
                                    if (volgende.Right == null)
                                    {
                                        OpslaanTijd(SectData.Left, iterator.Value);

                                        volgende.Right = SectData.Left;
                                        SectData.Left = null; // maak de vorige leeg
                                        SectData.DistanceLeft = 0;
                                    }
                                    else
                                    {
                                        SectData.DistanceLeft += 100;
                                    }
                                }
                                else
                                {
                                    OpslaanTijd(SectData.Left, iterator.Value);

                                    volgende.Left = SectData.Left;
                                    SectData.Left = null; // maak de vorige leeg
                                    SectData.DistanceLeft = 0;
                                }
                            }
                        }
                        else
                        {
                            var volgende = getNext(iterator);  // ga naar de volgende section
                            if (volgende.Left != null)
                            {
                                if (volgende.Right == null)
                                {
                                    OpslaanTijd(SectData.Left, iterator.Value);

                                    volgende.Right = SectData.Left;
                                    SectData.Left = null; // maak de vorige leeg
                                    SectData.DistanceLeft = 0;
                                }
                                else
                                {
                                    SectData.DistanceLeft += 100;
                                }
                            }
                            else
                            {
                                OpslaanTijd(SectData.Left, iterator.Value);

                                volgende.Left = SectData.Left;
                                SectData.Left = null; // maak de vorige leeg
                                SectData.DistanceLeft = 0;
                            }
                        }
                    }
                }
                else if (SectData.Left != null)
                {
                    BreakTheRocket(SectData.Left, iterator.Value);
                    OpslaanKapot(SectData.Left, iterator.Value);
                }
                if (SectData.Right != null && !SectData.Right.Equipment.IsBroken) // als er iemand  op rechts staat
                {
                    BreakTheRocket(SectData.Right, iterator.Value);
                    OpslaanKapot(SectData.Right, iterator.Value);
                    OpslaanSnelheid(SectData.Right, iterator.Value);
                    int rightperformance = SectData.Right.Equipment.Performance * SectData.Right.Equipment.Speed; // bepaal de performance voor diegene
                    SectData.DistanceRight += rightperformance; // tel deze bij distanceleft op
                    if (SectData.DistanceRight > 100) // als deze groter dan 100 is
                    {
                        if (iterator.Value.SectionType == SectionTypes.Finish)
                        {
                            if (_rounds[SectData.Right] > 1) // 2 rondes
                            {
                                EindstandQueue.Enqueue(SectData.Right);
                                SectData.Right = null; // haal weg
                                SectData.DistanceRight = 0;
                                _roundsteller++;
                            }
                            else
                            {
                                _rounds[SectData.Right] += 1;
                                var volgende = getNext(iterator);  // ga naar de volgende section
                                if (volgende.Right != null)
                                {
                                    if (volgende.Left == null)
                                    {
                                        OpslaanTijd(SectData.Right, iterator.Value);
                                        volgende.Left = SectData.Right;
                                        SectData.Right = null; // maak de vorige leeg
                                        SectData.DistanceRight = 0;
                                    }
                                    else
                                    {
                                        SectData.DistanceRight += 100;
                                    }
                                }
                                else
                                {
                                    OpslaanTijd(SectData.Right, iterator.Value);
                                    volgende.Right = SectData.Right;
                                    SectData.Right = null; // maak de vorige leeg
                                    SectData.DistanceRight = 0;
                                }
                            }
                        }
                        else
                        {
                            var volgende = getNext(iterator);  // ga naar de volgende section
                            if (volgende.Right != null)
                            {
                                if (volgende.Left == null)
                                {
                                    OpslaanTijd(SectData.Right, iterator.Value);
                                    volgende.Left = SectData.Right;
                                    SectData.Right = null; // maak de vorige leeg
                                    SectData.DistanceRight = 0;
                                }
                                else
                                {
                                    SectData.DistanceRight += 100;
                                }
                            }
                            else
                            {
                                OpslaanTijd(SectData.Right, iterator.Value);
                                volgende.Right = SectData.Right;
                                SectData.Right = null; // maak de vorige leeg
                                SectData.DistanceRight = 0;
                            }
                        }
                    }
                }
                else if (SectData.Right != null)
                {
                    BreakTheRocket(SectData.Right, iterator.Value);
                    OpslaanKapot(SectData.Right, iterator.Value);
                }
                iterator = iterator.Previous; // ga 1 terug
            }
        }
        public void OpslaanTijd(iParticipant participant, Section sectie)
        {
            Tijd tijd = new Tijd();
            tijd.Naam = participant.Name;
            tijd.Sectie = sectie;
            tijd.RondeTijd = SectieTijd();
            opslaanGegevensTijd.FillList(tijd);
        }

        public TimeSpan SectieTijd()
        {
            return DateTime.Now - startTijd;
        }

        public void OpslaanKapot(iParticipant participant, Section sectie)
        {
            Kapot kapot = new Kapot();
            kapot.Naam = participant.Name;
            kapot.Sectie = sectie;
            kapot.Sectie.SectionType = sectie.SectionType;
            opslaanGegevensKapot.FillList(kapot);
        }

        public void OpslaanSnelheid(iParticipant participant, Section sectie)
        {
            Speed speed = new Speed();
            speed.Naam = participant.Name;
            speed.Sectie = sectie;
            speed.Snelheid = participant.Equipment.Speed;
            opslaanGegevensSpeed.FillList(speed);
        }
       

        public void RaceFinished()
        {
            Data.competition.OpslaanPunten(EindstandQueue);
            OnRaceFinishedHandler?.Invoke(this, new DriversChangedEventArgs() { track = Track });
            CleanUp();
        }

        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
                _positions.Add(section, new SectionData(null, null, 0, 0));
            return _positions[section];
        }

        public void Start()
        {
            RandomizeEquipment();
            timer.Start();
        }

        public void RandomizeEquipment()
        {
            foreach (iParticipant participants in Participants)
            {
                int random = _random.Next(7, 15); 
                participants.Equipment.Speed = random;
                participants.Equipment.Quality = random;
                participants.Equipment.Performance = random;
            }
        }
        
        public void BreakTheRocket(iParticipant participant, Section sectie)
        {
            foreach (iParticipant participants in Participants)
            {
                int random = _random.Next(1, 100);
                if (random == 1)
                {
                    participants.Equipment.IsBroken = true;
                }
                if (random >= 20 && random <= 25)
                {
                    participants.Equipment.IsBroken = false;
                }
               
                if (participants.Equipment.IsBroken)
                {
                    if (participants.Equipment.Speed > 5)
                    {
                        participants.Equipment.Speed -= 1;
                    }
                }
            }
        }
        public void SetStartPosition(Track t, List<iParticipant> p)
        { // Deelnemers op startgrid zetten
            Track = t;
            Participants = p;
            LinkedListNode<Section> iterator = t.Sections.First;
            while (iterator.Value.SectionType != SectionTypes.Finish)
            { // iterator gaat door alle sections van de track heen tot de finish
                iterator = iterator.Next;
            }
            iterator = iterator.Previous; // degene vóór de finish
            foreach (iParticipant participant in p) // voor elke participant in de track
            {
                _rounds.Add(participant, 0);
                SectionData SectData = GetSectionData(iterator.Value);  // sectdata van de sections
                if (SectData.Left == null) // als er niemand op links staat
                {
                    SectData.Left = participant; // plaats de participant hier
                }
                else if (SectData.Right == null) // als er niemand op rechts staat 
                {
                    SectData.Right = participant; // plaats de participant hier
                }
                else
                {
                    iterator = iterator.Previous; // ga naar de vorige
                    SectionData Previous = GetSectionData(iterator.Value); // zet de vorige sectiondata in variabele Previous
                    Previous.Left = participant; // en plaats hier links de participant
                }
            }
        }
    }
}
