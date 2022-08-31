using Microsoft.Extensions.DependencyInjection;

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
            // Create customer
            case ConsoleKey.D1 or ConsoleKey.NumPad1:
                #region Create car
                Console.WriteLine("Numberplate: ");
                string numberplate = Validate.ValidString();
                Console.WriteLine("Number of seats: ");
                int seats = Validate.TryParseInt();
                Console.WriteLine("Car color: ");
                string carColor = Validate.ValidString();
                Console.WriteLine("Car brand: ");
                string carBrand = Validate.ValidString();
                Console.WriteLine("Car model: ");
                string carModel = Validate.ValidString();
                string feedback = carRepo.carRepo.NewCar(numberplate, seats, carColor, carBrand, carModel);
                Console.WriteLine(feedback);
                #endregion
                break;
            // Rent car
            case ConsoleKey.D2 or ConsoleKey.NumPad2:
                #region Rent car
                //Console.WriteLine("Customer id");
                //int customerId = customerRepo.customerRepo.GetCustomer(Validate.TryParseInt()).CustomerId;
                numberplate = String.Empty;
                bool exist;
                int customerId = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Customer id: ");
                        customerId = customerRepo.customerRepo.GetCustomer(Validate.TryParseInt()).CustomerId;
                        exist = true;
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Customer doesnt exist \nTry again");
                        exist = false;
                    }
                    try
                    {
                        Console.WriteLine("Numberplate");
                        numberplate = Validate.ValidString();
                        exist = true;
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Car doesnt exist \nTry again");
                        exist = false;
                    }
                } while (!exist);
                Console.WriteLine("Rent from: (dd-mm-yyyy)");
                DateTime rentFrom = Validate.TryParseDateTime();
                while (rentFrom < DateTime.Now)
                {
                    Console.WriteLine("Cannot rent backwards \nTry again: ");
                    rentFrom = Validate.TryParseDateTime();
                }
                Console.WriteLine("Rent to: (dd-mm-yyyy)");
                DateTime rentTo = Validate.TryParseDateTime();
                while (rentTo < rentFrom)
                {
                    Console.WriteLine("Cannot rent backwards \nTry again: ");
                    rentTo = Validate.TryParseDateTime();
                }

                carRepo.carRepo.RentCar(numberplate, customerId, rentFrom, rentTo);
                #endregion
                break;
            // Update car
            case ConsoleKey.D3 or ConsoleKey.NumPad3:
                #region Update car
                Console.WriteLine("Numberplate: ");
                numberplate = Validate.ValidString();
                Console.WriteLine("Seats: ");
                seats = Validate.TryParseInt();
                Console.WriteLine("Color: ");
                carColor = Validate.ValidString();
                Console.WriteLine("Carbrand: ");
                carBrand = Validate.ValidString();
                Console.WriteLine("Carmodel: ");
                carModel = Validate.ValidString();
                feedback = carRepo.carRepo.EditCar(numberplate, seats, carColor, carBrand, carModel);
                Console.WriteLine(feedback);
                #endregion
                break;
            // Wash car
            case ConsoleKey.D4 or ConsoleKey.NumPad4:
                #region Wash car
                Console.WriteLine("numberplate: ");
                carWash.AddCars(carRepo.carRepo.GetCar(Validate.ValidString()));
                #endregion
                break;
            // Delete car
            case ConsoleKey.D5 or ConsoleKey.NumPad5:
                #region Delete car
                Console.WriteLine("Car numberplate: ");
                numberplate = Validate.ValidString();
                bool isDeleted = carRepo.carRepo.DeleteCar(numberplate);
                Console.WriteLine(isDeleted ? "Car was deleted" : "Car doesnt exist");
                #endregion
                break;
            // Create customer
            case ConsoleKey.D6 or ConsoleKey.NumPad6:
                #region Create customer
                Console.WriteLine("Name: ");
                string customerName = Validate.ValidString();
                Console.WriteLine("Phone: ");
                string customerPhone = Validate.ValidString();
                feedback = customerRepo.customerRepo.NewCustomer(customerName, customerPhone);
                Console.WriteLine(feedback);
                #endregion
                break;
            // Update customer
            case ConsoleKey.D7 or ConsoleKey.NumPad7:
                #region Update customer
                Console.WriteLine("Customer id: ");
                customerId = Validate.TryParseInt();
                Console.WriteLine("Name: ");
                customerName = Validate.ValidString();
                Console.WriteLine("Phone: ");
                customerPhone = Validate.ValidString();
                feedback = customerRepo.customerRepo.EditCustomer(customerId, customerName, customerPhone);
                Console.WriteLine(feedback);
                #endregion
                break;
            // Delete customer
            case ConsoleKey.D8 or ConsoleKey.NumPad8:
                #region Delete customer
                Console.WriteLine("Customer id");
                customerId = Validate.TryParseInt();
                isDeleted = customerRepo.customerRepo.DeleteCustomer(customerId);
                Console.WriteLine(isDeleted ? "Customer was deleted" : "Customer doesnt exist");
                #endregion
                break;
            default:
                break;
        }
    } while (true);
}

ConsoleKey MenuList()
{
    List<string> list = new()
    {
        "1. New car",
        "2. Rent car",
        "3. Edit car",
        "4. Wash car",
        "5. Delete car",
        "6. New customer",
        "7. Edit customer",
        "8. Delete customer"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

