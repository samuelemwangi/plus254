using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Categories.Queries.GetAllCategories
{
    public class GetAllCetagoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoriesViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetAllCetagoriesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<CategoriesViewModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _appDbContext.Categories.ToListAsync(cancellationToken);

            var entityViewModel = new CategoriesViewModel
            {
                Categories = _mapper.Map<IEnumerable<CategoryDTO>>(categories),
                CreateEnabled = true
                //use user permissions later
            };

            return entityViewModel;

        }
    }
}
