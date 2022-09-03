using Rent_A_Car.Models;

namespace Rent_A_Car.Repository
{
    public interface ICarRepository
    {
        Car GetCar(string numberplate);
        string CarExist();
        Car NewCar(int seats, string color, string brand, string model);
        bool DeleteCar(string numberplate);
        Car EditCar(string numberplate, int seats, string color, string brand, string model);
        string RentCar(string numberplate, int customerId, DateTime rentFrom, DateTime rentTo);
        List<Reservation> GetReservations(Car car);
        List<Car> GetCustomerReservations(int customerID);
        List<Car> GetAllCars();
        Car ReturnCar(string numberplate, int customerId, int distance);
    }
}
