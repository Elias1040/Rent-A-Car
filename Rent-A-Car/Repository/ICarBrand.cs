using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public interface ICarBrand
    {
        string CarBrandName { get; set; }
        string CarModel { get; set; }
        string CarColor { get; set; }
    }
}
