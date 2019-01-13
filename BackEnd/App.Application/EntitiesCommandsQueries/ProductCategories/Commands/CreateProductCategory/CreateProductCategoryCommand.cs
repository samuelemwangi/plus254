using MediatR;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<long>
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
