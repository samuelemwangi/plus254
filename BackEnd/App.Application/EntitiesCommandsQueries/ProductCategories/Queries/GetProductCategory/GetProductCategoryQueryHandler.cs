using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, ProductCategoryViewModel>
    {

        private readonly AppDbContext _appDbContext;

        public GetProductCategoryQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<ProductCategoryViewModel> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductCategories.FirstOrDefaultAsync(e => e.ID == request.ID && e.Deleted != 1, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.ID);
            }

            return new ProductCategoryViewModel
            {
                CategoryName = entity.CategoryName,
                CategoryDescription = entity.CategoryDescription,
                LastUpdatedBy = "",
                LastUpdatedDate = entity.LastEditedDate + "",

            };
        }
    }
}
