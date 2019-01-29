using FluentValidation;

namespace BookRoom.Application.Rooms.Queries.GetRoomDetails
{
    public class GetRoomDetailsQueryValidator : AbstractValidator<GetRoomDetailsQuery>
    {
        public GetRoomDetailsQueryValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty();
        }
    }
}
