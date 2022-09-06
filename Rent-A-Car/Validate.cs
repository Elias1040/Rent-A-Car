
namespace Rent_A_Car
{
    public static class Validate
    {
        /// <summary>
        /// Validates for numbers
        /// </summary>
        /// <returns>input as int</returns>
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

        /// <summary>
        /// Validates for whitespace or null
        /// </summary>
        /// <returns>input as string</returns>
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

        /// <summary>
        /// Validates for correct datetime
        /// </summary>
        /// <returns>input as datetime</returns>
        public static DateTime TryParseDateTime()
        {
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Incorrect format! \nTry again: (dd-mm-yyyy)");
            }
            return dateTime;
        }

        /// <summary>
        /// validates for decimal values
        /// </summary>
        /// <returns>input as double</returns>
        public static double TryParseDouble()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Input must be a number \nTry again");
            }
            return value;
        }
    }
}
