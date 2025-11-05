

namespace RobotApp.Library
{
    public record Journey
    {
        public string StartConditons { get; set; } = string.Empty;

        public string EndConditons { get; set; } = string.Empty;

        public string Movements { get; set; } = string.Empty;
        

        public Position GetStartPosition()
        {
            var startConditions = StartConditons.Split();

            var col = int.Parse(startConditions[0]);

            var row = int.Parse(startConditions[1]);

            return new Position { Col = col, Row = row };
        }

        public Direction GetStartDirection()
        {
            var startDirectionChar = StartConditons.Substring(2).ToCharArray()[2];

            return startDirectionChar switch
            {
                'N' => Direction.N,
                'E' => Direction.E,
                'S' => Direction.S,
                'W' => Direction.W,
                _ => throw new ArgumentException("Invalid direction character, should be N E S W")
            };
        }

        public Position GetEndPosition()
        {
            var endConditions = EndConditons.Split();

            Console.WriteLine($"endconditons: {string.Join(",", endConditions)}");

            var col = int.Parse(endConditions[0]);

            var row = int.Parse(endConditions[1]);

            return new Position { Col = col, Row = row };
        }

        public Direction GetEndDirection()
        {
            var endDirectionChar = EndConditons.Substring(2).ToCharArray()[2];
            Console.WriteLine($"endDirectionChar {endDirectionChar}");

            return endDirectionChar switch
            {
                'N' => Direction.N,
                'E' => Direction.E,
                'S' => Direction.S,
                'W' => Direction.W,
                _ => throw new ArgumentException("Invalid direction character, should be N E S W")
            };
        }

        public List<char> GetMovements()
        {
            return Movements.ToCharArray().ToList();
        }
    }
}
