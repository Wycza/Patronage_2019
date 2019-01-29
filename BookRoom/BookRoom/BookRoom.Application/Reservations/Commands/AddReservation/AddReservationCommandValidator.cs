using FluentValidation;

namespace BookRoom.Application.Reservations.Commands.AddReservation
{
    public class AddReservationCommandValidator : AbstractValidator<AddReservationCommand>
    {
        public AddReservationCommandValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty();

            RuleFor(x => x.StartTime)
                .NotEmpty();

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be after start time");
        }
    }
}
