using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface iParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public iEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        enum TeamColors
        {
            Red,
            Green,
            Yellow,
            Grey,
            Blue
        }
    }
}
