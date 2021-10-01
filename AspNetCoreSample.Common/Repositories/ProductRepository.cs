using AspNetCoreSample.Common.Contexts;
using AspNetCoreSample.Common.Models;
using AspNetCoreSample.Common.Models.Requests;
using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreSample.Common.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ProductContext ProductContext;

        public ProductRepository(ProductContext productContext)
        {
            ProductContext = productContext;
        }

        public List<Product> GetAll(GetProductsRequest queryParams)
        {
            try
            {
                var query = ProductContext.Products.Include("Category").Where(x => x.StockQuantity >= x.Category.MinStockQuantity);

                if (queryParams != null)
                {
                    if (!string.IsNullOrEmpty(queryParams.Keyword))
                    {
                        var keyword = queryParams.Keyword.ToLowerInvariant();
                        query = query.Where(x => x.Title.Contains(keyword) || x.Description.Contains(keyword) || x.Category.Name.Contains(keyword));
                    }

                    if (queryParams.MinQuantity.HasValue)
                    {
                        query = query.Where(x => x.StockQuantity >= queryParams.MinQuantity.Value);
                    }

                    if (queryParams.MaxQuantity.HasValue)
                    {
                        query = query.Where(x => x.StockQuantity <= queryParams.MaxQuantity.Value);
                    }
                }

                return query.ToList();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public Product GetSingle(long id)
        {
            try
            {
                return ProductContext.Products.Include("Category").FirstOrDefault(x => x.ID == id);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public bool Add(Product item)
        {
            try
            {
                var category = ProductContext.Categories.Where(x => x.ID == item.CategoryId).FirstOrDefault();
                if (category != null)
                {
                    ProductContext.Products.Add(item);
                    return ProductContext.SaveChanges() >= 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Product product = GetSingle(id);
                if (product != null)
                {
                    ProductContext.Products.Remove(product);

                    return ProductContext.SaveChanges() >= 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        public bool Update(long id, Product item)
        {
            try
            {
                Product product = GetSingle(id);
                if (product != null)
                {
                    product.Update(item);

                    ProductContext.Products.Attach(product);
                    ProductContext.Entry(product).State = EntityState.Modified;

                    return ProductContext.SaveChanges() >= 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        public long Count()
        {
            try
            {
                return ProductContext.Products.Count();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return -1;
            }
        }
    }
}
