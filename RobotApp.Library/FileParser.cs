

namespace RobotApp.Library
{
    public static class FileParser
    {

        public static int[,] GetGridSize(string[] instructions)
        {
            int cols = 0;
            int rows = 0;

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

            foreach (string line in instructions)
            {
                var formattedLine = line.Trim().ToUpper();

                if (formattedLine.Contains("OBSTACLE"))
                {
                    var obstacleCol = int.Parse(formattedLine.Split(" ")[1]);
                    var obstacleRow = int.Parse(formattedLine.Split(" ")[2]);
                    obstacles.Add(new int[2] { obstacleCol, obstacleRow });
                }
            }
            
            return obstacles;
        }
        public static List<Journey> GetJourneys(string[] instructions)
        {
            // Create list and add each x line to it to get all starting positions
            List<string> parsedLines = new();
            List<Journey> journeys = new();

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
                    Movements = parsedLines[i + 1],
                    EndConditons = parsedLines[i + 2],
                };
                journeys.Add(journey);
            }

            return journeys;
        }
    }
}
