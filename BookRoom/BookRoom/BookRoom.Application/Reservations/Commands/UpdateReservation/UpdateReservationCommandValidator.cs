using FluentValidation;
using System;

namespace BookRoom.Application.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.ReservationId)
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
