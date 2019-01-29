using System;

namespace BookRoom.Application.Rooms.Queries.GetRoomCalendar
{
    public class ReservationDto
    {
        public string ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
