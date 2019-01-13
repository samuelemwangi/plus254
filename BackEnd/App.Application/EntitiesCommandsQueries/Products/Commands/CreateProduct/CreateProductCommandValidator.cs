using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(e => e.ProductCategoryID).NotEmpty();
            RuleFor(e => e.ProductName).NotEmpty().MaximumLength(100);
            RuleFor(e => e.ProductDescription).MaximumLength(800);

        }

    }
}
