using BookRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRoom.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.RoomId);

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.SizeM2)
                .IsRequired();

            builder.Property(x => x.NumberOfChairs)
                .IsRequired();

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Room);
        }
    }
}
