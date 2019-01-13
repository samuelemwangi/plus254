
/// <summary>
/// For County Products eg Coffee, Tea, Fish
/// </summary>

namespace App.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }        
        

        //Foreign Key
        public long? ProductCategoryID { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
