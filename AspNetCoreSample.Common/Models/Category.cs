using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreSample.Common.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public int MinStockQuantity { get; set; }
    }
}
