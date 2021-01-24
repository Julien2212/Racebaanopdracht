using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Kapot : iHelikopterview
    {
        public string Naam { get; set; }
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
                if (lijstitem.GetType() == typeof(Kapot)) 
                {
                    var kapotSectie = lijstitem as Kapot; 
                    kapotSectie.Sectie = Sectie; // overschrijf

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
            Kapot kapot = null;
            foreach (var item in lijst)
            {
                var Kapot = item as Kapot;
                if (Kapot.Sectie.SectionType == SectionTypes.Straight)
                {
                     kapot.Naam = Kapot.Naam;
                }
            }
            return kapot.Naam;
        }
    }
}
