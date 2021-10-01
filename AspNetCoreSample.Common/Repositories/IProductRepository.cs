using AspNetCoreSample.Common.Models;
using AspNetCoreSample.Common.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreSample.Common.Repositories
{
    public interface IProductRepository
    {
        Product GetSingle(long id);
        List<Product> GetAll(GetProductsRequest queryParameters);
        bool Add(Product item);
        bool Delete(long id);
        bool Update(long id, Product item);
        long Count();
    }
}
