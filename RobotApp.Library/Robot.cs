

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

                Commands = journey.GetMovements();

                EndPosition = journey.GetEndPosition();

                EndDirection = journey.GetEndDirection();

                Start();
            };

            return commands;
        }

        private void Start()
        {
            foreach (var command in Commands)
            {
        
                var currentDirection = CurrentDirection;


                Console.WriteLine(currentDirection);

                

                if(command == 'R')
                {
                    
                };
                // Direction = command switch
                // {
                //     'R' => 'E',
                //     _ => 'N'
                // };

            }
            Console.WriteLine($"starting position: { string.Join(" ", StartPosition)} {StartDirection}");
            Console.WriteLine($"starting direction {StartDirection}");
            Console.WriteLine($"commands: {string.Join(", ", Commands)}");

            Console.WriteLine($"ending position: { string.Join(" ", StartPosition)} {StartDirection}");


            Console.WriteLine($"ending direction {EndDirection}");
            Move();
        }

        private void Move()
        {
            foreach (var command in Commands)
            {


            }

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
