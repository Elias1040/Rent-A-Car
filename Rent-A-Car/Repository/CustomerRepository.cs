using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> _customer;
        public readonly ICustomerRepository _customerRepository;
        public CustomerRepository(ICustomerRepository customerRepository) 
        { 
            _customerRepository = customerRepository;
        }
        public Customer GetCustomer(int id) => _customer.Find(customer => customer.CustomerId == id);
        public void NewCustomer(Customer customer) => _customer.Add(new(customer.CustomerId, customer.CustomerName, customer.CustomerPhone));
        public void DeleteCustomer(Customer customer) => _customer.Remove(customer);
        public void EditCustomer(Customer customer, int id)
        {
            Customer theCustomer = GetCustomer(id);
            theCustomer = new(customer.CustomerId, customer.CustomerName, customer.CustomerName);
        }
        // public List<Reservation> GetReservations() => 
    }
}
