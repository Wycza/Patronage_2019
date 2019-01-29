using MediatR;

namespace BookRoom.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public string ReservationId { get; set; }
    }
}
