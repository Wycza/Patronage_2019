using BookRoom.Application.Exceptions;
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

        public DeleteRoomCommandHandler(BookRoomDbContext context)
        {
            _context = context;
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

            return Unit.Value;
        }
    }
}
