

namespace RobotApp.Library
{
    public record Grid
    {
        public int Columns { get; set; } = 0;
        public int Rows { get; set; } = 0;
        public int[] Obstacles { get; set; } = new int[2];

        public char[,] CreateGrid(List<int[]> obstacles)
        {
            var grid = new char[Columns, Rows];

            SetObstacles(obstacles, grid);

            return grid;
        }

        private static void SetObstacles(List<int[]> obstacles, char[,] grid)
        {
            Console.WriteLine($"grid rows: {grid.GetLength(0)}");
            Console.WriteLine($"grid cols: {grid.GetLength(1)}");
            foreach (var obstacle in obstacles)
            {
                var obstacleCol = obstacle[0];
                Console.WriteLine($"obstacle col: {obstacleCol}");
                var obstacleRow = obstacle[1];
                Console.WriteLine($"obstacle row: {obstacleRow}");
                grid[obstacleRow, obstacleCol] = 'O';

                Console.WriteLine($"obstacle value: {grid[obstacleRow, obstacleCol]}");
            }
            
            
            
        }
    }
}