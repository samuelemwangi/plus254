using App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty;
using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounties
{
    public class GetCountiesQueryHandler : IRequestHandler<GetCountiesQuery, CountiesViewModel>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetCountiesQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<CountiesViewModel> Handle(GetCountiesQuery request, CancellationToken cancellationToken)
        {


            IEnumerable<CountyDTO> counties = await _appDbContext.Counties
                .Where(e => e.Deleted != 1)
                .Select(CountyDTO.Projection)
                .ToListAsync();

            return new CountiesViewModel
            {
                Counties = counties,
                CreateEnabled = true

            };

        }
    }
}
