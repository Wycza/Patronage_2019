using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Task_1_Extra.Application.Exceptions;

namespace Task_1_Extra.Application.FizzBuzzs.Queries
{
    public class FizzBuzzQueryHandler : IRequestHandler<FizzBuzzQuery, string>
    {
        public async Task<string> Handle(FizzBuzzQuery request, CancellationToken cancellationToken)
        {
            int number = request.Number;

            if ((number < 0) || (number > 1000))
            {
                throw new FizzBuzzException(0, 1000);
            }

            if ((number % 2 == 0) && (number % 3 == 0))
            {
                return "FizzBuzz";
            }
            else if (number % 2 == 0)
            {
                return  "Fizz";
            }
            else if (number % 3 == 0)
            {
                return  "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }
    }
}
