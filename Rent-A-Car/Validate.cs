using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    public static class Validate
    {
        public static int TryParseInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Clear();
                Console.WriteLine("Input must be a number! \nTry again: ");
            }
            return value;
        }

        public static string ValidString()
        {
            string? item = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(item))
            {
                Console.WriteLine("Input required! \nTry again: ");
                item = Console.ReadLine();
            }
            return item;
        }

        public static DateTime TryParseDateTime()
        {
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Incorrect format! \nTry again: (dd-mm-yyyy)");
            }
            return dateTime;
        }
    }
}
