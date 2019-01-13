using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Persistence;
using App.Common.Interfaces;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using App.Application.Exceptions;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public UpdateProductCategoryCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductCategories
                .SingleAsync(e => e.ID == request.ID && e.Deleted != 1, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.ID);
            }
                        
            entity.CategoryName = request.CategoryName;
            entity.CategoryDescription = request.CategoryDescription;
            entity.LastEditedDate = _dateTime.Now;
            entity.Deleted = request.Deleted;

            _appDbContext.ProductCategories.Update(entity);

            await _appDbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;

        

            
        }
    }
}
