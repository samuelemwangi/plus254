using MediatR;
using App.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Categories.Queries.GetAllCategories
{
    public class GetAllCetagoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryViewModel>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllCetagoriesQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<CategoryViewModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
