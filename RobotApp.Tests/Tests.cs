using Xunit;
using RobotApp.Library;

namespace RobotApp.Tests
{
    public class RobotTests
    {
        [Fact]
        public void MoveRobot_North_AddsRow()
        {
            var robot = new Robot
            {
                CurrentPosition = new Position(1, 1),
                CurrentDirection = Direction.N
            };

            robot.Move();

            // Assert
            Assert.Equal(2, robot.CurrentPosition.Row);
            Assert.Equal(1, robot.CurrentPosition.Col);
        }

        [Fact]

        public void MoveRobot_South_SubtractsRow()
        {
            var robot = new Robot
            {
                CurrentPosition = new Position(1, 3),
                CurrentDirection = Direction.S
            };

            robot.Move();

            // Assert
            Assert.Equal(2, robot.CurrentPosition.Row);
            Assert.Equal(1, robot.CurrentPosition.Col);
        }

        [Fact]

        public void MoveRobot_East_AddsColumn()
        {
            var robot = new Robot
            {
                CurrentPosition = new Position(0, 3),
                CurrentDirection = Direction.E
            };

            robot.Move();
            robot.Move();

            // Assert
            Assert.Equal(3, robot.CurrentPosition.Row);
            Assert.Equal(2, robot.CurrentPosition.Col);
        }

        [Fact]
        public void TurnRobot_Right_FromNorth_UpdatesDirection()
        {
            var robot = new Robot
            {
                CurrentDirection = Direction.N
            };

            robot.Turn(Command.R);

            Assert.Equal(Direction.E, robot.CurrentDirection);
        }

        [Fact]
        public void TurnRobot_Left_FromNorth_UpdatesDirection()
        {
            var robot = new Robot
            {
                CurrentDirection = Direction.N
            };

            robot.Turn(Command.L);

            Assert.Equal(Direction.W, robot.CurrentDirection);
        }

        [Fact]
        public void StartJourney_OutOfBounds_ReturnsTrue()
        {
            var grid = new char[3, 3];

            var robot = new Robot
            {
                CurrentPosition = new Position(4, 3),
            };

            var result = robot.IsOutOfBounds(grid);

            Assert.True(result);
        }
        
        [Fact]
        public void StartJourney_IsCrashed_ReturnsTrue()
        {
            var grid = new char[3, 3];

            grid[2, 2] = 'O';
            
            var robot = new Robot
            {
                CurrentPosition = new Position(2, 2),
            };

            var result = robot.IsCrashed(grid);

            Assert.True(result);
        }
    }
}
