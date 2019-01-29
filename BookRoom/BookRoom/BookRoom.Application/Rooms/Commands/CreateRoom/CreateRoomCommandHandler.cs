using BookRoom.Application.Interfaces;
using BookRoom.Application.Notifications.Models;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, string>
    {
        private readonly BookRoomDbContext _context;
        private readonly INotificationService _notificationService;
        private readonly IMediator _mediator;

        public CreateRoomCommandHandler(
            BookRoomDbContext context,
            INotificationService notificationService,
            IMediator mediator)
        {
            _context = context;
            _notificationService = notificationService;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = new Room()
            {
                Name = request.Name,
                NumberOfChairs = request.NumberOfChairs,
                SizeM2 = request.SizeM2
            };

            _context.Rooms.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _notificationService.SendAsync(new Message
            {
                To = "patronage.zadanie3@gmail.com",
                Subject = $"Created room {entity.Name}",
                Body = $"Successfuly created room {entity.Name} with id {entity.RoomId}"
            });

            return entity.RoomId;
        }
    }
}
