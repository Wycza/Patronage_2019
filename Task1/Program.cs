using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int userAction = 0;
            while (userAction != 4)
            {
                PrintOptions();
                int.TryParse(Console.ReadLine(), out userAction);
                Console.Write("\n");

                switch (userAction)
                {
                    case 1:
                        UInt16 fizzBuzzNumber = AskForNumber(0, 1000);
                        FizzBuzz(fizzBuzzNumber);
                        break;
                    case 2:
                        Console.WriteLine("Not yet implemented");
                        break;
                    case 3:
                        Console.WriteLine("Not yet implemented");
                        break;
                    case 4:
                        Exit();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
            }
        }

        static void PrintOptions()
        {
            Console.WriteLine($"1. {nameof(FizzBuzz)}");
            Console.WriteLine($"2. {nameof(DeepDive)}");
            Console.WriteLine($"3. {nameof(DrownItDown)}");
            Console.WriteLine($"4. {nameof(Exit)}");
            Console.Write("Select: ");
        }

        static UInt16 AskForNumber(int min, int max)
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

        static void FizzBuzz(UInt16 number)
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
            }
        }

        static void DeepDive(UInt16 nestedLevel, string directoryName = "")
        {
            Console.WriteLine("Not yet implemented");
        }

        static void DrownItDown(UInt16 number)
        {
            Console.WriteLine("Not yet implemented");
        }

        static void Exit()
        {
            Console.WriteLine("See you again.");
        }
    }
}
