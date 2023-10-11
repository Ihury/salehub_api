using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleHub.Api.Models;

namespace SaleHub.Api.Models
{
    public class SaleHubContext : DbContext
    {
        public SaleHubContext(DbContextOptions<SaleHubContext> options)
            : base(options)
        {            
        }

        public DbSet<Product> Products { get; set; }
    }
}