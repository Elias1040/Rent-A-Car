using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public class CarMiddleman
    {
        public readonly ICarRepository _carRepo;
        public CarMiddleman(ICarRepository carRepository)
        {
            _carRepo = carRepository;
        }
    }
}
