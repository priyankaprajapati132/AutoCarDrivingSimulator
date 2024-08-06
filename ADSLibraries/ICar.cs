namespace AutoDrivingSimuator.ADSLibraries
{
    public interface ICar
    {
        string Name { get; }
        int X { get; }
        int Y { get; }
        CardinalDirection Direction { get; }
        void ExecuteNextCommand(int width, int height);
        bool HasCommandsLeft();
    }

}
