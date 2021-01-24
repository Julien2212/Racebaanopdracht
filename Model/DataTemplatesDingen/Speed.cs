using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Speed : iHelikopterview
    {
        public string Naam { get; set; }
        public int Snelheid { get; set; }
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
                if (lijstitem.GetType() == typeof(Speed))
                {
                    var snelheid = lijstitem as Speed;
                    snelheid.Snelheid = Snelheid; // overschrijf als het niet klopt
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
            Speed BesteDeelnemerSpeed = null;
            BesteDeelnemerSpeed.Naam = null;
            BesteDeelnemerSpeed.Snelheid = 0;
            BesteDeelnemerSpeed.Sectie = null;
            foreach (var item in lijst)
            {
                var Speed = item as Speed;
                if (Speed.Snelheid > BesteDeelnemerSpeed.Snelheid)
                {
                    BesteDeelnemerSpeed.Snelheid = Speed.Snelheid;
                    BesteDeelnemerSpeed.Naam = Speed.Naam;
                }
            }
            return BesteDeelnemerSpeed.Naam;
        }
    }
}
