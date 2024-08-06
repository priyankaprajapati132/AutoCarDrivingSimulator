namespace AutoDrivingSimuator.ADSLibraries
{
    public interface IField
    {
        void AddCar(ICar car);
        void RunSimulation();
        IEnumerable<ICar> GetCars();
    }
}
