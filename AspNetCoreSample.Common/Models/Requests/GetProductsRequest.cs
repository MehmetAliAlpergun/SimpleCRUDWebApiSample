using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSample.Common.Models.Requests
{
    public class GetProductsRequest
    {
        public string Keyword { get; set; }

        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
    }
}
