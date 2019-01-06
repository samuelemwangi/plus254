using System.Collections.Generic;

namespace App.Application.EntitiesCommandsQueries.Categories.Queries.GetAllCategories
{
    public class CategoryViewModel
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }

        //Resolve via persmissions
        public bool CreateEnabled { get; set; }



    }
}
