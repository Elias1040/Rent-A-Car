using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public interface IReservation
    {
        int CustomerId { get; set; }
        DateTime ReservedFrom { get; set; }
        DateTime ReservedTo { get; set; }
    }
}
