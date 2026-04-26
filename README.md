# OOP Racing

A simple racing simulation built with C# to demonstrate basic OOP principles.


## Files

| File | Description |
|------|-------------|
| `Program.cs` | Entry point. Sets up the race and kicks it off. |
| `Manager.cs` | `RaceManager` class. Handles vehicle registration, runs the race loop, and outputs the podium. |
| `Vehicle.cs` | `Vehicle` class. Represents a car with driver name, speed, odometer, and stall state. |

## How to run

```bash
dotnet run
```

The `[OUT]` tag means that car's engine stalled during the race (there's a 0.5% chance per tick).

