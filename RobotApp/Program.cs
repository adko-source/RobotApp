using RobotApp.Library;
using System;
using System.Collections.Generic;
using System.IO;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            Console.WriteLine($"Looking for instructions at {filePath}");

            if (File.Exists(filePath))
            {
                Console.WriteLine("Instructions found...");
                Console.WriteLine("Reading instructions...");


            }
            else
            {
                Console.WriteLine("Couldn't find the file. Please try again.");
                return;
            }

            string[] instructions = File.ReadAllLines(filePath);
        
            var colLength = FileParser.GetGridSize(instructions).GetLength(0);
    
            var rowLength = FileParser.GetGridSize(instructions).GetLength(1);
            Grid grid = new Grid
            {
                Columns = colLength,
                Rows = rowLength 
            };

            var parsedObstacles = FileParser.GetObstacles(instructions);
           
            var obstacles = new List<int[]>();
            foreach(var obstacle in parsedObstacles)
            {
                obstacles.Add(obstacle);
            };

            var g = grid.CreateGrid(obstacles);

            Console.WriteLine(g[1, 2]);
            Console.WriteLine(g[1,3]);
            //Console.WriteLine(g[2, 4]);
            if(g[1,2] == 'O')
            {
                Console.WriteLine("OBSTACLE HERE");
            }

            var journeys = FileParser.GetJourneys(instructions);

            int counter = 0;
            foreach(var journey in journeys)
            {
                counter++;
                Console.WriteLine($"Journey {counter}:");
                Console.WriteLine($"Start conditions: {journey.StartConditons}");
                Console.WriteLine($"Commands: {journey.Movements}");
                Console.WriteLine($"End conditions: {journey.EndConditons}");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            var robot = new Robot();
            robot.GiveInstructionsAndStart(instructions);
            



        }
    }
}
