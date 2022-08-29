using Rent_A_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        public readonly ICarRepository _carRepository;
        List<Car> _cars;
        public CarRepository(ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _cars = new List<Car>();
        }

        public Car? GetCar(string numberplate) => _cars.Find(car => car.Numberplate == numberplate);
        public void RentCar(DateTime rentFrom, DateTime rentTo) => GetCar("")?.Reservations.Add(new(rentFrom, rentTo)); 
        public void NewCar(Car car) => _cars.Add(new(car.CarId, car.Numberplate, car.Seats, car.CarModel, car.CarBrand));
        public void DeleteCar(Car car) => _cars.Remove(car);
        public void EditCar(Car car, string numberplate)
        {
            Car theCar = GetCar(numberplate);
            theCar = new(car.CarId, car.Numberplate, car.Seats, car.CarColor, new());
        }
        public List<Reservation> GetReservation(Car car) => car.Reservations;
    }
}
