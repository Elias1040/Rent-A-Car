using Rent_A_Car.Models;

namespace Rent_A_Car.Repository
{
    public interface ICarRepository
    {
        Car GetCar(string numberplate);
        string CarExist();
        string NewCar(int seats, string color, string brand, string model);
        bool DeleteCar(string numberplate);
        string EditCar(string numberplate, int seats, string color, string brand, string model);
        string RentCar(string numberplate, int customerId, DateTime rentFrom, DateTime rentTo);
        List<Reservation> GetReservations(Car car);
    }
}
