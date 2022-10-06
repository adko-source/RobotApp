using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApp.Library
{
    public class Journey
    {
        public string StartConditons { get; set; } = string.Empty;

        public string EndConditons { get; set; } = string.Empty;

        public string Commands { get; set; } = string.Empty;

        public string GetStartPosition()
        {
            Console.WriteLine(StartConditons.Substring(0, 1));
            return StartConditons.Substring(0,2);
        }

        public string GetStartDirection()
        {
            return StartConditons.Substring(2);
        }

        public string GetEndPosition()
        {
            Console.WriteLine(EndConditons.Substring(0, 1));
            return EndConditons.Substring(0, 2);
        }

        public string GetEndDirection()
        {
            return EndConditons.Substring(2);
        }

        public List<char> GetCommands()
        {
            return Commands.ToCharArray().ToList();
        }
    }
}
