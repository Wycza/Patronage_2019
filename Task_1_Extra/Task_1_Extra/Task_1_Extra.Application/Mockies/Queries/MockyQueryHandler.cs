using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Task_1_Extra.Application.Interfaces;

namespace Task_1_Extra.Application.Mockies.Queries
{
    public class MockyQueryHandler : IRequestHandler<MockyQuery, string>
    {
        private readonly IMockioService _mockioService;
        public MockyQueryHandler(IMockioService mockioService)
        {
            _mockioService = mockioService;
        }

        public async Task<string> Handle(MockyQuery request, CancellationToken cancellationToken)
        {
            return await _mockioService.GetResponseAsync("http://www.mocky.io/v2/5c127054330000e133998f85");
        }
    }
}
