using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Category> Categories { get; set; }  // em plural nome das tabelas 

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductsApi> ProductsApi { get; set; }
        // Fluent Api

        protected override void OnModelCreating(ModelBuilder mb)
        {
        
            //Products
            mb.Entity<ProductsApi>().Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
            mb.Entity<ProductsApi>().Property(c => c.Price)
                .HasMaxLength(100)
                .IsRequired();
            mb.Entity<ProductsApi>().Property(c=>c.Stock)
                .HasMaxLength(100)
                .IsRequired();
            
            // se nao tiver nada no banco cria assim
            mb.Entity<ProductsApi>().HasData(
                new ProductsApi
                {
                    Id = 1,
                    Name = "Coca-Cola ",
                    Price = 10.00,
                    Stock = 20
                },
                new ProductsApi
                {
                    Id = 2,
                    Name = "Cerveja ",
                    Price = 15.00,
                    Stock = 25

                });
        }
    }
}
