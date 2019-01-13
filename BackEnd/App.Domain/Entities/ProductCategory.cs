using System.Collections.Generic;

/// <summary>
/// For County Produc Catgeories eg Floriculture, Aquaculture, Hortilculture etc, Other Cash Crops, Manufacturing Industries
/// </summary>

namespace App.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }


        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }


        public ICollection<Product> Products { get; set; }


    }
}
