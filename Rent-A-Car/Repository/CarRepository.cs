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

        public string CarExist()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Numberplate: ");
                    return GetCar(Validate.ValidString()).Numberplate;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Car doesnt exist try again");
                }
            }
        }

        public string RentCar(string numberplate, int customerId, DateTime rentFrom, DateTime rentTo)
        {
            Car? car = GetCar(numberplate);
            Reservation reservation = new(customerId, rentFrom, rentTo);
            car.Reservations.Add(reservation);
            return $"Car rented: " +
                $"\nCar: {car.CarBrandName} {car.CarModel} " +
                $"\nRent from: {rentFrom}" +
                $"\nRent to: {rentTo}";
        }

        public string NumberplateGenerator()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            Random random = new Random();
            string plate = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                plate += letters[random.Next(0, letters.Length)];
            }
            for (int i = 0; i < 5; i++)
            {
                plate += numbers[random.Next(0, numbers.Length)];
            }
            return plate.ToUpper();
        }

        public string NewCar(int seats, string color, string brand, string model)
        {
            string numberplate = string.Empty;
            do
            {
                numberplate = NumberplateGenerator();
            } while (_cars.Contains(GetCar(numberplate)));
            Car car = new(numberplate, seats, color, brand, model);
            _cars.Add(new(numberplate, seats, color, brand, model));
            return $"Car created with: " +
                $"\nNumberplate: {car.Numberplate}" +
                $"\nBrand: {car.CarBrandName}" +
                $"\nModel: {car.CarModel}" +
                $"\nColor: {car.CarColor}" +
                $"\nSeats: {car.Seats}";
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
                $"\nNumberplate: {car.Numberplate} " +
                $"\nBrand: {car.CarBrandName} " +
                $"\nModel: {car.CarModel} " +
                $"\nColor: {car.CarColor} " +
                $"\nSeats: {car.Seats}" :
                "The car doesnt exist";
        }
        public List<Reservation> GetReservations(Car car) => car.Reservations;

    }
}
