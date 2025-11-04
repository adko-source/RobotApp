

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
