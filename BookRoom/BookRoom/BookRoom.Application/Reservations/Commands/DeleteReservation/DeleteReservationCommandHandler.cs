using BookRoom.Application.Exceptions;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly BookRoomDbContext _context;

        public DeleteReservationCommandHandler(BookRoomDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _context.Reservations.FindAsync(request.ReservationId);

            if (reservation == null)
            {
                throw new NotFoundException(nameof(Reservation), request.ReservationId);
            }

            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
