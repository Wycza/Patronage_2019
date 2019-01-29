using AutoMapper;
using BookRoom.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookRoom.Application.Rooms.Queries.GetRooms
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, RoomsListViewModel>
    {
        private readonly BookRoomDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(BookRoomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomsListViewModel> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _context.Rooms.ToListAsync(cancellationToken);

            var model = new RoomsListViewModel
            {
                Rooms = _mapper.Map<IEnumerable<RoomDto>>(rooms)
            };

            return model;
        }
    }
}
