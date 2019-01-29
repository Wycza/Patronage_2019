using FluentValidation;

namespace BookRoom.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(64)
                .NotEmpty();

            RuleFor(x => x.SizeM2)
                .NotEmpty();

            RuleFor(x => x.NumberOfChairs)
                .NotEmpty();
        }
    }
}
