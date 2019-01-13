using MediatR;
using App.Persistence;
using App.Domain.Entities;
using App.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.Application.Exceptions;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public UpdateProductCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Products.
                SingleAsync(e => e.ID == request.ID && e.Deleted != 1, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ID);
            }

            entity.ProductCategoryID = request.ProductCategoryId;
            entity.ProductName = request.ProductName;
            entity.ProductDescription = request.ProductDescription;
            entity.Deleted = request.Deleted;

            _appDbContext.Products.Update(entity);

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
            
        }
    }
}
