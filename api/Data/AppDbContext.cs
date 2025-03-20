using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Product 1", Description = "Product 1 description", Price = 10.99M, Category = "Category 1"},
                new Product {Id = 2, Name = "Product 2", Description = "Product 2 description", Price = 20.99M, Category = "Category 2"}
            );
        }
    }
}