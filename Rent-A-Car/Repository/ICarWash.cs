using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public interface ICarWash
    {
        int CarwashNumber { get; set; }

        Task<string> StartWash(Car car);
        string WashCar(Car car);
    }
}
