using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.CreateCounty
{
    public class CreateCountyCommandValidator : AbstractValidator<CreateCountyCommand>
    {
        public CreateCountyCommandValidator()
        {
            RuleFor(x => x.CountyName).MaximumLength(100);
            RuleFor(x => x.CountyDescription).MaximumLength(400);
        }

    }
}
