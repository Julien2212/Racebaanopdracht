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
            Data.Initialize();
            Data.NextRace();
            Console.WriteLine($"CurrentRace: {Data.CurrentRace.Track.Name} ");
            Visualisatie.Initialize();
            Data.CurrentRace.DriversChanged += Visualisatie.OnDriversChanged;  

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}