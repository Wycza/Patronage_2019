using System;

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
                Helper.PrintMenu();
                int.TryParse(Console.ReadLine(), out userAction);
                Console.WriteLine();

                switch (userAction)
                {
                    case 1:
                        FizzBuzzClass.PrintInstruction();
                        selectedNumber = Helper.AskForNumber(0, 1000);
                        FizzBuzzClass.FizzBuzz(selectedNumber);
                        break;
                    case 2:
                        DeepDiveClass.PrintInstruction();
                        selectedNumber = Helper.AskForNumber(0, 5);
                        DeepDiveClass.DeepDive(selectedNumber);
                        break;
                    case 3:
                        DrownItDownClass.PrintInstruction();
                        selectedNumber = Helper.AskForNumber(0, 5);
                        DrownItDownClass.DrownItDown(selectedNumber);
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

        static void Exit()
        {
            Console.WriteLine("See you again.");
        }

    }
}
