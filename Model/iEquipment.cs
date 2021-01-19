using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface iEquipment
    {
        public int Quality { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool IsBroken { get; set; }

        
        // 1 Section = 100 m (25 m per karakter)
        // Snelheid = Performance * Speed
    }

}
