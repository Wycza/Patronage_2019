using MediatR;

namespace BookRoom.Application.Rooms.Queries.GetRoomCalendar
{
    public class GetRoomCalendarQuery : IRequest<ReservationsListViewModel>
    {
        public string RoomId { get; set; }
    }
}
