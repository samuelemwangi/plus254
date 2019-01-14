using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.UpdateCounty
{
    public class UpdatecountyCommandValidator : AbstractValidator<UpdateCountyCommand>
    {
        public UpdatecountyCommandValidator()
        {
            RuleFor(e => e.CountyName).MaximumLength(100);
            RuleFor(e => e.CountyDescription).MaximumLength(400);
        }
    }
}
