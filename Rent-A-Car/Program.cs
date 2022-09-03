using Microsoft.Extensions.DependencyInjection;
using Rent_A_Car.Models;
using System.Text.RegularExpressions;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<ICarRepository, CarRepository>()
    .AddSingleton<ICustomerRepository, CustomerRepository>()
    .BuildServiceProvider();
CarMiddleman carRepo = new(serviceProvider.GetService<ICarRepository>());
CustomerMiddleman customerRepo = new(serviceProvider.GetService<ICustomerRepository>());

Menu(carRepo, customerRepo);

void Menu(CarMiddleman carRepo, CustomerMiddleman customerRepo)
{
    List<string> logs = new();
    CarWash carWash = new(0);
    Task.Run(() => carWash.WashCar());
    do
    {
        switch (MenuList())
        {
            case ConsoleKey.D1 or ConsoleKey.NumPad1:
                bool exit = false;
                do
                {
                    Console.Clear();
                    switch (CarSubMenuList())
                    {
                        case ConsoleKey.D1 or ConsoleKey.NumPad1:
                            #region Create car
                            Console.Clear();
                            Console.WriteLine("Number of seats: ");
                            int seats = Validate.TryParseInt();
                            Console.WriteLine("Car color: ");
                            string carColor = Validate.ValidString();
                            Console.WriteLine("Car brand: ");
                            string carBrand = Validate.ValidString();
                            Console.WriteLine("Car model: ");
                            string carModel = Validate.ValidString();
                            Car returnedCar = carRepo.carRepo.NewCar(seats, carColor, carBrand, carModel);
                            Console.Clear();
                            Console.WriteLine($"Car created with: " +
                                $"\nNumberplate: {returnedCar.Numberplate}" +
                                $"\nBrand: {returnedCar.CarBrandName}" +
                                $"\nModel: {returnedCar.CarModel}" +
                                $"\nColor: {returnedCar.CarColor}" +
                                $"\nSeats: {returnedCar.Seats}");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D2 or ConsoleKey.NumPad2:
                            #region Edit car
                            Console.Clear();
                            string numberplate = carRepo.carRepo.CarExist();
                            Console.WriteLine("Seats: ");
                            seats = Validate.TryParseInt();
                            Console.WriteLine("Color: ");
                            carColor = Validate.ValidString();
                            Console.WriteLine("Carbrand: ");
                            carBrand = Validate.ValidString();
                            Console.WriteLine("Carmodel: ");
                            carModel = Validate.ValidString();
                            returnedCar = carRepo.carRepo.EditCar(numberplate, seats, carColor, carBrand, carModel);
                            Console.Clear();
                            Console.WriteLine($"Car updated with: " +
                                $"\nNumberplate: {returnedCar.Numberplate}" +
                                $"\nBrand: {returnedCar.CarBrandName}" +
                                $"\nModel: {returnedCar.CarModel}" +
                                $"\nColor: {returnedCar.CarColor}" +
                                $"\nSeats: {returnedCar.Seats}");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D3 or ConsoleKey.NumPad3:
                            Console.Clear();
                            carRepo.carRepo.GetAllCars()
                                .ForEach(item => Console.WriteLine(
                                    $"{item.CarBrandName}\n" +
                                    $"{item.CarModel}\n" +
                                    $"{item.Numberplate}\n" +
                                    $"{item.CarColor}\n" +
                                    $"{item.Seats}"));
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D4 or ConsoleKey.NumPad4:
                            #region Wash car
                            Console.Clear();
                            carWash.AddCars(carRepo.carRepo.GetCar(carRepo.carRepo.CarExist()));
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D5 or ConsoleKey.NumPad5:
                            #region Delete car
                            Console.Clear();
                            Console.WriteLine("Car numberplate: ");
                            numberplate = Validate.ValidString();
                            bool isDeleted = carRepo.carRepo.DeleteCar(numberplate);
                            Console.Clear();
                            Console.WriteLine(isDeleted ? "Car was deleted" : "Car doesnt exist");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            exit = true;
                            break;
                    }
                } while (!exit);
                break;
            case ConsoleKey.D2 or ConsoleKey.NumPad2:
                exit = false;
                do
                {
                    Console.Clear();
                    switch (CustomerSubMenuList())
                    {
                        case ConsoleKey.D1 or ConsoleKey.NumPad1:
                            #region Create customer
                            Console.Clear();
                            Console.WriteLine("Name: ");
                            string customerName = Validate.ValidString();
                            Console.WriteLine("Phone: ");
                            string customerPhone = Validate.ValidString();
                            Customer returnedCustomer = customerRepo.customerRepo.NewCustomer(customerName, customerPhone);
                            Console.WriteLine($"Customer created with: " +
                                $"\nId: {returnedCustomer.CustomerId}" +
                                $"\nName: {returnedCustomer.CustomerName}" +
                                $"\nPhone: {returnedCustomer.CustomerPhone}");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D2 or ConsoleKey.NumPad2:
                            #region Update customer
                            Console.Clear();
                            int customerId = customerRepo.customerRepo.CustomerExist();
                            Console.WriteLine("Name: ");
                            customerName = Validate.ValidString();
                            Console.WriteLine("Phone: ");
                            customerPhone = Validate.ValidString();
                            returnedCustomer = customerRepo.customerRepo.EditCustomer(customerId, customerName, customerPhone);
                            Console.WriteLine(returnedCustomer != null ?
                                $"Customer updated with: " +
                                $"\nId: {returnedCustomer.CustomerId}" +
                                $"\nName: {returnedCustomer.CustomerName}" +
                                $"\nPhone: {returnedCustomer.CustomerPhone}" :
                                "Customer doesnt exist");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D3 or ConsoleKey.NumPad3:
                            #region Delete customer
                            Console.Clear();
                            Console.WriteLine("Customer id");
                            customerId = Validate.TryParseInt();
                            bool isDeleted = customerRepo.customerRepo.DeleteCustomer(customerId);
                            Console.WriteLine(isDeleted ? "Customer was deleted" : "Customer doesnt exist");
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D4 or ConsoleKey.NumPad4:
                            #region Rent car
                            Console.Clear();
                            string numberplate = carRepo.carRepo.CarExist();
                            customerId = customerRepo.customerRepo.CustomerExist();
                            Console.WriteLine("Rent from: (dd-mm-yyyy)");
                            DateTime rentFrom = Validate.TryParseDateTime();
                            while (rentFrom < DateTime.Now)
                            {
                                Console.Clear();
                                Console.WriteLine("Cannot rent backwards \nTry again: ");
                                rentFrom = Validate.TryParseDateTime();
                            }
                            Console.WriteLine("Rent to: (dd-mm-yyyy)");
                            DateTime rentTo = Validate.TryParseDateTime();
                            while (rentTo < rentFrom)
                            {
                                Console.Clear();
                                Console.WriteLine("Cannot rent backwards \nTry again: ");
                                rentTo = Validate.TryParseDateTime();
                            }
                            string feedback = carRepo.carRepo.RentCar(numberplate, customerId, rentFrom, rentTo);
                            while (feedback == String.Empty)
                            {
                                Console.WriteLine("Rent from: (dd-mm-yyyy)");
                                rentFrom = Validate.TryParseDateTime();
                                while (rentFrom < DateTime.Now)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Cannot rent backwards \nTry again: ");
                                    rentFrom = Validate.TryParseDateTime();
                                }
                                Console.WriteLine("Rent to: (dd-mm-yyyy)");
                                rentTo = Validate.TryParseDateTime();
                                while (rentTo < rentFrom)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Cannot rent backwards \nTry again: ");
                                    rentTo = Validate.TryParseDateTime();
                                }
                                feedback = carRepo.carRepo.RentCar(numberplate, customerId, rentFrom, rentTo);
                            }
                            Console.WriteLine(feedback);
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D5 or ConsoleKey.D5:
                            #region Return car
                            Console.Clear();
                            Console.WriteLine("Numberplate: ");
                            numberplate = Validate.ValidString();
                            Console.WriteLine("Customer id: ");
                            customerId = Validate.TryParseInt();
                            Console.WriteLine("Distance driven: ");
                            int distance = Validate.TryParseInt();
                            Car returnedCar = carRepo.carRepo.ReturnCar(numberplate, customerId, distance);
                            Console.WriteLine($"{returnedCar.CarBrandName} {returnedCar.CarModel} " +
                                $"was returned" +
                                $"\n {distance} km was added. Total distance {returnedCar.Distance}");
                            Console.ReadKey(true);

                            #endregion
                            break;
                        case ConsoleKey.D6 or ConsoleKey.NumPad6:
                            Console.Clear();
                            carRepo.carRepo.GetAllCars()
                                .ForEach(item => Console.WriteLine(
                                    $"{item.CarBrandName}\n" +
                                    $"{item.CarModel}\n" +
                                    $"{item.Numberplate}\n" +
                                    $"{item.CarColor}\n" +
                                    $"{item.Seats}"));
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D7 or ConsoleKey.NumPad7:
                            Console.Clear();
                            Console.WriteLine("Customer id");
                            carRepo.carRepo.GetCustomerReservations(Validate.TryParseInt()).
                                ForEach(res => Console.WriteLine(res));
                            Console.ReadKey(true);
                            break;
                    }
                } while (!exit);
                break;
            case ConsoleKey.D3 or ConsoleKey.NumPad3:
                Environment.Exit(0);
                break;
        }

    } while (true);
}

ConsoleKey MenuList()
{
    List<string> list = new()
    {
        "1. Car options",
        "2. Customer options",
        "Esc. Exit"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

ConsoleKey CarSubMenuList()
{
    List<string> list = new()
    {
        "1. New car",
        "2. Edit car",
        "3. Show all cars",
        "4. Wash car",
        "5. Delete car",
        "Esc. Exit"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

ConsoleKey CustomerSubMenuList()
{
    List<string> list = new()
    {
        "1. New customer",
        "2. Edit customer",
        "3. Delete customer",
        "4. Rent car",
        "5. Return car",
        "6. Show all cars",
        "7. Show rented cars",
        "Esc. Exit"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

