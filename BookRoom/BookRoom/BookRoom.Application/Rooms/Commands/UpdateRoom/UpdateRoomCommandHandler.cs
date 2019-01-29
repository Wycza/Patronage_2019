using BookRoom.Application.Exceptions;
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

        public UpdateRoomCommandHandler(BookRoomDbContext context)
        {
            _context = context;
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

            return Unit.Value;
        }
    }
}
