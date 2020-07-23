using Microsoft.EntityFrameworkCore;
using MyFirstCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreApi.Data
{
    public class ProductsDbContext: DbContext
    {

        public ProductsDbContext(DbContextOptions<ProductsDbContext>options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
