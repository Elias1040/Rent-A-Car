using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.BLL
{
    public class CustomerMiddleman
    {
        public readonly ICustomerRepository customerRepo;
        public CustomerMiddleman(ICustomerRepository customerRepository)
        {
            customerRepo = customerRepository;
        }
    }
}
