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
    do
    {
        if (carRepo.carRepo.Logs.Count > 0)
        {
            for (int i = 0; i < carRepo.carRepo.Logs.Count; i++)
            {
                Console.SetCursorPosition(60, i);
                Console.WriteLine(carRepo.carRepo.Logs[i]);
            }
        }
        Console.SetCursorPosition(0, 0);

        switch (MenuList())
        {
            case ConsoleKey.D1 or ConsoleKey.NumPad1:
                bool exit = false;
                do
                {
                    Console.Clear();
                    if (carRepo.carRepo.Logs.Count > 0)
                    {
                        for (int i = 0; i < carRepo.carRepo.Logs.Count; i++)
                        {
                            Console.SetCursorPosition(60, i);
                            Console.WriteLine(carRepo.carRepo.Logs[i]);
                        }
                    }
                    Console.SetCursorPosition(0, 0);

                    switch (CarSubMenuList())
                    {
                        case ConsoleKey.D1 or ConsoleKey.NumPad1:
                            #region Create car
                            Console.Clear();
                            Console.WriteLine("Car model: ");
                            string carModel = Validate.ValidString();
                            Console.WriteLine("Car brand: ");
                            string carBrand = Validate.ValidString();
                            Console.WriteLine("Car color: ");
                            string carColor = Validate.ValidString();
                            Console.WriteLine("Horsepower: ");
                            int horsepower = Validate.TryParseInt();
                            Console.WriteLine("Number of seats: ");
                            int seats = Validate.TryParseInt();
                            Car returnedCar = carRepo.carRepo.NewCar(seats, carColor, carBrand, carModel, horsepower);
                            Console.Clear();
                            Console.WriteLine($"Car created with: " +
                                $"\nNumberplate: {returnedCar.Numberplate}" +
                                $"\nBrand: {returnedCar.CarBrandName}" +
                                $"\nModel: {returnedCar.CarModel}" +
                                $"\nColor: {returnedCar.CarColor}" +
                                $"\nSeats: {returnedCar.Seats}" +
                                $"\nHorsepower: {returnedCar.Horsepower}");
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
                            #region Get all cars
                            Console.Clear();
                            carRepo.carRepo.GetAllCars()
                                .ForEach(item => Console.WriteLine(
                                    $"Car: {item.CarBrandName} {item.CarModel} " +
                                    $"\nNumberplate: {item.Numberplate} " +
                                    $"\nColor: {item.CarColor} " +
                                    $"\nSeats: {item.Seats} " +
                                    $"\nHorsepower: {item.Horsepower}"));
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D4 or ConsoleKey.NumPad4:
                            #region Wash car
                            Console.Clear();
                            Console.WriteLine("Numberplate: ");
                            numberplate = Validate.ValidString();
                            carRepo.carRepo.WashCar(numberplate);
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
                    if (carRepo.carRepo.Logs.Count > 0)
                    {
                        for (int i = 0; i < carRepo.carRepo.Logs.Count; i++)
                        {
                            Console.SetCursorPosition(60, i);
                            Console.WriteLine(carRepo.carRepo.Logs[i]);
                        }
                    }
                    Console.SetCursorPosition(0, 0);
                    switch (CustomerSubMenuList())
                    {
                        case ConsoleKey.D1 or ConsoleKey.NumPad1:
                            #region Create customer
                            Console.Clear();
                            Console.WriteLine("Name: ");
                            string customerName = Validate.ValidString();
                            Console.WriteLine("Phone: ");
                            string customerPhone = Validate.ValidString();
                            Console.WriteLine("Age: ");
                            int customerAge = Validate.TryParseInt();
                            if (customerAge >= 18)
                            {
                                Customer newCustomer = customerRepo.customerRepo.NewCustomer(customerName, customerPhone, customerAge);
                                Console.WriteLine($"Customer created with: " +
                                    $"\nId: {newCustomer.CustomerId}" +
                                    $"\nName: {newCustomer.CustomerName}" +
                                    $"\nPhone: {newCustomer.CustomerPhone}");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.WriteLine("You must be 18 or older");
                                Console.ReadKey(true);
                            }
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
                            Customer returnedCustomer = customerRepo.customerRepo.EditCustomer(customerId, customerName, customerPhone);
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
                            carRepo.carRepo.GetAllCars().ForEach(car => 
                            Console.WriteLine($"Car: {car.CarBrandName} {car.CarModel} " +
                                                $"\nNumberplate: {car.Numberplate} " +
                                                $"\nColor: {car.CarColor} " +
                                                $"\nSeats: {car.Seats} " +
                                                $"\nHorsepower: {car.Horsepower}"));
                            
                            string numberplate = carRepo.carRepo.CarExist();
                            Customer customer = customerRepo.customerRepo.GetCustomer(customerRepo.customerRepo.CustomerExist());
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
                            string feedback = carRepo.carRepo.RentCar(numberplate, customer, rentFrom, rentTo);
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
                                feedback = carRepo.carRepo.RentCar(numberplate, customer, rentFrom, rentTo);
                            }
                            Console.WriteLine(feedback);
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D5 or ConsoleKey.NumPad5:
                            #region Collect car
                            Console.WriteLine("Numberplate: ");
                            numberplate = Validate.ValidString();
                            Console.WriteLine("Customer id: ");
                            customerId = Validate.TryParseInt();
                            bool collected = carRepo.carRepo.CollectCar(numberplate, customerId);
                            Console.WriteLine(collected ? "Car was collected" : "Car needs to be rented");
                            #endregion
                            break;
                        case ConsoleKey.D6 or ConsoleKey.D6:
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
                        case ConsoleKey.D7 or ConsoleKey.NumPad7:
                            #region Get all cars
                            Console.Clear();
                            carRepo.carRepo.GetAllCars()
                                .ForEach(item => Console.WriteLine(
                                    $"Car: {item.CarBrandName} {item.CarModel} " +
                                    $"\nNumberplate: {item.Numberplate} " +
                                    $"\nColor: {item.CarColor} " +
                                    $"\nSeats: {item.Seats} " +
                                    $"\nHorsepower: {item.Horsepower}"));
                            Console.ReadKey(true);
                            #endregion
                            break;
                        case ConsoleKey.D8 or ConsoleKey.NumPad8:
                            #region Get reservations for customer
                            Console.Clear();
                            Console.WriteLine("Customer id");
                            carRepo.carRepo.GetCustomerReservations(Validate.TryParseInt()).
                                ForEach(res => Console.WriteLine(res));
                            Console.ReadKey(true);
                            #endregion
                            break;
                    }
                } while (!exit);
                break;
            case ConsoleKey.Escape:
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
        "5. Collect car",
        "6. Return car",
        "7. Show all cars",
        "8. Show rented cars",
        "Esc. Exit"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

