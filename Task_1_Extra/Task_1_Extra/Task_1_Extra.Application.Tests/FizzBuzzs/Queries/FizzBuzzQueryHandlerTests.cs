using Moq;
using System.Threading;
using Task_1_Extra.Application.Exceptions;
using Task_1_Extra.Application.FizzBuzzs.Queries;
using Xunit;

namespace Task_1_Extra.Application.Tests.FizzBuzzs.Queries
{
    public class FizzBuzzQueryHandlerTests
    {
        [Fact]
        public async void ReturnFizz()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();
            var response = await handler.Handle(new FizzBuzzQuery { Number = 2 }, It.IsAny<CancellationToken>());

            Assert.Equal("Fizz", response);
        }

        [Fact]
        public async void ReturnBuzz()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();
            var response = await handler.Handle(new FizzBuzzQuery { Number = 3 }, It.IsAny<CancellationToken>());

            Assert.Equal("Buzz", response);
        }

        [Fact]
        public async void ReturnFizzBuzz()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();
            var response = await handler.Handle(new FizzBuzzQuery { Number = 6 }, It.IsAny<CancellationToken>());

            Assert.Equal("FizzBuzz", response);
        }

        [Fact]
        public async void ReturnNumber()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();
            var response = await handler.Handle(new FizzBuzzQuery { Number = 5 }, It.IsAny<CancellationToken>());

            Assert.Equal("5", response);
        }

        [Fact]
        public async void ThrowExceptionIfMoreThan1000()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();

            var exception = await Record.ExceptionAsync(() =>
                handler.Handle(new FizzBuzzQuery { Number = 1001 }, It.IsAny<CancellationToken>()
            ));

            Assert.NotNull(exception);
            Assert.IsType<FizzBuzzException>(exception);
        }

        [Fact]
        public async void ThrowExceptionIfLessThan0()
        {
            FizzBuzzQueryHandler handler = new FizzBuzzQueryHandler();

            var exception = await Record.ExceptionAsync(() =>
                handler.Handle(new FizzBuzzQuery { Number = -1 }, It.IsAny<CancellationToken>()
            ));

            Assert.NotNull(exception);
            Assert.IsType<FizzBuzzException>(exception);
        }
    }
}
