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
            int rows = 0;
            int cols = 0;

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

        public static List<string> GetStartPositions(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> startingPositions = new List<string>();
           

            foreach (string line in fileContent)
            {
                string formattedLine = line.Trim().ToUpper();
                // Pull out only the lines we want from the file 
                // example: every 3rd line in instruction file should contain starting pos.
                if (formattedLine.Contains("GRID") == false &&
                    formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Length > 0)
                {
                    parsedLines.Add(formattedLine);
                };
            };

            for (int i = 0; i < parsedLines.Count; i += 3)
            {
                if (i == 0)
                {
                    startingPositions.Add(
                        $"{parsedLines[i].Trim().Split()[0]} {parsedLines[i].Trim().Split()[1]}"
                        );
                }
                else
                {
                    startingPositions.Add(
                        $"{parsedLines[i].Trim().Split()[0]} {parsedLines[i].Trim().Split()[1]}"
                        );
                };
            };

            return startingPositions;
        }

        public static List<string> GetEndPositions(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> endPositions = new List<string>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("GRID") == false &&
                    formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Trim().Length > 0)
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 2; i < parsedLines.Count; i += 3)
            {
                endPositions.Add(
                        $"{parsedLines[i].Split()[0]} {parsedLines[i].Split()[1]}"
                        );
            };

            return endPositions;
        }

        public static List<string> GetStartDirections(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> startingDirections = new List<string>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("GRID") == false &&
                    formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Length > 0)
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 0; i < parsedLines.Count; i += 3)
            {
                if (i == 0)
                {
                    startingDirections.Add(parsedLines[i].Trim().Split()[2]);
                }
                else
                {
                    startingDirections.Add(parsedLines[i].Trim().Split()[2]);
                };
            };

            return startingDirections;
        }

        public static List<string> GetEndDirections(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> endDirections = new List<string>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("GRID") == false &&
                    formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Length > 0)
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 2; i < parsedLines.Count; i += 3)
            {
                if (i == 0)
                {
                    endDirections.Add(parsedLines[i].Trim().Split()[2]);
                }
                else
                {
                    endDirections.Add(parsedLines[i].Trim().Split()[2]);
                };
            };

            return endDirections;
        }

        public static List<string> GetCommands(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> commands = new List<string>();

            foreach (string line in fileContent)
            {
                var formattedLine = line.Trim().ToUpper();
                if (formattedLine.Contains("GRID") == false &&
                    formattedLine.Contains("OBSTACLE") == false &&
                    formattedLine.Trim().Length > 0)
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 1; i < parsedLines.Count; i += 3)
            {
                commands.Add(parsedLines[i].Trim());
            };

            return commands;
        }
        public static List<string> GetObstacles(string filePath)
        {
            // Create list and add each x line to it to get all starting positions
            string[] fileContent = File.ReadAllLines(filePath);
            List<string> parsedLines = new List<string>();
            List<string> obstacles = new List<string>();

            foreach (string line in fileContent)
            {
                // Pull out only the lines we want from the file 
                // example: every 3rd line in instruction file should contain starting pos.
                if (line.Trim().ToUpper().Contains("OBSTACLE"))
                {
                    parsedLines.Add(line);
                };
            };

            for (int i = 1; i < parsedLines.Count; i += 3)
            {
                obstacles.Add(parsedLines[i].Trim().Split()[i]);
            };

            return obstacles;
        }


    }
}
