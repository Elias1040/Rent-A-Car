
namespace Rent_A_Car.Models
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string CustomerPhone { get; set; }
        int Age { get; set; }
    }
}
