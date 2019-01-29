using MediatR;

namespace BookRoom.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<string>
    {
        public string Name { get; set; }
        public int NumberOfChairs { get; set; }
        public int SizeM2 { get; set; }
    }
}
