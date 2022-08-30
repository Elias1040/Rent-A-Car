using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public class CustomerMiddleman
    {
        public readonly ICustomerRepository _customerRepo;
        public CustomerMiddleman(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }
    }
}
