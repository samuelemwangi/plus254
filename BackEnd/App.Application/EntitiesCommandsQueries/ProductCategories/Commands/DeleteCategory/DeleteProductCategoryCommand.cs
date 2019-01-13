using MediatR;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.DeleteCategory
{
    public class DeleteProductCategoryCommand:IRequest
    {
        public long ID { get; set; }
    }
}
