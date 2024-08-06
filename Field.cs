using AutoDrivingSimuator.ADSLibraries;

namespace AutoDrivingSimuator
{
    public class Field : IField
    {
        private readonly int width;
        private readonly int height;
        private readonly List<ICar> cars;

        public Field(int width, int height)
        {
            this.width = width;
            this.height = height;
            cars = new List<ICar>();
        }

        public void AddCar(ICar car)
        {
            cars.Add(car);
        }

        public void RunSimulation()
        {
            bool commandsLeft;
            do
            {
                commandsLeft = false;
                foreach (var car in cars)
                {
                    if (car.HasCommandsLeft())
                    {
                        car.ExecuteNextCommand(width, height);
                        commandsLeft = true;
                    }
                }

                // Check for collisions
                for (int i = 0; i < cars.Count; i++)
                {
                    for (int j = i + 1; j < cars.Count; j++)
                    {
                        if (cars[i].X == cars[j].X && cars[i].Y == cars[j].Y)
                        {
                            Console.WriteLine($"Collision detected between {cars[i].Name} and {cars[j].Name} at ({cars[i].X}, {cars[i].Y})");
                            return;
                        }
                    }
                }
            } while (commandsLeft);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} is at ({car.X}, {car.Y}) facing {car.Direction}");
            }
        }

        public IEnumerable<ICar> GetCars() => cars;
    }

}
