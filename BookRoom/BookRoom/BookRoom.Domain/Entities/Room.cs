using System;
using System.Collections.Generic;

namespace BookRoom.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public string RoomId { get; set; }
        public string Name { get; set; }
        public int NumberOfChairs { get; set; }
        public int SizeM2 { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
