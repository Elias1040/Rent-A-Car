namespace Rent_A_Car.Models
{
    public class Car : ICar
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
        public Car(string numberplate, int seats, string carColor, string carBrandName, string carModel, int horsePower, double price)
        {
            Numberplate = numberplate;
            Seats = seats;
            CarColor = carColor;
            CarBrandName = carBrandName;
            CarModel = carModel;
            Reservations = new List<Reservation>();
            Distance = 0;
            Horsepower = horsePower;
            Price = price;
            Dirt = 0;
            Removed = false;
        }
    }
}
