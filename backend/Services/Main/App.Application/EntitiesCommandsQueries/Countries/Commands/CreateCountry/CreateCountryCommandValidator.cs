using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandValidator: AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}
