using MediatR;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery: IRequest<ProductDetailViewModel>
    {
        public long ID { get; set; }
    }
}
