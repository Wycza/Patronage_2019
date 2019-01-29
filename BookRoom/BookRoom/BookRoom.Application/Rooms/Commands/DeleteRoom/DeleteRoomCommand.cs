using MediatR;

namespace BookRoom.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }
}
