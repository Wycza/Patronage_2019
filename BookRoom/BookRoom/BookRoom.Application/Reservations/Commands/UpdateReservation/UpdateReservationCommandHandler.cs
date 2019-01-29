using BookRoom.Application.Exceptions;
using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
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
        private readonly INotificationService _notificationService;

        public UpdateReservationCommandHandler(BookRoomDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
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

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Updated reservation of room {reservation.RoomId}",
                Body = $"Successfuly updated reservation {reservation.ReservationId} of room {reservation.RoomId}"
            });

            return Unit.Value;
        }
    }
}
