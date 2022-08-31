namespace Rent_A_Car.Models
{
    public class Reservation : IReservation
    {
        public int CustomerId { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public Reservation(int customerId, DateTime reservedFrom, DateTime reservedTo)
        {
            CustomerId = customerId;
            ReservedFrom = reservedFrom;
            ReservedTo = reservedTo;
        }
    }
}
