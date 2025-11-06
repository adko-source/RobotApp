


namespace RobotApp.Library
{
    public class Robot
    {
        public Position? StartPosition { get; set; }

        public Position? CurrentPosition { get; set; }

        public Direction StartDirection { get; set; }

        public Direction CurrentDirection { get; set; }
        public List<char> Commands { get; set; } = new List<char>();

        public Position? ExpectedEndPosition { get; set; }

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

                Start(grid);
            };

            return commands;
        }

        private void Start(char[,] grid)
        {
            System.Console.WriteLine($"journey started pos {string.Join(" ", StartPosition)}");
            System.Console.WriteLine($"journey started dir {StartDirection}");
            System.Console.WriteLine($"journey commands {string.Join("", Commands)}");

            System.Console.WriteLine($"journey expected end pos {string.Join(" ", ExpectedEndPosition)}");
            System.Console.WriteLine($"journey expected end dir {ExpectedEndDirection}");

            CurrentPosition = StartPosition;

            CurrentDirection = StartDirection;

            foreach (var command in Commands)
            {
                if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }
                else if (command == 'F')
                {
                    Move();

                    if (!IsCurrentPositionValid(grid))
                    {
                        Console.WriteLine("OUT OF BOUNDS");
                        break;
                    }
                    else if (IsCrashed(grid))
                    {
                        Console.WriteLine($"CRASHED {CurrentPosition.Col} {CurrentPosition.Row} {CurrentDirection}");
                        break;
                    }
                }
            }

            var journeyResult = $"{CurrentPosition.Col} {CurrentPosition.Row} {CurrentDirection}";
            
            var expectedResult = $"{ExpectedEndPosition.Col} {ExpectedEndPosition.Row} {ExpectedEndDirection}";

            var status = journeyResult == expectedResult ? "SUCCESS" : "FAILURE";

            Console.WriteLine($"{status} {journeyResult}");
        }

        public void Turn(char command)
        {
            if (command == 'R')
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
            else if (command == 'L')
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

        private void Move()
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
                Row = CurrentPosition.Row + rowOffset,
                Col = CurrentPosition.Col + colOffset
            };

            CurrentPosition = newPosition;
        }

        private bool IsCurrentPositionValid(char[,] grid)
        {
            var maxRows = grid.GetLength(0) -1;

            var maxCols = grid.GetLength(1) -1;

            if (CurrentPosition?.Row > maxRows || CurrentPosition?.Row < 0 || CurrentPosition?.Col >= maxCols || CurrentPosition?.Col < 0)
            {
                return false;
            }

            return true;
        }

        private bool IsCrashed(char[,] grid)
        {
            if (grid[CurrentPosition.Row, CurrentPosition.Col] == 'O')
            {
                return true;
            }

            return false;
        }

        private static void CheckCurrentStatus(string currentPosition)
        {
            // switch(currentPosition)
            // {
            //     case ""
            // }
        }

        private static void PrintJourneyLog(string result)
        {


            if (result == "")
            {
                Console.WriteLine("ss");
            }
            else
            {
                Console.WriteLine("ss");
            }

            

        }







    }
}
