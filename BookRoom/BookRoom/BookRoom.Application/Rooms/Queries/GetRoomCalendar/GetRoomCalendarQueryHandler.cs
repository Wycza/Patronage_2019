using AutoMapper;
using BookRoom.Application.Exceptions;
using BookRoom.Domain.Entities;
using BookRoom.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Rooms.Queries.GetRoomCalendar
{
    public class GetRoomCalendarQueryHandler : IRequestHandler<GetRoomCalendarQuery, ReservationsListViewModel>
    {
        private readonly BookRoomDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomCalendarQueryHandler(BookRoomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationsListViewModel> Handle(GetRoomCalendarQuery request, CancellationToken cancellationToken)
        {
            if (!_context.Rooms.Any(el => el.RoomId == request.RoomId))
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var reservations = await _context.Reservations.Where(x => x.RoomId == request.RoomId).ToListAsync(cancellationToken);

            var model = new ReservationsListViewModel
            {
                Reservations = _mapper.Map<IEnumerable<ReservationDto>>(reservations)
            };

            return model;
        }
    }
}
