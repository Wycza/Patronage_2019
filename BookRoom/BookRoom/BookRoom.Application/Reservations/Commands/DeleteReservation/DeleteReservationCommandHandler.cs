using BookRoom.Application.Exceptions;
using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
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
        private readonly INotificationService _notificationService;

        public DeleteReservationCommandHandler(BookRoomDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
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

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Deleted reservation of room {reservation.RoomId}",
                Body = $"Successfuly deleted reservation {reservation.ReservationId} of room {reservation.RoomId}"
            });

            return Unit.Value;
        }
    }
}
