using App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory;
using System.Collections.Generic;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategories
{
    public class ProductCategoriesViewModel : ProductCategoryDTO
    {
        public IEnumerable<ProductCategoryDTO> ProductCategories { get; set; }        
        public bool CreateEnabled { get; set; }



    }
}
