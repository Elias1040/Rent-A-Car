namespace Rent_A_Car.Models
{
    public interface ICar
    {
        string Numberplate { get; set; }
        int Seats { get; set; }
        string CarColor { get; set; }
        List<Reservation> Reservations { get; set; }
        string CarBrandName { get; set; }
        string CarModel { get; set; }
    }
}
