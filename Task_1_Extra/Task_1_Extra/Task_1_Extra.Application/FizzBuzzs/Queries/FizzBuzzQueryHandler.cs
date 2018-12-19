using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1_Extra.Application.FizzBuzzs.Queries
{
    public class FizzBuzzQueryHandler : IRequestHandler<FizzBuzzQuery, string>
    {
        public async Task<string> Handle(FizzBuzzQuery request, CancellationToken cancellationToken)
        {
            return $"Not yet implemented. Value = {request.Number}";
        }
    }
}
