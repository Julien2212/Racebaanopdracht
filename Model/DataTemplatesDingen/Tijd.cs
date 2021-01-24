using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Tijd : iHelikopterview
    {
        public string Naam { get; set; }
        public TimeSpan RondeTijd { get; set; }
        public Section Sectie { get; set; }

        public void Add(List<iHelikopterview> lijst)
        {
            bool gevonden = false;
            foreach (var lijstitem in lijst)
            {
                if (lijstitem.Naam != Naam)
                {
                    continue;
                }
                if (lijstitem.GetType() == typeof(Tijd))
                {
                    var tijd = lijstitem as Tijd;
                    tijd.RondeTijd = RondeTijd; // overschrijf de rondetijd

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
            Tijd BesteDeelnemerTijd = null;
            BesteDeelnemerTijd.RondeTijd = TimeSpan.Zero;
            foreach (var item in lijst)
            {
                var Tijd = item as Tijd;
                if (Tijd.RondeTijd > BesteDeelnemerTijd.RondeTijd)
                {
                    BesteDeelnemerTijd.RondeTijd = Tijd.RondeTijd;
                    BesteDeelnemerTijd.Naam = Tijd.Naam;
                }
            }
            return BesteDeelnemerTijd.Naam;
        }
    }
}
