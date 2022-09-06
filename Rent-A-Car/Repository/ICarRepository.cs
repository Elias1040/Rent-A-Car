
namespace Rent_A_Car.Repository
{
    public interface ICarRepository
    {
        CarWash CarWash { get; set; }
        List<string> Logs { get; set; }

        Car GetCar(string numberplate);
        string CarExist();
        CarOut NewCar(int seats, string color, string brand, string model, int horsePower, double price);
        bool DeleteCar(string numberplate);
        CarOut EditCar(string numberplate, int seats, string color, string brand, string model, int horsepower, double price);
        string RentCar(string numberplate, Customer customer, DateTime rentFrom, DateTime rentTo);
        List<ReservationOut> GetReservations(Car car);
        List<ReservationOut> GetCustomerReservations(int customerID);
        List<CarOut> GetAllCars();
        CarOut ReturnCar(string numberplate, int customerId, int distance, int dirt);
        void AddDistance(Car car, int distance);
        Task WashCar(string numberplate);
        void Receipt(Car car, DateTime rentFrom, DateTime rentTo, double chargeCarwash = 0, double chargeExceed = 0);
        bool CollectCar(string numberplate, int customerId);
        public double Sales();
    }
}
