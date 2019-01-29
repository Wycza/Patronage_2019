using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookRoom.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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
