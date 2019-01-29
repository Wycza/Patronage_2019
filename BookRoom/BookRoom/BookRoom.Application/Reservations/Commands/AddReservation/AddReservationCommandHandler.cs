using BookRoom.Application.Exceptions;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Reservations.Commands.AddReservation
{
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, string>
    {
        private readonly BookRoomDbContext _context;

        public AddReservationCommandHandler(BookRoomDbContext context)
        {
            _context = context;
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

            return reservation.ReservationId;
        }
    }
}
