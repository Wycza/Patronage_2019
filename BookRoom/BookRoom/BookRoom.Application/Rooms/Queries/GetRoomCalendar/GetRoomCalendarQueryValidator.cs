using FluentValidation;

namespace BookRoom.Application.Rooms.Queries.GetRoomCalendar
{
    public class GetRoomCalendarQueryValidator : AbstractValidator<GetRoomCalendarQuery>
    {
        public GetRoomCalendarQueryValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty();
        }
    }
}
