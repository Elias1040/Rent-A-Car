
namespace Rent_A_Car.Repository
{
    public interface ICarRepository
    {
        Car GetCar(string numberplate);
        void NewCar(Car car);
        void DeleteCar(Car car);
        void EditCar(Car car, string numberplate);
        void RentCar(int customerId, DateTime rentFrom, DateTime rentTo);
        List<Reservation> GetReservations(Car car);
    }
}
