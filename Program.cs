using AutoDrivingSimuator.ADSLibraries;
using AutoDrivingSimuator;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace AutoDrivingSimuator
{
    public class Program
    {
        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IField>(provider => new Field(10, 10))
                .AddTransient<ICar, Car>()
                .BuildServiceProvider();

            var field = serviceProvider.GetService<IField>();

            Console.WriteLine("Welcome to Auto Driving Car Simulation!");
            Console.Write("Please enter the width and height of the simulation field in x y format: ");
            var fieldDimensions = Console.ReadLine().Split();
            int width = int.Parse(fieldDimensions[0]);
            int height = int.Parse(fieldDimensions[1]);

            Console.WriteLine($"You have created a field of {width} x {height}.");

            bool running = true;
            while (running)
            {
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("[1] Add a car to field");
                Console.WriteLine("[2] Run simulation");
                Console.WriteLine("[3] Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Please enter the name of the car: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter the initial position of the car in x y direction format (e.g., 1 2 N): ");
                        var carDetails = Console.ReadLine().Split();
                        int x = int.Parse(carDetails[0]);
                        int y = int.Parse(carDetails[1]);
                        CardinalDirection direction = Enum.Parse<CardinalDirection>(carDetails[2].ToUpper());
                        Console.Write("Please enter the commands for the car: ");
                        string commands = Console.ReadLine();

                        var car = new Car(name, x, y, direction, commands);
                        field.AddCar(car);
                        break;

                    case "2":
                        field.RunSimulation();
                        break;

                    case "3":
                        running = false;
                        break;
                }
            }

            Console.WriteLine("Thank you for running the simulation. Goodbye!");
        }
    }
}