using Microsoft.EntityFrameworkCore;
using BookRoom.Persistence.Infrastructure;

namespace BookRoom.Persistence
{
    public class BookRoomDbContextFactory : DesignTimeDbContextFactoryBase<BookRoomDbContext>
    {
        protected override BookRoomDbContext CreateNewInstance(DbContextOptions<BookRoomDbContext> options)
        {
            return new BookRoomDbContext(options);
        }
    }
}
