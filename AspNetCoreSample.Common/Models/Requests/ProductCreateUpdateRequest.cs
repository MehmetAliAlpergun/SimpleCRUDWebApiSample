using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreSample.Common.Models.Requests
{
    public class ProductCreateUpdateRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
