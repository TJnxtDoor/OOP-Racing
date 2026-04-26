using ProRacing.Core.Logic;

namespace ProRacing.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            // Initialize race manager with a track length of 150 miles
            var session = new RaceManager(trackLength: 150.0);

            // Populate the grid
            session.RegisterRacer("Chad", 340.5);
            session.RegisterRacer("Foxxy", 338.2);
            session.RegisterRacer("Stephen", 341.0);
            session.RegisterRacer("Norris", 335.8);

            session.StartRace();
            
            Console.WriteLine("\nPress ENTER to close telemetry.");
            Console.ReadLine();
        }
    }
}