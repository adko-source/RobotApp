

namespace RobotApp.Library
{
    public record Journey
    {
        public string StartConditons { get; set; } = string.Empty;

        public string EndConditons { get; set; } = string.Empty;

        public string Movements { get; set; } = string.Empty;
        

        public int[] GetStartPosition()
        {
            var startConditions = StartConditons.Split();
            var col = int.Parse(startConditions[0]);
            var row = int.Parse(startConditions[1]);
       
            return new int[2] {  col,  row };
        }

        public char GetStartDirection()
        {
            return StartConditons.Substring(2).ToCharArray()[2];
        }

        public string GetEndPosition()
        {
            Console.WriteLine(EndConditons.Substring(0, 1));
            return EndConditons.Substring(0, 2);
        }

        public char GetEndDirection()
        {
            return EndConditons.Substring(2).ToCharArray()[0];
        }

        public List<char> GetMovements()
        {
            return Movements.ToCharArray().ToList();
        }
    }
}
