
namespace Rent_A_Car.Models
{
    public class Car : ICar
    {
        public int CarId { get; set; }
        public string Numberplate { get; set; }
        public int Seats { get; set; }
        public string CarBrandName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Car(int carId, string numberplate, int seats, string carColor, string carBrandName, string carModel)
        {
            CarId = carId;
            Numberplate = numberplate;
            Seats = seats;
            CarColor = carColor;
            CarBrandName = carBrandName;
            CarModel = carModel;
            List<Reservation> reservations = new List<Reservation>();
        }
    }
}
