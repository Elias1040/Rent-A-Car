
namespace Rent_A_Car.Models
{
    public class CustomerOut
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public CustomerOut(Customer customer)
        {
            CustomerId = customer.CustomerId;
            CustomerName = customer.CustomerName;
            CustomerPhone = customer.CustomerPhone;
            Age = customer.Age;
            IsDeleted = customer.IsDeleted;
        }
    }
}
