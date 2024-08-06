using AutoDrivingSimuator.ADSLibraries;
using AutoDrivingSimuator;
using System.Linq;
using Xunit;


namespace AutoDrivingSimuator.UT
{
    public class FieldTests
    {
        [Fact]
        public void Field_AddCar_Correctly()
        {
            var field = new Field(10, 10);
            var car = new Car("A", 1, 2, CardinalDirection.N, "FFRFF");
            field.AddCar(car);
            var cars = field.GetCars().ToList();
            Assert.Single(cars);
            Assert.Equal("A", cars[0].Name);
            Assert.Equal(1, cars[0].X);
            Assert.Equal(2, cars[0].Y);
            Assert.Equal(CardinalDirection.N, cars[0].Direction);
        }

        [Fact]
        public void Field_DetectsCollision()
        {
            var field = new Field(10, 10);
            var carA = new Car("A", 0, 0, CardinalDirection.N, "FFFF");
            var carB = new Car("B", 0, 3, CardinalDirection.S, "F");
            field.AddCar(carA);
            field.AddCar(carB);
            field.RunSimulation();
            // If collision happens, we will not reach the end of the simulation
            var cars = field.GetCars().ToList();
            Assert.Equal(0, carA.X);
            Assert.Equal(4, carA.Y); // As simulation would have stopped
        }
    }
}