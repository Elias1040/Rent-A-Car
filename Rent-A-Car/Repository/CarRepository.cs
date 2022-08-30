
namespace Rent_A_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        readonly List<Car> _cars;
        public CarRepository()
        {
            _cars = new List<Car>();
        }

        public Car? GetCar(string numberplate) => _cars.Find(car => car.Numberplate == numberplate);
        public void RentCar(int customerId, DateTime rentFrom, DateTime rentTo) => GetCar("")?.Reservations.Add(new(customerId, rentFrom, rentTo)); 
        public void NewCar(Car car) => _cars.Add(new(car.CarId, car.Numberplate, car.Seats, car.CarColor, car.CarBrandName, car.CarModel));
        public void DeleteCar(Car car) => _cars.Remove(car);
        public void EditCar(Car car, string numberplate)
        {
            Car theCar = GetCar(numberplate);
            theCar.Seats = Validate.TryParseInt();
            theCar.Numberplate = Validate.ValidString();
            theCar.CarColor = Validate.ValidString();
        }
        public List<Reservation> GetReservations(Car car) => car.Reservations;

    }
}
