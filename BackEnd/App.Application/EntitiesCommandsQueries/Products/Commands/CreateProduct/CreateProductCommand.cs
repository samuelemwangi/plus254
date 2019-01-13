using MediatR;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<long>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long ProductCategoryID { get; set; }
    }
}
