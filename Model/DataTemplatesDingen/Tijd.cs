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

    }
}
