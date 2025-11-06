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

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Couldn't find the file. Please try again.");
                return;
            }

            var instructions = File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();

            if(!FileParser.IsValidFile(instructions))
            {
                Console.WriteLine("Instructions aren't valid. Please see 'Sample2.txt' for expected format.");
            }
    
            var grid = Grid.BuildGrid(instructions);

            var robot = new Robot();

            robot.GiveInstructionsAndStart(instructions, grid);
            
        }
    }
}
