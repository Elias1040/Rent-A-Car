
namespace Rent_A_Car.Repository
{
    public class CarRepository : ICarRepository
    {
        readonly List<Car> _cars;
        public CarWash CarWash { get; set; }
        public List<string> Logs { get; set; }
        double overallSales;
        public CarRepository()
        {
            _cars = new List<Car>();
            Logs = new List<string>();
            CarWash = new(0);
            overallSales = 0;
        }

        /// <summary>
        /// Gets car by numberplate from _cars list
        /// </summary>
        /// <param name="numberplate"></param>
        /// <returns>First matching car or null if nothing found</returns>
        public Car GetCar(string numberplate) =>
            _cars.Find(car => car.Numberplate
            .Replace(" ", string.Empty) == numberplate
            .Replace(" ", string.Empty).ToUpper() && !car.Removed);

        /// <summary>
        /// Checks if car exist
        /// </summary>
        /// <returns>numberplate of car</returns>
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
                    Console.Clear();
                    Console.WriteLine("Car doesnt exist try again");
                }
            }
        }

        /// <summary>
        /// Adds reservation to selected cars reservations list
        /// </summary>
        /// <param name="numberplate"></param>
        /// <param name="customer"></param>
        /// <param name="rentFrom"></param>
        /// <param name="rentTo"></param>
        /// <returns>feedback from reservation</returns>
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
            Reservation reservation = new(customer.CustomerId, rentFrom, rentTo, numberplate);
            car.Reservations.Add(reservation);
            Receipt(car, rentFrom, rentTo);
            return $"Car rented: " +
                $"\nCar: {car.CarBrandName} {car.CarModel} " +
                $"\nRent from: {rentFrom:dd-MM-yyyy}" +
                $"\nRent to: {rentTo:dd-MM-yyyy}" +
                $"\nPrice: {car.Price:c}";
        }

        /// <summary>
        /// Creates new file and write the renting details and return details to the file
        /// </summary>
        /// <param name="car"></param>
        /// <param name="rentFrom"></param>
        /// <param name="rentTo"></param>
        /// <param name="chargeCarwash"></param>
        /// <param name="chargeExceed"></param>
        public void Receipt(Car car, DateTime rentFrom, DateTime rentTo, double chargeCarwash = 0, double chargeExceed = 0)
        {
            FileStream file = File.Create($@"C:\Users\elias\Downloads\RentACarReceipts\{car.Numberplate}.txt");
            using (StreamWriter sw = new(file))
            {
                sw.WriteLine($"Brand: {car.CarBrandName}");
                sw.WriteLine($"Model: {car.CarModel}");
                sw.WriteLine($"Numberplate: {car.Numberplate}");
                sw.WriteLine($"Rent from: {rentFrom}");
                sw.WriteLine($"Rent to: {rentTo}");
                sw.WriteLine($"Charge: {car.Price:c}");
                sw.WriteLine($"Carwash charge: {chargeCarwash:c}");
                sw.WriteLine($"Charge exceeded days: {chargeExceed:c}");
                sw.WriteLine($"Total charge: {car.Price + chargeCarwash + chargeExceed}");
            }
        }

        /// <summary>
        /// creates a random numberplate that doesnt already exist
        /// </summary>
        /// <returns>the numberplate created</returns>
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
            } while (_cars.Find(car => car.Numberplate == plate) != null);
            return plate.ToUpper();
        }

        /// <summary>
        /// Adds a new car to _cars list
        /// </summary>
        /// <param name="seats"></param>
        /// <param name="color"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="horsePower"></param>
        /// <param name="price"></param>
        /// <returns>Copy of created car</returns>
        public CarOut NewCar(int seats, string color, string brand, string model, int horsePower, double price)
        {
            string numberplate = NumberplateGenerator();
            Car car = new(numberplate, seats, color, brand, model, horsePower, price);
            _cars.Add(car);
            return new(car);
        }

        /// <summary>
        /// sets the Removed property to true
        /// </summary>
        /// <param name="numberplate"></param>
        /// <returns></returns>
        public bool DeleteCar(string numberplate) => _cars.Find(car => car.Numberplate == numberplate).Removed = true;

        /// <summary>
        /// Updates properties of the selected car
        /// </summary>
        /// <param name="numberplate"></param>
        /// <param name="seats"></param>
        /// <param name="color"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="horsepower"></param>
        /// <param name="price"></param>
        /// <returns>Copy of the updated car</returns>
        public CarOut EditCar(string numberplate, int seats, string color, string brand, string model, int horsepower, double price)
        {
            Car car = GetCar(numberplate);
            car.Seats = seats;
            car.CarColor = color;
            car.CarBrandName = brand;
            car.CarModel = model;
            car.Horsepower = horsepower;
            car.Price = price;

            return new(car);
        }

        /// <summary>
        /// Gets all reservations in car objects reservations list
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>Copy of reservation in lists</returns>
        public List<ReservationOut> GetCustomerReservations(int customerID)
        {
            List<ReservationOut> reservations = new();
            _cars.ForEach(car => car.Reservations.ForEach(res =>
            {
                if (!res.Returned)
                {
                    reservations.Add(new(res));
                }
            }));
            return reservations;
        }

        /// <summary>
        /// Returns the selected rented car
        /// </summary>
        /// <param name="numberplate"></param>
        /// <param name="customerId"></param>
        /// <param name="distance"></param>
        /// <param name="dirt"></param>
        /// <returns>copy of returned car</returns>
        public CarOut ReturnCar(string numberplate, int customerId, int distance, int dirt)
        {
            Car car = GetCar(numberplate);
            Reservation? reservation = car.Reservations.Find(res => res.CustomerId == customerId);
            reservation.Returned = true;
            reservation.Collected = false;
            AddDistance(car, distance);
            double chargeWash = 0;
            double chargeExceed = 0;
            if (car.Distance >= 200000)
            {
                DeleteCar(car.Numberplate);
            }
            else
            {
                if (dirt > 50)
                {
                    chargeWash = 75;
                }
                WashCar(car.Numberplate);
            }
            if (reservation.ReservedTo.Date >= DateTime.Now.Date)
            {
                Console.Clear();
                Console.WriteLine($"You will be charged {car.Price + chargeWash:c} in total");
                Console.ReadKey();
            }
            else
            {
                int daysExceeded = DateTime.Now.Subtract(car.Reservations.Find(res => res.CustomerId == customerId).ReservedTo).Days;
                chargeExceed = daysExceeded * 100;
                Console.Clear();
                Console.WriteLine($"You will be charged an extra {100:c} foreach date exceeded." +
                    $"\nCarwash charge {chargeWash:c}. \nCharged total {car.Price + chargeExceed + chargeWash:c}");
                Console.ReadKey();
            }
            Receipt(car, reservation.ReservedFrom, reservation.ReservedTo, chargeWash, chargeExceed);
            overallSales += car.Price + chargeExceed + chargeWash;
            return new(car);
        }

        /// <summary>
        /// Adds distance to car object
        /// </summary>
        /// <param name="car"></param>
        /// <param name="distance"></param>
        public void AddDistance(Car car, int distance) => car.Distance += distance;

        /// <summary>
        /// Gets all cars
        /// </summary>
        /// <returns>copy of all cars in a list</returns>
        public List<CarOut> GetAllCars()
        {
            List<CarOut> cars = new();
            _cars.ForEach((car) =>
            {
                if (!car.Removed)
                {
                    cars.Add(new(car));
                }
            });
            return cars;
        }

        /// <summary>
        /// Gets alll reservations from given car object
        /// </summary>
        /// <param name="car"></param>
        /// <returns>copy of reservations in list</returns>
        public List<ReservationOut> GetReservations(Car car)
        {
            List<ReservationOut> reserservations = new();
            car.Reservations.ForEach(res =>
            {
                if (!res.Returned)
                {
                    reserservations.Add(new(res));
                }
            });
            return reserservations;
        }

        /// <summary>
        /// starts a Carwash task and adds logs to logg list
        /// </summary>
        /// <param name="numberplate"></param>
        /// <returns>logs</returns>
        public async Task WashCar(string numberplate)
        {
            Logs.Add(await CarWash.StartWash(GetCar(numberplate)));
        }

        /// <summary>
        /// Collects the car
        /// </summary>
        /// <param name="numberplate"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool CollectCar(string numberplate, int customerId)
        {
            Car? car = GetCar(numberplate);
            Reservation? reservation = car.Reservations.Find(res => res.CustomerId == customerId);
            if (DateTime.Now.Date >= reservation?.ReservedFrom.Date && DateTime.Now.Date <= reservation.ReservedTo.Date)
            {
                Console.WriteLine("Washing...");
                CarWash.WashCar(car);
                return car.Reservations.Find(res => res.CustomerId == customerId).Collected = true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get all sales
        /// </summary>
        /// <returns>all sales</returns>
        public double Sales() => overallSales;

    }
}
