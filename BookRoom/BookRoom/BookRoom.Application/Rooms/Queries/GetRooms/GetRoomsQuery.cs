using MediatR;

namespace BookRoom.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQuery : IRequest<RoomsListViewModel>
    {
    }
}
