using System.Threading;
using System.Threading.Tasks;
using MediatR;
using App.Persistence;
using App.Common.Interfaces;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using App.Application.Exceptions;
using System.Linq;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.UpdateCounty
{
    public class UpdateCountyCommandHandler : IRequestHandler<UpdateCountyCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDateTime _dateTime;

        public UpdateCountyCommandHandler(AppDbContext appDbContext, IDateTime dateTime)
        {
            _appDbContext = appDbContext;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(UpdateCountyCommand request, CancellationToken cancellationToken)
        {
            var county = await _appDbContext.Counties
                .Where(e => e.ID == request.ID && e.Deleted != 1)
                .FirstOrDefaultAsync(cancellationToken);

            if(county == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.ID);
            }
                        
            county.CountyName = request.CountyName;
            county.CountyDescription = request.CountyDescription;
            county.LastEditedDate = _dateTime.Now;
            county.Deleted = request.Deleted;

            _appDbContext.Counties.Update(county);

            await _appDbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;       

            
        }
    }
}