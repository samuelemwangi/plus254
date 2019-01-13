using App.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail
{
    public class ProductDetailViewModel : ProductDTO
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }

        public new static Expression<Func<Product, ProductDetailViewModel>> Projection
        {
            get
            {
                return product => new ProductDetailViewModel
                {
                    ID = product.ID,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductCategoryName = product.ProductCategory.CategoryName,
                    CreatedBy = product.CreatedBy,
                    CreatedDate = product.CreatedDate

                };
            }
        }


    }
}
