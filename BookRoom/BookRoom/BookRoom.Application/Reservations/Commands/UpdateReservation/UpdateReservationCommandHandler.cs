using BookRoom.Application.Exceptions;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly BookRoomDbContext _context;

        public UpdateReservationCommandHandler(BookRoomDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.FindAsync(request.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), request.ReservationId);
            }

            reservation.StartTime = request.StartTime;
            reservation.EndTime = request.EndTime;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
