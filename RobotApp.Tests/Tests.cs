using Xunit;
using RobotApp.Library;

namespace RobotApp.Tests
{
    public class RobotTests
    {
        [Fact]
        public void MoveRobot_North_IncrementsRow()
        {
            var robot = new Robot();
            robot.CurrentPosition = new Position(1, 1);
            robot.CurrentDirection = Direction.N;

            robot.Move();

            // Assert
            Assert.Equal(2, robot.CurrentPosition.Row);
            Assert.Equal(1, robot.CurrentPosition.Col);
        }

        [Fact]
        public void TurnRobot_Right_FromNorth_UpdatesDirection()
        {
            var robot = new Robot();
            robot.CurrentDirection = Direction.N;

            robot.Turn('R');

            Assert.Equal(Direction.E, robot.CurrentDirection);
        }

        [Fact]
        public void StartJourney_OutOfBounds_ReturnsOutOfBounds()
        {
            // Arrange
            var grid = new char[3,3];
            var robot = new Robot();

            // Act
            robot.Start(grid);

            // Assert
            //Assert.Contains("OUT OF BOUNDS", result);
        }
    }
}
