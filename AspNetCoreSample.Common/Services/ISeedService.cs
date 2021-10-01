using AspNetCoreSample.Common.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Common.Services
{
    public interface ISeedService
    {
        Task Initialize(ProductContext context);
    }
}
