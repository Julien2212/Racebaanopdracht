using System;
using Controller;
using Model;

namespace Racebaanopdracht

{
    class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize("bruh");
            Data.NextRace();
            Console.WriteLine($"bruh bruh {Track} bruh {CurrentRace} bruh bruh");
        }
    }
}
