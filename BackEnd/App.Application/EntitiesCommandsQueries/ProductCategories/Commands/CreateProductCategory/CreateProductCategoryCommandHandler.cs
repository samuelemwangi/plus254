using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Common.Interfaces;



namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.CreateProductCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, long>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public CreateCategoryCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }

        public async Task<long> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductCategory
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                CreatedDate = _dateTime.Now,
                LastEditedDate = _dateTime.Now
                
            };


            _appDbContext.ProductCategories.Add(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return entity.ID;
        }
    }
}
