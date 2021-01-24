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

        public GenericGegevens<Punten> gegevens = new GenericGegevens<Punten>(); // goed


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
        public void BepaalEindstand(Queue<iParticipant> queue)
        {
            if (queue.Count == 4)
            {
                Punten p = new Punten();
                p.Naam = queue.Dequeue().Name;
                p.PuntenDeelnemer = 10;
                gegevens.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 3)
            {
                Punten p = new Punten();
                p.Naam = queue.Dequeue().Name;
                p.PuntenDeelnemer = 7;
                gegevens.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 2)
            {
                Punten p = new Punten();
                p.Naam = queue.Dequeue().Name;
                p.PuntenDeelnemer = 5;
                gegevens.FillList(p);
                queue.Dequeue();
            }
            if (queue.Count == 1)
            {
                Punten p = new Punten();
                p.Naam = queue.Dequeue().Name;
                p.PuntenDeelnemer = 3;
                gegevens.FillList(p);
                queue.Dequeue();
            }

        }
    }
}
