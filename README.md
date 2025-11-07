# Robot Console App

## Description
This console app processes a `.txt` instructions file containing:

- The grid size (GRID 4X3) cols x rows
- One or more journeys containing:
  - Starting coordinates (1 3)
  - Starting direction (N = North, E = East, S = South, W = West)
  - Commands (L = Turn left, R = Turn right, F = Move forward)
  - Expected ending coordinates and direction (0 3 W)
- Optional obstacles (OBSTACLE 2 3)

The app moves a robot inside of a grid based on the instructions and outputs the results to the console.

---

## How to Run
1. Create an instructions file (`.txt`). You can use any of the provided `Sample.txt` files as a template.  
2. Open a terminal and cd into 'RobotApp' and then run:
`dotnet build`
`dotnet run "C:\path\to\your\instructions.txt"`

## Expected Output
The app should output the result of each journey followed by its coordinates and direction.

SUCCESS 1 0 W<br>
FAILURE 0 0 W<br>
OUT OF BOUNDS<br>
CRASHED 1 1<br>

### Description of outputs
SUCCESS = The final coordinates and direction after the journey match the expected coordinates and direction<br>
FAILURE = The final coordinates and direction after the journey don't match the expected coordinates and direction<br>
OUT OF BOUNDS = The journey took the robot outside of the grid<br>
CRASHED = The robot hit an obstacle 'O' within the grid at the displayed coordinates

## Running Unit Tests
1. cd into RobotApp.Tests
2. run `dotnet build; dotnet test`