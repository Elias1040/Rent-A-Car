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
    CarWash carWash = new CarWash(0);
    Task.Run(() => carWash.WashCar());
    do
    {
        switch (MenuList())
        {
            case ConsoleKey.D1 or ConsoleKey.NumPad1:
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
                Car car = new(0, numberplate, seats, carColor, carBrand, carModel);
                carRepo._carRepo.NewCar(car);
                break;
            case ConsoleKey.D2 or ConsoleKey.NumPad2:
                Console.WriteLine("Name: ");
                string customerName = Validate.ValidString();
                Console.WriteLine("Phone: ");
                string customerPhone = Validate.ValidString();
                Customer customer = new(0, customerName, customerPhone);
                customerRepo._customerRepo.NewCustomer(customer);
                break;
            case ConsoleKey.D3 or ConsoleKey.NumPad3:
                Console.WriteLine("Rent from: (dd-mm-yyyy)");
                DateTime rentFrom = Validate.TryParseDateTime();
                Console.WriteLine("Rent to: (dd-mm-yyyy)");
                DateTime rentTo = Validate.TryParseDateTime();
                carRepo._carRepo.RentCar(0, rentFrom, rentTo);
                break;
            case ConsoleKey.D4 or ConsoleKey.NumPad4:
                Console.WriteLine("numberplate: ");
                carWash.AddCars(carRepo._carRepo.GetCar(Validate.ValidString()));

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
        "2. New customer",
        "3. Rent car",
        "4. Wash car"
    };
    list.ForEach(item => Console.WriteLine(item));
    return Console.ReadKey(true).Key;
}

