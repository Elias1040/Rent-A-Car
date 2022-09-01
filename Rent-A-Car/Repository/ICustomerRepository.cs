using Rent_A_Car.Models;

namespace Rent_A_Car.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        int CustomerExist();
        string NewCustomer(string name, string phone);
        bool DeleteCustomer(int id);
        string EditCustomer(int id, string name, string phone);
        // List<Reservation> GetReservations();

    }
}
