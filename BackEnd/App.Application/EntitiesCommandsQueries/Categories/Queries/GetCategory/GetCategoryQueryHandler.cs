using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryViewModel>
    {

        private readonly AppDbContext _appDbContext;

        public GetCategoryQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<CategoryViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryEntity = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.ID == request.ID);

            if (categoryEntity == null)
            {
                throw new NotFoundException(nameof(Category), request.ID);
            }

            return new CategoryViewModel
            {
                CategoryName = categoryEntity.CategoryName,
                CategoryDescription = categoryEntity.Description,
                LastUpdatedBy = "",
                LastUpdatedDate = categoryEntity.LastEditedDate + "",

            };
        }
    }
}
