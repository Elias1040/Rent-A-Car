
namespace Rent_A_Car.Models
{
    public class CarOut
    {
        public string Numberplate { get; set; }
        public int Seats { get; set; }
        public string CarBrandName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int Distance { get; set; }
        public int Horsepower { get; set; }
        public double Price { get; set; }
        public int Dirt { get; set; }
        public bool Removed { get; set; }
        public CarOut(Car car)
        {
            Numberplate = car.Numberplate;
            Seats = car.Seats;
            CarColor = car.CarColor;
            CarBrandName = car.CarBrandName;
            CarModel = car.CarModel;
            Reservations = car.Reservations;
            Distance = 0;
            Horsepower = car.Horsepower;
            Price = car.Price;
            Dirt = car.Dirt;
            Removed = car.Removed;
        }
    }
}
