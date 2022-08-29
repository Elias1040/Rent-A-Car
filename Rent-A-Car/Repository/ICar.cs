using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public interface ICar
    {
        int CarId { get; set; }
        string Numberplate { get; set; }
        int Seats { get; set; }
        string CarColor { get; set; }
        List<Reservation> Reservations { get; set; }
        CarBrand CarBrand { get; set; }
    }
}
