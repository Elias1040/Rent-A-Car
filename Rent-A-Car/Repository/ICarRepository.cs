using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public interface ICarRepository
    {
        Car GetCar(Car car);
        Car GetCar(string numberplate);
        void NewCar(Car car);
        void DeleteCar(Car car);
        void EditCar(Car car, string numberplate);
        List<Reservation> GetReservation(Car car);
    }
}
