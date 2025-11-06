

using System.Linq.Expressions;

namespace RobotApp.Library
{
    public static class FileParser
    {

        public static bool IsValidFile(string[] instructions)
        {
            return instructions.Length != 0 && instructions.First().ToUpper().Contains("GRID");
        }
        public static int[,] GetGridSize(string[] instructions)
        {
            var cols = 0;

            var rows = 0;

            foreach (string line in instructions)
            {
                var formattedLine = line.Trim().ToUpper();

                if (formattedLine.Contains("GRID"))
                {
                    // Parse grid size from instructions
                    // Example line: GRID 4x4
                    var parsedGridSize = formattedLine.Split(" ")[1];

                    cols = int.Parse(parsedGridSize.Split("X")[0]);

                    rows = int.Parse(parsedGridSize.Split("X")[1]);
                }
            }

            return new int[rows, cols];
        }

        public static List<int[]> GetObstacles(string[] instructions)
        {
            // Create list and add each OBSTACLE line
            List<int[]> obstacles = new();

            var parsingError = false;

            foreach (var (line, index) in instructions.Select((value, i) => (value, i)))
            {
                var formattedLine = line.Trim().ToUpper();

                if (formattedLine.Contains("OBSTACLE"))
                {
                    string? previousLine = index > 0 ? instructions[index - 1] : "";

                    // Check that OBSTACLE line isn't after a journey in the file
                    if ("NESW".Any(c => previousLine.ToUpper().Contains(c)))
                    {
                        parsingError = true;
                    }
                    else
                    {
                        var obstacleCol = int.Parse(formattedLine.Split(" ")[1]);

                        var obstacleRow = int.Parse(formattedLine.Split(" ")[2]);

                        obstacles.Add(new int[2] { obstacleCol, obstacleRow });
                    }
                }
            }
            
            if(parsingError)
            {
                Console.WriteLine("Error parsing instructions file: OBSTACLES line should come before journeys.");
            }

            return obstacles;
        }
        public static List<Journey> GetJourneys(string[] instructions)
        {
            // Create list and add each x line to it to get all starting positions
            var parsedLines = new List<string>();

            var journeys = new List<Journey>();

            foreach (string line in instructions)
            {
                var formattedLine = line.Trim().ToUpper();

                if (formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Contains("GRID") == false &&
                    formattedLine.Length > 0
                    )
                {
                    parsedLines.Add(line);
                }
            }

            for (int i = 0; i < parsedLines.Count; i += 3)
            {
                var journey = new Journey
                {
                    StartConditons = parsedLines[i],
                    Commands = parsedLines[i + 1],
                    EndConditons = parsedLines[i + 2],
                };

                journeys.Add(journey);
            }
            
            return journeys;
        }
    }

    
}
