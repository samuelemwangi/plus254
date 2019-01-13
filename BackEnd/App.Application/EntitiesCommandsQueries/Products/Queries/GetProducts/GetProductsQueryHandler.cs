using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Persistence;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsViewModel>
    {
        private readonly AppDbContext _appDbContext;
        

        public GetProductsQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public async Task<ProductsViewModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductDTO> products = await _appDbContext.Products
                .Where(e => e.Deleted != 1)
                .Select(ProductDTO.Projection)
                .ToListAsync();


            
            return new ProductsViewModel
            {
                Products = products,
                CreateEnabled = true

            };

            
        }
    }
}
