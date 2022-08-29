using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Models
{
    public class Car : CarBrand, ICar
    {
        public int CarId { get; set; }
        public string Numberplate { get; set; }
        public int Seats { get; set; }
        public List<Reservation> Reservations { get; set; }
        public CarBrand CarBrand { get; set; }
        public Car(int carId, string numberplate, int seats, string carColor, CarBrand carBrand)
        {
            CarId = carId;
            Numberplate = numberplate;
            Seats = seats;
            CarColor = carColor;
            CarBrand = carBrand;
            List<Reservation> reservations = new List<Reservation>();
        }
    }
}
