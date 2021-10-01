using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSample.Common.Models.Responses
{
    public class ProductResponse
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
    }
}
