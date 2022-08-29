
namespace Rent_A_Car.Models
{
    public class Reservation : IReservation
    {
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public Reservation(DateTime reservedFrom, DateTime reservedTo)
        {
            ReservedFrom = reservedFrom;
            ReservedTo = reservedTo;
        }
    }
}
