using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaleHub.Api.Models
{
    public class Product : ProductBase
    {
        [Key]
        public long Id { get; set; }
    }
}