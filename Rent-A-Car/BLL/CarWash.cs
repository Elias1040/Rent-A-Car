
namespace Rent_A_Car.BLL
{
    public class CarWash : ICarWash
    {
        public int CarwashNumber { get; set; }

        public CarWash(int carwashNumber)
        {
            CarwashNumber = carwashNumber;
        }

        /// <summary>
        /// Starts a asynchronus task with WashCar method
        /// </summary>
        /// <param name="car"></param>
        /// <returns>feedback</returns>
        public async Task<string> StartWash(Car car)
        {
            string feedback = await Task.Run(() => WashCar(car));
            return feedback;
        }

        /// <summary>
        /// Delays for 10 seconds
        /// </summary>
        /// <param name="car"></param>
        /// <returns>feedback</returns>
        public string WashCar(Car car)
        {
            Task.Delay(10000).Wait();
            car.Dirt = 0;
            return $"{car.Numberplate} has been washed - {DateTime.Now:HH:mm:ss - MM/dd/yyyy}";
        }
    }
}
