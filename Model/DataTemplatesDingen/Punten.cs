using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Punten : iHelikopterview
    {
        public string Naam { get; set; }
        public int PuntenDeelnemer { get; set; }

        public void Add(List<iHelikopterview> lijst)
        {
            bool gevonden = false;
            foreach (var lijstitem in lijst)
            {
                if (lijstitem.Naam != Naam) // Als de naam van het item in de lijst niet gelijk is aan de prop Naam
                {
                    continue; // ga verder, want dit is goed
                }
                if (lijstitem.GetType() == typeof(Punten)) // als het type van het lijstitem gelijk is met Punten
                {
                    var punten = lijstitem as Punten; // pak het lijstitem als punten
                    punten.PuntenDeelnemer += PuntenDeelnemer; // en voeg de punten erbij
                    gevonden = true;
                }
            }
            if (gevonden == false)
            {
                lijst.Add(this);
            }
        }
        public string BesteDeelnemer(List<iHelikopterview> lijst)
        {
            int BesteDeelnemerPunten = 0;
            string BesteDeelnemerNaam = " ";
            foreach (var item in lijst)
            {
                var Punten = item as Punten;
                if (Punten.PuntenDeelnemer > BesteDeelnemerPunten)
                {
                    BesteDeelnemerPunten = Punten.PuntenDeelnemer;
                    BesteDeelnemerNaam = Punten.Naam;
                }
            }
            return BesteDeelnemerNaam;
        }
    }
}
