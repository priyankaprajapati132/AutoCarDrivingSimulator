using AutoDrivingSimuator.ADSLibraries;

namespace AutoDrivingSimuator
{
    public class Car : ICar
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public CardinalDirection Direction { get; private set; }
        private readonly string commands;
        private int currentCommandIndex;

        public Car(string name, int x, int y, CardinalDirection direction, string commands)
        {
            Name = name;
            X = x;
            Y = y;
            Direction = direction;
            this.commands = commands;
            currentCommandIndex = 0;
        }

        private void TurnLeft() => Direction = (CardinalDirection)(((int)Direction + 3) % 4);
        private void TurnRight() => Direction = (CardinalDirection)(((int)Direction + 1) % 4);

        private void MoveForward(int width, int height)
        {
            switch (Direction)
            {
                case CardinalDirection.N:
                    if (Y < height - 1) Y++;
                    break;
                case CardinalDirection.E:
                    if (X < width - 1) X++;
                    break;
                case CardinalDirection.S:
                    if (Y > 0) Y--;
                    break;
                case CardinalDirection.W:
                    if (X > 0) X--;
                    break;
            }
        }

        public void ExecuteNextCommand(int width, int height)
        {
            if (currentCommandIndex >= commands.Length) return;

            char command = commands[currentCommandIndex++];
            switch (command)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'F':
                    MoveForward(width, height);
                    break;
            }
        }

        public bool HasCommandsLeft() => currentCommandIndex < commands.Length;
    }

}
