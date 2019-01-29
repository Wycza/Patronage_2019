using System.Collections.Generic;

namespace BookRoom.Application.Rooms.Queries.GetRooms
{
    public class RoomsListViewModel
    {
        public IEnumerable<RoomDto> Rooms { get; set; }

    }
}
