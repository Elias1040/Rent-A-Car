using Rent_A_Car.Models;
using System.Security.Cryptography.X509Certificates;

namespace Rent_A_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        readonly List<Car> _cars;
        public CarWash CarWash { get; set; }
        public List<string> Logs { get; set; }
        public CarRepository()
        {
            _cars = new List<Car>();
            Logs = new List<string>();
            CarWash = new(0);
        }

        public Car GetCar(string numberplate) =>
            _cars.Find(car => car.Numberplate
            .Replace(" ", string.Empty) == numberplate
            .Replace(" ", string.Empty).ToUpper());

        public string CarExist()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Numberplate: ");
                    string numberplate = Validate.ValidString();
                    return GetCar(numberplate).Numberplate;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Car doesnt exist try again");
                }
            }
        }

        public string RentCar(string numberplate, Customer customer, DateTime rentFrom, DateTime rentTo)
        {
            Car? car = GetCar(numberplate);
            foreach (Reservation item in car.Reservations)
            {
                if ((rentFrom > item.ReservedFrom || rentFrom < item.ReservedTo) && (rentTo > item.ReservedFrom || rentTo < item.ReservedTo))
                {
                    return string.Empty;
                }
            }
            if (customer.Age <= 21 && car.Horsepower >= 100)
            {
                return "You must be 22 or older to rent cars above 100HP";
            }
            Reservation reservation = new(customer.CustomerId, rentFrom, rentTo);
            car.Reservations.Add(reservation);
            Receipt(car, rentFrom, rentTo);
            return $"Car rented: " +
                $"\nCar: {car.CarBrandName} {car.CarModel} " +
                $"\nRent from: {rentFrom}" +
                $"\nRent to: {rentTo}";
        }

        public void Receipt(Car car, DateTime rentFrom, DateTime rentTo)
        {
            FileStream file = File.Create($@"C:\Users\elias\Downloads\RentACarReceipts\{car.Numberplate}.txt");
            using (StreamWriter sw = new(file))
            {
                sw.WriteLine($"Brand: {car.CarBrandName}");
                sw.WriteLine($"Model: {car.CarModel}");
                sw.WriteLine($"Numberplate: {car.Numberplate}");
                sw.WriteLine($"Rent from: {rentFrom}");
                sw.WriteLine($"Rent to: {rentTo}");
            }
        }

        public string NumberplateGenerator()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            Random random = new();
            string plate;
            do
            {
                plate = string.Empty;
                for (int i = 0; i < 2; i++)
                {
                    plate += letters[random.Next(0, letters.Length)];
                }
                plate += " ";
                for (int i = 0; i < 2; i++)
                {
                    plate += numbers[random.Next(0, numbers.Length)];
                }
                plate += " ";
                for (int i = 0; i < 3; i++)
                {
                    plate += numbers[random.Next(0, numbers.Length)];
                }
            } while (_cars.Contains(GetCar(plate)));
            return plate.ToUpper();
        }

        public Car NewCar(int seats, string color, string brand, string model, int horsePower)
        {
            string numberplate = NumberplateGenerator();
            Car car = new(numberplate, seats, color, brand, model, horsePower);
            _cars.Add(car);
            return car;
        }

        public bool DeleteCar(string numberplate) =>
            _cars.Remove(_cars.Find(car => car.Numberplate == numberplate));

        public Car EditCar(string numberplate, int seats, string color, string brand, string model)
        {
            Car car = GetCar(numberplate);
            car.Seats = seats;
            car.CarColor = color;
            car.CarBrandName = brand;
            car.CarModel = model;
            return car;
        }

        public List<Car> GetCustomerReservations(int customerID)
        {
            List<Car> cars = new();
            foreach (Car car in _cars)
            {
                foreach (Reservation res in car.Reservations)
                {
                    if (customerID == res.CustomerId)
                    {
                        cars.Add(car);
                    }
                }
            }
            return cars;
        }

        public Car ReturnCar(string numberplate, int customerId, int distance)
        {
            Car car = GetCar(numberplate);
            car.Reservations.Remove(car.Reservations.Find(res => res.CustomerId == customerId));
            AddDistance(car, distance);
            if (car.Distance >= 200000)
            {
                DeleteCar(car.Numberplate);
            }
            else
            {
                CarWash.StartWash(car);
            }
            return car;
        }

        public void AddDistance(Car car, int distance) => car.Distance += distance;

        public List<Car> GetAllCars() => _cars;

        public List<Reservation> GetReservations(Car car) => car.Reservations;

        public async Task WashCar(string numberplate)
        {
            Logs.Add(await CarWash.StartWash(GetCar(numberplate)));
        }

        public bool CollectCar(string numberplate, int customerId)
        {
            Car? car = GetCar(numberplate);
            Reservation? reservation = car.Reservations.Find(res => res.CustomerId == customerId);
            if (DateTime.Now >= reservation?.ReservedFrom && DateTime.Now <= reservation.ReservedTo)
            {
                Task.Run(async () => await WashCar(numberplate));
                return car.Reservations.Remove(GetCar(numberplate).Reservations
                    .Find(res => res.CustomerId == customerId));
            }
            else
            {
                return false;
            }
        }

    }
}
