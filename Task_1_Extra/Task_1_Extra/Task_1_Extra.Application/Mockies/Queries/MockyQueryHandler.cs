using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1_Extra.Application.Mockies.Queries
{
    public class MockyQueryHandler : IRequestHandler<MockyQuery, string>
    {
        public async Task<string> Handle(MockyQuery request, CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetStringAsync("http://www.mocky.io/v2/5c127054330000e133998f85");
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
