

namespace RobotApp.Library
{
    public record Grid
    {
        public static char[,] BuildGrid(string[] instructions)
        {
            var rows = FileParser.GetGridSize(instructions).GetLength(0);

            var cols = FileParser.GetGridSize(instructions).GetLength(1);

            var grid = new char[cols, rows];

            var parsedObstacles = new List<int[]>();

            try
            {
                parsedObstacles = FileParser.GetObstacles(instructions) ?? parsedObstacles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Environment.Exit(1);
            }

            var obstacles = new List<int[]>();
            
            foreach(var obstacle in parsedObstacles)
            {
                obstacles.Add(obstacle);
            };

            SetObstacles(obstacles, grid);

            return grid;
        }

        private static void SetObstacles(List<int[]> obstacles, char[,] grid)
        {
            foreach (var obstacle in obstacles)
            {
                var obstacleCol = obstacle[0];

                var obstacleRow = obstacle[1];
                
                grid[obstacleCol, obstacleRow] = 'O';
            }
        }
    }
}