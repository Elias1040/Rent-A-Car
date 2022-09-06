
namespace Rent_A_Car.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        int CustomerExist();
        CustomerOut NewCustomer(string name, string phone, int age);
        bool DeleteCustomer(int id);
        CustomerOut? EditCustomer(int id, string name, string phone, int age);
        // List<Reservation> GetReservations();

    }
}
