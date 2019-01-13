using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Persistence;
using App.Domain.Entities;
using App.Common.Interfaces;

namespace App.Application.EntitiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, long>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public CreateProductCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                ProductCategoryID = request.ProductCategoryID,
                CreatedDate =  _dateTime.Now,
                LastEditedDate = _dateTime.Now
            };

            _appDbContext.Products.Add(entity);

            await _appDbContext.SaveChangesAsync();

            return entity.ID;
        }
    }
}
