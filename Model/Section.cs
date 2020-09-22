using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Section
    {
        public SectionTypes SectionType { get; set; }

        public static implicit operator Section(SectionData v)
        {
            throw new NotImplementedException();
        }
    }
    public enum SectionTypes
    {
        Straight,
        LeftCorner,
        RightCorner,
        StartGrid,
        Finish
    }
}
