using Microsoft.EntityFrameworkCore;
using BookRoom.Domain.Entities;

namespace BookRoom.Persistence
{
    public class BookRoomDbContext : DbContext
    {
        public BookRoomDbContext(DbContextOptions<BookRoomDbContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookRoomDbContext).Assembly);
        }
    }
}
