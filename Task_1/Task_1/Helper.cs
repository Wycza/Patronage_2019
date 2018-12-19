using System;

namespace Task_1
{
    public static class Helper
    {
        public static void PrintMenu()
        {
            Console.WriteLine($"1. {nameof(FizzBuzzClass.FizzBuzz)}");
            Console.WriteLine($"2. {nameof(DeepDiveClass.DeepDive)}");
            Console.WriteLine($"3. {nameof(DrownItDownClass.DrownItDown)}");
            Console.WriteLine($"4. Exit");
            Console.Write("Select: ");
        }

        /// <summary>
        /// Ask user for a number between {min} and {max}.
        /// </summary>
        /// <param name="min">Lowest possible number</param>
        /// <param name="max">Highest possible number</param>
        /// <returns>Number chosen by user</returns>
        public static UInt16 AskForNumber(int min, int max)
        {
            int userNumber;

            while (true)
            {
                Console.Write($"Please provide number between {min} - {max}: ");
                int.TryParse(Console.ReadLine(), out userNumber);

                if ((userNumber >= min) && (userNumber <= max))
                {
                    return Convert.ToUInt16(userNumber);
                }
                else if (userNumber < min)
                {
                    Console.WriteLine($"Number must be more or equal {min}. Try again.");
                }
                else if (userNumber > max)
                {
                    Console.WriteLine($"Number must be less or equal {max}. Try again.");
                }
            }
        }
    }
}
