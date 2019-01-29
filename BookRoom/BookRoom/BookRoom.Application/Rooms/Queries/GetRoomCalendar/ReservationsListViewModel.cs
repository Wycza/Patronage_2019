using System.Collections.Generic;

namespace BookRoom.Application.Rooms.Queries.GetRoomCalendar
{
    public class ReservationsListViewModel
    {
        public IEnumerable<ReservationDto> Reservations { get; set; }
    }
}
