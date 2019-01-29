using FluentValidation;

namespace BookRoom.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(x => x.ReservationId)
                .NotEmpty();
        }
    }
}
