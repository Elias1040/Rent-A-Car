using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string CustomerPhone { get; set; }
    }
}
