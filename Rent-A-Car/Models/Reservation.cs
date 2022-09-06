namespace Rent_A_Car.Models
{
    public class Reservation : IReservation
    {
        public int CustomerId { get; set; }
        public string Numberplate { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public bool Returned { get; set; }
        public bool Collected { get; set; }
        public Reservation(int customerId, DateTime reservedFrom, DateTime reservedTo, string numberplate)
        {
            CustomerId = customerId;
            ReservedFrom = reservedFrom;
            ReservedTo = reservedTo;
            Numberplate = numberplate;
            Returned = false;
            Collected = false;
        }
    }
}
