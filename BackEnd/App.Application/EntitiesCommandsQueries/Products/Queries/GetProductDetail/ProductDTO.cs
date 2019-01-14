using App.Domain.Entities;
using System;
using System.Linq.Expressions;
using App.Common.Interfaces;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail
{
    public class ProductDTO
    {   
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategoryName { get; set; }
        
        public static Expression<Func<Product, ProductDTO>> Projection
        {
            get
            {
                return product => new ProductDTO
                {
                    ID = product.ID,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductCategoryName = product.ProductCategory.CategoryName,
                    
                };
            }
        }

    }
}
