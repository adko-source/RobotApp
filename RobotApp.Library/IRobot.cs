namespace RobotApp.Library
{
    public interface IRobot
    {
        string EndDirection { get; set; }
        string EndPosition { get; set; }
        string StartDirection { get; set; }
        string StartPosition { get; set; }
    }
}