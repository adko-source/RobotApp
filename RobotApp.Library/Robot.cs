using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotApp.Library;

namespace RobotApp.Library
{
    public class Robot
    {
        public int[] Position { get; set; } = new int[2];

        public char Direction { get; set; }
        public List<char> Commands { get; set; } = new List<char>();
       
        public List<char> GiveInstructionsAndStart(string[] instuctions)
        {
            var journeys = FileParser.GetJourneys(instuctions);

            var commands = new List<char>();

            foreach (var journey in journeys)
            {
                Position = journey.GetStartPosition();

                Direction = journey.GetStartDirection();

                Commands = journey.GetMovements();

                Start();
            };

            return commands;
        }

        private void Start()
        {
            Console.WriteLine("Robot started... Executing intstructions...");
            Console.WriteLine($"Starting at col {Position[0]} and row {Position[1]}");
            Console.WriteLine($"Facing direction {Direction}");
            Move();
        }

        private void Move()
        {
            Console.WriteLine("Commands:");
            foreach (var command in Commands)
            {
                Console.WriteLine($"Move {command}");

            }

            Console.WriteLine();
            Console.WriteLine();
        }







    }
}
