﻿using BookRoom.Application.Customers.Queries.GetCustomerDetail;
using BookRoom.Application.Tests.Infrastructure;
using BookRoom.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookRoom.Application.Tests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerDetailQueryHandlerTests
    { 
        private readonly NorthwindDbContext _context;

        public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }    

        public async Task GetCustomerDetail()
        {
            var sut = new GetCustomerDetailQueryHandler(_context);

            var result = await sut.Handle(new GetCustomerDetailQuery { Id = "JASON" }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDetailModel>();
            result.Id.ShouldBe("JASON");
        }
    }
}
