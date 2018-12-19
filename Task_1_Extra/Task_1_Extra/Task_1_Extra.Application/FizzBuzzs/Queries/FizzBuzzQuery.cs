
using MediatR;

namespace Task_1_Extra.Application.FizzBuzzs.Queries
{
    public class FizzBuzzQuery : IRequest<string>
    {
        public int Number { get; set; }
    }
}
