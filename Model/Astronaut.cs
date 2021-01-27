using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Astronaut : iParticipant
    {
        public string Name { get; set; }
        public int Points { get ; set ; }
        public iEquipment Equipment { get ; set; }
        public iParticipant.TeamColors TeamColor { get ; set ; }
        public Astronaut(string name, iEquipment equipment, iParticipant.TeamColors kleur)
        {
            Name = name;
            Equipment = equipment;
            TeamColor = kleur;
        }
    }
}
