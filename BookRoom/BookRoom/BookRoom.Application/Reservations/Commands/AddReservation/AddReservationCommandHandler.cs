using BookRoom.Application.Exceptions;
using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Reservations.Commands.AddReservation
{
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, string>
    {
        private readonly BookRoomDbContext _context;
        private readonly INotificationService _notificationService;

        public AddReservationCommandHandler(BookRoomDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<string> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.Where(x => x.RoomId == request.RoomId).SingleOrDefaultAsync(cancellationToken);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var reservation = new Reservation
            {
                RoomId = request.RoomId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Room = room
            };

            _context.Reservations.Add(reservation);

            await _context.SaveChangesAsync(cancellationToken);

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Added reservation to room {reservation.Room.Name}",
                Body = $"Successfuly added reservation {reservation.ReservationId} to room {reservation.Room.Name}"
            });

            return reservation.ReservationId;
        }
    }
}
