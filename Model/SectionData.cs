using System;

namespace Model
{
    public class SectionData : iParticipant
    {
        public iParticipant Left { get; set; }
        public int DistanceLeft { get; set; }
        public iParticipant Right { get; set; }
        public int DistanceRight { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public iEquipment Equipment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public iParticipant.TeamColors TeamColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SectionData(iParticipant left, iParticipant right, int distanceright, int distanceleft)
        {
            Left = left;
            DistanceLeft = distanceleft;

            Right = right;
            DistanceRight = distanceright;
        }
    }
}
