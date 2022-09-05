using Rent_A_Car.Models;

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

        public Customer GetCustomer(int id) => 
            _customer.Find(customer => customer.CustomerId == id);

        public int CustomerExist()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Customer id: ");
                    return GetCustomer(Validate.TryParseInt()).CustomerId;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Customer doesnt exist try again");
                }
            }
        }
        public Customer NewCustomer(string name, string phone, int age)
        {
            Customer customer = new(_customerCounter++, name, phone, age);
            _customer.Add(customer);
            return customer;
        }

        public bool DeleteCustomer(int id) => 
            _customer.Remove(_customer.Find(customer => customer.CustomerId == id));

        public Customer? EditCustomer(int id, string customerName, string customerPhone)
        {
            Customer? customer = GetCustomer(id);
            customer.CustomerName = customerName;
            customer.CustomerPhone = customerPhone;
            return customer;
        }

        // public List<Reservation> GetReservations() => 
    }
}
