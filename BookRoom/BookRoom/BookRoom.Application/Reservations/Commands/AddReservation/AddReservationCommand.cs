using MediatR;
using System;

namespace BookRoom.Application.Reservations.Commands.AddReservation
{
    public class AddReservationCommand : IRequest<string>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RoomId { get; set; }
    }
}
