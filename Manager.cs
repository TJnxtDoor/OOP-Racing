using System;
using System.Collections.Generic;
using System.Linq;
using ProRacing.Core.Models;

namespace ProRacing.Core.Logic
{
    public class RaceManager
    {
        private readonly List<Vehicle> _grid = new(); // List to hold all participating vehicles
        private readonly double _trackLength; // in miles

        public RaceManager(double trackLength)
        {
            _trackLength = trackLength;
        }

        public void RegisterRacer(string name, double topSpeed) =>
            _grid.Add(new Vehicle(name, topSpeed));

        public void StartRace()
        {
            Console.WriteLine($"Race started: {_trackLength}miles track.");
            bool winnerCrossed = false;

            while (!winnerCrossed)
            {
                Console.Clear();
                Console.WriteLine("LIVE TELEMETRY FEED");

                foreach (var car in _grid)
                {
                    car.Accelerate();
                    Console.WriteLine(car.GetTelemetry() + (car.IsEngineStalled ? " [OUT]" : ""));

                    if (car.Odometer >= _trackLength) winnerCrossed = true;
                }

                System.Threading.Thread.Sleep(200); // Simulate real-time updates
            }

            FinalizeResults();
        }

        private void FinalizeResults()
        {
            // Sort racers by distance covered and display podium
            var podium = _grid.OrderByDescending(x => x.Odometer).Take(3).ToList();
            Console.WriteLine("\n=== PODIUM FINISHERS ===");
            for (int i = 0; i < podium.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {podium[i].DriverName} ({podium[i].Odometer:F2} mi)");
            }
        }
    }
}