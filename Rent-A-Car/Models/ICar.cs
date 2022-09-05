namespace Rent_A_Car.Models
{
    public interface ICar
    {
        string CarBrandName { get; set; }
        string CarModel { get; set; }
        string Numberplate { get; set; }
        int Seats { get; set; }
        string CarColor { get; set; }
        int Distance { get; set; }
        List<Reservation> Reservations { get; set; }
        int Horsepower { get; set; }
    }
}
