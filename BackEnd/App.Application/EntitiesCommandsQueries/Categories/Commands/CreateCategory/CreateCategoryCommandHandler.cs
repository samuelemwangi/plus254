using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Entities;



namespace App.Application.EntitiesCommandsQueries.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, long>
    {
        private readonly AppDbContext _appDbContext;

        public CreateCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description
            };


            _appDbContext.Categories.Add(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return entity.ID;
        }
    }
}
