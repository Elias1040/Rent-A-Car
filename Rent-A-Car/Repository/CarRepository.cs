using Rent_A_Car.Models;

namespace Rent_A_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        readonly List<Car> _cars;
        public CarRepository()
        {
            _cars = new List<Car>();
        }

        public Car GetCar(string numberplate) =>
            _cars.Find(car => car.Numberplate == numberplate);

        public string RentCar(string numberplate, int customerId, DateTime rentFrom, DateTime rentTo)
        {
            Car? car = GetCar(numberplate);
            car.Reservations.Add(new((int)customerId, rentFrom, rentTo));
            return $"Car rented: \n";
        }

        public string NewCar(string numberplate, int seats, string color, string brand, string model)
        {
            Car car = new(numberplate, seats, color, brand, model);
            _cars.Add(new(numberplate, seats, color, brand, model));
            return $"Car created with: \n{car.Numberplate}\n{car.CarBrandName}\n{car.CarModel}\n{car.CarColor}";
        }

        public bool DeleteCar(string numberplate) => _cars.Remove(_cars.Find(car => car.Numberplate == numberplate));

        public string EditCar(string numberplate, int seats, string color, string brand, string model)
        {
            Car? car = GetCar(numberplate);
            car.Numberplate = numberplate;
            car.Seats = seats;
            car.CarColor = color;
            car.CarBrandName = brand;
            car.CarModel = model;
            return car != null ? $"{car.Numberplate} was updated with: " +
                $"\n{car.Numberplate} " +
                $"\n{car.CarBrandName} " +
                $"\n{car.CarModel} " +
                $"\n{car.CarColor} " +
                $"\n{car.Seats}" :
                "The car doesnt exist";
        }
        public List<Reservation> GetReservations(Car car) => car.Reservations;

    }
}
