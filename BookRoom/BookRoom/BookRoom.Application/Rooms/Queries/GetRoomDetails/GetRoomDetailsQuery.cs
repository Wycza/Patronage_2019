using MediatR;

namespace BookRoom.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQuery : IRequest<RoomDetailsViewModel>
    {
        public string RoomId { get; set; }
    }
}
