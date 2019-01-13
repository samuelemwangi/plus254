using MediatR;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand:IRequest
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public short Deleted { get; set; }
    }
}
