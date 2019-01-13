using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetAllProductCategories
{
    public class GetAllProductCetagoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, ProductCategoriesViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetAllProductCetagoriesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ProductCategoriesViewModel> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _appDbContext.ProductCategories.AllAsync(e => e.Deleted != 1);

            var entityViewModel = new ProductCategoriesViewModel
            {
                ProductCategories = _mapper.Map<IEnumerable<ProductCategoryDTO>>(categories),
                CreateEnabled = true
                //use user permissions later
            };

            return entityViewModel;

        }
    }
}
