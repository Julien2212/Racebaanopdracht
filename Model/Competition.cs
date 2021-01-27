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

        public GenericGegevens<Punten> gegevensPunten = new GenericGegevens<Punten>();
        public GenericGegevens<Speed> gegevensSpeed = new GenericGegevens<Speed>();
        public GenericGegevens<Tijd> gegevensTijd = new GenericGegevens<Tijd>();
        public GenericGegevens<Kapot> gegevensKapot = new GenericGegevens<Kapot>();

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
        public void OpslaanPunten(Queue<iParticipant> queue)
        {
            if (queue.Count == 4)
            {
                Punten p = new Punten();
                p.Naam = queue.Peek().Name;
                p.PuntenDeelnemer = 10;
                gegevensPunten.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 3)
            {
                Punten p = new Punten();
                p.Naam = queue.Peek().Name;
                p.PuntenDeelnemer = 7;
                gegevensPunten.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 2)
            {
                Punten p = new Punten();
                p.Naam = queue.Peek().Name;
                p.PuntenDeelnemer = 5;
                gegevensPunten.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 1)
            {
                Punten p = new Punten();
                p.Naam = queue.Peek().Name;
                p.PuntenDeelnemer = 3;
                gegevensPunten.FillList(p);
                queue.Dequeue();
            }
        }
    }
}
