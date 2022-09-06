
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

        /// <summary>
        /// Get customer by id from _customer list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>First matching customer or null if nothing found</returns>
        public Customer GetCustomer(int id) => 
            _customer.Find(customer => customer.CustomerId == id && !customer.IsDeleted);

        /// <summary>
        /// Check if customer exists
        /// </summary>
        /// <returns>id of customer</returns>
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

        /// <summary>
        /// Adds new customer to _customer list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="age"></param>
        /// <returns>Copy of the customer created</returns>
        public CustomerOut NewCustomer(string name, string phone, int age)
        {
            Customer customer = new(_customerCounter++, name, phone, age);
            _customer.Add(customer);
            return new(customer);
        }

        /// <summary>
        /// Sets the IsDeleted property to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id) => 
            _customer.Find(customer => customer.CustomerId == id).IsDeleted = true;

        /// <summary>
        /// Updates the properties of selected customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerName"></param>
        /// <param name="customerPhone"></param>
        /// <param name="age"></param>
        /// <returns>Copy of the updated customer</returns>
        public CustomerOut? EditCustomer(int id, string customerName, string customerPhone, int age)
        {
            Customer? customer = GetCustomer(id);
            customer.CustomerName = customerName;
            customer.CustomerPhone = customerPhone;
            customer.Age = age;
            return new(customer);
        }
    }
}
