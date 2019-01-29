using BookRoom.Application.Exceptions;
using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly BookRoomDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteRoomCommandHandler(BookRoomDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Rooms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            _context.Rooms.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Deleted room {entity.Name}",
                Body = $"Successfuly deleted room {entity.Name} with id {entity.RoomId}"
            });

            return Unit.Value;
        }
    }
}
