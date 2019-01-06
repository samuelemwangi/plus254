using MediatR;

namespace App.Application.EntitiesCommandsQueries.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryViewModel>
    {
        public long ID { get; set; }
    }
}
