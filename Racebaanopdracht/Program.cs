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
            Data.Initialize("Test");
            Data.NextRace();
            Console.WriteLine($"CurrentRace: {Data.CurrentRace.Track.Name} ");
            //Visualisatie.DrawTrack(Data.NextRace());

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}
