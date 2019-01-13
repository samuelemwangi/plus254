using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName).MaximumLength(100);
            RuleFor(x => x.CategoryDescription).MaximumLength(400);
        }

    }
}
