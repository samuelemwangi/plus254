using MediatR;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory
{
    public class GetProductCategoryQuery : IRequest<ProductCategoryViewModel>
    {
        public long ID { get; set; }
    }
}
