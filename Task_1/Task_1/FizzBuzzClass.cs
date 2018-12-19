using System;

namespace Task_1
{
    public static class FizzBuzzClass
    {
        public static void PrintInstruction()
        {
            Console.WriteLine("For multiples of three print \"Fizz\" instead of the number " +
                            "and for the multiples of five print \"Buzz\". " +
                            "For numbers which are multiples of both three and five print \"FizzBuzz\".");
        }

        /// <summary>
        /// For multiples of three print "Fizz" instead of the number
        /// and for the multiples of five print "Buzz".
        /// For numbers which are multiples of both three and five print "FizzBuzz".
        /// </summary>
        /// <param name="number">Number to check</param>
        public static void FizzBuzz(UInt16 number)
        {
            if ((number < 0) || (number > 1000))
            {
                throw new Exception("Number must be between 0 - 1000");
            }

            if ((number % 2 == 0) && (number % 3 == 0))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 2 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Buzz");
            } else
            {
                Console.WriteLine(number);
            }
        }
    }
}
