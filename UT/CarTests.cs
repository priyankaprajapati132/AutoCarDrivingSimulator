using AutoDrivingSimuator.ADSLibraries;
using AutoDrivingSimuator;
using Xunit;
namespace AutoDrivingSimuator.UT
{
    public class CarTests
    {
        [Fact]
        public void Car_TurnLeft_FromNorth_ToWest()
        {
            var car = new Car("TestCar", 0, 0, CardinalDirection.N, "");
            car.ExecuteNextCommand(10, 10); // Assume 'L' command is at index 0
            Assert.Equal(CardinalDirection.W, car.Direction);
        }

        [Fact]
        public void Car_TurnRight_FromNorth_ToEast()
        {
            var car = new Car("TestCar", 0, 0, CardinalDirection.N, "");
            car.ExecuteNextCommand(10, 10); // Assume 'R' command is at index 0
            Assert.Equal(CardinalDirection.E, car.Direction);
        }

        [Fact]
        public void Car_MoveForward_FromNorth()
        {
            var car = new Car("TestCar", 0, 0, CardinalDirection.N, "");
            car.ExecuteNextCommand(10, 10); // Assume 'F' command is at index 0
            Assert.Equal(0, car.X);
            Assert.Equal(1, car.Y);
        }

        [Fact]
        public void Car_MoveForward_FromEast()
        {
            var car = new Car("TestCar", 0, 0, CardinalDirection.E, "");
            car.ExecuteNextCommand(10, 10); // Assume 'F' command is at index 0
            Assert.Equal(1, car.X);
            Assert.Equal(0, car.Y);
        }

        [Fact]
        public void Car_IgnoresCommand_IfOutOfBounds()
        {
            var car = new Car("TestCar", 0, 0, CardinalDirection.S, "F");
            car.ExecuteNextCommand(10, 10);
            Assert.Equal(0, car.X);
            Assert.Equal(0, car.Y);
        }

        [Fact]
        public void Car_ExecutesCommands_Correctly()
        {
            var car = new Car("TestCar", 1, 2, CardinalDirection.N, "LMLMLMLMM");
            while (car.HasCommandsLeft())
            {
                car.ExecuteNextCommand(5, 5);
            }
            Assert.Equal(1, car.X);
            Assert.Equal(3, car.Y);
            Assert.Equal(CardinalDirection.N, car.Direction);
        }
    }
}