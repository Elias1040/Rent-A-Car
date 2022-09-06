

namespace Rent_A_Car.Models
{
    public class ReservationOut
    {
        public int CustomerId { get; set; }
        public string Numberplate { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public bool Returned { get; set; }
        public bool Collected { get; set; }
        public ReservationOut(Reservation reservation)
        {
            CustomerId = reservation.CustomerId;
            ReservedFrom = reservation.ReservedFrom;
            ReservedTo = reservation.ReservedTo;
            Numberplate = reservation.Numberplate;
            Returned = reservation.Returned;
            Collected = reservation.Collected;
        }
    }
}
