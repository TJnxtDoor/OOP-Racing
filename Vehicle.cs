using System;

namespace ProRacing.Core.Models
{
    public class Vehicle
    {
        // Auto-properties with private setters for data integrity
        public string Id { get; } = Guid.NewGuid().ToString().Substring(0, 8); //
        public string DriverName { get; init; } // Immutable after initialization
        public double CurrentVelocity { get; private set; } // in mph
        public double Odometer { get; private set; } // in miles
        public bool IsEngineStalled { get; private set; } // Simulate mechanical failure

        private readonly double _maxSpeed; // in mph
        private static readonly Random _physicsEngine = new(); // Shared random generator for all vehicles

        public Vehicle(string driver, double maxSpeed) // Constructor with parameters for better encapsulation
        {
            if (string.IsNullOrWhiteSpace(driver))
            {
                throw new ArgumentException("Driver name is required.", nameof(driver));
            }

            if (maxSpeed <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxSpeed), "Maximum speed must be greater than zero.");
            }

            DriverName = driver.Trim();
            _maxSpeed = maxSpeed;
        }

        public void Accelerate()
        {
            if (IsEngineStalled) return;

            // Simulate mechanical failure (0.5% chance)
            if (_physicsEngine.NextDouble() < 0.005)
            {
                IsEngineStalled = true;
                return;
            }

            
            double acceleration = _physicsEngine.NextDouble() * 15; // Random acceleration up to 15 mph
            CurrentVelocity = Math.Min(CurrentVelocity + acceleration, _maxSpeed); // Cap at max speed
            Odometer += CurrentVelocity * 0.1; // Simulated time step
        }

        public string GetTelemetry() => 
            $"[{Id}] {DriverName.PadRight(12)} | {Odometer,8:F2} mi | {CurrentVelocity,6:F1} mph";
    }
}
