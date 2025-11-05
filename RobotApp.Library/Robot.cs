

using System.Collections;
using System.Globalization;

namespace RobotApp.Library
{
    public class Robot
    {
        public Position? StartPosition { get; set; }

        public Position? CurrentPosition { get; set; }

        public Direction StartDirection { get; set; }

        public Direction CurrentDirection { get; set; }
        public List<char> Commands { get; set; } = new List<char>();

        public Position? EndPosition { get; set; }

        public Direction EndDirection { get; set; }
       
        public List<char> GiveInstructionsAndStart(string[] instuctions)
        {
            var journeys = FileParser.GetJourneys(instuctions);

            var commands = new List<char>();

            foreach (var journey in journeys)
            {
                StartPosition = journey.GetStartPosition();

                StartDirection = journey.GetStartDirection();

                Commands = journey.GetCommands();

                EndPosition = journey.GetEndPosition();

                EndDirection = journey.GetEndDirection();

                Start();
            };

            return commands;
        }

        private void Start()
        {
            CurrentDirection = StartDirection;
            
            Console.WriteLine($"starting position: {string.Join(" ", StartPosition?.Col.ToString() + " " + StartPosition?.Row.ToString())} {StartDirection}");
            Console.WriteLine($"commands: {string.Join(", ", Commands)}");

            Console.WriteLine($"ending position: {string.Join(" ", EndPosition?.Col.ToString() + " " + EndPosition?.Row.ToString())} {EndDirection}");

            foreach (var command in Commands)
            {

                if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }
                else if (command == 'F')
                {
                    Move(command);
                }
                // Direction = command switch
                // {
                //     'R' => 'E',
                //     _ => 'N'
                // };

            }


            //Move();
        }
        
        public void Turn(char command)
        {
            System.Console.WriteLine($"Direction before turning {CurrentDirection}");

            if (command == 'R')
            {
                CurrentDirection = CurrentDirection switch
                {
                    Direction.N => Direction.E,
                    Direction.E => Direction.S,
                    Direction.S => Direction.W,
                    Direction.W => Direction.N,
                    _ => CurrentDirection
                };
            }
            else if (command == 'L')
            {
                CurrentDirection = CurrentDirection switch
                {
                    Direction.N => Direction.W,
                    Direction.W => Direction.S,
                    Direction.S => Direction.E,
                    Direction.E => Direction.N,
                    _ => CurrentDirection
                };
            }

                
            System.Console.WriteLine($"Direction after turning {CurrentDirection}");
        }

        private void Move(char command)
        {
            

        }
        
   

        private static void CheckCurrentStatus(string currentPosition)
        {
            // switch(currentPosition)
            // {
            //     case ""
            // }
        }

        private static void PrintJourneyLog(string result)
        {


            if (result == "")
            {
                Console.WriteLine("ss");
            }
            else
            {
                Console.WriteLine("ss");
            }

            

        }







    }
}
