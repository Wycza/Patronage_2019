using FluentValidation;

namespace Task_1_Extra.Application.FizzBuzzs.Queries
{
    public class FizzBuzzQueryValidator : AbstractValidator<FizzBuzzQuery>
    {
        public FizzBuzzQueryValidator()
        {
            RuleFor(x => x.Number)
                .InclusiveBetween(0, 1000);
        }
    }
}
