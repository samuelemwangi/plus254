using FluentValidation;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(e => e.ProductCategoryId).NotEmpty();
            RuleFor(e => e.ProductName).NotEmpty().MaximumLength(100);
            RuleFor(e => e.ProductDescription).MaximumLength(800);
        }
    }
}
