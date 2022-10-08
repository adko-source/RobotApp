

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
            foreach(var obstacle in obstacles)
            {
                var obstacleRow = obstacle[0];
                var obstacleCol = obstacle[1];
                grid[obstacleRow, obstacleCol] = 'O';
            }
            
        }



        

    }
}