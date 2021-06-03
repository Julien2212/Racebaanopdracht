using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            Sections = trackArray(sections);
        }

        public LinkedList<Section> trackArray(SectionTypes[] s)
        {
            LinkedList<Section> L = new LinkedList<Section>();
            for (int i = 0; i < s.Length; i++)
            {
                Section a = new Section() { SectionType = s[i] };
                L.AddLast(a);
            }
            return L;
        }
    }
}