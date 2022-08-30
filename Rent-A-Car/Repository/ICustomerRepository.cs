
namespace Rent_A_Car.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        void NewCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void EditCustomer(Customer customer, int id);
        // List<Reservation> GetReservations();

    }
}
