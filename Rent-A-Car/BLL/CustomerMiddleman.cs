
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
