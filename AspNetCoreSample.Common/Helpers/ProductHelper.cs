using AspNetCoreSample.Common.Models;
using AspNetCoreSample.Common.Models.Requests;
using AspNetCoreSample.Common.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSample.Common.Helpers
{
    public static class ProductHelper
    {
        public static ProductResponse CreateResponse(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductResponse()
            {
                CategoryName = product.Category.Name,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                Title = product.Title
            };
        }


        public static Product CreateProduct(ProductCreateUpdateRequest productRequest)
        {
            if(productRequest == null)
            {
                return null;
            }

            return new Product()
            {
                CategoryId = productRequest.CategoryId,
                Description = productRequest.Description,
                StockQuantity = productRequest.StockQuantity,
                Title = productRequest.Title
            };
        }
    }
}
