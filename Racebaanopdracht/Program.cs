using System;
using System.Threading;
using Controller;
using Model;

namespace Racebaanopdracht

{
    public class Program
    {
        static void Main(string[] args)
        {
            /* SectionTypes[] s = new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight,  SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.Finish };
             SectionTypes[] elburg = new SectionTypes[]
             {
                 SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.RightCorner, SectionTypes.Straight,
                 SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                 SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,
                 SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.RightCorner,
                 SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.RightCorner,
                 SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                 SectionTypes.StartGrid, SectionTypes.StartGrid
             };
             Track Test = new Track("print", elburg);*/

            Data.Initialize();
            Data.NextRace();
            Console.WriteLine($"CurrentRace: {Data.CurrentRace.Track.Name} ");
            //Visualisatie.PlaatsenDeelnemers("  # ", new Astronaut("test"), new Astronaut("test2"));
            Visualisatie.Initialize();
            //Visualisatie.DrawTrack(Data.CurrentRace.Track);
            Data.CurrentRace.DriversChanged += Visualisatie.OnDriversChanged;  

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}