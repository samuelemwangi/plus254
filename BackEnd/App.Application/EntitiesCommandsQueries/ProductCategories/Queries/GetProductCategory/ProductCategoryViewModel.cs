using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.Application.EntitiesCommandsQueries.ProductCategories.Queries.GetProductCategory
{
    public class ProductCategoryViewModel: ProductCategoryDTO
    {
        public ICollection<CategoryProductsDTO> CategoryProducts { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }
        //add other columns

        public new static Expression<Func<ProductCategory, ProductCategoryDTO>> Projection
        {
            get
            {
                return productCategory => new ProductCategoryViewModel
                {
                    ID = productCategory.ID,
                    ProductCategoryName = productCategory.CategoryName,
                    ProductCategoryDescription = productCategory.CategoryDescription,                    
                    CategoryProducts = productCategory.Products.AsQueryable()
                                            .Select(CategoryProductsDTO.Projection)
                                            .Take(2)
                                            .OrderBy(p => p.ID)
                                            .ToList()


                };
            }
        }
    }

    public class CategoryProductsDTO
    {
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public static Expression<Func<Product, CategoryProductsDTO>> Projection
        {
            get
            {
                return categoryProduct => new CategoryProductsDTO
                {
                    ID = categoryProduct.ID,
                    ProductName = categoryProduct.ProductName,
                    ProductDescription = categoryProduct.ProductDescription
                };
            }
        }

    }
}
