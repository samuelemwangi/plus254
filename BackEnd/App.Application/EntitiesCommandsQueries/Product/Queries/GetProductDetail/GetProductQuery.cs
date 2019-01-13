using MediatR;

namespace App.Application.EntitiesCommandsQueries.Product.Queries.GetProduct
{
    public class GetProductQuery: IRequest
    {
        public long ID { get; set; }
    }
}
