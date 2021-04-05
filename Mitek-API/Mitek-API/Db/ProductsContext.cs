using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mitek_API.Models;

namespace Mitek_API.Db
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Entity to table.
            builder.Entity<Product>().ToTable("Products");

            //Primary key
            builder.Entity<Product>().HasKey(p => p.Id).HasName("id");

            builder.Entity<Product>().Property(p => p.Id).IsRequired().HasColumnType("int");
            builder.Entity<Product>().Property(p => p.Category).IsRequired().HasColumnType("int");
            builder.Entity<Product>().Property(p => p.Description).IsRequired().HasColumnType("varchar(200)");
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
        }
    }
}
