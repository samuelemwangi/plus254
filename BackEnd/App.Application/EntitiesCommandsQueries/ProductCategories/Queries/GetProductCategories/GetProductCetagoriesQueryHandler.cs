using App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory;
using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategories
{
    public class GetProductCetagoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, ProductCategoriesViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetProductCetagoriesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ProductCategoriesViewModel> Handle(GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {


            IEnumerable<ProductCategoryDTO> productCategories = await _appDbContext.ProductCategories
                .Where(e => e.Deleted != 1)
                .Select(ProductCategoryDTO.Projection)
                .ToListAsync();

            return new ProductCategoriesViewModel
            {
                ProductCategories = productCategories,
                CreateEnabled = true
                //use user permissions later
            };

        }
    }
}
