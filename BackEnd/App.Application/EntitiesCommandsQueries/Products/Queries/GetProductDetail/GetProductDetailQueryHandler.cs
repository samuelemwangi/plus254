using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {

            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task<ProductDetailViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductDetailViewModel>
                (
                    await _appDbContext.Products
                        .Where(e => e.Deleted != 1 && e.ID == request.ID)
                        .Select(ProductDetailViewModel.Projection)
                        .FirstOrDefaultAsync(cancellationToken)
                );

            //TODO - Implement permissions resolver
            product.EditEnabled = true;
            product.DeleteEnabled = true;

            return product;

        }
    }
}
