using AspNetCoreSample.Common.Contexts;
using AspNetCoreSample.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Common.Services
{
    public class SeedService : ISeedService
    {
        public async Task Initialize(ProductContext context)
        {
            context.Add(new Product() { Title = "Product A", Description = "Product A Description", StockQuantity = 100, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product A" } });
            context.Add(new Product() { Title = "Product B", Description = "Product B Description", StockQuantity = 10, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product B" } });
            context.Add(new Product() { Title = "Product C", Description = "Product C Description", StockQuantity = 1000, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product C" } });
            context.Add(new Product() { Title = "Product D", Description = "Product D Description", StockQuantity = 10000, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product D" } });
            context.Add(new Product() { Title = "Product E", Description = "Product E Description", StockQuantity = 500, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product E" } });
            context.Add(new Product() { Title = "Product F", Description = "Product F Description", StockQuantity = 200, Category = new Category() { MinStockQuantity = 50, Name = "Category for Product F" } });
            context.Add(new Product() { Title = "Product H", Description = "Product H Description", StockQuantity = 1, Category = new Category() { MinStockQuantity = 1, Name = "Category for Product A" } });

            await context.SaveChangesAsync();
        }
    }
}
