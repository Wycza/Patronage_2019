using System;
using BookRoom.Persistence;

namespace BookRoom.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly NorthwindDbContext _context;

        public CommandTestBase()
        {
            _context = NorthwindContextFactory.Create();
        }

        public void Dispose()
        {
            NorthwindContextFactory.Destroy(_context);
        }
    }
}