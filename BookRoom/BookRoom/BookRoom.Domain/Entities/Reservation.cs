using System;

namespace BookRoom.Domain.Entities
{
    public class Reservation
    {
        public string ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string RoomId { get; set; }
        public Room Room { get; set; }

    }
}
