using RobotApp.Library;
using System;
using System.IO;

namespace RobotApp
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Please enter the file name:");
            //var fileName = Console.ReadLine();
            var inputFile = @"C:\Users\adko8\OneDrive\Desktop\robot-dev-test (2)\robot-dev-test\RobotApp\Sample2.txt";
            Console.WriteLine("STARTING POSITIONS::");
            foreach(string line in FileParser.GetStartPositions(inputFile))
            {
                
                Console.WriteLine(line);
                
            };
            Console.WriteLine("");
            Console.WriteLine("COMMANDS::");
            foreach (string line in FileParser.GetCommands(inputFile))
            {

                Console.WriteLine(line);

            };
            Console.WriteLine("");
            Console.WriteLine("EXPECTED END POSITIONS::");
            foreach (string line in FileParser.GetEndPositions(inputFile))
            {

                Console.WriteLine(line);

            };
            Console.WriteLine("");
            Console.WriteLine("START DIRECTIONS::");
            foreach (string line in FileParser.GetStartDirections(inputFile))
            {

                Console.WriteLine(line);

            };
            Console.WriteLine("");
            Console.WriteLine("END DIRECTIONS::");
            foreach (string line in FileParser.GetEndDirections(inputFile))
            {

                Console.WriteLine(line);

            };

            var rowLength = FileParser.GetGridSize(inputFile).GetLength(0);
            var colLength = FileParser.GetGridSize(inputFile).GetLength(1);
            string[,] grid = new string[rowLength, colLength];
            grid[0, 0] = "X";

            //Console.WriteLine(Path.GetFullPath("sample.txt") );
            






        }
    }
}
