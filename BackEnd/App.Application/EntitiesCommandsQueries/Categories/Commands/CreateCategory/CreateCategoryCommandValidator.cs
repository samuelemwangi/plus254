using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName).MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(200);
        }

    }
}
