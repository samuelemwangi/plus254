using MediatR;

namespace App.Application.EntitiesCommandsQueries.Counties.Commands.UpdateCounty
{
    public class UpdateCountyCommand: IRequest
    {
        public long ID { get; set; }
        public string CountyName { get; set; }
        public string CountyDescription { get; set; }
        public short Deleted { get; set; }
    }
}
