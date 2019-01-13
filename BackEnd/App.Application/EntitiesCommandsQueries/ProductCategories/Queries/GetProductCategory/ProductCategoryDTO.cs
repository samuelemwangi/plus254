using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Domain.Entities;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory
{
    public class ProductCategoryDTO
    {
        public long ID { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public int CountCategoryProducts { get; set; }

        public static Expression<Func<ProductCategory, ProductCategoryDTO>> Projection
        {
            get
            {
                return productCategory => new ProductCategoryDTO
                {
                    ID = productCategory.ID,
                    ProductCategoryName = productCategory.CategoryName,
                    ProductCategoryDescription = productCategory.CategoryDescription,
                    CountCategoryProducts = productCategory.Products.Count()
                    
                };
            }
        }

    }

   
}
