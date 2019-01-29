using FluentValidation;

namespace BookRoom.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
