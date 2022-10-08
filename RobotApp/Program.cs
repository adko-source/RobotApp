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

            // TODO: Write method to get file path from file name
            // TODO: Check file exists
            //var fileName = Console.ReadLine();

            // change classes to records to make them immutable 
            // keep only data inside, bring methods to helper class?

            // pass records into constructors and don't use primative types

            var inputFile = @"C:\Users\adko8\OneDrive\Desktop\robot-dev-test (2)\robot-dev-test\RobotApp\Sample2.txt";

            var colLength = FileParser.GetGridSize(inputFile).GetLength(0);
            var rowLength = FileParser.GetGridSize(inputFile).GetLength(1);
            Grid grid = new Grid
            {
                Columns = colLength,
                Rows = rowLength 
            };

            var parsedObstacles = FileParser.GetObstacles(inputFile);
            List<int[]> obstacles = new List<int[]>();
            foreach(var obstacle in parsedObstacles)
            {
                obstacles.Add(obstacle);
            };

            
            var g = grid.CreateGrid(obstacles);

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
