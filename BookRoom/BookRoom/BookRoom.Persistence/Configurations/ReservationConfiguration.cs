using BookRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRoom.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.ReservationId);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();
        }
    }
}
