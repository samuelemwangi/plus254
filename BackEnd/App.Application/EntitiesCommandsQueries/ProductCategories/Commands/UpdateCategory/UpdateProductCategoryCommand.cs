using MediatR;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.UpdateCategory
{
    public class UpdateProductCategoryCommand:IRequest
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
