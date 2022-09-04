using Rent_A_Car.Models;

namespace Rent_A_Car.BLL
{
    public class CarWash : ICarWash
    {
        public int CarwashNumber { get; set; }

        public CarWash(int carwashNumber)
        {
            CarwashNumber = carwashNumber;
        }

        public async Task<string> StartWash(Car car)
        {
            string feedback = $"{await Task.Run(() => WashCar(car))} - {DateTime.Now.ToString("HH:mm:ss - MM/dd/yyyy")}";
            return feedback;
        }
        public string WashCar(Car car)
        {
            Console.WriteLine("Washing...");
            Task.Delay(40000).Wait();
            return $"{car.Numberplate} has been washed";
        }
    }
}
