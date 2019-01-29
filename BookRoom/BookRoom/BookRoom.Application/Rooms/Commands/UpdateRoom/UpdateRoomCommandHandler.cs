using BookRoom.Application.Exceptions;
using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly BookRoomDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateRoomCommandHandler(BookRoomDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.Name = request.Name;
            entity.NumberOfChairs = request.NumberOfChairs;
            entity.SizeM2 = request.SizeM2;

            await _context.SaveChangesAsync(cancellationToken);

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Updated room {entity.Name}",
                Body = $"Successfuly updated room {entity.Name}."
            });

            return Unit.Value;
        }
    }
}
