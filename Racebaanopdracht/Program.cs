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

            Visualisatie1.Initialize();
           

            for (; ; )
            {
                Thread.Sleep(100);
            }
        }
    }
}