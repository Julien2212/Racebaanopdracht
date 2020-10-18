using System;
using System.Threading;
using Controller;
using Model;

namespace Racebaanopdracht

{
    class Program
    {
        static void Main(string[] args)
        {
            SectionTypes[] s = new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Finish };
            Track test = new Track("testTrack", s);
            Data.Initialize();
            Data.NextRace();
            Console.WriteLine($"CurrentRace: {Data.CurrentRace.Track.Name} ");
            Visualisatie.DrawTrack(test);
            

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}
