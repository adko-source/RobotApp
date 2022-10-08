using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApp.Library
{
    public static class FileParser
    {
        
        public static int[,] GetGridSize(string filePath)
        {

            string[] instructions = File.ReadAllLines(filePath);
            int cols = 0;
            int rows = 0;
            

            foreach (string item in instructions)
            {
                if (item.Trim().ToUpper().Contains("GRID"))
                {
                    // Parse grid size from instructions
                    // Example instruction: GRID 4x4
                    var parsedGridSize = item.Split(" ")[1];
                    cols = int.Parse(parsedGridSize.Split("x")[0]);
                    rows = int.Parse(parsedGridSize.Split("x")[1]);
                }

            };
            int[,] gridSize = new int[rows, cols];
            return gridSize;
        }
        public static List<int[]> GetObstacles(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<int[]> obstacles = new List<int[]>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("OBSTACLE"))
                {
                    var obstacleCol = int.Parse(formattedLine.Split(" ")[1]);
                    var obstacleRow = int.Parse(formattedLine.Split(" ")[2]);
                    obstacles.Add(new int[2] { obstacleCol, obstacleRow });
                };
            } 

            return obstacles;
        }
        public static List<Journey> GetJourneys(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<Journey> journeys = new List<Journey>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Contains("GRID") == false &&
                    formattedLine.Length > 0
                    )
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 0; i < parsedLines.Count; i += 3)
            {
                
                var journey = new Journey
                {
                    StartConditons = parsedLines[i],
                    Movements = parsedLines[i + 1],
                    EndConditons = parsedLines[i + 2],
                };
                journeys.Add(journey);
            };

            return journeys;
        }


    }
}
