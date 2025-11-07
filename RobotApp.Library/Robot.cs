


namespace RobotApp.Library
{
    public class Robot
    {
        public Position StartPosition = new(0, 0);

        public Position CurrentPosition = new(0, 0);
        public Direction StartDirection { get; set; }

        public Direction CurrentDirection { get; set; }
        
        public List<Command> Commands { get; set; } = new List<Command>();

        public Position ExpectedEndPosition = new(0, 0);

        public Direction ExpectedEndDirection { get; set; }
        

        public List<char> GiveInstructionsAndStart(string[] instuctions, char[,] grid)
        {
            var journeys = FileParser.GetJourneys(instuctions);

            var commands = new List<char>();

            foreach (var journey in journeys)
            {
                StartPosition = journey.GetStartPosition();

                StartDirection = journey.GetStartDirection();

                Commands = journey.GetCommands();

                ExpectedEndPosition = journey.GetEndPosition();

                ExpectedEndDirection = journey.GetEndDirection();

                RunCommands(grid);
            };

            return commands;
        }

        public void RunCommands(char[,] grid)
        {
            CurrentPosition = StartPosition;

            CurrentDirection = StartDirection;

            foreach (var command in Commands)
            {
                if (command == Command.L || command == Command.R)
                {
                    Turn(command);
                }
                else if (command == Command.F)
                {
                    Move();

                    if (IsOutOfBounds(grid))
                    {
                        Console.WriteLine("OUT OF BOUNDS");
                        return;
                    }
                    else if (IsCrashed(grid))
                    {
                        Console.WriteLine($"CRASHED {CurrentPosition.Col} {CurrentPosition.Row}");
                        return;
                    }
                }
            }

            var journeyResult = $"{CurrentPosition.Col} {CurrentPosition?.Row} {CurrentDirection}";
            
            var expectedResult = $"{ExpectedEndPosition.Col} {ExpectedEndPosition.Row} {ExpectedEndDirection}";

            var status = journeyResult == expectedResult ? "SUCCESS" : "FAILURE";

            Console.WriteLine($"{status} {journeyResult}");
        }

        public void Turn(Command command)
        {
            if (command == Command.R)
            {
                CurrentDirection = CurrentDirection switch
                {
                    Direction.N => Direction.E,
                    Direction.E => Direction.S,
                    Direction.S => Direction.W,
                    Direction.W => Direction.N,
                    _ => CurrentDirection
                };
            }
            else if (command == Command.L)
            {
                CurrentDirection = CurrentDirection switch
                {
                    Direction.N => Direction.W,
                    Direction.W => Direction.S,
                    Direction.S => Direction.E,
                    Direction.E => Direction.N,
                    _ => CurrentDirection
                };
            }
        }

        public void Move()
        {
            var rowOffset = CurrentDirection switch
            {
                Direction.N => 1,
                Direction.S => -1,
                _ => 0
            };

            var colOffset = CurrentDirection switch
            {
                Direction.E => 1,
                Direction.W => -1,
                _ => 0
            };

            var newPosition = CurrentPosition with
            {
                Col = CurrentPosition.Col + colOffset,
                Row = CurrentPosition.Row + rowOffset,
            };

            CurrentPosition = newPosition;
        }

        public bool IsOutOfBounds(char[,] grid)
        {
            var maxRows = grid.GetLength(1);

            var maxCols = grid.GetLength(0);

            return (CurrentPosition.Row > maxRows) || (CurrentPosition.Row < 0) || (CurrentPosition.Col >= maxCols) || (CurrentPosition.Col < 0);
        }

        public bool IsCrashed(char[,] grid)
        {
            return grid[CurrentPosition.Col, CurrentPosition.Row] == 'O';
        }
    }
}
