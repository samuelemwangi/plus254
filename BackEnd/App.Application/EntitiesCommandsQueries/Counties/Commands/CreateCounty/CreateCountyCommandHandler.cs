using App.Common.Interfaces;
using App.Domain.Entities;
using App.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.CreateCounty
{
    public class CreateCountyCommandHandler : IRequestHandler<CreateCountyCommand, long>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public CreateCountyCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;

        }

        public async Task<long> Handle(CreateCountyCommand request, CancellationToken cancellationToken)
        {
            var county = new County
            {
                CountyName = request.CountyName,
                CountyDescription = request.CountyDescription,
                CreatedDate = _dateTime.Now,
                LastEditedDate = _dateTime.Now

            };


            _appDbContext.Counties.Add(county);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return county.ID;
        }
    }
}
