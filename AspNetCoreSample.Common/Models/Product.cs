using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetCoreSample.Common.Models
{
    public class Product
    {
        [Required]
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public void Update(Product product)
        {
            
            this.StockQuantity = product.StockQuantity;
            this.Title = product.Title;
            this.Description = product.Description;
            this.CategoryId = product.CategoryId;
        }
    }
}
