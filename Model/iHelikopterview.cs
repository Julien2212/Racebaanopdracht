using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // 6.6
    public interface iHelikopterview
    {
        public string Naam { get; set; }

        public void Add(List<iHelikopterview> lijst)
        {
        }

        public string BesteDeelnemer(List<iHelikopterview> lijst)
        {
            return "s";
        }
    }
}
