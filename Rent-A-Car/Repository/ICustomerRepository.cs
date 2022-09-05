using Rent_A_Car.Models;

namespace Rent_A_Car.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        int CustomerExist();
        Customer NewCustomer(string name, string phone, int age);
        bool DeleteCustomer(int id);
        Customer? EditCustomer(int id, string name, string phone);
        // List<Reservation> GetReservations();

    }
}
