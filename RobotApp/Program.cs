using RobotApp.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];

            if (File.Exists(filePath))
            {
                // Console.WriteLine("Instructions found...");
                // Console.WriteLine("Reading instructions...");
            }
            else
            {
                Console.WriteLine("Couldn't find the file. Please try again.");
                return;
            }
            
            var instructions = File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();
    
            var parsedObstacles = FileParser.GetObstacles(instructions);

            var obstacles = new List<int[]>();
            
            foreach(var obstacle in parsedObstacles)
            {
                obstacles.Add(obstacle);
            };

            var grid = Grid.BuildGrid(instructions);

            var robot = new Robot();
            robot.GiveInstructionsAndStart(instructions, grid);
            
        }
    }
}
