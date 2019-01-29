using MediatR;
using System;

namespace BookRoom.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<Unit>
    {
        public string ReservationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
