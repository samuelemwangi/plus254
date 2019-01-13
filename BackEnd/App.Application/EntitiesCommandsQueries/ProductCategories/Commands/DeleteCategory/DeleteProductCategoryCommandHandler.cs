using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Persistence;
using App.Common.Interfaces;
using App.Domain.Entities;
using App.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.DeleteCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public DeleteProductCategoryCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }
        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductCategories
                .SingleAsync(e => e.ID == request.ID, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(ProductCategories), request.ID);
            }

            entity.Deleted = 1;

            _appDbContext.ProductCategories.Update(entity);

            await _appDbContext.SaveChangesAsync(cancellationToken);          
            
            return Unit.Value;
        }
    }
}
