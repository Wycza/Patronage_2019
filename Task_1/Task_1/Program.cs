using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int userAction = 0;
            UInt16 selectedNumber;

            while (userAction != 4)
            {
                PrintOptions();
                int.TryParse(Console.ReadLine(), out userAction);
                Console.Write("\n");

                switch (userAction)
                {
                    case 1:
                        selectedNumber = AskForNumber(0, 1000);
                        FizzBuzz(selectedNumber);
                        break;
                    case 2:
                        selectedNumber = AskForNumber(0, 5);
                        DeepDive(selectedNumber);
                        break;
                    case 3:
                        selectedNumber = AskForNumber(0, 5);
                        DrownItDown(selectedNumber);
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

        /// <summary>
        /// Ask user for a number between {min} and {max}.
        /// </summary>
        /// <param name="min">Lowest possible number</param>
        /// <param name="max">Highest possible number</param>
        /// <returns>Number chosen by user</returns>
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

        /// <summary>
        /// For multiples of three print "Fizz" instead of the number
        /// and for the multiples of five print "Buzz".
        /// For numbers which are multiples of both three and five print "FizzBuzz".
        /// </summary>
        /// <param name="number">Number to check</param>
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

        /// <summary>
        /// Method which creates nested directories using recurrence.
        /// </summary>
        /// <param name="nestingLevel">Level of nesting</param>
        /// <param name="directoryName">Name of the directory created at current level of nesting</param>
        static void DeepDive(UInt16 nestingLevel, string directoryName = "")
        {
            if ((nestingLevel < 0) || (nestingLevel > 5))
            {
                throw new Exception("Number must be between 0 - 5");
            }

            if (String.IsNullOrEmpty(directoryName))
            {
                directoryName = Directory.GetCurrentDirectory();
            }

            if (nestingLevel > 0)
            {
                --nestingLevel;
                string folderName = Path.Combine(directoryName, Guid.NewGuid().ToString());
                Directory.CreateDirectory(folderName);
                Console.WriteLine($"Created folder: {folderName}");

                DeepDive(nestingLevel, folderName);
            }
            return;
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
