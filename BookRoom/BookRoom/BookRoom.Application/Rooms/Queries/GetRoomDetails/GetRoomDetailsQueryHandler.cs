using AutoMapper;
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

namespace BookRoom.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsViewModel>
    {
        private readonly BookRoomDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomDetailsQueryHandler(BookRoomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomDetailsViewModel> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.Where(x => x.RoomId == request.RoomId).SingleOrDefaultAsync(cancellationToken);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            var model = _mapper.Map<RoomDetailsViewModel>(room);

            return model;
        }
    }
}
