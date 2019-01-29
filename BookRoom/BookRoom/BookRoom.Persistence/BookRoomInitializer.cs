using System;
using System.Collections.Generic;
using System.Linq;
using BookRoom.Domain.Entities;
using BookRoom.Persistence.Infrastructure;

namespace BookRoom.Persistence
{
    public class BookRoomInitializer
    {
        //private readonly Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

        public static void Initialize(BookRoomDbContext context)
        {
            var initializer = new BookRoomInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(BookRoomDbContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Rooms.Any())
            //{
            //    return; // Db has been seeded
            //}


            //SeedTerritories(context);

        }
    }
}