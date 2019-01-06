using MediatR;

namespace App.Application.EntitiesCommandsQueries.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<long>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
