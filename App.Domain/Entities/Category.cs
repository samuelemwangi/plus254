using System.Collections.Generic;

namespace App.Domain.Entities
{
    public class Category: BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        
        public string CategoryName { get; set; }
        public string Description { get; set; }


        public ICollection<Product> Products { get; private set; }


    }
}
