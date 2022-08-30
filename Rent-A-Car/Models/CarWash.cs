using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class CarWash : ICarWash
    {
        public int CarwashNumber { get; set; }
        Queue<Car> carsQueue { get; set; }

        public CarWash(int carwashNumber)
        {
            CarwashNumber = carwashNumber;
            carsQueue = new();
        }

        public void AddCars(Car car)
        {
            carsQueue.Enqueue(car);
        }
        public void WashCar()
        {
            while (true)
            {
                while (carsQueue.Count > 0)
                {
                    Task.Delay(20000).Wait();
                    Car car = carsQueue.Dequeue();
                    Console.WriteLine($"{car.CarId} has been washed");
                }
            }
        }
    }
}
