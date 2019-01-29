using MediatR;
using System;
using System.Collections.Generic;

namespace BookRoom.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumberOfChairs { get; set; }
        public int SizeM2 { get; set; }
    }
}
