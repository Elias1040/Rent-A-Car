
namespace Rent_A_Car.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customer;
        int _customerCounter;
        public CustomerRepository()
        {
            _customer = new List<Customer>();
        }

        public Customer GetCustomer(int id) => _customer.Find(customer => customer.CustomerId == id);
        public void NewCustomer(Customer customer) => 
            _customer.Add(new(_customerCounter++, customer.CustomerName, customer.CustomerPhone));
        public void DeleteCustomer(Customer customer) => _customer.Remove(customer);
        public void EditCustomer(Customer customer, int id)
        {
            Customer theCustomer = GetCustomer(id);
            theCustomer = new(customer.CustomerId, customer.CustomerName, customer.CustomerName);
        }
        // public List<Reservation> GetReservations() => 
    }
}
