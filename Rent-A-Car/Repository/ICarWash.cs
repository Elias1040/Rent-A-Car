

namespace Rent_A_Car.Repository
{
    public interface ICarWash
    {
        int CarwashNumber { get; set; }

        Task<string> StartWash(Car car);
        string WashCar(Car car);
    }
}
