using Microsoft.Extensions.DependencyInjection;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<ICarRepository, CarRepository>()
    .AddSingleton<ICustomerRepository, CustomerRepository>()
    .BuildServiceProvider();

Menu(serviceProvider);

void Menu(ServiceProvider serviceProvider)
{
    CarRepository carRepository = new(serviceProvider.GetService<ICarRepository>());
    CustomerRepository customerRepository = new(serviceProvider.GetService<ICustomerRepository>());
    switch (MenuList())
    {
        case ConsoleKey.D1 or ConsoleKey.NumPad1:
            Console.WriteLine("Numberplate: ");
            string numberplate = ValidString();
            Console.WriteLine("Number of seats: ");
            int seats = TryParseInt();
            Console.WriteLine("Car color: ");
            string carColor = ValidString();
            carRepository.NewCar(new(0, numberplate, seats, carColor, new()));
            break;
        case ConsoleKey.D2 or ConsoleKey.NumPad2:
            Console.WriteLine("Name: ");
            string customerName = ValidString();
            Console.WriteLine("Phone: ");
            string customerPhone = ValidString();
            customerRepository.NewCustomer(new(0, customerName, customerPhone));
            break;
        case ConsoleKey.D3 or ConsoleKey.NumPad3:

            break;
        case ConsoleKey.D4 or ConsoleKey.NumPad4:
            break;
        default:
            break;
    }
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

int TryParseInt()
{
    int value;
    while (!int.TryParse(Console.ReadLine(), out value))
    {
        Console.Clear();
        Console.WriteLine("Input must be a number! \nTry again: ");
    }
    return value;
}

string ValidString()
{
    string? item = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(item))
    {
        Console.WriteLine("Input required! \nTry again: ");
        item = Console.ReadLine();
    }
    return item;
}