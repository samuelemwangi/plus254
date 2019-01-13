using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.UpdateCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(e => e.CategoryName).MaximumLength(100);
            RuleFor(e => e.CategoryDescription).MaximumLength(400);
        }
    }
}
