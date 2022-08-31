namespace Rent_A_Car.Models
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public Customer(int customerId, string customerName, string customerPhone)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
        }
    }
}
