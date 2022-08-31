using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.BLL
{
    public class CarMiddleman
    {
        public readonly ICarRepository carRepo;
        public CarMiddleman(ICarRepository carRepository)
        {
            carRepo = carRepository;
        }
    }
}
