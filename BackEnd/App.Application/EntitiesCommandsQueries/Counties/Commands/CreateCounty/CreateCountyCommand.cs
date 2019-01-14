using MediatR;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.CreateCounty
{
    public class CreateCountyCommand : IRequest<long>
    {
        public string CountyName { get; set; }
        public string CountyDescription { get; set; }
    }
}
