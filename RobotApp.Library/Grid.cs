

namespace RobotApp.Library
{
    public class Grid
    {
        public int Rows { get; set; } = 0;
        public int Columns { get; set; } = 0;
        public int[] Obstacles { get; set; } = new int[2];

        public int[,] Create(List<int[]> obstacles)
        {
            var grid = new int[Rows, Columns];
            SetObstacles(obstacles, grid);
            return grid;
        }

        private void SetObstacles(List<int[]> obstacles, int[,] grid)
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