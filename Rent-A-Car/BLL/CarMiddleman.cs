
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
