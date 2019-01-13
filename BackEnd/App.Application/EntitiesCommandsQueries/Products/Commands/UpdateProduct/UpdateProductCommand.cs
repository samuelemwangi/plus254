using MediatR;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long ProductCategoryId { get; set; }
        public short Deleted { get; set; }
    }
}
