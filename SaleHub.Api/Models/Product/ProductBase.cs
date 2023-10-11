using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleHub.Api.Models
{
    public class ProductBase
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Name { get; set; } 

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        [Range(0.0, 100_000_000.00)]
        public decimal Price { get; set; }        
    }
}