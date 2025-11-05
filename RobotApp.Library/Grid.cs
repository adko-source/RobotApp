

namespace RobotApp.Library
{
    public record Grid
    {
        // public int Columns { get; set; } = 0;
        // public int Rows { get; set; } = 0;
        // public int[] Obstacles { get; set; } = new int[2];

        public static char[,] BuildGrid(string[] instructions)
        {
            var rows = FileParser.GetGridSize(instructions).GetLength(0);

            var cols = FileParser.GetGridSize(instructions).GetLength(1);

            Console.WriteLine($"Building grid with {cols} cols and {rows} rows");

            var grid = new char[rows, cols];

            var parsedObstacles = FileParser.GetObstacles(instructions);
           
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
                Console.WriteLine($"obstacle col: {obstacleCol}");

                var obstacleRow = obstacle[1];
                Console.WriteLine($"obstacle row: {obstacleRow}");
                
                // Set obstacle 'O' in grid[row, col]
                grid[obstacleRow, obstacleCol] = 'O';

                Console.WriteLine($"obstacle value: {grid[obstacleRow, obstacleCol]}");
            }
        }
    }
}