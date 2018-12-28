using Moq;
using System.Threading;
using Task_1_Extra.Application.Interfaces;
using Task_1_Extra.Application.Mockies.Queries;
using Xunit;

namespace Task_1_Extra.Application.Tests.Mockies.Queries
{
    public class MockyQueryHandlerTests
    {
        [Fact]
        public async void MockioGetResponse()
        {
            var mockioServiceMock = new Mock<IMockioService>();
            mockioServiceMock.Setup(x => x.GetResponseAsync(It.IsAny<string>())).ReturnsAsync("Fake response");

            MockyQueryHandler mockyHandler = new MockyQueryHandler(mockioServiceMock.Object);

            var result = await mockyHandler.Handle(new MockyQuery(), It.IsAny<CancellationToken>());
            Assert.Equal("Fake response", result);
        }
    }
}
