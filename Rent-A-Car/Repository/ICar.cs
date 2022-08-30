
namespace Rent_A_Car.Repository
{
    public interface ICar
    {
        int CarId { get; set; }
        string Numberplate { get; set; }
        int Seats { get; set; }
        string CarColor { get; set; }
        List<Reservation> Reservations { get; set; }
        string CarBrandName { get; set; }
        string CarModel { get; set; }
    }
}
