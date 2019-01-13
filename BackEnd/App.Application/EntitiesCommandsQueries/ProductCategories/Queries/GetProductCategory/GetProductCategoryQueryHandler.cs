using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, ProductCategoryViewModel>
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetProductCategoryQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task<ProductCategoryViewModel> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            //Recheck this 
            var productCategory = _mapper.Map<ProductCategoryViewModel>(await _appDbContext.ProductCategories
                .Include(c => c.Products)
                .Where(e => e.ID == request.ID && e.Deleted != 1)
                .Select(ProductCategoryViewModel.Projection)
                .FirstOrDefaultAsync(cancellationToken)
                );
            

            if (productCategory == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.ID);
            }

            //implement permission resolver
            productCategory.EditEnabled = true;
            productCategory.DeleteEnabled = true;

            return productCategory;

        }
    }
}
