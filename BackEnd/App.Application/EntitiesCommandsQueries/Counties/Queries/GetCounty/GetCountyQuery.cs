using MediatR;

namespace App.Application.EntitiesCommandsQueries.Counties.Queries.GetCounty
{
    public class GetCountyQuery : IRequest<CountyViewModel>
    {
        public long ID { get; set; }
    }
}
