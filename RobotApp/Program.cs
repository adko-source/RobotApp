using RobotApp.Library;
using System;
using System.Collections.Generic;
using System.IO;

namespace RobotApp
{
    class Program
    {
        static void Main()
        {

            //Console.WriteLine("Please provide file name");
            //var fileName = Console.ReadLine();
            // Write method to get file path from file name
            var inputFile = @"C:\Users\adko8\OneDrive\Desktop\robot-dev-test (2)\robot-dev-test\RobotApp\Sample2.txt";

            var rowLength = FileParser.GetGridSize(inputFile).GetLength(0);
            var colLength = FileParser.GetGridSize(inputFile).GetLength(1);
            Grid grid = new Grid
            {
                Rows = rowLength,
                Columns = colLength,
            };

            var parsedObstacles = FileParser.GetObstacles(inputFile);
            List<int[]> obstacles = new List<int[]>();
            foreach(var obstacle in parsedObstacles)
            {
                obstacles.Add(obstacle);
            };

            
            var g = grid.Create(obstacles);

            Console.WriteLine(g[1, 2]);
            Console.WriteLine(g[1,3]);
            Console.WriteLine(g[2, 4]);
            if(g[1,2] == 'O')
            {
                Console.WriteLine("OBSTACLE HERE");
            }

            var journeys = FileParser.GetJourneys(inputFile);

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
            robot.GiveInstructionsAndStart(inputFile);
            



        }
    }
}
