

namespace Rent_A_Car.Models
{
    public interface IReservation
    {
        int CustomerId { get; set; }
        string Numberplate { get; set; }
        DateTime ReservedFrom { get; set; }
        DateTime ReservedTo { get; set; }
    }
}
