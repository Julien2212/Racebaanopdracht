using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Astronaut : iParticipant
    {
        public string Name { get; set; }
        public int Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public iEquipment Equipment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public iParticipant.TeamColors TeamColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Astronaut(string name)
        {
            Name = name;
        }
    }
}
