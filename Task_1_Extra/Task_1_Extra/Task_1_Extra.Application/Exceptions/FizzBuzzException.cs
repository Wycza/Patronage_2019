using System;

namespace Task_1_Extra.Application.Exceptions
{
    public class FizzBuzzException : Exception
    {
        public FizzBuzzException(int min, int max) : base($"The value must be between {min} and {max}.")
        {

        }
    }
}
