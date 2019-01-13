using System.Collections.Generic;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetAllProductCategories
{
    public class ProductCategoriesViewModel
    {
        public IEnumerable<ProductCategoryDTO> ProductCategories { get; set; }

        //Resolve via persmissions
        public bool CreateEnabled { get; set; }



    }
}
