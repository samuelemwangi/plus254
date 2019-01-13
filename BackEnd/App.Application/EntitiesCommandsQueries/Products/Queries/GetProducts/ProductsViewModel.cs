using System.Collections.Generic;
using App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProducts
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
