# OOP Racing

A simple racing simulation built with C# to demonstrate basic OOP principles.

## Updates made

The program was updated to make the race simulation more reliable and easier to understand.

- Added validation so the race track length must be greater than zero.
- Added validation so each vehicle must have a driver name and a max speed greater than zero.
- Trimmed extra spaces from driver names before saving them.
- Fixed the race loop so it stops if all engines stall before anyone finishes.
- Prevented the program from crashing when `Console.Clear()` is not supported by the runner.
- Updated the final output to show clearer race results, including whether each racer finished, stalled, or did not finish.
- Fixed small formatting issues in the console output, such as spacing in the track length message.

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

