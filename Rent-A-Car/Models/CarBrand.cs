using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class CarBrand : ICarBrand
    {
        public string CarBrandName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
    }
}
