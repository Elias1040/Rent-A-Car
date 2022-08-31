using Rent_A_Car.Models;

namespace Rent_A_Car.BLL
{
    public class CarWash : ICarWash
    {
        public int CarwashNumber { get; set; }
        Queue<Car> CarsQueue { get; set; }

        public CarWash(int carwashNumber)
        {
            CarwashNumber = carwashNumber;
            CarsQueue = new();
        }

        public void AddCars(Car car)
        {
            CarsQueue.Enqueue(car);
        }
        public void WashCar()
        {
            while (true)
            {
                while (CarsQueue.Count > 0)
                {
                    Task.Delay(20000).Wait();
                    Car car = CarsQueue.Dequeue();
                    Console.WriteLine($"{car.Numberplate} has been washed");
                }
            }
        }
    }
}
