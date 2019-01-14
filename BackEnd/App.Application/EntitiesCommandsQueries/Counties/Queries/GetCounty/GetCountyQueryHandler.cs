using App.Application.Exceptions;
using App.Domain.Entities;
using App.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty
{
    public class GetCountyQueryHandler : IRequestHandler<GetCountyQuery, CountyViewModel>
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public GetCountyQueryHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task<CountyViewModel> Handle(GetCountyQuery request, CancellationToken cancellationToken)
        {

            var county = _mapper.Map<CountyViewModel>
                (
                    await _appDbContext.Counties
                        .Where(e => e.ID == request.ID && e.Deleted != 1)
                        .Select(CountyViewModel.Projection)
                        .FirstOrDefaultAsync(cancellationToken)
                );


            if (county == null)
            {
                throw new NotFoundException(nameof(County), request.ID);
            }

            //implement permission resolver
            county.EditEnabled = true;
            county.DeleteEnabled = true;

            return county;

        }
    }
}
